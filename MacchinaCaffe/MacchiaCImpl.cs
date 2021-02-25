using ClassLibrary1;
using System;
using System.Collections.Generic;

namespace MacchinaCaffe
{
    public class MacchiaCImpl : IMacchinaC
    {
        #region Attributi e costruttori
        private int credito;
        private int zucchero;
        private List<Soldo> monete = new List<Soldo>();
        private Inventario inventario = new Inventario();

        public int Credito { get => credito; set => credito = value; }
        public int Zucchero { get => zucchero; set => zucchero = value; }
        internal Inventario Inventario { get => inventario; set => inventario = value; }
        internal List<Soldo> Monete { get => monete; set => monete = value; }

        public MacchiaCImpl(int credito, int zucchero, Inventario inventario, List<Soldo> monete)
        {
            this.credito = credito;
            this.zucchero = zucchero;
            Inventario = inventario;
            this.monete = monete;
        }

        public MacchiaCImpl()
        {
            Inizialize();
        }
        #endregion

        #region Metodi
        /// <summary>
        /// Metodo che da uno stato iniziale alla macchinetta con prodotti e monete
        /// </summary>
        public void Inizialize()
        {
            Bevanda espresso = new Bevanda(30, "Espresso", true, 1);
            Bevanda cappuccino = new Bevanda(40, "Cappuccino", true, 1);
            Bevanda tea = new Bevanda(50, "Te'", false, 1);
            Soldo cinque = new Soldo("Cinque", 5, 50, 0);
            Soldo dieci = new Soldo("Dieci", 10, 30, 0);
            Soldo venti = new Soldo("Venti", 20, 20, 0);
            Soldo cinquanta = new Soldo("Cinquanta", 50, 10, 0);
            Soldo cento = new Soldo("Cento", 100, 5, 0);
            Soldo duecento = new Soldo("Duecento", 200, 5, 0);
            Monete.Add(cinque);
            Monete.Add(dieci);
            Monete.Add(venti);
            Monete.Add(cinquanta);
            Monete.Add(cento);
            Monete.Add(duecento);
            credito = 0;
            zucchero = 1;
            Inventario.ListaBevande.Add(espresso);
            Inventario.ListaBevande.Add(cappuccino);
            Inventario.ListaBevande.Add(tea);
        }

        /// <summary>
        /// Metodo che controlla se è ancora disponibile lo zucchero nella macchinetta
        /// </summary>
        public bool ControlloZucchero()
        {
            if (zucchero <= 0) { return false; }
            else { return true; }
        }

        /// <summary>
        /// Metodo che ricarica lo zucchero nella macchinetta (100 unità)
        /// </summary>
        public void RicaricaZucchero()
        {
            zucchero = 100;
        }


        /// <summary>
        /// Metodo che eroga la bevanda scelta dall'utente
        /// </summary>
        public string ErogaBevanda(int scelta)
        {
            for (int i = 0; i < Inventario.ListaBevande.Count; i++)
            {
                if (i == scelta)
                {
                    if (Inventario.ListaBevande[i].Zucchero == true)
                    {
                        if (ControlloZucchero() == true)
                        {
                            Console.WriteLine("Quanto zucchero desideri? (tra 0 e 4)\n");
                            int z = Convert.ToInt32(Console.ReadLine());
                            UsaZucchero(z);
                        }
                    }
                    Inventario.ListaBevande[i].Tot--;
                    return "Erogazione " + Inventario.ListaBevande[i].Nome + "\n";
                }
            }
            return null;
        }


        /// <summary>
        /// Metodo che utilizza lo zucchero scelto dall'utente
        /// </summary>
        public void UsaZucchero(int n)
        {
            zucchero -= n;
        }

        /// <summary>
        /// Metodo che controlla il prezzo del prodotto
        /// </summary>
        public int ControlloPrezzo(int scelta)
        {
            for (int i = 0; i < Inventario.ListaBevande.Count; i++)
            {
                if (i == scelta)
                {
                    return Inventario.ListaBevande[i].Costo;
                }
            }
            return -1;
        }

        /// <summary>
        /// Metodo che visualizza la lista delle monete accettate
        /// </summary>
        public string ListaMonete()
        {
            string stringa = "";
            for (int i = 0; i < Monete.Count; i++)
            {
                stringa += "Inserisci " + i + " per " + Monete[i].Nome + "\n";
            }
            return stringa;
        }

        /// <summary>
        /// Metodo che restituisce il valore della moneta
        /// </summary>
        public int ControlloValore(int scelta)
        {
            for (int i = 0; i < Monete.Count; i++)
            {
                if (i == scelta)
                {
                    return Monete[i].Valore;
                }
            }
            return -1;
        }

        /// <summary>
        /// Metodo che aggiunge la moneta alla macchinetta
        /// </summary>
        public void InserisciMoneta(int moneta)
        {
            for (int i = 0; i < Monete.Count; i++)
            {
                if (i == moneta)
                {
                    Monete[i].Qnt++;
                }
            }
        }

        /// <summary>
        /// Metodo che calcola resto
        /// </summary>
        /// <param name="resto">Il resto</param>
        /// <returns>Resto calcolato</returns>
        public string CalcolaResto(int resto)
        {
            if (resto == 0)
            {
                return null;
            }
            string stringa = "Il resto e' di:  ";
            CalcolaMonete(resto);
            for (int i = 0; i < Monete.Count; i++)
            {
                if (Monete[i].Resto > 0)
                {
                    stringa += "" + Monete[i].Resto + " di " + Monete[i].Nome + "\n";
                }
            }
            for (int i = 0; i < Monete.Count; i++)
            {
                if (Monete[i].Resto > 0)
                {
                    Monete[i].Resto = 0;
                }
            }
            credito = 0;
            return stringa;

        }

        /// <summary>
        /// Metodo che distingue quali monete utilizzare per scalare il totale del resto
        /// </summary>
        public void CalcolaMonete(int resto)
        {
            if (resto != 0)
            {
                for (int i = 0; i < Monete.Count; i++)
                {

                    if (Monete[i].Valore == resto)
                    {
                        if (Monete[i].Qnt > 0)
                        {
                            Monete[i].Qnt--;
                            Monete[i].Resto++;
                            CalcolaMonete(resto - Monete[i].Valore);
                            break;
                        }
                    }
                    if (Monete[i].Valore > resto)
                    {
                        if (Monete[i].Qnt > 0)
                        {
                            Monete[i - 1].Qnt--;
                            Monete[i - 1].Resto++;
                            CalcolaMonete(resto - Monete[i - 1].Valore);
                            break;
                        }
                    }

                }
            }
        }
        #endregion

    }
}
