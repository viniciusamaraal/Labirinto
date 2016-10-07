using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Labirinto.TAD
{
    public class Labirinto
    {
        Posicao[,] Mapa;
        CPilha Caminho;
        int xPosAtual;
        int yPosAtual;
        int qtdPremios;

        public Labirinto(int nLinhas, int nColunas)
        {
            Mapa = new Posicao[nLinhas, nColunas];
            Caminho = new CPilha();
        }

        public void IncluirPosicao(int xPos, int yPos, char tipoCampo)
        {
            Mapa[xPos, yPos] = new Posicao(tipoCampo, xPos, yPos);

            if (tipoCampo == 'o')
            {
                Caminho.Empilha(Mapa[xPos, yPos]);
                xPosAtual = xPos;
                yPosAtual = yPos;
            }
        }

        private Posicao BuscarPosicao(int xPos, int yPos)
        {
            return Mapa[xPos, yPos];
        }

        private bool PodeMover(int xPos, int yPos)
        {
            // Se a posição nunca foi visitada e se trata de um espaço vazio ou espaço com prêmio, pode-se mover o robô para essa posição
            return !Mapa[xPos, yPos].visitado && (Mapa[yPos, xPos].tipo == ' ' || Mapa[yPos, xPos].tipo == 'p'); 
        }

        public void PercorrerMapa()
        {
            bool novoMovimento = false;

            while (!Caminho.Vazia())
            {
                ImprimirMovimento(' ');

                if (PodeMover(xPosAtual - 1, yPosAtual)) // Pode mover para a esquerda?
                {
                    xPosAtual--; // Redefine a posição atual
                    Mapa[xPosAtual, yPosAtual].visitado = true; // Registra que o campo foi visitado 
                    Caminho.Empilha(Mapa[xPosAtual, yPosAtual]); // Empilha a nova posição encontrada
                    novoMovimento = true; // Identifica que tratou-se de um novo movimento e não de um recuo (desempilhamento)
                }
                else if (PodeMover(xPosAtual, yPosAtual - 1)) // Se não pode mover para a esquerda, pode mover para a cima?
                {
                    yPosAtual--; // Redefine a posição atual
                    Mapa[xPosAtual, yPosAtual].visitado = true; // Registra que o campo foi visitado
                    Caminho.Empilha(Mapa[xPosAtual, yPosAtual]); // Empilha a nova posição encontrada
                    novoMovimento = true; // Identifica que tratou-se de um novo movimento e não de um recuo (desempilhamento)
                }
                else if (PodeMover(xPosAtual + 1, yPosAtual)) // Se não pode mover para cima, pode mover para a direita?
                {
                    xPosAtual++; // Redefine a posição atual
                    Mapa[xPosAtual, yPosAtual].visitado = true; // Registra que o campo foi visitado
                    Caminho.Empilha(Mapa[xPosAtual, yPosAtual]); // Empilha a nova posição encontrada
                    novoMovimento = true; // Identifica que tratou-se de um novo movimento e não de um recuo (desempilhamento)
                }
                else if (PodeMover(xPosAtual, yPosAtual + 1)) // Se não pode mover para a direita, pode mover para baixo?
                {
                    yPosAtual++; // Redefine a posição atual
                    Mapa[xPosAtual, yPosAtual].visitado = true; // Registra que o campo foi visitado
                    Caminho.Empilha(Mapa[xPosAtual, yPosAtual]); // Empilha a nova posição encontrada
                    novoMovimento = true; // Identifica que tratou-se de um novo movimento e não de um recuo (desempilhamento)
                }
                else // Se não pode mover para lugar algum, volta para a posicao anterior
                {
                    Caminho.Desempilha();

                    if (!Caminho.Vazia())
                    {
                        Posicao topo = (Posicao)Caminho.Peek();
                        xPosAtual = topo.xPos;
                        yPosAtual = topo.yPos;
                    }
                }

                // Se a posição nunca havia sido visitada e nela foi encontrado um prêmio incrementa-se a quantidade de prêmios
                if (novoMovimento && Mapa[xPosAtual, yPosAtual].tipo == 'p') 
                    qtdPremios++;

                ImprimirMovimento('o'); // Imprime o "robô" na nova posição encontrada

                novoMovimento = false; // Reseta o indicador de novo movimento
                Thread.Sleep(250); // Faz o programa esperar por x milisegundos antes de definir o próximo movimento (apenas para dar tempo de ver os movimentos sendo executados)
            }

            Console.WriteLine("\n\n\nVisitei todos os espaços possíveis, capturei " + qtdPremios + " prêmios e retornei ao ponto de partida! =)");
        }

        public void ImprimirMapa()
        {
            for (int i = 0; i<Mapa.GetLength(0); i++)
            {
                for (int j = 0; j<Mapa.GetLength(1); j++)
                    Console.Write(Mapa[i, j].tipo);
        
                Console.WriteLine();
            }
        }

        private void ImprimirMovimento(char caracter)
        {
            Console.SetCursorPosition(xPosAtual, yPosAtual); // Define a posição do cursor na tela onde o caracter será impresso
            Console.Write(caracter);
        }
    }
}
