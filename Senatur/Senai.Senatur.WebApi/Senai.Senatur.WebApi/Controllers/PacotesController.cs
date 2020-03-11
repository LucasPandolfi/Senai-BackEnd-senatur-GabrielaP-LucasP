using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("Aplication/Json")]

    [Route("api/[controller]")]
    [ApiController]
    public class PacotesController : ControllerBase
    {
        private IPacotesRepository _pacoteRepository;

        public PacotesController()
        {
            _pacoteRepository = new PacotesRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pacoteRepository.ListarPacotes());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_pacoteRepository.BuscarPacotesPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Pacotes novoPacote)
        {
            _pacoteRepository.CadastrarPacote(novoPacote);

            return StatusCode(201);
        }

        [HttpPut]
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
    }
}