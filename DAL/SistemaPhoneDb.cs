using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.Entity;

namespace DAL
{
    public class SistemaPhoneDb : DbContext
    {
        public SistemaPhoneDb() : base("ConStr")
        {

        }

        public virtual DbSet<Usuarios> Usuarios { get; set; }

    }
}
