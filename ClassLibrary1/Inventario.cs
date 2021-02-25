using System.Collections.Generic;

namespace ClassLibrary1
{
    public class Inventario
    {
        #region Attributi e costruttore
        private List<Bevanda> listaBevande = new List<Bevanda>();

        public List<Bevanda> ListaBevande { get => listaBevande; set => listaBevande = value; }
        public Inventario(List<Bevanda> listaBevande)
        {
            this.listaBevande = listaBevande;
        }

        public Inventario()
        {
        }
        #endregion


        #region Metodi
        /// <summary>
        /// Metodo che mostra l'elenco delle bevande disponibili
        /// </summary>
        public string ElencoBevande()
        {
            string elenco = "";
            for (int i = 0; i < listaBevande.Count; i++)
            {
                if (listaBevande[i].ControlloTot() == true)
                    elenco += "posizione " + i + " " + listaBevande[i].Nome + "\n";
            }
            return elenco;
        }

        /// <summary>
        /// Metodo che mi restituisce l'elenco delle bevande non disponibili
        /// </summary>
        public string ElencoBevandeTerminate()
        {
            string elenco = "";
            for (int i = 0; i < listaBevande.Count; i++)
            {
                if (listaBevande[i].ControlloTot() == false)
                    elenco += "posizione " + i + " " + listaBevande[i].Nome + "\n";
            }
            return elenco;
        }

        /// <summary>
        /// Metodo che ricarica la bevanda
        /// </summary>
        public string RicaricaBevanda(int scelta)
        {
            string bevanda = "";
            for (int i = 0; i < listaBevande.Count; i++)
            {
                if (scelta == i)
                {
                    listaBevande[i].RicaricaTot();
                    bevanda = "Bevanda " + listaBevande[i].Nome + " ricaricata!\n";
                }
            }
            return bevanda;
        }
        #endregion
    }
}
