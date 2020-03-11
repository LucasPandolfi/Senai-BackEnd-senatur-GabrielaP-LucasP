using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IPacotesRepository
    {
        List<Pacotes> ListarPacotes();

        void CadastrarPacote(Pacotes Novopacote);

        Pacotes BuscarPacotesPorId(int id);

        void AtualizarPacote(int id, Pacotes pacoteAtualizado);

        List<Pacotes> ListarPacotePorCidade(string nomeCidade);

        List<Pacotes> ListarPorPrecoAscendente(int valor);
    }
}
