using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Secao : Entidade<int>
    {
        public string Nome { get; set; }
        public string Local { get; set; }

        public int BibliotecaId { get; set; }
        public Biblioteca Biblioteca { get; set; }
        public IList<Livro> Livros { get; set; }

        public Secao()
        {
            Livros = new List<Livro>();
        }
    }
}