using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using WebAppOppgaveTo.MODEL;

namespace WebAppOppgaveTo.DAL
{
    public class DBInit : DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext context)
        {


            string salt = lagSalt();
            var pass = "Admin123";
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
                Fra = "Oslo",
                Til = "Krstiansand"
            };


            var nystrekning4 = new Strekninger
            {
                Fra = "Oslo",
                Til = "Trondiheim"
            };
            var nystrekning5 = new Strekninger
            {
                Fra = "Oslo",
                Til = "Drammen"
            };
            var nystrekning6 = new Strekninger
            {
                Fra = "Oslo",
                Til = "OsloLufthaven"
            };

            var nystrekning7 = new Strekninger
            {
                Fra = "Oslo",
                Til = "Lillehammer"
            };
            var nystrekning8 = new Strekninger
            {
                Fra = "Oslo",
                Til = "Skien"
            };

            var nystrekning9 = new Strekninger
            {
                Fra = "Oslo",
                Til = "Gjøvik"
            };

            var nystrekning10 = new Strekninger
            {
                Fra = "Bergen",
                Til = "Oslo"
            };

            var nystrekning11 = new Strekninger
            {
                Fra = "Bergen",
                Til = "Drammen"
            };


            var nystrekning12 = new Strekninger
            {
                Fra = "Stavanger",
                Til = "Oslo"
            };

            var nystrekning13 = new Strekninger
            {
                Fra = "Stavanger",
                Til = "KrstianSand"
            };


            var nystrekning14 = new Strekninger
            {
                Fra = "Stavanger",
                Til = "Drammen"
            };


            var nystrekning15 = new Strekninger
            {
                Fra = "KrstianSand",
                Til = "Oslo"
            };

            var nystrekning16 = new Strekninger
            {
                Fra = "KrstianSand",
                Til = "Drammen"
            };
            var nystrekning17 = new Strekninger
            {
                Fra = "KrstianSand",
                Til = "Stavanger"
            };


            var nystrekning18 = new Strekninger
            {
                Fra = "Trondiheim",
                Til = "Oslo"
            };

            var nystrekning19 = new Strekninger
            {
                Fra = "Trondiheim",
                Til = "Lillehammer"
            };

            var nystrekning20 = new Strekninger
            {
                Fra = "Trondiheim",
                Til = "Drammen"
            };

            var nystrekning21 = new Strekninger
            {
                Fra = "Drammen",
                Til = "Oslo"
            };

            var nystrekning22 = new Strekninger
            {
                Fra = "Drammen",
                Til = "Krstiansand"
            };

            var nystrekning23 = new Strekninger
            {
                Fra = "Drammen",
                Til = "Stavanger"
            };

            var nystrekning24 = new Strekninger
            {
                Fra = "Drammen",
                Til = "Bergen"
            };

            var nystrekning25 = new Strekninger
            {
                Fra = "Drammen",
                Til = "OsloLufthaven"
            };

            var nystrekning26 = new Strekninger
            {
                Fra = "OsloLufthaven",
                Til = "Oslo"
            };

            var nystrekning27 = new Strekninger
            {
                Fra = "Skien",
                Til = "Oslo"
            };

            var nystrekning28 = new Strekninger
            {
                Fra = "Gjøvik",
                Til = "Oslo"
            };
            var nystrekning29 = new Strekninger
            {
                Fra = "Lillehammer",
                Til = "Oslo"
            };

            var nystrekning30 = new Strekninger
            {
                Fra = "Lillehammer",
                Til = "OsloLufthaven"
            };




            var nyavgang1 = new Avganger
            {

                FraogTiltid = "10:30-17:30",
                Lengdne = "7timer",
                Price = 599,
                Strekning = nystrekning1

            };
            var nyavgang2 = new Avganger
            {

                FraogTiltid = "14:30-21:30",
                Lengdne = "7timer",
                Price = 499,
                Strekning = nystrekning1

            };
            var nyavgang3 = new Avganger
            {

                FraogTiltid = "08:30-16:30",
                Lengdne = "8timer",
                Price = 499,
                Strekning = nystrekning2
            };

            var nyavgang4 = new Avganger
            {


                FraogTiltid = "10:30-17:30",
                Lengdne = "7timer",
                Price = 599,
                Strekning = nystrekning2

            };
            var nyavgang5 = new Avganger
            {

                FraogTiltid = "10:30-15:30",
                Lengdne = "5timer",
                Price = 299,
                Strekning = nystrekning3

            };

            var nyavgang6 = new Avganger
            {

                FraogTiltid = "15:30-21:00",
                Lengdne = "5.5timer",
                Price = 599,
                Strekning = nystrekning3

            };


            var nyavgang7 = new Avganger
            {

                FraogTiltid = "10:30-17:30",
                Lengdne = "6.5timer",
                Price = 449,
                Strekning = nystrekning4

            };

            var nyavgang8 = new Avganger
            {

                FraogTiltid = "14:30-20:30",
                Lengdne = "6timer",
                Price = 499,
                Strekning = nystrekning4

            };

            var nyavgang9 = new Avganger
            {

                FraogTiltid = "08:30-09:20",
                Lengdne = "50min",
                Price = 90,
                Strekning = nystrekning5

            };


            var nyavgang10 = new Avganger
            {

                FraogTiltid = "10:30-11:20",
                Lengdne = "50min",
                Price = 90,
                Strekning = nystrekning5

            };

            var nyavgang11 = new Avganger
            {

                FraogTiltid = "12:30-13:20",
                Lengdne = "50min",
                Price = 90,
                Strekning = nystrekning5

            };

            var nyavgang12 = new Avganger
            {

                FraogTiltid = "18:30-19:20",
                Lengdne = "50min",
                Price = 90,
                Strekning = nystrekning5

            };

            var nyavgang13 = new Avganger
            {

                FraogTiltid = "07:30-07:56",
                Lengdne = "25min",
                Price = 90,
                Strekning = nystrekning6
            };
            var nyavgang14 = new Avganger
            {

                FraogTiltid = "08:30-08:55",
                Lengdne = "25min",
                Price = 90,
                Strekning = nystrekning6

            };
            var nyavgang15 = new Avganger
            {

                FraogTiltid = "14:30-14:55",
                Lengdne = "25min",
                Price = 90,
                Strekning = nystrekning6

            };
            var nyavgang16 = new Avganger
            {

                FraogTiltid = "18:30-18:55",
                Lengdne = "25min",
                Price = 90,
                Strekning = nystrekning6

            };


            var nyavgang17 = new Avganger
            {

                FraogTiltid = "08:30-11:00",
                Lengdne = "2.5timer",
                Price = 299,
                Strekning = nystrekning7

            };
            var nyavgang18 = new Avganger
            {

                FraogTiltid = "12:30-15:00",
                Lengdne = "2.5timer",
                Price = 299,
                Strekning = nystrekning7

            };


            var nyavgang19 = new Avganger
            {

                FraogTiltid = "10:30-13:00",
                Lengdne = "2.5timer",
                Price = 299,
                Strekning = nystrekning8

            };


            var nyavgang20 = new Avganger
            {

                FraogTiltid = "16:30-19:00",
                Lengdne = "2.5timer",
                Price = 299,
                Strekning = nystrekning8

            };


            var nyavgang21 = new Avganger
            {

                FraogTiltid = "10:30-12:30",
                Lengdne = "2timer",
                Price = 299,
                Strekning = nystrekning9

            };
            var nyavgang22 = new Avganger
            {

                FraogTiltid = "18:30-20:30",
                Lengdne = "2timer",
                Price = 299,
                Strekning = nystrekning9

            };


            var nyavgang23 = new Avganger
            {

                FraogTiltid = "08:30-16:30",
                Lengdne = "8timer",
                Price = 599,
                Strekning = nystrekning10

            };

            var nyavgang24 = new Avganger
            {

                FraogTiltid = "18:30-00:30",
                Lengdne = "6tmer",
                Price = 599,
                Strekning = nystrekning10

            };
            var nyavgang25 = new Avganger
            {

                FraogTiltid = "08:30-15:30",
                Lengdne = "7timer",
                Price = 549,
                Strekning = nystrekning11

            };

            var nyavgang26 = new Avganger
            {

                FraogTiltid = "18:30-23:30",
                Lengdne = "5timer",
                Price = 549,
                Strekning = nystrekning11

            };

            var nyavgang27 = new Avganger
            {

                FraogTiltid = "08:30-17:30",
                Lengdne = "8timer",
                Price = 599,
                Strekning = nystrekning12

            };

            var nyavgang28 = new Avganger
            {

                FraogTiltid = "08:30-11:30",
                Lengdne = "3timer",
                Price = 299,
                Strekning = nystrekning13

            };


            var nyavgang29 = new Avganger
            {

                FraogTiltid = "18:30-00:30",
                Lengdne = "6timer",
                Price = 499,
                Strekning = nystrekning12

            };


            var nyavgang30 = new Avganger
            {

                FraogTiltid = "18:30-21:30",
                Lengdne = "3timer",
                Price = 299,
                Strekning = nystrekning13

            };


            var nyavgang31 = new Avganger
            {

                FraogTiltid = "08:30-15:30",
                Lengdne = "5timer",
                Price = 399,
                Strekning = nystrekning14

            };


            var nyavgang32 = new Avganger
            {

                FraogTiltid = "11:30-16:30",
                Lengdne = "5timer",
                Price = 499,
                Strekning = nystrekning15

            };


            var nyavgang33 = new Avganger
            {

                FraogTiltid = "21:30-00:30",
                Lengdne = "3timer",
                Price = 399,
                Strekning = nystrekning15

            };


            var nyavgang34 = new Avganger
            {

                FraogTiltid = "11:30-15:30",
                Lengdne = "4timer",
                Price = 399,
                Strekning = nystrekning16

            };


            var nyavgang35 = new Avganger
            {

                FraogTiltid = "13:30-16:30",
                Lengdne = "3timer",
                Price = 299,
                Strekning = nystrekning17

            };

            var nyavgang36 = new Avganger
            {

                FraogTiltid = "10:30-16:30",
                Lengdne = "6timer",
                Price = 399,
                Strekning = nystrekning18

            };

            var nyavgang37 = new Avganger
            {

                FraogTiltid = "15:30-21:30",
                Lengdne = "6timer",
                Price = 399,
                Strekning = nystrekning18

            };

            var nyavgang38 = new Avganger
            {

                FraogTiltid = "18:30-00:30",
                Lengdne = "6timer",
                Price = 299,
                Strekning = nystrekning12

            };
            var nyavgang39 = new Avganger
            {

                FraogTiltid = "10:30-13:30",
                Lengdne = "3timer",
                Price = 299,
                Strekning = nystrekning19

            };

            var nyavgang40 = new Avganger
            {

                FraogTiltid = "10:30-12:30",
                Lengdne = "5timer",
                Price = 299,
                Strekning = nystrekning20

            };

            var nyavgang41 = new Avganger
            {

                FraogTiltid = "08:30-09:20",
                Lengdne = "50min",
                Price = 90,
                Strekning = nystrekning21

            };

            var nyavgang42 = new Avganger
            {

                FraogTiltid = "10:30-11:20",
                Lengdne = "50min",
                Price = 90,
                Strekning = nystrekning21

            };


            var nyavgang43 = new Avganger
            {

                FraogTiltid = "12:30-13:20",
                Lengdne = "50min",
                Price = 90,
                Strekning = nystrekning21

            };


            var nyavgang44 = new Avganger
            {

                FraogTiltid = "16:30-17:20",
                Lengdne = "50min",
                Price = 90,
                Strekning = nystrekning21

            };

            var nyavgang45 = new Avganger
            {

                FraogTiltid = "19:30-20:20",
                Lengdne = "50min",
                Price = 90,
                Strekning = nystrekning21

            };

            var nyavgang46 = new Avganger
            {

                FraogTiltid = "09:30-14:30",
                Lengdne = "5timer",
                Price = 499,
                Strekning = nystrekning22

            };



            var nyavgang47 = new Avganger
            {

                FraogTiltid = "17:30-22:30",
                Lengdne = "5timer",
                Price = 499,
                Strekning = nystrekning22

            };

            var nyavgang48 = new Avganger
            {

                FraogTiltid = "09:30-16:30",
                Lengdne = "7timer",
                Price = 499,
                Strekning = nystrekning23

            };

            var nyavgang49 = new Avganger
            {

                FraogTiltid = "17:30-23:30",
                Lengdne = "6timer",
                Price = 499,
                Strekning = nystrekning23

            };

            var nyavgang50 = new Avganger
            {

                FraogTiltid = "09:30-15:30",
                Lengdne = "6timer",
                Price = 499,
                Strekning = nystrekning24

            };

            var nyavgang51 = new Avganger
            {

                FraogTiltid = "10:30-10:55",
                Lengdne = "25min",
                Price = 103,
                Strekning = nystrekning26

            };


            var nyavgang52 = new Avganger
            {

                FraogTiltid = "12:30-12:55",
                Lengdne = "25min",
                Price = 103,
                Strekning = nystrekning26

            };
            var nyavgang53 = new Avganger
            {

                FraogTiltid = "14:30-14:55",
                Lengdne = "25min",
                Price = 103,
                Strekning = nystrekning26

            };
            var nyavgang54 = new Avganger
            {

                FraogTiltid = "16:30-16:55",
                Lengdne = "25min",
                Price = 103,
                Strekning = nystrekning26

            };
            var nyavgang55 = new Avganger
            {

                FraogTiltid = "18:30-18:55",
                Lengdne = "25min",
                Price = 103,
                Strekning = nystrekning26

            };



            var nyavgang56 = new Avganger
            {

                FraogTiltid = "10:30-13:00",
                Lengdne = "2.5timer",
                Price = 299,
                Strekning = nystrekning27

            };
            var nyavgang57 = new Avganger
            {

                FraogTiltid = "15:30-18:00",
                Lengdne = "2.5timer",
                Price = 299,
                Strekning = nystrekning27

            };
            var nyavgang58 = new Avganger
            {

                FraogTiltid = "10:30-10:55",
                Lengdne = "2.5timer",
                Price = 299,
                Strekning = nystrekning28

            };

            var nyavgang59 = new Avganger
            {

                FraogTiltid = "14:30-17:00",
                Lengdne = "2.5timer",
                Price = 299,
                Strekning = nystrekning28

            };

            var nyavgang60 = new Avganger
            {

                FraogTiltid = "10:30-13:30",
                Lengdne = "3timer",
                Price = 299,
                Strekning = nystrekning29

            };


            var nyavgang61 = new Avganger
            {

                FraogTiltid = "15:30-18:30",
                Lengdne = "3timer",
                Price = 299,
                Strekning = nystrekning29

            };

            var nyavgang62 = new Avganger
            {

                FraogTiltid = "10:30-11:30",
                Lengdne = "1timer",
                Price = 199,
                Strekning = nystrekning25

            };

            var nyavgang63 = new Avganger
            {

                FraogTiltid = "13:30-14:30",
                Lengdne = "1timer",
                Price = 199,
                Strekning = nystrekning25

            };


            var nyavgang64 = new Avganger
            {

                FraogTiltid = "16:30-17:30",
                Lengdne = "1timer",
                Price = 199,
                Strekning = nystrekning25

            };




            var nyavgang65 = new Avganger
            {

                FraogTiltid = "10:30-13:00",
                Lengdne = "2.5timer",
                Price = 299,
                Strekning = nystrekning30

            };

            var nyavgang66 = new Avganger
            {

                FraogTiltid = "15:30-18:00",
                Lengdne = "2.5timer",
                Price = 199,
                Strekning = nystrekning25

            };


            var nystasjon1 = new Togstasjoner
            {
                Stasjon = "Oslo"
            };

            var nystasjon2 = new Togstasjoner
            {
                Stasjon = "Bergen"
            };

            var nystasjon3 = new Togstasjoner
            {
                Stasjon = "Stavanger"
            };

            var nystasjon4 = new Togstasjoner
            {
                Stasjon = "Krstiansand"
            };

            var nystasjon5 = new Togstasjoner
            {
                Stasjon = "Trondiheim"
            };


            var nystasjon6 = new Togstasjoner
            {
                Stasjon = "Drammen"
            };

            var nystasjon7 = new Togstasjoner
            {
                Stasjon = "OsloLufthaven"
            };


            var nystasjon8 = new Togstasjoner
            {
                Stasjon = "Lillehammer"
            };


            var nystasjon9 = new Togstasjoner
            {
                Stasjon = "Skien"
            };

            var nystasjon10 = new Togstasjoner
            {
                Stasjon = "Gjøvik"
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
            nyavganger.Add(nyavgang11);
            nyavganger.Add(nyavgang12);
            nyavganger.Add(nyavgang13);
            nyavganger.Add(nyavgang14);
            nyavganger.Add(nyavgang15);
            nyavganger.Add(nyavgang16);
            nyavganger.Add(nyavgang17);
            nyavganger.Add(nyavgang18);
            nyavganger.Add(nyavgang19);
            nyavganger.Add(nyavgang20);
            nyavganger.Add(nyavgang21);
            nyavganger.Add(nyavgang22);
            nyavganger.Add(nyavgang23);
            nyavganger.Add(nyavgang24);
            nyavganger.Add(nyavgang25);
            nyavganger.Add(nyavgang26);
            nyavganger.Add(nyavgang27);
            nyavganger.Add(nyavgang28);
            nyavganger.Add(nyavgang29);
            nyavganger.Add(nyavgang30);
            nyavganger.Add(nyavgang31);
            nyavganger.Add(nyavgang32);
            nyavganger.Add(nyavgang33);
            nyavganger.Add(nyavgang34);
            nyavganger.Add(nyavgang35);
            nyavganger.Add(nyavgang34);
            nyavganger.Add(nyavgang37);
            nyavganger.Add(nyavgang38);
            nyavganger.Add(nyavgang39);
            nyavganger.Add(nyavgang40);
            nyavganger.Add(nyavgang41);
            nyavganger.Add(nyavgang42);
            nyavganger.Add(nyavgang43);
            nyavganger.Add(nyavgang44);
            nyavganger.Add(nyavgang45);
            nyavganger.Add(nyavgang46);
            nyavganger.Add(nyavgang47);
            nyavganger.Add(nyavgang48);
            nyavganger.Add(nyavgang49);
            nyavganger.Add(nyavgang50);
            nyavganger.Add(nyavgang51);
            nyavganger.Add(nyavgang52);
            nyavganger.Add(nyavgang53);
            nyavganger.Add(nyavgang54);
            nyavganger.Add(nyavgang55);
            nyavganger.Add(nyavgang56);
            nyavganger.Add(nyavgang57);
            nyavganger.Add(nyavgang58);
            nyavganger.Add(nyavgang59);
            nyavganger.Add(nyavgang60);
            nyavganger.Add(nyavgang61);
            nyavganger.Add(nyavgang62);
            nyavganger.Add(nyavgang63);
            nyavganger.Add(nyavgang64);
            nyavganger.Add(nyavgang65);
            nyavganger.Add(nyavgang66);

            var nystrekning = new List<Strekninger>();
            nystrekning.Add(nystrekning1);
            nystrekning.Add(nystrekning2);
            nystrekning.Add(nystrekning3);
            nystrekning.Add(nystrekning4);
            nystrekning.Add(nystrekning5);
            nystrekning.Add(nystrekning6);
            nystrekning.Add(nystrekning7);
            nystrekning.Add(nystrekning8);
            nystrekning.Add(nystrekning9);
            nystrekning.Add(nystrekning10);
            nystrekning.Add(nystrekning11);
            nystrekning.Add(nystrekning12);
            nystrekning.Add(nystrekning13);
            nystrekning.Add(nystrekning14);
            nystrekning.Add(nystrekning15);
            nystrekning.Add(nystrekning16);
            nystrekning.Add(nystrekning17);
            nystrekning.Add(nystrekning18);
            nystrekning.Add(nystrekning19);
            nystrekning.Add(nystrekning20);
            nystrekning.Add(nystrekning21);
            nystrekning.Add(nystrekning22);
            nystrekning.Add(nystrekning23);
            nystrekning.Add(nystrekning24);
            nystrekning.Add(nystrekning25);
            nystrekning.Add(nystrekning26);
            nystrekning.Add(nystrekning27);
            nystrekning.Add(nystrekning28);
            nystrekning.Add(nystrekning29);
            nystrekning.Add(nystrekning30);

            var nystasjon = new List<Togstasjoner>();
            nystasjon.Add(nystasjon1);
            nystasjon.Add(nystasjon2);
            nystasjon.Add(nystasjon3);
            nystasjon.Add(nystasjon4);
            nystasjon.Add(nystasjon5);
            nystasjon.Add(nystasjon6);
            nystasjon.Add(nystasjon7);
            nystasjon.Add(nystasjon8);
            nystasjon.Add(nystasjon9);
            nystasjon.Add(nystasjon10);

            var nyadmin = new List<Adminer>();
            nyadmin.Add(nyAdmin);
            context.Adminer.AddRange(nyadmin);
            context.Avganger.AddRange(nyavganger);
            context.Strekninger.AddRange(nystrekning);
            context.Togstasjoner.AddRange(nystasjon);
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