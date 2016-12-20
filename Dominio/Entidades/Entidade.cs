using System;
using Dominio.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public abstract class Entidade<T> : IEntidade<T>
    {
        public string CriadoPor { get; set; }
        public string ModificadoPor { get; set; }
        public string Name { get; set; }

        [Timestamp]
        public byte[] Versao { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
        object IEntidade.Id
        {
            get
            {
                return this.Id;
            }
        }

        private DateTime? dataCriacao;
        [DataType(DataType.DateTime)]
        public DateTime DataCriacao
        {
            get { return dataCriacao ?? DateTime.UtcNow; }
            set { dataCriacao = value; }
        }

        [DataType(DataType.DateTime)]
        public DateTime? DataModificacao { get; set; }
    }
}
