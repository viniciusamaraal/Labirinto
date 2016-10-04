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

        public Posicao(char tipoEntrada)
        {
            tipo = tipoEntrada;
        }
    }
}
