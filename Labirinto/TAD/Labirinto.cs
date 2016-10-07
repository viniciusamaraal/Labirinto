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
        Posicao[,] Mapa { get; set; }
        CPilha Caminho;
        int xPosAtual;
        int yPosAtual;
        int xPosAnterior; // TODO: repensar essa bagaça
        int yPosAnterior; // TODO: repensar essa bagaça
        int qtdPremios;

        public Labirinto(int nLinhas, int nColunas)
        {
            Mapa = new Posicao[nLinhas, nColunas];
            Caminho = new CPilha();
        }

        public void IncluirPosicao(int xPos, int yPos, char tipoCampo)
        {
            Mapa[xPos, yPos] = new Posicao(tipoCampo);

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
            return !Mapa[xPos, yPos].visitado && (Mapa[xPos, yPos].tipo == ' ' || Mapa[xPos, yPos].tipo == 'p'); 
        }

        public void PercorrerMapa()
        {
            bool novoMovimento = false;

            while (!Caminho.Vazia())
            {
                ImprimirMovimento(' ');

                if (PodeMover(xPosAtual - 1, yPosAtual)) // Pode mover para a esquerda?
                {
                    xPosAnterior = xPosAtual;
                    xPosAtual = xPosAtual - 1; // Redefine a posição atual
                    Caminho.Empilha(Mapa[xPosAtual, yPosAtual]); // Empilha a nova posição encontrada
                    novoMovimento = true;
                }
                else if (PodeMover(xPosAtual, yPosAtual + 1)) // Se não pode mover para a esquerda, pode mover para a cima?
                {
                    yPosAnterior = yPosAtual;
                    yPosAtual = yPosAtual + 1; // Redefine a posição atual
                    Caminho.Empilha(Mapa[xPosAtual, yPosAtual]); // Empilha a nova posição encontrada
                    novoMovimento = true;
                }
                else if (PodeMover(xPosAtual + 1, yPosAtual)) // Se não pode mover para cima, pode mover para a direita?
                {
                    xPosAnterior = xPosAtual;
                    xPosAtual = xPosAtual + 1; // Redefine a posição atual
                    Caminho.Empilha(Mapa[xPosAtual, yPosAtual]); // Empilha a nova posição encontrada
                    novoMovimento = true;
                }
                else if (PodeMover(xPosAtual, yPosAtual - 1)) // Se não pode mover para a direita, pode mover para baixo?
                {
                    yPosAnterior = yPosAtual;
                    yPosAtual = yPosAtual - 1; // Redefine a posição atual
                    Caminho.Empilha(Mapa[xPosAtual, yPosAtual]); // Empilha a nova posição encontrada
                    novoMovimento = true;
                }
                else // Se não pode mover para lugar algum, volta para a posicao anterior
                {
                    // TODO: pensar como voltar para as coordenadas da posição anterior

                    Caminho.Desempilha();
                }

                // Se a posição nunca havia sido visitada e nela foi encontrado um prêmio incrementa-se a quantidade de prêmios
                if (novoMovimento && Mapa[xPosAtual, yPosAtual].tipo == 'p') 
                    qtdPremios++;

                ImprimirMovimento('o'); // Imprime o "robô" na nova posição encontrada

                novoMovimento = false; // Reseta o indicador de novo movimento
                Thread.Sleep(1000); // Faz o programa esperar por um segundo para andar novamente (para dar tempo de ver os movimentos sendo executados)
            }
        }

        private void ImprimirMovimento(char caracter)
        {
            Console.SetCursorPosition(xPosAtual, yPosAtual); // Define a posição do cursor na tela onde o caracter será impresso
            Console.Write(caracter);
        }
    }
}
