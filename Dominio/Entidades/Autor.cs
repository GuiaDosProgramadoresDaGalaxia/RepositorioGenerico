using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Autor : Entidade<int>
    {
        public string Nome { get; set; }

        public IList<Livro> Livros { get; set; }
        public IList<Biblioteca> Bibliotecas { get; set; }
        public Autor()
        {
            Livros = new List<Livro>();
            Bibliotecas = new List<Biblioteca>();
        }
    }
}