using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class AdminRepository : DAL.IAdminRepository
    {
        public List<Admin> alleAdminer()
        {
            using (var db = new DBContext())
            {
                List<Admin> alleAdminer = db.Adminer.Select(k => new Admin
                {
                    Navn = k.Navn,
                    PassordByte = k.Passord,


                }).ToList();

                return alleAdminer;
            }
        }
        public List<Admin> hentAdminInnhold(string Navn)
        {
            using (var db = new DBContext())
            {

                List<Admin> hentetAdminer = db.Adminer.Where(k => k.Navn.Contains(Navn)).Select(n => new Admin
                {
                    Navn = n.Navn,
                    PassordByte = n.Passord


                }).ToList();

                if (hentetAdminer.Count < 1)
                {
                    return null;
                }
                return hentetAdminer;
            }
        }

        public bool lagreAdmin(Admin innAdmin)
        {

            using (var db = new DBContext())
            {
                try
                {
                    var nyAdminRad = new Adminer();
                    string salt = lagSalt();
                    var passordOgSalt = innAdmin.Passord + salt;
                    byte[] passord = lagHash(passordOgSalt);
                    nyAdminRad.Navn = innAdmin.Navn;
                    nyAdminRad.Passord = passord;
                    nyAdminRad.Salt = salt;
                    db.Adminer.Add(nyAdminRad);
                    db.SaveChanges();
                    return true;

                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }


        public bool Admin_i_db(Admin innAdmin)
        {
            using (var db = new DBContext())
            {
                Adminer funnetAdmin = db.Adminer.FirstOrDefault(b => b.Navn == innAdmin.Navn);
                if (funnetAdmin != null)
                {
                    string salt = lagSalt();
                    byte[] passordForTest = lagHash(innAdmin.Passord + funnetAdmin.Salt);
                    bool riktigBruker = funnetAdmin.Passord.SequenceEqual(passordForTest);  // merk denne testen!
                    return riktigBruker;
                }
                else
                {
                    return false;
                }
            }
        }



        public bool slett(string Navn)
        {
            using (var db = new DBContext())
            {
                try
                {
                    var slettObjekt = db.Adminer.Find(Navn);
                    db.Adminer.Remove(slettObjekt);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }

        private static byte[] lagHash(string innPassord)
        {
            byte[] innData, utData;
            var algoritme = System.Security.Cryptography.SHA256.Create();
            innData = System.Text.Encoding.ASCII.GetBytes(innPassord);
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
                sb.Append(hash[i].ToString("x2")); // konverterer byte'ene til en char (streng) av hex-tegn.
            }
            return sb.ToString();
        }

    }
}
