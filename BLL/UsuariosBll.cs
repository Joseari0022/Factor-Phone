using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;
using System.Linq.Expressions;

namespace BLL
{
    public class UsuariosBll
    {
        public static bool Guardar(Usuarios usuarios)
        {
            using (var reposi = new Repositorio<Usuarios>())
            {
                try
                {
                    if(Buscar(u => u.IdUsuarios == usuarios.IdUsuarios) == null)
                    {
                        return reposi.Guardar(usuarios);
                    }
                    else
                    {
                        return reposi.Modificar(usuarios);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static Usuarios Buscar(Expression<Func<Entidades.Usuarios, bool>> Busqueda)
        {
            Usuarios Result = null;
            using (var repoitorio = new Repositorio<Usuarios>())
            {
                Result = repoitorio.Buscar(Busqueda);
            }
            return Result;
        }

        public static bool Modificar(Usuarios usuarios)
        {
            bool modifica = false;
            using (var reposi = new Repositorio<Usuarios>())
            {
                modifica = reposi.Modificar(usuarios);
            }
            return modifica;
        }

        public static bool Eliminar(Usuarios usuario)
        {
            bool eliminado = false;
            using (var reposi = new Repositorio<Usuarios>())
            {
                eliminado = reposi.Eliminar(usuario);
            }
            return eliminado;
        }

        public static List<Usuarios> Listar(Expression<Func<Usuarios, bool>> Busqueda)
        {
            List<Usuarios> resultado = null;
            using (var reposi = new Repositorio<Usuarios>())
            {
                try
                {
                    resultado = reposi.Lista(Busqueda).ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                return resultado;
            }
        }

        public static List<Usuarios> ListarTodo()
        {
            List<Usuarios> resultado = null;
            using (var reposi = new Repositorio<Usuarios>())
            {
                try
                {
                    resultado = reposi.ListaGet().ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                return resultado;
            }
        }
    }
}
