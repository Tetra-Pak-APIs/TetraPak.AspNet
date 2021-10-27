using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using demo.Acme.Models;
using demo.Acme.Repositories;
using Microsoft.Extensions.Logging;

namespace demo.AcmeProducts.Data
{
    public class ProductsAndAssetsRepository : SimpleRepository<ProductAssetEntry>
    {
        public ProductsAndAssetsRepository(ILogger logger) : base(logger)
        {
        }

        protected override ProductAssetEntry OnMakeNewItem(ProductAssetEntry source)
        {
             
        }

        protected override Task OnUpdateItemAsync(ProductAssetEntry target, ProductAssetEntry source)
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class ProductAssetEntry : Model
    {
        [Required]
        public string OrderId { get; set; }

        [Required]
        public string AssetId { get; set; }
        
        public ProductAssetEntry(string? id) 
        : base(id)
        {
        }
    }
}