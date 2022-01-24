using ApiClienteModeloDDD.Application.DTOs;
using ApiClienteModeloDDD.Application.Interfaces;
using ApiClienteModeloDDD.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClienteModeloDDD.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IApplicationServiceCliente _applicationServiceCliente;


        public ClienteController(IApplicationServiceCliente ApplicationServiceCliente)
        {
            _applicationServiceCliente = ApplicationServiceCliente;
        }

        /// <summary>Retorna todos os registros da tabela de Clientes</summary> 
        /// <remarks>
        /// Descrição
        /// 
        ///         GET api/{version}/clientes
        ///         
        ///         Consulta a tabela clientes e retorna uma lista com todos os registros.
        /// </remarks>
        /// <response code="200">Retorna uma lista com todos os clientes</response>

        [ProducesResponseType(typeof(IEnumerable<ClienteResponse>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {   
            var clientes = await _applicationServiceCliente.GetAll();
            return clientes.Any()
                ? Ok(clientes)
                : BadRequest("Lista de clientes vazia");
        }

        /// <summary>Retorna um único registro da lista de Clientes cujo id corresponda ao passado como parâmetros</summary> 
        /// <remarks>
        /// Descrição
        /// 
        ///     GET api/{version}/clientes/{id}
        ///     
        ///     Retorna um único registro cujo id corresponda ao passado como parâmetro.
        ///     
        /// Id example:
        /// 
        ///     3
        /// </remarks>
        /// <response code="200">Retorna o cliente correspondente ao id pesquisado</response>
        /// <response code="400">Se o valor pesquisado não for válido</response>
        /// <response code="404">Se o valor pesquisado não for encontrado</response> 
        [ProducesResponseType(typeof(ClienteResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _applicationServiceCliente.GetById(id);
            return result != null ? Ok(result) : NotFound($"Cliente com id = {id} não encontrado");
        }

        /// <summary>
        /// Retorna todos os clientes cujo nome contenha a string passada como parâmetro.
        /// </summary>
        /// <remarks>
        /// Descrição:
        /// 
        ///     GET api/{version}/clientes/filtros?nome=Francisco
        ///     Retorna todos os alunos cujo nome contenha a string passada como parâmetro.
        /// 
        /// Nome Exemplo:
        ///
        ///     Francisco
        ///
        /// </remarks>
        /// <response code="200">Retorna uma lista de clientes</response>
        /// <response code="400">Se o valor pesquisado não for válido</response> 

        [Route("filtros")]
        [HttpGet]
        [ProducesResponseType(typeof(ClienteResponse), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public async Task<IActionResult> GetByNome([FromQuery] string nome)
        {

            var result = await _applicationServiceCliente.GetByNome(nome);
            return result.Any()
                ? Ok(result)
                : BadRequest($"{nome} não encontrado no banco de clientes cadastrados");
        }

        /// <summary>Cria uma novo Cliente para o banco de dados de Clientes</summary> 
        /// <remarks>
        /// Descrição:
        /// 
        ///     POST api/{version}/livros/
        ///     Inclui na lista de Clientes um objeto do tipo Cliente.
        /// 
        /// Exemplo:
        /// 
        ///     {
        ///        "nome": "Bruna Nicholy",
        ///        "sobrenome": "Rubens de Castro",
        ///        "dataNascimento": "1998-07-07T17:33:39.631Z",
        ///        "cpf": "44043256743",
        ///        "enderecoId": 2
        ///     }
        ///     
        /// </remarks>
        /// <returns>Um novo item criado</returns>
        /// <response code="201">Se o novo item for criado</response>
        /// <response code="400">Se o item não for criado</response> 
        [ProducesResponseType(typeof(ActionResult), 201)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ClienteRequest cliente)
        {
            await _applicationServiceCliente.PostAsync(cliente);
            return this.Created("clientes", cliente);
        }

        /// <summary>Faz uma alteração nos parâmetros de um objeto Cliente</summary> 
        /// <remarks>
        /// Descrição
        /// 
        ///     PUT api/{version}/livros/{id}
        ///     
        ///     Atualiza algum parâmetro do objeto Cliente de acordo com o Id passado como parâmetro.
        ///     
        /// Id
        /// 
        ///     3
        ///     
        /// Exemplo:
        /// 
        ///     {
        ///        "nome": "Bruna Santos",
        ///        "sobrenome": "Rubens Abreu",
        ///        "dataNascimento": "1998-07-07T17:33:39.631Z",
        ///        "cpf": "44043256743",
        ///        "enderecoId": 2
        ///     }
        /// 
        /// 
        /// </remarks>
        /// <response code="204">Atualização realizada</response>
        /// <response code="400">Valores informados não são válidos</response> 
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ClienteResponse), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteRequestPut clienteRequest)
        {
            
            try
            {
                await _applicationServiceCliente.Update(id,clienteRequest);
                return Ok("Cliente Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>Remove um cliente na lista Clientes.</summary> 
        /// <remarks>
        /// Descrição
        /// 
        ///     Delete api/{version}/clientes/{id}
        ///     
        ///     Deleta um cliente da lista cujo id corresponda ao passado como parâmetro.
        ///     Ex: api/2/clientes/5
        ///  
        /// id
        /// 
        ///     2
        /// </remarks>
        /// <response code="204">Remoção realizada</response>
        /// <response code="400">Valores informados não são válidos</response> 
        [ApiVersion("2")]
        [HttpDelete]
        [ProducesResponseType(typeof(ClienteResponse), 204)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        public async Task<IActionResult> Delete(int id)
        {
            await _applicationServiceCliente.Delete(id);
            return this.NoContent();

        }
    }
}
