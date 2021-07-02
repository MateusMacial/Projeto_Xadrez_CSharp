using System;
using tabuleiro;
using xadrez;

namespace Projeto_Xadrez_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.turno);
                        Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoOrigem(origem);

                        //a partir da posicao de origin pegar a peça e virificar seu movimentos possiveis e guardar na amatriz
                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        //quando for imprimir o tabuleiro de novo vai ser com as posicoes possiveis em destaque
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDestino(origem, destino);

                        partida.realizaJogada(origem, destino);
                    }
                    catch(TabuleiroExeption e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                }

            }
            catch(TabuleiroExeption e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.ReadLine();

        }
    }
}
