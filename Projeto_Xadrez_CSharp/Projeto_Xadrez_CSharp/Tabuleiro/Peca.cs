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

        //Decrementa a quantidade de movimentos de uma peca
        public void decrementarQtdMovimentos()
        {
            qtdMovimentos--;
        }

        //verifica se a posicao tem pelo menos 1 movimento possivel
        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for(int i=0; i<tab.linhas; i++)
            {
                for(int j=0; j<tab.colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //verifica de uma dada posição pode receber uma peça
        public bool podeMoverPara(Posicao pos)
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }

        //Metodo abstrato para verificar movimentos possiveis da peca
        public abstract bool[,] movimentosPossiveis();
    }
}
