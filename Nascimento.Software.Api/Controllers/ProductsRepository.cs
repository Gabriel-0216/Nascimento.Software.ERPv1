using Domain.Entities.Product;
using Infra.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nascimento.Software.Api.DTO;

namespace Nascimento.Software.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsRepository : ControllerBase
    {

        [HttpGet]
        [Route("listarProdutos")]
        public async Task<ActionResult> ListarProdutos([FromServices] IRepository<Products> _productsRepo)
        {
            try
            {
                var productsListDB = await _productsRepo.Get();
                if (productsListDB == null) return BadRequest();

                var productsListDTO = MapearDTOS(productsListDB.ToList());
                return Ok(productsListDTO);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            

        }
        [HttpPost]
        [Route("cadastrarProduto")]
        public async Task<ActionResult> CadastrarProduto([FromServices] IRepository<Products> _productsRepo, ProductInsertDTO productDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var productEntity = new Products();
                    productEntity.SetProductName(productDTO.FirstName);
                    productEntity.SetProductValue(productDTO.ProductValue);

                    var dataInserted = await _productsRepo.Add(productEntity);

                    if (dataInserted) return Ok("Cadastrado");
                }
                return BadRequest();


            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
        [HttpPost]
        [Route("inserirEstoque")]
        public async Task<ActionResult> AdicionarProdutoEstoque([FromServices] IRepository<Products> _productsRepo, 
            [FromServices] IRepository<ProductStock> _productStockRepo, ProductInsertStockDTO productStockDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var productExists = await _productsRepo.GetOne(productStockDTO.ProductId);
                    if (productExists == null) return BadRequest("Produto não existe");

                    productExists.AddQuantityStock(productStockDTO.quantityAdded);
                    var updated = await _productsRepo.Update(productExists);
                    if(!updated) return StatusCode(StatusCodes.Status500InternalServerError);

                    var productStockEntity = new ProductStock();
                    productStockEntity.SetProductId(productExists.Id);
                    productStockEntity.SetQuantity(productStockDTO.quantityAdded);
                    
                    var updatedStock = await _productStockRepo.Add(productStockEntity);
                    if (updatedStock) return Ok();
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        private IEnumerable<ProductDTO> MapearDTOS(List<Products> products)
        {
            var listDTO = new List<ProductDTO>();
            foreach(var item in products)
            {
                listDTO.Add(new ProductDTO
                {
                    AvailableQuantity = item.AvailableQuantity,
                    FirstName = item.ProductName.FirstName,
                    ProductValue = item.ProductValue,
                });
            }
            return listDTO;
        }
    }
}
