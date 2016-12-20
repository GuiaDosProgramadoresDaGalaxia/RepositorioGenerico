using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Biblioteca : Entidade<int>
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }

        public IList<Livro> Livros { get; set; }
        public IList<Secao> Secoes { get; set; }
        public IList<Autor> Autores { get; set; }

        public Biblioteca()
        {
            Livros = new List<Livro>();
            Secoes = new List<Secao>();
            Autores = new List<Autor>();
        }
    }
}
