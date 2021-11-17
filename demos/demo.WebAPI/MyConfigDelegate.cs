﻿using System;
using System.Threading.Tasks;
using TetraPak;
using TetraPak.AspNet;
using TetraPak.DynamicEntities;
using TetraPak.SecretsManagement;

#nullable enable

namespace WebAPI
{
    public class MyConfigDelegate : TetraPakConfigDelegate
    {
        protected override Task<Outcome<Credentials>> OnGetClientCredentialsAsync(AuthContext authContext)
        {
            
            if (!TryGetConfiguredValue(nameof(TetraPakConfig.ClientId), authContext, out var clientId, true))
            {
                clientId = "noI5fBHGFdy5HQIkzwxa6XI7Smg2Iyco";
            }
            if (!TryGetConfiguredValue(nameof(TetraPakConfig.ClientSecret), authContext, out var clientSecret, true))
            {
                clientSecret = "H6WDbPSeIe2gigYF";
            }
            
            return Task.FromResult(Outcome<Credentials>.Success(
                new Credentials(clientId, clientSecret)));
        }

        public MyConfigDelegate(ITetraPakSecretsProvider? secretsProvider = default) 
        : base(secretsProvider)
        {
        }
    }

    public class MySecretsProvider : ITetraPakSecretsProvider
    {
        public Task<Outcome<string>> GetSecretStringAsync(DynamicPath path)
        {
            if (path == Secrets.ClientIdUri)
                return Task.FromResult(getClientIdAsync(path));

            return Task.FromResult(path == Secrets.ClientIdUri 
                ? getClientSecretAsync(path) 
                : Outcome<string>.Fail(new ArgumentOutOfRangeException(nameof(path))));
        }

        static Outcome<string> getClientIdAsync(DynamicPath path)
        {
            /*
             in reality you might have a need to obtain different client ids here, and do so
             from a secure persistent store somewhere, such as an Azure Key Vault
            */
            return Outcome<string>.Success("-my-client-id-");
        }

        static Outcome<string> getClientSecretAsync(DynamicPath path)
        {
            /*
             in reality you might have a need to obtain different client ids here, and do so
             from a secure persistent store somewhere, such as an Azure Key Vault
            */
            return Outcome<string>.Success("-m4-c1i3n7-s3cr37");
        }
    }
}