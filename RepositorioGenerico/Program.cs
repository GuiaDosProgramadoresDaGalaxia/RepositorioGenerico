using Dominio.Entidades;
using Service;

namespace RepositorioGenerico
{
    class Program
    {
        static void Main(string[] args)
        {
            var repositorio = Injecao.ObterRepositorio();

            var biblioteca = repositorio.ObterPrimeiro<Biblioteca>(null, null, c => c.Autores, c => c.Secoes, c => c.Livros);
        }
    }
}
