using Labirinto.TAD;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirinto
{
    class Program
    {
        static void Main(string[] args)
        {
            string nomePrograma;
            string[] tamanhoMatriz;
            string linha;
            int nLinhaMapa = 0;
            int qtdPremios = 0;
            int nLinha = 0, nColuna = 0;

            TAD.Labirinto labirinto;

            // Fluxo de leitura do arquivo .dat que representa o labirinto
            using (StreamReader leituraArquivo = new StreamReader("labirinto.dat"))
            {
                // Por definição, a primeira linha é uma string
                nomePrograma = leituraArquivo.ReadLine();

                // Definido o tamanho da matriz dinamicamente de acordo com a segunda linha do arquivo
                tamanhoMatriz = leituraArquivo.ReadLine().Split(' ');
                labirinto = new TAD.Labirinto(int.Parse(tamanhoMatriz[0]), int.Parse(tamanhoMatriz[1]));

                // Pra cada linha encontrada no arquivo (a partir da terceira), percorre a string definindo uma nova posição da matriz (cada caracter será uma coluna da respectiva linha)
                linha = leituraArquivo.ReadLine();
                while(!String.IsNullOrEmpty(linha))
                {
                    for (int i = 0; i < linha.Length; i++)
                    {
                        labirinto.IncluirPosicao(nLinhaMapa, i, linha[i]); // nLinhaMapa: eixo x da matriz; i: eixo y da matriz; linha[i]: caracter lido que representará o tipo do campo (buraco, espaço livre ou prêmio) para as coordenadas definidas

                        if (linha[i] == 'o')
                        {
                            nLinha = nLinhaMapa;
                            nColuna = i;
                        }
                    }

                    nLinhaMapa++; // Incrementa o número de linhas da matriz para que uma nova linha do arquivo seja lida
                    linha = leituraArquivo.ReadLine(); // Lê a próxima linha do arquivo
                }
            }

            labirinto.ImprimirMapa();
            labirinto.PercorrerMapa();

            Console.WriteLine("Pressione qualquer tecla para finalizar...");
            Console.ReadKey();
        }
    }
}