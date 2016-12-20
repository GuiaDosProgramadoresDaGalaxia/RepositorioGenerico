using System;

namespace Dominio.Interfaces
{
    public interface IEntidade : IModificavelEntidade
    {
        object Id { get; }
        DateTime DataCriacao { get; set; }
        DateTime? DataModificacao { get; set; }
        string CriadoPor { get; set; }
        string ModificadoPor { get; set; }
        byte[] Versao { get; set; }
    }

    public interface IEntidade<T> : IEntidade
    {
        new T Id { get; set; }
    }
}
