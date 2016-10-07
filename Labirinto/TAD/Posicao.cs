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
        public int xPos { get; set; }
        public int yPos { get; set; }

        public Posicao(char tipoEntrada, int xPos, int yPos)
        {
            this.tipo = tipoEntrada;
            this.xPos = xPos;
            this.yPos = yPos;
        }
    }
}
