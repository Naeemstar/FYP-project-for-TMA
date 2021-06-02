using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAppTMA.Models
{
    public class TMAdb:DbContext

    {
        public TMAdb():
            base("cs")
        {

        }
        public DbSet<user> users { get; set; }
        public DbSet<Rolee> Roles { get; set; }
        public DbSet<Clientes> clientes { get; set; }
        public DbSet<Complain> Complains{ get; set; }
        public DbSet<Notifaction> Notifactions { get; set; }
        public DbSet<Planing> planings { get; set; }
        public DbSet<Resources> resources { get; set; }
        public DbSet<SuccessDeplyment> successDeplyments { get; set; }
        public DbSet<File> files { get; set; }


    }
}