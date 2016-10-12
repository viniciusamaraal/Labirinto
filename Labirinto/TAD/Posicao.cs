using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirinto.TAD
{
    public class Posicao
    {
        public char tipo { get; set; }
        public bool visitado { get; set; }
        public int linhaPos { get; set; }
        public int colunaPos { get; set; }

        public Posicao(char tipoEntrada, int linhaPos, int colunaPos)
        {
            this.tipo = tipoEntrada;
            this.linhaPos = linhaPos;
            this.colunaPos = colunaPos;
        }
    }
}
