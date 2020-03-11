using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class PacotesRepository : IPacotesRepository
    {
        SenaturContext ctx = new SenaturContext();

        public List<Pacotes> ListarPacotes()
        {
            return ctx.Pacotes.ToList();
        }

        public void CadastrarPacote (Pacotes novoPacote)
        {
            ctx.Pacotes.Add(novoPacote);

            ctx.SaveChanges();
        }

        public void AtualizarPacote(int id, Pacotes pacoteAtualizado)
        {
            Pacotes pacoteBuscado = ctx.Pacotes.Find(id);

            pacoteBuscado.NomePacote = pacoteAtualizado.NomePacote;
            pacoteBuscado.Descricao = pacoteAtualizado.Descricao;
            pacoteBuscado.DataIda = pacoteAtualizado.DataIda;
            pacoteBuscado.DataVolta = pacoteAtualizado.DataVolta;
            pacoteBuscado.Valor = pacoteAtualizado.Valor;
            pacoteBuscado.NomeCidade = pacoteAtualizado.NomeCidade;

            // Atualiza o jogo que foi buscado
            ctx.Pacotes.Update(pacoteBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        public Pacotes BuscarPacotesPorId(int id)
        {
            return ctx.Pacotes.FirstOrDefault(P => P.IdPacote == id);
        }

        public List<Pacotes> ListarPacotePorCidade(string nomeCidade)
        {
            return ctx.Pacotes.ToList().FindAll(p => p.NomeCidade == nomeCidade);
        }

        public List<Pacotes> ListarPorPrecoAscendente(int valor)
        {
            if(valor == 1)
            {
                return ctx.Pacotes.OrderByDescending(p => p.Valor).ToList();
            }
            else
            {
                return ctx.Pacotes.OrderBy(p => p.Valor).ToList();
            }
        }
    }
}
