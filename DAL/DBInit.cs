using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBInit : DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext context)
        {


            string salt = lagSalt();
            var pass = "Admin";
            var passordOgSalt = pass + salt;
            byte[] passordDB = lagHash(passordOgSalt);

            var nyAdmin = new Adminer
            {

                Navn = "Admin",
                Passord = passordDB,
                Salt = salt
            };





            var nystrekning1 = new Strekninger
            {
                Fra = "Oslo",
                Til = "Bergen"
            };
            var nystrekning2 = new Strekninger
            {
                Fra = "Oslo",
                Til = "Stavanger"
            };
           
            var nystrekning3 = new Strekninger
            {
                Fra = "Bergen",
                Til = "Oslo"
            };

           

            var nystrekning4 = new Strekninger
            {
                Fra = "Stavanger",
                Til = "Oslo"
            };

           

            var nystrekning5 = new Strekninger
            {
                Fra = "Trondiheim",
                Til = "Oslo"
            };

           



            var nyavgang1 = new Avganger
            {

                FraogTiltid = "10:30-17:30",
                Lengdne = "7timer",
                Price = 599,
                StrekningId = 1

            };
            var nyavgang2 = new Avganger
            {

                FraogTiltid = "14:30-21:30",
                Lengdne = "7timer",
                Price = 499,
                StrekningId = 1

            };
            var nyavgang3 = new Avganger
            {

                FraogTiltid = "08:30-16:30",
                Lengdne = "8timer",
                Price = 499,
                StrekningId = 2
            };

            var nyavgang4 = new Avganger
            {


                FraogTiltid = "10:30-17:30",
                Lengdne = "7timer",
                Price = 599,
                StrekningId = 2

            };
            var nyavgang5 = new Avganger
            {

                FraogTiltid = "10:30-15:30",
                Lengdne = "5timer",
                Price = 299,
                StrekningId = 3

            };

            var nyavgang6 = new Avganger
            {

                FraogTiltid = "15:30-21:00",
                Lengdne = "5.5timer",
                Price = 599,
                StrekningId = 3

            };


            var nyavgang7 = new Avganger
            {

                FraogTiltid = "10:30-17:30",
                Lengdne = "6.5timer",
                Price = 449,
                StrekningId = 4

            };

            var nyavgang8 = new Avganger
            {

                FraogTiltid = "14:30-20:30",
                Lengdne = "6timer",
                Price = 499,
                StrekningId = 4

            };

            var nyavgang9 = new Avganger
            {

                FraogTiltid = "08:30-14:00",
                Lengdne = "5.5timer",
                Price = 599,
                StrekningId = 5

            };


            var nyavgang10 = new Avganger
            {

                FraogTiltid = "10:30-16:30",
                Lengdne = "6timer",
                Price = 499,
                StrekningId = 5

            };

           
            var nyavganger = new List<Avganger>();
            nyavganger.Add(nyavgang1);
            nyavganger.Add(nyavgang2);
            nyavganger.Add(nyavgang3);
            nyavganger.Add(nyavgang4);
            nyavganger.Add(nyavgang5);
            nyavganger.Add(nyavgang6);
            nyavganger.Add(nyavgang7);
            nyavganger.Add(nyavgang8);
            nyavganger.Add(nyavgang9);
            nyavganger.Add(nyavgang10);
            
            var nystrekning = new List<Strekninger>();
            nystrekning.Add(nystrekning1);
            nystrekning.Add(nystrekning2);
            nystrekning.Add(nystrekning3);
            nystrekning.Add(nystrekning4);
            nystrekning.Add(nystrekning5);
            
            var nyadmin = new List<Adminer>();
            nyadmin.Add(nyAdmin);
            context.Adminer.AddRange(nyadmin);
            context.Avganger.AddRange(nyavganger);
            context.Strekninger.AddRange(nystrekning);
          
            base.Seed(context);
        }

        private static byte[] lagHash(string innPassord)
        {
            byte[] innData, utData;
            var algoritme = SHA256.Create();
            innData = Encoding.ASCII.GetBytes(innPassord);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }
        private static string lagSalt()
        {
            byte[] randomArray = new byte[10];
            string randomString;

            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomArray);
            randomString = Convert.ToBase64String(randomArray);
            return randomString;
        }

        public string HashStreng(string innStreng)
        {
            byte[] hash = lagHash(innStreng);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

    }
}
