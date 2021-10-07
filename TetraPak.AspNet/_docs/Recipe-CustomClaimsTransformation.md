# Recipe: Adding a custom claims transformation

> For the examples in this recipe to make sense it is assumed you have first gone through the [Adding a custom auth scheme][recipe-custom-auth-scheme] recipe. If not, please do so and then return here.
> 
> Also, please read up on [Claims Transformation][cat-claims-transformation] if that's an unfamiliar concept.

For the most part [claims transformation][cat-claims-transformation] can be left as-is, letting the SDK handle it for you. However, in some circumstances you might see a need for adding extra claims due to legacy requirements or because you have added a custom auth scheme, like in the ["AliBaba" recipe][recipe-custom-auth-scheme].

Adding custom claims transformation includes:

- Implementing a custom "claims transformer" 
- Configuring your project to use it

## Implementing custom claims transformer

We will pick up from where we left, in the ["AliBaba" recipe][recipe-custom-auth-scheme] where we implemented a custom auth scheme that  relies on the client simply sending her credentials via [Basic Authentication](https://swagger.io/docs/specification/authentication/basic-authentication/). 

Just to show how it can be done we will now write a custom *claims transformer* that simply adds the passed secret as a [claim][cat-claim] to the request's *principal* object (a `ClaimsPrincipal`) when a flag requires it. This is, obviously, a very poor idea but we'll ignore that for sake of clarity this time. 

When integrating your project with [TPAS][cat-tpas] you have to implement the [`ITetraPakClaimsTransformation`][code-ITetraPakClaimsTransformation] interface. That is easily done by deriving your *claims transformer* class from the abstract [`TetraPakClaimsTransformation`][code-TetraPakClaimsTransformation]. 

The custom claims transformer we're writing will only be adding the "secret" claim *if* this is stated by the `IsSecretRevealedInClaims` property we implemented in the ["AliBaba" recipe][recipe-custom-auth-scheme]. Here it is again:

```c#
class AliBabaAuthenticationOptions : AuthenticationSchemeOptions
{
    public bool IsSecretRevealedInClaims { get; set; }
}
```

So, here is how this claims transformer could be implemented:

```c#
class AliBabaClaimsTransformation : TetraPakClaimsTransformation
    {
        public bool IsSecretRevealedAsClaim { get; }

        protected override async Task<ClaimsPrincipal> OnTransformAsync(ClaimsPrincipal principal)
        {
            // bolter if secret should not be added as claim ...
            if (!IsSecretRevealedAsClaim)
                return principal;
            
            // get the token and try parsing it as Basic Auth Credentials ...
            var tokenOutcome = await Context.GetAccessTokenAsync(TetraPakConfig);
            if (!tokenOutcome)
                return principal;

            var token = tokenOutcome.Value!;
            var basicAuthCredentials =  BasicAuthCredentials.Parse(token);
            if (basicAuthCredentials is null)
                return principal;

            // add the secret to the "AliBaba" identity ...  
            foreach (var identity in principal.Identities)
            {
                if (identity is not { AuthenticationType: "AliBaba" } claimsIdentity)
                    return principal; // not the "AliBaba" identity

                var secret = basicAuthCredentials.Secret;
                claimsIdentity.BootstrapContext = token;
                claimsIdentity.AddClaim(
                    new Claim("secret", $"The secret used was: '{secret}'"));
            }
            return principal;
        }

        public AliBabaClaimsTransformation(TetraPakConfig tetraPakConfig)
        {
            // get the configured setting from the "AliBaba" sub section ...
            var aliBabaConfig = tetraPakConfig.Section?.GetSection("AliBaba");
            IsSecretRevealedAsClaim = aliBabaConfig.GetBool(nameof(IsSecretRevealedAsClaim), false);
        }
    }
```

Pretty straight-forward code here but let's go through anyway, starting with the constructor, at the bottom of the class. All we are doing here is fetching a setting - "IsSecretRevealedAsClaim" - from the "AliBaba" configuration sub section, in the "TetraPak" configuration section. This is what the "appsettings.json" file can look like to support this:

```json
{
  "TetraPak": {
    "AliBaba": {
      "IsSecretRevealedAsClaim": "true"
    },
    "(more settings)": "(with more values)"
  }
}
```

The `OnTransformAsync` method is abstract in the super class ([`TetraPakClaimsTransformation`][code-TetraPakClaimsTransformation]) and, so, *must* be implemented. Here's what it does: 

- Checks whether the secret should be added as a claim at all, and skips out when not

- Gets the access token from the request context and try parsing it as a [`BasicAuthCredentials`][code-BasicAuthCredentials]. If that succeeds it extracts the secret from the credentials. If it fails the method bolters. 
- After this the method iterates through all supplied identities (usually there's just one), looking for identities created from the "AliBaba" auth scheme. When it finds one it adds the "`secret`" claim to it.

When you check out other implementations for ASP.NET custom claims transformation the recommendation is usually to always clone the principal before making changes to it. But when you implement Tetra Pak custom claims transformation this has already been done, prior to invoking the custom *claims transformers*.

## Concluding

Like with custom auth schemes always consider if what you are trying to do is something that should be supported out of the box, by the SDK. If so, don't hesitate to [suggest it][repo-tetrapak-aspnet-issues].

[cat-claim]: ../../CAT.md#claim
[cat-claims-transformation]: ../../CAT.md#claims-transformation
[cat-identity]: ../../CAT.md#identity
[cat-tpas]: ../../CAT.md#tpas

[code-BasicAuthCredentials]: https://github.com/Tetra-Pak-APIs/TetraPak.Common/blob/master/TetraPak.Common/_docs/_code/TetraPak_BasicAuthCredentials.md
[code-ITetraPakClaimsTransformation]: ./_code/TetraPak_AspNet_ITetraPakClaimsTransformation.md
[code-TetraPakClaimsTransformation]: ./_code/TetraPak_AspNet_TetraPakClaimsTransformation.md

[recipe-custom-auth-scheme]: ./Recipe-CustomAuthScheme.md
[repo-tetrapak-aspnet-issues]: https://github.com/Tetra-Pak-APIs/TetraPak.AspNet/issues