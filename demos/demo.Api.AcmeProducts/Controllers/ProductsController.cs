using System.Linq;
using System.Threading.Tasks;
using demo.Acme.Models;
using demo.AcmeProducts.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TetraPak;
using TetraPak.AspNet.Api.Controllers;

namespace demo.AcmeProducts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // [Authorize]
    public class ProductsController : ControllerBase
    {
        readonly ProductsRepository _productsRepository;
        readonly ProductCategoriesRepository _categoriesRepository;

        #region .  Products  .

        [HttpGet]
        public async Task<ActionResult> GetProducts(string? id = null, [FromQuery] string? cat = null)
        {
            var cats = (MultiStringValue)cat;
            if (string.IsNullOrEmpty(id))
                return await this.RespondAsync(
                    cats.IsEmpty
                        ? await _productsRepository.ReadAsync()
                        : await _productsRepository.ReadWhereCategoriesAsync(cats));
            
            if (!cats.IsEmpty)
                // passing id AND category is bad form ...
                return this.RespondErrorBadRequest("Duh! Either pass id OR category, not both!");
                
            var ids = (MultiStringValue)id;
            return await this.RespondAsync(ids.IsEmpty
                ? await _productsRepository.ReadAsync(cancellation: HttpContext.RequestAborted)
                : await _productsRepository.ReadAsync(ids.Items, cancellation: HttpContext.RequestAborted));
        }
        
        [HttpPost]
        public async Task<ActionResult> PostProduct([FromBody] Product? product)
        {
            if (product is null)
                return this.RespondErrorBadRequest("Expected product in body");

            return await this.RespondAsync(await _productsRepository.CreateAsync(product));
        }

        [HttpPut]
        public async Task<ActionResult> PutProduct([FromBody] Product? product)
        {
            if (product is null)
                return this.RespondErrorBadRequest("Expected product in body");

            return await this.RespondAsync(await _productsRepository.CreateOrReplaceAsync(product));
        }

        [HttpPatch]
        public async Task<ActionResult> PatchProduct([FromBody] Product? product)
        {
            if (product is null)
                return this.RespondErrorBadRequest("Expected product in body");

            return await this.RespondAsync(await _productsRepository.UpdateAsync(product));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            return await this.RespondAsync(await _productsRepository.DeleteAsync(id));
        }

        #endregion

        #region .  Categories  .

        // NOTE! we do not support PUT and PATCH for product categories

        [HttpGet, Route("Categories")]
        public async Task<ActionResult> GetCategories()
        {
            var outcome = await _categoriesRepository.ReadAsync();
            if (!outcome)
                return await this.RespondAsync(outcome);
            
            EnumOutcome<string> stringOutcome = 
                EnumOutcome<string>.Success(outcome.Value!.Select(i => i.StringValue).ToArray()); 
            return await this.RespondAsync(stringOutcome);
        }

        [HttpPost, Route("Categories")]
        public async Task<ActionResult> PostCategory([FromBody] string? category)
        {
            if (category is null)
                return this.RespondErrorBadRequest("Expected category in body");

            return await this.RespondAsync(await _categoriesRepository.CreateAsync(category));
        }
        
        [HttpDelete, Route("Categories")]
        public async Task<ActionResult> DeleteCategories(string categories)
        {
            // remove category from existing products, then the category itself
            await _productsRepository.RemoveCategoriesFromAllProducts(categories, HttpContext.RequestAborted);
            return await this.RespondAsync(await _categoriesRepository.DeleteAsync(categories));
        }
        #endregion

        public ProductsController(
            ProductsRepository productsProductsRepository, 
            ProductCategoriesRepository categoriesRepository)
        {
            _productsRepository = productsProductsRepository;
            _categoriesRepository = categoriesRepository;
        }
    }
}