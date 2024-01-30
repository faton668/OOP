using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{



    // Klasa baze per lenden OOP
    public abstract class LendaOOP
    {
        public abstract void MesazhiHyres();

        public abstract void Kyqu();

        public abstract void ShfaqDatOren();

        public abstract void VendosEmratMbiemrat();
    }

    // Klasa e trashëguar nga LendaOOP
    public class ListaDixhitale : LendaOOP
    {
        private bool eshteKyqur = false;
        private const string paswordiSakte = "UniversumBesart4774";
        private List<string> emratMbiemrat = new List<string>();

        public override void MesazhiHyres()
        {
            Console.WriteLine("Kjo eshte Lista Dixhitale per lenden OOP");
            Console.Write("A jeni ju profesori Besart Prebreza? (Po/Jo): ");
            string pergjigja = Console.ReadLine().ToLower();

            if (pergjigja == "po")
            {
                Kyqu();
            }
            else
            {
                Console.WriteLine("Ju nuk keni akses ne kete liste.");
            }
        }

        public override void Kyqu()
        {
            Console.Write("Sheno Paswordin per tu kyqur: ");
            string paswordi = Console.ReadLine();

            if (paswordi == paswordiSakte)
            {
                eshteKyqur = true;
                Console.WriteLine("Ju jeni kyqur me sukses!");
                ShfaqDatOren();
                VendosEmratMbiemrat();
            }
            else
            {
                Console.WriteLine("Paswordi gabim. Nuk lejohet asnje shenim tjeter te te dhenave.");
            }
        }

        public override void ShfaqDatOren()
        {
            if (eshteKyqur)
            {
                Console.WriteLine($"Data dhe Ora aktuale: {DateTime.Now}");
            }
            else
            {
                Console.WriteLine("Ju duhet te kyqeni per te shfaqur daten dhe oren.");
            }
        }

        public override void VendosEmratMbiemrat()
        {
            if (eshteKyqur)
            {
                Console.WriteLine("Vendos Emrat dhe Mbiemrat e studenteve (shtyp dy her Enter per te perfunduar):");

                int numri = 1;
                while (true)
                {
                    Console.Write($"{numri}. ");
                    string emriMbiemri = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(emriMbiemri))
                    {
                        Console.WriteLine("Keta studenta jane present!");
                        RuajNeFile(emratMbiemrat);
                        break;
                    }
                    else
                    {
                        emratMbiemrat.Add(emriMbiemri);
                        numri++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Ju duhet te kyqeni per te vendosur emrat dhe mbiemrat.");
            }
        }

        private void RuajNeFile(List<string> lista)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "emrat_mbiemrat.txt");

            try
            {
                File.WriteAllLines(filePath, lista);
                Console.WriteLine($"Te dhenat jane ruajtur ne {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gabim gjate ruajtjes ne file: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            ListaDixhitale lista = new ListaDixhitale();
            lista.MesazhiHyres();
        }
    }






}
