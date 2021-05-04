using System.Threading.Tasks;
using TetraPak.Auth.OpenIdConnect;

namespace TetraPak.AspNet.Api.Auth.Development
{
    public class MockedSidecarDiscoveryDocumentHandler : MockedSidecarHandler
    {
        DiscoveryDocument _document;
        
       
        protected override Task<bool> OnHandle()
        {
            if (Context.Request.Path != DiscoveryDocument.DefaultPath)
                return Task.FromResult(false);

            if (_document is { }) 
                return Ok(_document);

            ensureDiscoveryDocument();
            return Ok(_document);
        }

        void ensureDiscoveryDocument()
        {
            lock (SyncRoot)
            {
                if (_document is {})
                    return;
                
                if (Options is SidecarJwBearerAssertionOptions jwtOptions)
                {
                    _document = DiscoveryDocument.GetDefault(jwtOptions.AuthConfig.AuthDomain);
                }
                else
                {
                    _document = DiscoveryDocument.GetDefault($"{Context.Request.Scheme}://{Context.Request.Host.Value}");
                }
            }
        }
    }
}