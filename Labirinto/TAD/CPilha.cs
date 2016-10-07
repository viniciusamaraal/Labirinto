using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirinto.TAD
{
    /// <summary>
    /// Classe que representa uma Pilha (ou lista LIFO: last-in first-out)
    /// </summary>
    class CPilha
    {
        class CCelula
        {

            public Object item;
            public CCelula prox;

            public CCelula(object valorItem)
                : this(valorItem, null)
            {
            }

            public CCelula(object valorItem, CCelula proxCelula)
            {
                item = valorItem;
                prox = proxCelula;
            }
        }

        private CCelula topo = null;
        private int Qtde = 0;

        /// <summary>
        /// Função construtora.
        /// </summary>
        public CPilha()
        {
            // nenhum código
        }

        /// <summary>
        /// Verifica se a Pilha está vazia.
        /// </summary>
        /// <returns>Retorna TRUE se a PILHA estiver vazia e FALSE caso contrário.</returns>
        public bool Vazia()
        {
            return topo == null;
        }

        /// <summary>
        /// Insere o novo item no topo da Pilha
        /// </summary>
        /// <param name="valorItem">Um Object contendo o item a ser inserido no topo da Pilha.</param>
        public void Empilha(Object valorItem)
        {
            CCelula aux = topo;
            topo = new CCelula(valorItem);
            topo.prox = aux;
            Qtde++;
        }

        /// <summary>
        /// Retira e retorna o item do topo da Pilha.
        /// </summary>
        /// <returns>Um Object contendo o item retirado do topo da Pilha. Caso a Pilha esteja vazia retorna null.</returns>
        public Object Desempilha()
        {
            Object item = null;
            if (topo != null)
            {
                item = topo.item;
                topo = topo.prox;
                Qtde--;
            }
            return item;
        }

        /// <summary>
        /// Verifica se o item passado como parâmetro está contido na lista.
        /// </summary>
        /// <param name="elemento">Um object contendo o item a ser localiado.</param>
        /// <returns>Retorna TRUE caso o item esteja presente na lista.</returns>
        public bool Contem(Object elemento)
        {
            bool achou = false;
            CCelula aux = topo;
            while (aux != null && !achou)
            {
                achou = aux.item.Equals(elemento);
                aux = aux.prox;
            }
            return achou;
        }

        /// <summary>
        /// Verifica se o item passado como parâmetro está contido na lista. (Obs: usa o comando FOR)
        /// </summary>
        /// <param name="elemento">Um object contendo o item a ser localiado.</param>
        /// <returns>Retorna TRUE caso o item esteja presente na lista.</returns>
        public bool ContemFor(Object elemento)
        {
            bool achou = false;
            for (CCelula aux = topo; aux != null && !achou; aux = aux.prox)
                achou = aux.item.Equals(elemento);
            return achou;
        }

        /// <summary>
        /// Retorna o item do topo da Pilha sem removê-lo.
        /// </summary>
        /// <returns>Um Object contendo o item do topo da Pilha. Caso a Pilha esteja vazia retorna null.</returns>
        public Object Peek()
        {
            if (topo != null)
                return topo.item;
            else
                return null;
        }

        /// <summary>
        /// Insere um novo item no fundo da Pilha.
        /// </summary>
        /// <param name="valorItem">Um Object contendo o item a ser inserido no fundo da Pilha.</param>
        public void VaiProFundo(Object valorItem)
        {
            if (topo != null)
            {
                CCelula aux = topo;
                CCelula auxAnt = null;
                while (aux != null)
                {
                    auxAnt = aux;
                    aux = aux.prox;
                }
                auxAnt.prox = new CCelula(valorItem);
                Qtde++;
            }
            else
                Empilha(valorItem);
        }

        /// <summary>
        /// Função que retorna a quantidade de itens da Pilha.
        /// </summary>
        /// <returns>Quantidade de itens da Pilha.</returns>
        public int Quantidade() //Função
        {
            return Qtde;
        }

        /// <summary>
        /// Propriedade que retorna a quantidade de itens da Pilha.
        /// </summary>
        public int Count // Propriedade
        {
            get
            {
                return Qtde;
            }
        }

    }
}
