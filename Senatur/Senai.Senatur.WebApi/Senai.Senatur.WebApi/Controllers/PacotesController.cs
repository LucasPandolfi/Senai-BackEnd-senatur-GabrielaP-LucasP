using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    [Authorize]
    public class PacotesController : ControllerBase
    {
        private IPacotesRepository _pacoteRepository;

        public PacotesController()
        {
            _pacoteRepository = new PacotesRepository();
        }

        /// <summary>
        /// Listando todos os pacotes
        /// </summary>
        /// <param></param>
        /// <returns>Retorna uma objeto pacote</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pacoteRepository.ListarPacotes());
        }

        /// <summary>
        /// Listando os pacotes pela id
        /// </summary>
        /// <param></param>
        /// <returns>Retorna uma objeto pacote</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById(int id)
        {
            return Ok(_pacoteRepository.BuscarPacotesPorId(id));
        }

        /// <summary>
        /// Cadastra um pacote
        /// </summary>
        /// <param></param>
        /// <returns>Cria um objeto pacote</returns>
        [Authorize(Roles = "1")]   
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(Pacotes novoPacote)
        {
            _pacoteRepository.CadastrarPacote(novoPacote);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um pacote
        /// </summary>
        /// <param></param>
        /// <returns>Atualiza um objeto pacote</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, Pacotes pacoteAtualizado)
        {
            Pacotes pacoteBuscado = _pacoteRepository.BuscarPacotesPorId(id); 
            if(pacoteBuscado == null)
            {
                return StatusCode(404);
            }

            _pacoteRepository.AtualizarPacote(id, pacoteAtualizado);

            return StatusCode(204);
        }

        /// <summary>
        /// Lista todos os pacotes que sejam na mesma cidade
        /// </summary>
        /// <param></param>
        /// <returns>lista um objeto pacote</returns>
        [HttpGet ("NomeCidade/{nomeCidade}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(string nomeCidade)
        {
            return  Ok(_pacoteRepository.ListarPacotePorCidade(nomeCidade));
        }

        /// <summary>
        /// Lista todos os pacotes pelo seu preço 1=ASC ou 0=DESC
        /// </summary>
        /// <param></param>
        /// <returns>lista um objeto pacote</returns>
        [HttpGet("Valor/{valor}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetOrderBy(int valor)
        {
            return Ok(_pacoteRepository.ListarPorPrecoAscendente(valor));
        }
    }
}