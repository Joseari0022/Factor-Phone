using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Guardar(TEntity Entidad);
        bool Modificar(TEntity Entidad);
        bool Eliminar(TEntity Entidad);

        TEntity Buscar(Expression<Func<TEntity, bool>> Busqueda);
        List<TEntity> Lista(Expression<Func<TEntity, bool>> Busqueda);
    }
}
