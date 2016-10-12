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
        int colunaAtual;
        int linhaAtual;
        int qtdPremios;

        public Labirinto(int nLinhas, int nColunas)
        {
            Mapa = new Posicao[nLinhas, nColunas];
            Caminho = new CPilha();
        }

        public void IncluirPosicao(int linha, int coluna, char tipoCampo)
        {
            Mapa[linha, coluna] = new Posicao(tipoCampo, linha, coluna);

            if (tipoCampo == 'o')
            {
                Caminho.Empilha(Mapa[linha, coluna]);
                linhaAtual = linha;
                colunaAtual = coluna;
            }
        }

        private Posicao BuscarPosicao(int linha, int coluna)
        {
            return Mapa[linha, coluna];
        }

        private bool PodeMover(int linha, int coluna)
        {
            // Se a posição nunca foi visitada e se trata de um espaço vazio ou espaço com prêmio, pode-se mover o robô para essa posição
            return !Mapa[linha, coluna].visitado && (Mapa[linha, coluna].tipo == ' ' || Mapa[linha, coluna].tipo == 'p'); 
        }

        public void PercorrerMapa()
        {
            bool novoMovimento = false;

            while (!Caminho.Vazia())
            {
                ImprimirMovimento(' ');

                if (PodeMover(linhaAtual - 1, colunaAtual)) // Pode mover para cima?
                {
                    linhaAtual--; // Redefine a posição atual
                    Mapa[linhaAtual, colunaAtual].visitado = true; // Registra que o campo foi visitado 
                    Caminho.Empilha(Mapa[linhaAtual, colunaAtual]); // Empilha a nova posição encontrada
                    novoMovimento = true; // Identifica que tratou-se de um novo movimento e não de um recuo (desempilhamento)
                }
                else if (PodeMover(linhaAtual, colunaAtual - 1)) // Se não pode mover para a cima, pode mover para a esquerda?
                {
                    colunaAtual--; // Redefine a posição atual
                    Mapa[linhaAtual, colunaAtual].visitado = true; // Registra que o campo foi visitado
                    Caminho.Empilha(Mapa[linhaAtual, colunaAtual]); // Empilha a nova posição encontrada
                    novoMovimento = true; // Identifica que tratou-se de um novo movimento e não de um recuo (desempilhamento)
                }
                else if (PodeMover(linhaAtual + 1, colunaAtual)) // Se não pode mover para esquerda, pode mover para baixo?
                {
                    linhaAtual++; // Redefine a posição atual
                    Mapa[linhaAtual, colunaAtual].visitado = true; // Registra que o campo foi visitado
                    Caminho.Empilha(Mapa[linhaAtual, colunaAtual]); // Empilha a nova posição encontrada
                    novoMovimento = true; // Identifica que tratou-se de um novo movimento e não de um recuo (desempilhamento)
                }
                else if (PodeMover(linhaAtual, colunaAtual + 1)) // Se não pode mover para a baixo, pode mover para direita?
                {
                    colunaAtual++; // Redefine a posição atual
                    Mapa[linhaAtual, colunaAtual].visitado = true; // Registra que o campo foi visitado
                    Caminho.Empilha(Mapa[linhaAtual, colunaAtual]); // Empilha a nova posição encontrada
                    novoMovimento = true; // Identifica que tratou-se de um novo movimento e não de um recuo (desempilhamento)
                }
                else // Se não pode mover para lugar algum, volta para a posicao anterior
                {
                    Caminho.Desempilha();

                    if (!Caminho.Vazia())
                    {
                        Posicao topo = (Posicao)Caminho.Peek();
                        linhaAtual = topo.linhaPos;
                        colunaAtual = topo.colunaPos;
                    }
                }

                // Se a posição nunca havia sido visitada e nela foi encontrado um prêmio incrementa-se a quantidade de prêmios
                if (novoMovimento && Mapa[linhaAtual, colunaAtual].tipo == 'p') 
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
            Console.SetCursorPosition(colunaAtual, linhaAtual); // Define a posição do cursor na tela onde o caracter será impresso
            Console.Write(caracter);
        }
    }
}
