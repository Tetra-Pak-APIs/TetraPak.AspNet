namespace TetraPak.AspNet.Api.Controllers
{
    public class ResourceLocator
    {
        public string Location { get; set; }

        public ResourceLocator()
        {
            
        }
        
        public ResourceLocator(string location)
        {
            Location = location;
        }
    }
}