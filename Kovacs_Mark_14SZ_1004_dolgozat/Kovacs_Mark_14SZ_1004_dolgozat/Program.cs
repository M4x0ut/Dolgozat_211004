using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kovacs_Mark_14SZ_1004_dolgozat
{
    enum marka
    {
        Benz,
        Ferrari,
        Suzuki,
        Ford,
        Jaguar,
    }
    class auto {
        public float atlagfogyasztas;
        public int tankm;
        public float aktualisbenzin;
        public marka Marka { get; set; }
        public bool matrica;
        public string rendszam;
    }


    class Program
    {
        
        static List<auto> Autok = new List<auto>();
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            
            Autotoltes();
            foprogram();
            Console.ReadKey();
        }

        private static void foprogram()
        {
            int[] markatobbseg = {0, 0, 0, 0, 0};
            Console.WriteLine("-------------------------------------");
            auto legtobb=Autok[0];
            foreach (var vizsgalt in Autok)
            {
                if ((vizsgalt.aktualisbenzin / vizsgalt.atlagfogyasztas) >(legtobb.aktualisbenzin / legtobb.atlagfogyasztas))
                {
                    legtobb = vizsgalt;
                }
                if (vizsgalt.matrica==true)
                {
                    if (Convert.ToString(vizsgalt.Marka)=="Benz")
                    {
                        markatobbseg[0]++;
                    }
                    if (Convert.ToString(vizsgalt.Marka) == "Ferrari")
                    {
                        markatobbseg[1]++;
                    }
                    if (Convert.ToString(vizsgalt.Marka) == "Suzuki")
                    {
                        markatobbseg[2]++;
                    }
                    if (Convert.ToString(vizsgalt.Marka) == "Ford")
                    {
                        markatobbseg[3]++;
                    }
                    if (Convert.ToString(vizsgalt.Marka) == "Jaguar")
                    {
                        markatobbseg[4]++;
                    }

                }
            }
            Console.WriteLine("A kocsi ami a legtöbb km-t tudja még megtenni "+ legtobb.aktualisbenzin / legtobb.atlagfogyasztas + "Km számmal: ");
            Console.WriteLine("Márka: " + legtobb.Marka + " |Tankméret: " + legtobb.tankm + " |Aktuális Benzin: " + legtobb.aktualisbenzin + " |Átlagfogyasztás: " + legtobb.atlagfogyasztas + " |Matrica: " + legtobb.matrica + " |Rendszám: " + legtobb.rendszam);
            Console.WriteLine("--------------------------------------------------");
            int tobbseg=0;
            int lada = 0;
            string matricaskocs="";
            for (int i = 0; i < markatobbseg.Length; i++)
            {
                if (markatobbseg[i]>tobbseg)
                {
                    tobbseg = markatobbseg[i];
                    lada = i;
                }
            }
            switch (lada)
            {
                case 0:
                    matricaskocs = "Benz";
                    break;
                case 1:
                    matricaskocs = "Ferrari";
                    break;
                case 2:
                    matricaskocs = "Suzuki";
                    break;
                case 3:
                    matricaskocs = "Ford";
                    break;
                case 4:
                    matricaskocs = "Jaguar";
                    break;
                default:
                    break;
            }
            Console.WriteLine("A legtöbb matricával rendelkező márkás kocsik: "+matricaskocs+" "+tobbseg);
            
        }

        private static void Autotoltes()
        {
            var betuk = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < 30; i++)
            {
                Autok.Add(new auto()
                {
                    atlagfogyasztas = rnd.Next(3, 20),
                    tankm = rnd.Next(20, 100),
                    Marka = (marka)rnd.Next(Enum.GetNames(typeof(marka)).Length),
                    rendszam = "" + betuk[rnd.Next(0, betuk.Length)]+ "" + betuk[rnd.Next(0, betuk.Length)]+ "" + betuk[rnd.Next(0, betuk.Length)]+"-"+rnd.Next(1,999),
                }) ;
            }
            foreach (var vizsgalt in Autok)
            {
                vizsgalt.aktualisbenzin = rnd.Next(0,vizsgalt.tankm);
                if (rnd.Next(0,2)==1)
                {
                    vizsgalt.matrica = true;
                }
                else
                {
                    vizsgalt.matrica = false;
                }

                Console.WriteLine("Márka: "+vizsgalt.Marka+ " |Tankméret: " + vizsgalt.tankm+ " |Aktuális Benzin: " + vizsgalt.aktualisbenzin + " |Átlagfogyasztás: " + vizsgalt.atlagfogyasztas + " |Matrica: " + vizsgalt.matrica+ " |Rendszám: " + vizsgalt.rendszam);

            }


        }
    }
}
