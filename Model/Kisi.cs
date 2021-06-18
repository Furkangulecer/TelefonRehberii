using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberii.Model
{
    class Kisi
    {
        string baglan = "C:\\TelefonRehber\\Kisi.txt";

        public string Ad { get; set;}
        public string Soyad { get; set; }
        public string SirketUnvan { get; set; }
        public int Turu { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Web { get; set; }
        public string Adres { get; set; }
        public int Id { get; set; }

        public void Insert( Kisi Model)
        {
            StreamWriter sw = File.AppendText(baglan);

            int Id = IdCagır();
            Model.Id = Id;


            sw.WriteLine(

                Model.Ad + "$" +
                Model.Soyad + "$" +
                Model.SirketUnvan + "$" +
                Model.Turu + "$" +
                Model.Tel1 + "$" +
                Model.Tel2 + "$" +
                Model.Fax + "$" +
                Model.Email + "$" +
                Model.KayitTarihi + "$" +
                Model.Web + "$" +
                Model.Adres + "$" +
                Model.Id

                );
            sw.Close();
            sw.Dispose();

        }

        public List<Kisi> Get()
        {
            List<Kisi> liste = new List<Kisi>();

            StreamReader sr = new StreamReader(baglan);
            string oku = sr.ReadLine();

            while (oku!=null)
            {
                string[] parcala = oku.Split('$');

                Kisi model = new Kisi();
                  

                model.Ad= parcala[0];
                model.Soyad =parcala[1];
                model.SirketUnvan = parcala[2];
                model.Turu = Convert.ToInt32(parcala[3]);
                model.Tel1 = parcala[4];
                model.Tel2 = parcala[5];
                model.Fax = parcala[6];
                model.Email = parcala[7];
                model.KayitTarihi = Convert.ToDateTime(parcala[8]);
                model.Web = parcala[9];
                model.Adres = parcala[10];
                model.Id = Convert.ToInt32(parcala[11]);

                liste.Add(model);
                oku = sr.ReadLine();

            }

            sr.Close();
            sr.Dispose();
            return liste;
        }

       public int IdCagır()
        {

            StreamReader sr = new StreamReader("C:\\TelefonRehber\\KisiId.txt");
            string oku = sr.ReadLine();

            if (oku!=null)
            {
                sr.Close();
                sr.Dispose();

                try
                {
                    int _Id = Convert.ToInt32(oku);
                    _Id++;
                    StreamWriter sw = File.CreateText("C:\\TelefonRehber\\KisiId.txt");
                    sw.Write(_Id.ToString());

                    sw.Close();
                    sw.Dispose();

                    return _Id;

                }
                catch (Exception)
                {
                    StreamWriter sw = File.CreateText("C:\\TelefonRehber\\KisiId.txt");
                    sw.Write("1");

                    sw.Close();
                    sw.Dispose();

                    return 1;
                }

            }
            else
            {
                sr.Close();
                sr.Dispose();

                StreamWriter sw = File.CreateText("C:\\TelefonRehber\\KisiId.txt");
                sw.Write("1");

                sw.Close();
                sw.Dispose();

                return 1;
            }


            return 1;
        }
        


    }



}
