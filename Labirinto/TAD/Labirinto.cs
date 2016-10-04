using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirinto.TAD
{
    public class Labirinto
    {
        Posicao[,] Mapa { get; set; }

        public Labirinto(int nLinhas, int nColunas)
        {
            Mapa = new Posicao[nLinhas, nColunas];
        }

        public void IncluirPosicao(int x, int y, char tipoCampo)
        {
            Mapa[x, y] = new Posicao(tipoCampo);
        }

        public void ImprimirMapa()
        {
            for (int i = 0; i < Mapa.GetLength(0); i++)
            {
                for (int j = 0; j < Mapa.GetLength(1); j++)
                    Console.Write(Mapa[i, j].tipo);

                Console.WriteLine();
            }
        }
    }
}
