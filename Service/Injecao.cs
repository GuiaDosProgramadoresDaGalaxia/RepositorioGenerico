using Data.Contexto;
using Data.Repositorios;
using Dominio.Interfaces;

namespace Service
{
    public static class Injecao
    {
        public static IRepositorio ObterRepositorio()
        {
            return new Repositorio<BibliotecaContexto>(new BibliotecaContexto());
        }
    }
}
