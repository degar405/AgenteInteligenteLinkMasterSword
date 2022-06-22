using AgenteInteligenteLinkMasterSword.src.Comum;

namespace AgenteInteligenteLinkMasterSword.src.EstruturacaoProblema
{
    public class OrdemDeVisitacao
    {
        public int[,] CustosViagem { get; set; }
        public List<PosicaoItem>?[,] Caminhos { get; set; }

        public OrdemDeVisitacao()
        {
            int quantidadeDePontos = Enum.GetNames(typeof(PontosVisitacaoHyrule)).Length;
            CustosViagem = new int[quantidadeDePontos,quantidadeDePontos];
            Caminhos = new List<PosicaoItem>?[quantidadeDePontos, quantidadeDePontos];
        }

        public void AdicionarCaminho(PontosVisitacaoHyrule origem, PontosVisitacaoHyrule destino, List<PosicaoItem> caminho, int custoCaminho)
        {
            CustosViagem[(int)origem, (int)destino] = custoCaminho;
            Caminhos[(int)origem, (int)destino] = caminho;

            List<PosicaoItem> caminhoDeVolta = new(caminho);
            caminhoDeVolta.Reverse();

            Caminhos[(int)destino, (int)origem] = caminhoDeVolta;
            CustosViagem[(int)destino, (int)origem] = custoCaminho;
        }

        public PontosVisitacaoHyrule[] CalcularMelhorOrdemDeVisitacao()
        {
            List<PontosVisitacaoHyrule[]> permutacoesDeDungeons = ObterPermutacoesDeDungeons();

            int menorCustoViagem = int.MaxValue;
            PontosVisitacaoHyrule[] viagemDeMenorCusto = new PontosVisitacaoHyrule[0];
            
            foreach (var viagem in permutacoesDeDungeons)
            {
                int custoViagem = CalcularCustoTotalViagem(viagem);
                if (custoViagem < menorCustoViagem)
                {
                    menorCustoViagem = custoViagem;
                    viagemDeMenorCusto = viagem;
                }
            }

            PontosVisitacaoHyrule[] retorno = new PontosVisitacaoHyrule[viagemDeMenorCusto.Length + 2];
            retorno[0] = retorno[retorno.Length - 1] = PontosVisitacaoHyrule.CasaDoLink;

            for (int i = 0; i < viagemDeMenorCusto.Length; i++)
            {
                retorno[i + 1] = viagemDeMenorCusto[i];
            }

            return retorno;
        }

        private List<PontosVisitacaoHyrule[]> ObterPermutacoesDeDungeons()
        {
            List<PontosVisitacaoHyrule[]> retorno = new()
            {
                new PontosVisitacaoHyrule[] { PontosVisitacaoHyrule.Dungeon1, PontosVisitacaoHyrule.Dungeon2, PontosVisitacaoHyrule.Dungeon3 },
                new PontosVisitacaoHyrule[] { PontosVisitacaoHyrule.Dungeon1, PontosVisitacaoHyrule.Dungeon3, PontosVisitacaoHyrule.Dungeon2 },
                new PontosVisitacaoHyrule[] { PontosVisitacaoHyrule.Dungeon2, PontosVisitacaoHyrule.Dungeon1, PontosVisitacaoHyrule.Dungeon3 },
                new PontosVisitacaoHyrule[] { PontosVisitacaoHyrule.Dungeon2, PontosVisitacaoHyrule.Dungeon3, PontosVisitacaoHyrule.Dungeon1 },
                new PontosVisitacaoHyrule[] { PontosVisitacaoHyrule.Dungeon3, PontosVisitacaoHyrule.Dungeon1, PontosVisitacaoHyrule.Dungeon2 },
                new PontosVisitacaoHyrule[] { PontosVisitacaoHyrule.Dungeon3, PontosVisitacaoHyrule.Dungeon2, PontosVisitacaoHyrule.Dungeon1 }
            };

            return retorno;
        }

        private int CalcularCustoTotalViagem(PontosVisitacaoHyrule[] viagem)
        {
            int custo = 0;

            custo += CustosViagem[(int)PontosVisitacaoHyrule.CasaDoLink, (int)viagem[0]];

            for (int i = 1; i < viagem.Length; i++)
            {
                custo += CustosViagem[(int)viagem[i - 1], (int)viagem[i]];
            }

            custo += CustosViagem[(int)viagem[viagem.Length - 1], (int)PontosVisitacaoHyrule.CasaDoLink];

            return custo;
        }
    }
}
