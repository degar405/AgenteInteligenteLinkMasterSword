using AgenteInteligenteLinkMasterSword.src.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenteInteligenteLinkMasterSword.src.EstruturacaoProblema
{
    public class NoBuscaAestrela
    {
        public PosicaoItem Estado { get; set; }
        public int Custo { get; set; }
        public NoBuscaAestrela? NoPai { get; set; }

        public NoBuscaAestrela(PosicaoItem estado, int custo, NoBuscaAestrela? noPai = null)
        {
            Estado = estado;
            Custo = custo;
            NoPai = noPai;
        }
    }

    public class BuscaAestrela
    {
        public Mapa Mapa { get; set; }
        public PosicaoItem PosicaoInicial { get; set; }
        public PosicaoItem Destino { get; set; }
        public int[] CustoTerreno { get; set; }

        public BuscaAestrela(Mapa mapa, PosicaoItem posicaoInicial, PosicaoItem destino, int[] custoTerreno)
        {
            Mapa = mapa;
            PosicaoInicial = posicaoInicial;
            Destino = destino;
            CustoTerreno = custoTerreno;
        }

        public List<PosicaoItem>? EncontrarMelhorCaminho(out int custoCaminho)
        {
            custoCaminho = int.MaxValue;

            NoBuscaAestrela no = new(PosicaoInicial, CustoTerreno[Mapa.Matriz[PosicaoInicial.Linha, PosicaoInicial.Coluna]]);
            List<NoBuscaAestrela> nosExplorados = new List<NoBuscaAestrela>();
            PriorityQueue<NoBuscaAestrela, int> borda = new();
            borda.Enqueue(no, no.Custo + 0);

            while (true)
            {
                if (borda.Count == 0) return null;

                no = borda.Dequeue();
                if (TesteDeObjetivo(no, borda)) {
                    custoCaminho = no.Custo;
                    return MontarSolucao(no);
                }

                nosExplorados.Add(no);
                foreach (var noFilho in ExpandirNo(no))
                {
                    if (nosExplorados.Where(x => x.Estado.Linha == noFilho.Estado.Linha && x.Estado.Coluna == noFilho.Estado.Coluna).Count() > 0)
                        continue;

                    AdicionarNoABorda(noFilho, borda);
                }
            }
        }

        private List<NoBuscaAestrela> ExpandirNo(NoBuscaAestrela no)
        {
            List<PosicaoItem> posicoesVizinhas = new() { 
                new PosicaoItem(no.Estado.Coluna, no.Estado.Linha + 1),
                new PosicaoItem(no.Estado.Coluna + 1, no.Estado.Linha),
                new PosicaoItem(no.Estado.Coluna, no.Estado.Linha - 1),
                new PosicaoItem(no.Estado.Coluna - 1, no.Estado.Linha)
            };

            posicoesVizinhas = posicoesVizinhas
                .Where(x => x.Linha >= 0
                         && x.Coluna >= 0
                         && x.Linha < Mapa.Matriz.GetLength(0) 
                         && x.Coluna < Mapa.Matriz.GetLength(1)
                         && Mapa.Matriz[x.Linha, x.Coluna] != (int)Terreno.NaoCaminhavel)
                .ToList();
            List<NoBuscaAestrela> nosFilhos = new();

            foreach (var posicao in posicoesVizinhas)
            {
                int custoDaPosicao = CustoTerreno[Mapa.Matriz[posicao.Linha, posicao.Coluna]];
                nosFilhos.Add(new(posicao, no.Custo + custoDaPosicao, no));
            }

            return nosFilhos;
        }

        private int ObterCustoEstimado(PosicaoItem estado)
        {
            return 0;
        }

        private void AdicionarNoABorda(NoBuscaAestrela noFilho, PriorityQueue<NoBuscaAestrela, int> borda)
        {
            int prioridadeNo = noFilho.Custo + ObterCustoEstimado(noFilho.Estado);
            List<(NoBuscaAestrela Element, int Priority)> listaBorda = borda.UnorderedItems.ToList();
            
            bool noFilhoExisteNaBorda = listaBorda.Where(x => x.Element.Estado.Linha == noFilho.Estado.Linha && x.Element.Estado.Coluna == noFilho.Estado.Coluna)
                .Count() > 0;
            var noFilhoExistente = listaBorda.Where(x => x.Element.Estado.Linha == noFilho.Estado.Linha && x.Element.Estado.Coluna == noFilho.Estado.Coluna)
                .FirstOrDefault();

            if (noFilhoExisteNaBorda && noFilhoExistente.Priority <= prioridadeNo)
                return;

            if (noFilhoExisteNaBorda)
            {
                listaBorda.Remove(noFilhoExistente);
                borda = new(listaBorda);
            }

            borda.Enqueue(noFilho, prioridadeNo);
        }

        private bool TesteDeObjetivo(NoBuscaAestrela no, PriorityQueue<NoBuscaAestrela, int> borda)
        {
            if (no.Estado.Coluna == Destino.Coluna && no.Estado.Linha == Destino.Linha)
                return true;

            return false;
        }

        private List<PosicaoItem> MontarSolucao(NoBuscaAestrela? no)
        {
            if (no == null)
            {
                return new List<PosicaoItem>();
            }

            List<PosicaoItem> solucao = MontarSolucao(no.NoPai);
            solucao.Add(no.Estado);
            return solucao;
        }
    }
}
