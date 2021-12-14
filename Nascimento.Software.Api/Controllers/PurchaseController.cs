using AutoMapper;
using Domain.Entities.Buyer;
using Domain.Entities.Payments;
using Domain.Entities.Product;
using Domain.Entities.PurchaseRequest;
using Domain.Entities.Purchases;
using Infra.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nascimento.Software.Api.DTO;
using Nascimento.Software.Api.DTO.Responses;

namespace Nascimento.Software.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {

        [HttpGet]
        [Route("listarCompras")]
        public async Task<ActionResult> Get
            ([FromServices] IMapper _mapper,
            [FromServices] IRepository<Purchase> _purchaseRepo)
        {
            return Ok(await _purchaseRepo.Get());
        }

        [HttpPost]
        [Route("comprarBoleto")]
        public async Task<ActionResult> ComprarBoleto
            ([FromServices] IRepository<Purchase> _purchaseRepo,
            [FromServices] IRepository<Buyers> _buyerRepo,
            [FromServices] IRepository<Products> _productRepo,
            [FromServices] IRepository<BoletoPayment> _boletoPaymentRepo,
            [FromServices] IMapper _mapper,
            PurchaseDTO dto)
        {
            var buyerExists = await _buyerRepo.GetOne(dto.BuyerId);
            if (buyerExists == null) return BadRequest("Cliente não existe");

            if (dto.Products.Count == 0) return BadRequest();
            var productsPurchase = await MapearPurchase(_productRepo, dto);

            var purchase = new Purchase();
            purchase.SetBuyer(buyerExists);
            purchase.AddProductList(productsPurchase.ToList());

            var boletoPayment = new BoletoPayment();
            boletoPayment.SetBuyer(purchase.Buyer);
            boletoPayment.SetPaymentAddress(purchase.Buyer.Address);
            purchase.FinishPurchase();
            boletoPayment.SetTotalPaid(purchase.PurchaseTotalValue);

            var boletoPaymentInserted = await _boletoPaymentRepo.Add(boletoPayment);
            if (!boletoPaymentInserted) return BadRequest("Ocorreu um erro registrando o boleto");

            purchase.PaymentId = boletoPayment.Id;
            var purchaseInserted = await _purchaseRepo.Add(purchase);
            if (!purchaseInserted) return BadRequest("ocorreu um erro registrando a compra");


            return Ok(new BoletoPaymentResponse()
            {
                Buyer = _mapper.Map<BuyerDTO>(purchase.Buyer)
            });
        }
       
        [HttpPost]
        [Route("comprarCartao")]
        public async Task<ActionResult> ComprarCartao
            ([FromServices] IRepository<Purchase> _purchaseRepo,
            [FromServices] IRepository<Buyers> _buyerRepo,
            [FromServices] IRepository<Products> _productRepo,
            [FromServices] IMapper _mapper,
            [FromServices] IRepository<CreditCartPayment> _creditCard,
            PurchaseCreditCartDTO purchaseDTO)
        {
            var buyerExists = await _buyerRepo.GetOne(purchaseDTO.BuyerId);
            if (buyerExists == null) return BadRequest();
            if (purchaseDTO.Products.Count == 0) return BadRequest();

            var buyerCreditCard = await _buyerRepo.GetOne(purchaseDTO.CreditCard.BuyerId);
            if(buyerCreditCard == null) return BadRequest();

            var productsPurchase = await MapearPurchase(_productRepo, purchaseDTO);

            var purchase = new Purchase();
            purchase.SetBuyer(buyerExists);
            purchase.AddProductList(productsPurchase.ToList());

            var creditCardPayment = new CreditCartPayment();
            creditCardPayment.SetBuyer(buyerCreditCard);
            if(buyerCreditCard.Address != null) creditCardPayment.SetPaymentAddress(buyerCreditCard.Address);
            purchase.FinishPurchase();
            creditCardPayment.SetTotalPaid(purchase.PurchaseTotalValue);

            var creditCard = await _creditCard.Add(creditCardPayment);
            if (!creditCard) return BadRequest();

            purchase.PaymentId = creditCardPayment.Id;
            var purchaseAdd = await _purchaseRepo.Add(purchase);
            if (!purchaseAdd) return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro interno no servidor");

            return Ok();
        }

        [HttpGet]
        [Route("listarComprasPorCliente")]
        public async Task<ActionResult> ComprasPorCliente()
        {
            return Ok();
        }
        private async Task<IEnumerable<Products>> MapearPurchase
            (IRepository<Products> _productRepo, 
            PurchaseDTO dto)
        {
            var listProducts = new List<Products>();
            foreach(var item in dto.Products)
            {
                var products = await _productRepo.GetOne(item.ProductId);
                if (products == null) continue;
                listProducts.Add(products);
            }
            return listProducts;
        }
    }
}
