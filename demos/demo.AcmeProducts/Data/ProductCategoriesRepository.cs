using System.Threading.Tasks;
using demo.Acme.Models;
using demo.Acme.Repositories;
using Microsoft.Extensions.Logging;

namespace demo.AcmeProducts.Data
{
    public class ProductCategoriesRepository : SimpleRepository<Category>
    {
        protected override Category OnMakeNewItem(Category source) => new(source.Id);

        protected override Task OnUpdateItemAsync(Category target, Category source)
        {
            // no need to "update" a string ...
            return Task.CompletedTask; 
        }
        
        public ProductCategoriesRepository(ILogger? logger) 
        : base(logger!)
        {
        }
    }
}