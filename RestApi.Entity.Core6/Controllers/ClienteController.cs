using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Entity.Core6.Modelos;
using RestApi.Entity.Core6.Repositories;

namespace RestApi.Entity.Core6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository icliente;

        public ClienteController(IClienteRepository icliente)
        {
            this.icliente = icliente;
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var response = icliente.GetById(id);
            if(response != null) return Ok(response);
            return NotFound();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = icliente.Get();
            if(response !=null) return Ok(response);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody]ClientePostRequest post)
        {
            if (icliente.PostClientes(post))
            {
                return Ok();
            }
            return BadRequest();
             
        }

        [HttpPut]
        public  IActionResult Put([FromBody]ClientePutRequest put)
        {
          if(icliente.Update(put)) return Ok();

            return BadRequest();


        }

        [HttpDelete ("{id}")]
        public IActionResult Delete([FromRoute] int id )
        {
            if (icliente.Delete(id)) return Ok();

            return BadRequest();
        }
    }
}
