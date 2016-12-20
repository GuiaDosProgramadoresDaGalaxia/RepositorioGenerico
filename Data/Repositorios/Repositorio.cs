using Dominio.Interfaces;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

namespace Data.Repositorios
{
    public class Repositorio<TContexto> : IRepositorio where TContexto : DbContext
    {
        protected readonly TContexto contexto;

        public Repositorio(TContexto contexto)
        {
            this.contexto = contexto;
        }

        protected virtual IQueryable<TEntidade> ObterQueryable<TEntidade>(
        Expression<Func<TEntidade, bool>> filtro = null,
        Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> ordenarPor = null,
        int? skip = null,
        int? take = null,
        params Expression<Func<TEntidade, object>>[] incluirPropriedades)
        where TEntidade : class, IEntidade
        {

            IQueryable<TEntidade> query = contexto.Set<TEntidade>();

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            if(incluirPropriedades != null)
            {
                query = incluirPropriedades.Aggregate(query, (current, include) => current.Include(include));
            }

            if (ordenarPor != null)
            {
                query = ordenarPor(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        #region CRUD    
        public virtual void Criar<TEntidade>(TEntidade entidade, string criadoPor) where TEntidade : class, IEntidade
        {
            entidade.DataCriacao = DateTime.UtcNow;
            entidade.CriadoPor = criadoPor;
            contexto.Set<TEntidade>().Add(entidade);
        }

        public virtual void Atualizar<TEntidade>(TEntidade entidade, string modificadoPor) where TEntidade : class, IEntidade
        {
            entidade.DataModificacao = DateTime.UtcNow;
            entidade.ModificadoPor = modificadoPor;
            contexto.Set<TEntidade>().Attach(entidade);
            contexto.Entry(entidade).State = EntityState.Modified;
        }

        public virtual void Deletar<TEntidade>(TEntidade entidade) where TEntidade : class, IEntidade
        {
            var dbSet = contexto.Set<TEntidade>();
            if (contexto.Entry(entidade).State == EntityState.Detached)
            {
                dbSet.Attach(entidade);
            }
            dbSet.Remove(entidade);
        }

        public virtual void Deletar<TEntidade>(object id) where TEntidade : class, IEntidade
        {
            TEntidade entidade = contexto.Set<TEntidade>().Find(id);
            Deletar(entidade);
        }
        #endregion

        #region Querys
        public virtual IEnumerable<TEntidade> Obter<TEntidade>(Expression<Func<TEntidade, bool>> filtro, Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> ordenarPor, int? skip, int? take, params Expression<Func<TEntidade, object>>[] incluirPropriedades) where TEntidade : class, IEntidade
        {
            return ObterQueryable<TEntidade>(filtro, ordenarPor, skip, take, incluirPropriedades).ToList();
        }

        public virtual async Task<IEnumerable<TEntidade>> ObterAsync<TEntidade>(Expression<Func<TEntidade, bool>> filtro, Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> ordenarPor, int? skip, int? take, params Expression<Func<TEntidade, object>>[] incluirPropriedades) where TEntidade : class, IEntidade
        {
            return await ObterQueryable<TEntidade>(filtro, ordenarPor, skip, take, incluirPropriedades).ToListAsync();
        }

        public virtual bool ObterExistente<TEntidade>(Expression<Func<TEntidade, bool>> filtro) where TEntidade : class, IEntidade
        {
            return ObterQueryable<TEntidade>(filtro).Any();
        }

        public virtual Task<bool> ObterExistenteAsync<TEntidade>(Expression<Func<TEntidade, bool>> filtro) where TEntidade : class, IEntidade
        {
            return ObterQueryable<TEntidade>(filtro).AnyAsync();
        }

        public virtual TEntidade ObterPorId<TEntidade>(object id) where TEntidade : class, IEntidade
        {
            return contexto.Set<TEntidade>().Find(id);
        }

        public virtual Task<TEntidade> ObterPorIdAsync<TEntidade>(object id) where TEntidade : class, IEntidade
        {
            return contexto.Set<TEntidade>().FindAsync(id);
        }

        public virtual TEntidade ObterPrimeiro<TEntidade>(Expression<Func<TEntidade, bool>> filtro, Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> ordenarPor, params Expression<Func<TEntidade, object>>[] incluirPropriedades) where TEntidade : class, IEntidade
        {
            return ObterQueryable<TEntidade>(filtro, ordenarPor, incluirPropriedades:incluirPropriedades).FirstOrDefault();
        }

        public virtual async Task<TEntidade> ObterPrimeiroAsync<TEntidade>(Expression<Func<TEntidade, bool>> filtro, Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> ordenarPor, params Expression<Func<TEntidade, object>>[] incluirPropriedades) where TEntidade : class, IEntidade
        {
            return await ObterQueryable<TEntidade>(filtro, ordenarPor, incluirPropriedades:incluirPropriedades).FirstOrDefaultAsync();
        }

        public virtual int ObterQuantidade<TEntidade>(Expression<Func<TEntidade, bool>> filtro) where TEntidade : class, IEntidade
        {
            return ObterQueryable<TEntidade>(filtro).Count();
        }

        public virtual Task<int> ObterQuantidadeAsync<TEntidade>(Expression<Func<TEntidade, bool>> filtro) where TEntidade : class, IEntidade
        {
            return ObterQueryable<TEntidade>(filtro).CountAsync();
        }

        public virtual IEnumerable<TEntidade> ObterTodos<TEntidade>(Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> ordenarPor, int? skip, int? take, params Expression<Func<TEntidade, object>>[] incluirPropriedades) where TEntidade : class, IEntidade
        {
            return ObterQueryable<TEntidade>(null, ordenarPor, skip, take, incluirPropriedades).ToList();
        }

        public virtual async Task<IEnumerable<TEntidade>> ObterTodosAsync<TEntidade>(Func<IQueryable<TEntidade>, IOrderedQueryable<TEntidade>> ordenarPor, int? skip, int? take, params Expression<Func<TEntidade, object>>[] incluirPropriedades) where TEntidade : class, IEntidade
        {
            return await ObterQueryable<TEntidade>(null, ordenarPor, skip, take, incluirPropriedades).ToListAsync();
        }

        public virtual TEntidade ObterUm<TEntidade>(Expression<Func<TEntidade, bool>> filtro, params Expression<Func<TEntidade, object>>[] incluirPropriedades) where TEntidade : class, IEntidade
        {
            return ObterQueryable<TEntidade>(filtro, null, incluirPropriedades:incluirPropriedades).SingleOrDefault();
        }

        public virtual async Task<TEntidade> ObterUmAsync<TEntidade>(Expression<Func<TEntidade, bool>> filtro, params Expression<Func<TEntidade, object>>[] incluirPropriedades) where TEntidade : class, IEntidade
        {
            return await ObterQueryable<TEntidade>(filtro, null, incluirPropriedades:incluirPropriedades).SingleOrDefaultAsync();
        }
        #endregion

        #region Implementacao 'Salvar'
        public virtual void Salvar()
        {
            try
            {
                contexto.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                ThrowEnhancedValidationException(e);
            }
        }

        public virtual Task SalvarAsync()
        {
            try
            {
                return contexto.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                ThrowEnhancedValidationException(e);
            }

            return Task.FromResult(0);
        }

        protected virtual void ThrowEnhancedValidationException(DbEntityValidationException e)
        {
            var errorMessages = e.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

            var fullErrorMessage = string.Join("; ", errorMessages);
            var exceptionMessage = string.Concat(e.Message, " The validation errors are: ", fullErrorMessage);
            throw new DbEntityValidationException(exceptionMessage, e.EntityValidationErrors);
        }
        #endregion
    }
}
