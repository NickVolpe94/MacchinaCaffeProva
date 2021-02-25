using System;


namespace MacchinaCaffe
{
    public class Program
    {
        static void Main(string[] args)
        {
            MacchiaCImpl lavazza = new MacchiaCImpl();
            while (true)
            {
                try
                {
                    Console.WriteLine("Buongiorno, premere 1 per interfaccia macchinetta, 2 per interfaccia tecnico, 3 per uscire \n");
                    int scelta = Convert.ToInt32(Console.ReadLine());
                    bool p = true;
                    if (scelta == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("|||  INTERFACCIA UTENTE  |||");
                        while (p)
                        {
                            Console.WriteLine("Premere 1 per ordinare, 2 uscire \n");
                            if (lavazza.ControlloZucchero() == false)
                            {
                                Console.WriteLine("Lo zucchero e' terminato\n");
                            }
                            int scelta2 = Convert.ToInt32(Console.ReadLine());
                            switch (scelta2)
                            {
                                case 1:
                                    if (lavazza.Inventario.ElencoBevande() != "")
                                    {
                                        Console.Clear();
                                        Console.WriteLine(lavazza.Inventario.ElencoBevande());
                                        Console.WriteLine("Indicare il numero della bevanda desiderata:\n");
                                        int scelta3 = Convert.ToInt32(Console.ReadLine());
                                        do
                                        {
                                            Console.WriteLine("Devi inserire almeno " + lavazza.ControlloPrezzo(scelta3) + " euro\n");
                                            Console.WriteLine(lavazza.ListaMonete());
                                            int scelta4 = Convert.ToInt32(Console.ReadLine());
                                            Console.Clear();
                                            lavazza.InserisciMoneta(scelta4);
                                            lavazza.Credito += lavazza.ControlloValore(scelta4);
                                            Console.WriteLine("Credito residuo " + lavazza.Credito + "\n");
                                        } while (lavazza.Credito < lavazza.ControlloPrezzo(scelta3));
                                        Console.Clear();
                                        Console.WriteLine(lavazza.ErogaBevanda(scelta3));
                                        Console.WriteLine(lavazza.CalcolaResto(lavazza.Credito - lavazza.ControlloPrezzo(scelta3)));
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Le bevande sono terminate!");
                                    }
                                    break;                           
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Arrivederci!\n");
                                    p = false;
                                    break;
                            }
                        }
                    }
                    if (scelta == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("|||  INTERFACCIA TECNICO  |||");
                        while (p)
                        {
                            Console.WriteLine("Premere 1 per ricaricare lo zucchero, 2 Ricaricare una bevanda terminata, 3 uscire\n");
                            int scelta2 = Convert.ToInt32(Console.ReadLine());
                            switch (scelta2)
                            {
                                case 1:
                                    Console.Clear();
                                    lavazza.RicaricaZucchero();
                                    Console.WriteLine("Zucchero ricaricato!\n");
                                    break;
                                case 2:
                                    Console.Clear();
                                    if (lavazza.Inventario.ElencoBevandeTerminate() != "")
                                    {
                                        Console.WriteLine(lavazza.Inventario.ElencoBevandeTerminate() + "\n");
                                        Console.WriteLine("Quale bevanda vuoi ricaricare? Inserisci il numero\n");
                                        int scelta3 = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine(lavazza.Inventario.RicaricaBevanda(scelta3));
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Nessuna bevanda è terminata");
                                    }
                                    break;
                                case 3:
                                    Console.Clear();
                                    p = false;
                                    break;
                            }
                        }
                    }
                    if (scelta == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Arrivederci");
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Inserisci un numero!");
                }
            }

        }
    }
}
