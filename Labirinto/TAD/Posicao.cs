using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirinto.TAD
{
    public class Posicao
    {
        public char tipo;
        public bool visitado;
        public int linhaPos;
        public int colunaPos;

        public Posicao(char tipoEntrada, int linhaPosEntrada, int colunaPosEntrada)
        {
            tipo = tipoEntrada;
            linhaPos = linhaPosEntrada;
            colunaPos = colunaPosEntrada;
        }
    }
}
