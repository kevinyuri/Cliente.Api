using ApiClienteModeloDDD.Application.DTOs;
using ApiClienteModeloDDD.Application.Interfaces;
using ApiClienteModeloDDD.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiClienteModeloDDD.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/enderecos")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IApplicationServiceEndereco _applicationServiceEndereco;

        public EnderecoController(IApplicationServiceEndereco ApplicationServiceEndereco)
        {
            _applicationServiceEndereco = ApplicationServiceEndereco;
        }

        /// <summary>Retorna todos os registros da tabela de Endereços</summary> 
        /// <remarks>
        /// Descrição
        /// 
        ///         GET api/{version}/enderecos
        ///         
        ///         Consulta a tabela enderecos e retorna uma lista com todos os registros.
        /// </remarks>
        /// <response code="200">Retorna uma lista com todos os endereços</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EnderecoResponse>), 200)]
        public async Task<IActionResult> Get()
        {
            return this.Ok(await _applicationServiceEndereco.GetAll());
        }

        /// <summary>Retorna um único registro da lista de Enderecos cujo id corresponda ao passado como parâmetros</summary> 
        /// <remarks>
        /// Descrição
        /// 
        ///     GET api/{version}/enderecos/{id}
        ///     
        ///     Retorna um único registro cujo id corresponda ao passado como parâmetro.
        ///     
        /// Id example:
        /// 
        ///     3
        /// </remarks>
        /// <response code="200">Retorna o endereço correspondente ao id pesquisado</response>
        /// <response code="400">Se o valor pesquisado não for válido</response> 

        [ProducesResponseType(typeof(EnderecoResponse), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _applicationServiceEndereco.GetById(id);
            if (result == null)
            {
                return BadRequest("Endereço não encontrado.");
            }
            return this.Ok(result);
        }

        /// <summary>Cria uma novo Endereco para o banco de dados de Enderecos</summary> 
        /// <remarks>
        /// Descrição
        /// 
        ///     POST api/{version}/enderecos/
        ///     
        ///     Inclui na lista de Endereco um objeto do tipo Endereco.
        /// 
        /// Exemplo
        /// 
        ///     {
        ///         "cep": "60525-280",
        ///         "logradouro": "Rua Antônio Ivo",
        ///         "complemento": "de 1261/1262 ao fim",
        ///         "bairro": "João XXIII",
        ///         "uf": "CE"
        ///     }
        /// 
        /// </remarks>
        /// <response code="200">OK</response>
        /// <returns>Um novo item criado</returns>
        /// <response code="201">Se o novo item for criado</response>
        /// <response code="400">Se o item não for criado</response>
        
        [ProducesResponseType(typeof(ActionResult), 201)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] EnderecoDto enderecoDTO)
        {

            await _applicationServiceEndereco.PostAsync(enderecoDTO);
            return this.Created("enderecos", enderecoDTO);
        }

        /// <summary>Cria uma novo Endereco por meio do serviço ViaCepApi</summary> 
        /// <remarks>
        /// Descrição
        /// 
        ///     POST api/{version}/enderecos/PostViaCep/{cep}
        ///     
        ///     Inclui na lista de Endereco um objeto do tipo Endereco, por meio da api externa ViaCep
        /// 
        /// Exemplo
        /// 
        ///     api/{version}/enderecos/PostViaCep/60525-280
        /// 
        /// </remarks>
        /// <returns>Um novo item criado</returns>
        /// <response code="200">OK</response>
        /// <response code="201">Se o novo item for criado</response>
        /// <response code="400">Se o item não for criado</response> 


        [Route("PostViaCep/{cep}")]
        [HttpPost]
        public async Task<IActionResult> PostViaCep(string cep)
        {
            
            var endereco = _applicationServiceEndereco.PostViaCep(cep);
            await _applicationServiceEndereco.PostAsync(endereco);
            return this.Created("enderecos", endereco);

        }

        /// <summary>Faz uma alteração nos parâmetros de um objeto Endereco</summary> 
        /// <remarks>
        /// Descrição
        /// 
        ///     POST api/{version}/enderecos/{id}
        ///     
        ///     Atualiza algum parâmetro do objeto Endereco de acordo com o Id.
        /// 
        /// Id
        /// 
        ///     3
        /// 
        /// Exemplo
        /// 
        ///     {
        ///         "cep": "60525-280",
        ///         "logradouro": "Rua Antônio Ivo",
        ///         "complemento": "de 1261/1262 ao fim",
        ///         "bairro": "João XXIII",
        ///         "uf": "CE"
        ///     }
        /// </remarks>
        /// <response code="204">Atualização realizada</response>
        /// <response code="400">Valores informados não são válidos</response> 
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] EnderecoDtoPut enderecoDTO)
        {
            try
            {
                await _applicationServiceEndereco.Update(id,enderecoDTO);
                return Ok("O endereço foi atualizado com sucesso!");

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>Remove um endereço na lista Enderecos.</summary> 
        /// <remarks>
        /// Descrição
        /// 
        ///     Delete api/{version}/enderecos/{id}
        ///     
        ///     Deleta um endereco da lista cujo id corresponda ao passado como parâmetro.
        ///     Ex: api/2/enderecos/2
        /// 
        /// Id
        /// 
        ///     2
        ///     
        /// </remarks>
        /// <response code="204">Remoção realizada</response>
        /// <response code="400">Valores informados não são válidos</response> 

        [ApiVersion("2")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _applicationServiceEndereco.Delete(id);
            return this.NoContent();
        }
    }
}
