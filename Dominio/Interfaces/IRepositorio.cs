using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IRepositorio
    {
        IEnumerable<TEntidade> ObterTodos<TEntidade>(
        Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> ordenarPor = null,
        int? skip = null,
        int? take = null,
        params Expression<Func<TEntidade, object>>[] incluirPropriedades)
        where TEntidade : class, IEntidade;

        Task<IEnumerable<TEntidade>> ObterTodosAsync<TEntidade>(
            Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> ordenarPor = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntidade, object>>[] incluirPropriedades)
            where TEntidade : class, IEntidade;

        IEnumerable<TEntidade> Obter<TEntidade>(
            Expression<Func<TEntidade, bool>> filtro = null,
            Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> ordenarPor = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntidade, object>>[] incluirPropriedades)
            where TEntidade : class, IEntidade;

        Task<IEnumerable<TEntidade>> ObterAsync<TEntidade>(
            Expression<Func<TEntidade, bool>> filtro = null,
            Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> ordenarPor = null,
            int? skip = null,
            int? take = null,
            params Expression<Func<TEntidade, object>>[] incluirPropriedades)
            where TEntidade : class, IEntidade;

        TEntidade ObterUm<TEntidade>(
            Expression<Func<TEntidade, bool>> filtro = null,
            params Expression<Func<TEntidade, object>>[] incluirPropriedades)
            where TEntidade : class, IEntidade;

        Task<TEntidade> ObterUmAsync<TEntidade>(
            Expression<Func<TEntidade, bool>> filtro = null,
            params Expression<Func<TEntidade, object>>[] incluirPropriedades)
            where TEntidade : class, IEntidade;

        TEntidade ObterPrimeiro<TEntidade>(
            Expression<Func<TEntidade, bool>> filtro = null,
            Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> ordenarPor = null,
            params Expression<Func<TEntidade, object>>[] incluirPropriedades)
            where TEntidade : class, IEntidade;

        Task<TEntidade> ObterPrimeiroAsync<TEntidade>(
            Expression<Func<TEntidade, bool>> filtro = null,
            Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> ordenarPor = null,
            params Expression<Func<TEntidade, object>>[] incluirPropriedades)
            where TEntidade : class, IEntidade;

        TEntidade ObterPorId<TEntidade>(object id)
            where TEntidade : class, IEntidade;

        Task<TEntidade> ObterPorIdAsync<TEntidade>(object id)
            where TEntidade : class, IEntidade;

        int ObterQuantidade<TEntidade>(Expression<Func<TEntidade, bool>> filtro = null)
            where TEntidade : class, IEntidade;

        Task<int> ObterQuantidadeAsync<TEntidade>(Expression<Func<TEntidade, bool>> filtro = null)
            where TEntidade : class, IEntidade;

        bool ObterExistente<TEntidade>(Expression<Func<TEntidade, bool>> filtro = null)
            where TEntidade : class, IEntidade;

        Task<bool> ObterExistenteAsync<TEntidade>(Expression<Func<TEntidade, bool>> filtro = null)
            where TEntidade : class, IEntidade;

        void Criar<TEntidade>(TEntidade entidade, string criadoPor = null)
        where TEntidade : class, IEntidade;

        void Atualizar<TEntidade>(TEntidade entidade, string modificadoPor = null)
            where TEntidade : class, IEntidade;

        void Deletar<TEntidade>(object id)
            where TEntidade : class, IEntidade;

        void Deletar<TEntidade>(TEntidade entidade)
            where TEntidade : class, IEntidade;

        void Salvar();

        Task SalvarAsync();
    }
}
