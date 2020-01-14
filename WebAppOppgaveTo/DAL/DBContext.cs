using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebAppOppgaveTo.MODEL;

namespace WebAppOppgaveTo.DAL
{

    public class Adminer
    {
        [Key]
        public string Navn { get; set; }
        public byte[] Passord { get; set; }
        public string Salt { get; set; }
    }


    public class Togstasjoner
    {

        [Key]
        public int Id { get; set; }
        public string Stasjon { get; set; }

    }


    public class Strekninger
    {
        [Key]
        public int SId { get; set; }
        public string Fra { get; set; }
        public string Til { get; set; }
        public virtual List<Avganger> Avganger { get; set; }

    }




    public class Avganger
    {
        [Key]
        public int AId { get; set; }
        public string FraogTiltid { get; set; }
        public string Lengdne { get; set; }
        public double Price { get; set; }
        public virtual Strekninger Strekning { get; set; }


    }


    public class DBContext : DbContext
    {
        public DBContext() :
             base("name=togdatabase")
        {
            Database.CreateIfNotExists();
            Database.SetInitializer(new DBInit());
        }

        public virtual DbSet<Strekninger> Strekninger { get; set; }
        public virtual DbSet<Avganger> Avganger { get; set; }
        public virtual DbSet<Togstasjoner> Togstasjoner { get; set; }
        public virtual DbSet<Adminer> Adminer { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}