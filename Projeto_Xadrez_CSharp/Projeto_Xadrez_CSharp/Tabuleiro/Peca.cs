namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qtdMovimentos = 0;
        }

        //Incrementa a quantidade de movimentos de uma peca
        public void incrementarQtdMovimentos()
        {
            qtdMovimentos++;
        }

        //Metodo abstrato para verificar movimentos possiveis da peca
        public abstract bool[,] movimentosPossiveis();
    }
}
