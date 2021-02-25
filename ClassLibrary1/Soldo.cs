namespace ClassLibrary1
{
    public class Soldo
    {
        #region Attributi e costruttore
        private string nome;
        private int valore;
        private int qnt;
        private int resto;

      

        public Soldo(string nome, int valore, int qnt = 0, int resto = 0)
        {
            this.nome = nome;
            this.valore = valore;
            this.qnt = qnt;
            this.resto = resto;
        }

        public string Nome { get => nome; set => nome = value; }
        public int Valore { get => valore; set => valore = value; }
        public int Qnt { get => qnt; set => qnt = value; }
        public int Resto { get => resto; set => resto = value; }
        #endregion

    }
}
