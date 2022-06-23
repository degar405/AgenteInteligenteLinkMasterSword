namespace AgenteInteligenteLinkMasterSword.src.EstruturacaoProblema
{
    public class ExibidorDeCaminhos
    {
        private Mapa Mapa { get; set; }
        private PosicaoItem PosicaoLink { get; set; }
        private PosicaoItem? ItemBuscado { get; set; }
        private int[] CustoTerreno { get; set; }
        public int Custo { get; private set; }
        private bool AtualizacaoCustoAcumula { get; set; }
        private int TempoDeAtualizacao { get; set; }
        private string NomeDoMapa { get; set; }
        private static ConsoleColor[] CoresTerreno = { 
            ConsoleColor.Green, 
            ConsoleColor.Yellow, 
            ConsoleColor.DarkRed, 
            ConsoleColor.DarkYellow, 
            ConsoleColor.Blue, 
            ConsoleColor.Black,
            ConsoleColor.White
        };

        public ExibidorDeCaminhos(Mapa mapa, PosicaoItem posicaoLink, PosicaoItem itemBuscado, int[] custoTerreno, int tempoDeAtualizacao, string nomeDoMapa)
        {
            Mapa = mapa;
            PosicaoLink = posicaoLink;
            ItemBuscado = itemBuscado;
            CustoTerreno = custoTerreno;
            Custo = CustoTerreno[Mapa.Matriz[PosicaoLink.Linha, PosicaoLink.Coluna]];
            AtualizacaoCustoAcumula = true;
            TempoDeAtualizacao = tempoDeAtualizacao;
            NomeDoMapa = nomeDoMapa;
        }

        public void AtualizarCusto(int custo)
        {
            if (AtualizacaoCustoAcumula)
                Custo += custo;
            else
                Custo = custo;
        }

        public void AplicarCaminho(List<PosicaoItem> caminho, bool viagemDeIdaEVolta = false)
        {
            AtualizacaoCustoAcumula = false;
            bool primeiraIteracao = true;

            foreach(PosicaoItem posicao in caminho)
            {
                if (!primeiraIteracao)
                    Custo += CustoTerreno[Mapa.Matriz[posicao.Linha, posicao.Coluna]];
                else
                    primeiraIteracao = false;

                PosicaoLink = posicao;
                if (ItemBuscado != null && PosicaoLink.Linha == ItemBuscado.Linha && PosicaoLink.Coluna == ItemBuscado.Coluna)
                    ItemBuscado = null;

                Console.Clear();
                Console.WriteLine($"Mapa: {NomeDoMapa}");
                Console.WriteLine();
                Console.WriteLine($"Custo: {Custo}");
                Console.WriteLine();
                PrintarMapa();
                Thread.Sleep(TempoDeAtualizacao);
            }

            if (viagemDeIdaEVolta)
            {
                List<PosicaoItem> caminhoDeVolta = new(caminho);
                caminhoDeVolta.Reverse();
                AplicarCaminho(caminhoDeVolta);
            }
        }

        private void PrintarMapa()
        {
            Console.Write("  ");
            for (int i = 0; i < Mapa.Matriz.GetLength(1); i++)
            {
                if (i % 2 == 0)
                    Console.ForegroundColor = ConsoleColor.White;
                else
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"{(i + 1).ToString().PadLeft(2)}");
            }
            Console.WriteLine();
            for (int i = 0; i < Mapa.Matriz.GetLength(0); i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{(i+1).ToString().PadLeft(2)} ");
                for (int o = 0; o < Mapa.Matriz.GetLength(1); o++)
                {
                    if (i == PosicaoLink.Linha && o == PosicaoLink.Coluna)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("L ");
                    }
                    else if (ItemBuscado != null && i == ItemBuscado.Linha && o == ItemBuscado.Coluna)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("X ");
                    }
                    else
                    {
                        Console.ForegroundColor = CoresTerreno[Mapa.Matriz[i, o]];
                        Console.Write($"\x2B1C ");
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
