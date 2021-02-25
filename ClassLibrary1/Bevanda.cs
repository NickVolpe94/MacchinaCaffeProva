namespace ClassLibrary1
{
    public class Bevanda
    {
        #region Attributi e costruttore
        private int costo;
        private string nome;
        private bool zucchero; //Bevanda che vuole lo zucchero oppure no
        private int tot;    //Quantità

        public int Costo { get => costo; set => costo = value; }
        public string Nome { get => nome; set => nome = value; }
        public bool Zucchero { get => zucchero; set => zucchero = value; }
        public int Tot { get => tot; set => tot = value; }


        public Bevanda()
        {

        }

        public Bevanda(int costo, string nome, bool zucchero, int tot)
        {
            this.costo = costo;
            this.nome = nome;
            this.zucchero = zucchero;
            this.tot = tot;
        }
        #endregion

        #region Metodi
        /// <summary>
        /// Metodo che controlla se la quantità di bevanda è terminata
        /// </summary>
        public bool ControlloTot()
        {
            if (tot == 0) { return false; }
            else { return true; }
        }

        /// <summary>
        /// Metodo che ricarica la bevanda (30 unità)
        /// </summary>
        public void RicaricaTot()
        {
            tot = 30;
        }
        #endregion


    }
}
