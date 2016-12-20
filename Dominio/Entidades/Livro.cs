namespace Dominio.Entidades
{
    public class Livro : Entidade<int>
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int BibliotecaId { get; set; }
        public Biblioteca Biblioteca { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        public int SecaoId { get; set; }
        public Secao Secao { get; set; }
    }
}