using AutoMapper;
using Domain.Entities.Buyer;
using Infra.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nascimento.Software.Api.DTO;

namespace Nascimento.Software.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyersController : ControllerBase
    {
        [HttpGet]
        [Route("listarClientes")]
        public async Task<ActionResult> SearchClientsList
            ([FromServices] IRepository<Buyers> _buyerRepo,
            [FromServices] IMapper _mapper)
        {
            var buyerList = await _buyerRepo.Get();
            if (buyerList == null) return BadRequest();

            var buyerDTOlist = _mapper.Map<IEnumerable<BuyerDTO>>(buyerList);
            if (buyerDTOlist == null) return BadRequest();

            return Ok(buyerDTOlist);
        }
        [HttpPost]
        [Route("cadastrarClientes")]
        public async Task<ActionResult> ClientRegistration
            ([FromServices] IRepository<Buyers> _buyerRepo, 
            [FromServices] IMapper _mapper,
            BuyerDTO buyerDTO)
        {
            if (ModelState.IsValid)
            {
                var buyerModel = _mapper.Map<Buyers>(buyerDTO);
                if (buyerModel == null) return BadRequest();

                var insertWorks = await _buyerRepo.Add(buyerModel);
                if (insertWorks) return Ok("Cadastrado");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> DeleteClient
            ([FromServices] IRepository<Buyers> _buyerRepo, string BuyerId)
        {
            if(string.IsNullOrWhiteSpace(BuyerId)) return BadRequest("Id não pode ser nulo");

            var buyerExists = await _buyerRepo.GetOne(BuyerId);
            if (buyerExists == null) return BadRequest("Cliente não existe");

            var buyerDeleted = await _buyerRepo.Delete(buyerExists);
            if (buyerDeleted) return StatusCode(StatusCodes.Status202Accepted);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
