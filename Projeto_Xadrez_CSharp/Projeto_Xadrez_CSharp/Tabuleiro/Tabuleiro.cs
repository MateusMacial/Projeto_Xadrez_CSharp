namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        //Colocar uma peca no tabulerio dada uma linha e uma coluna
        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        //sobrecarga do metodo peca porem recebendo uma dada posicao
        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        //metodo para verificar se existe uma peca passando uma posicao como parametro
        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }

        //coloca uma peca p em uma posicao pos as mesmas sao passadas como parametro
        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroExeption("Já existe peça nessa posição!");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        //retira uma peca dada uma posicao
        public Peca retirarPeca(Posicao pos)
        {
            if(peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;
        }

        //verifica se uma dada posicao é valida
        public bool posicaoValida(Posicao pos)
        {
            if(pos.linha<0 || pos.linha>=linhas || pos.coluna<0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }

        //dá uma excecao caso a posicao não seja valida
        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroExeption("Posição inválida!");
            }
        }
    }
}
