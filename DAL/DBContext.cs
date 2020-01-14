using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Adminer
    {
        [Key]
        public string Navn { get; set; }
        public byte[] Passord { get; set; }
        public string Salt { get; set; }
    }


   


    public class Strekninger
    {
        [Key]
        public int SId { get; set; }
        public string Fra { get; set; }
        public string Til { get; set; }
       

    }




    public class Avganger
    {
        [Key]
        public int AId { get; set; }
        public string FraogTiltid { get; set; }
        public string Lengdne { get; set; }
        public double Price { get; set; }
        
        public int StrekningId { get; set; }


    }


    public class DBContext : DbContext
    {
        public DBContext() :
             base("name=admindatabase")
        {
            Database.CreateIfNotExists();
            Database.SetInitializer(new DBInit());
        }

        public virtual DbSet<Strekninger> Strekninger { get; set; }
        public virtual DbSet<Avganger> Avganger { get; set; }
       
        public virtual DbSet<Adminer> Adminer { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
