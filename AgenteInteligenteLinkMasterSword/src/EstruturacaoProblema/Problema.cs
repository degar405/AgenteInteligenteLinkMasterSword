using AgenteInteligenteLinkMasterSword.src.Comum;

namespace AgenteInteligenteLinkMasterSword.src.EstruturacaoProblema
{
    public class PosicaoItem
    {
        public int Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoItem(int Coluna, int Linha)
        {
            this.Coluna = Coluna;
            this.Linha = Linha;
        }

        public int CalcularDistanciaDeDoisPontos(PosicaoItem posicaoDestino)
        {
            int distanciaEixoX = posicaoDestino.Coluna - Coluna;
            int distanciaEixoY = posicaoDestino.Linha - Linha;

            int distancia = (int)Math.Floor(Math.Sqrt((distanciaEixoX * distanciaEixoX) + (distanciaEixoY * distanciaEixoY)));
            return distancia;
        }
    }

    public class Mapa
    {
        public int[,] Matriz { get; set; }

        public Mapa(TipoDeMapa tipo)
        {
            Matriz = LeitorDeMapa.GeraMatriz(tipo);
        }
    }

    public class Problema
    {
        public PosicaoItem CasaLink { get; set; }
        public PosicaoItem EntradaDungeon1 { get; set; }
        public PosicaoItem EntradaDungeon2 { get; set; }
        public PosicaoItem EntradaDungeon3 { get; set; }
        public PosicaoItem EntradaLostWoods { get; set; }
        public PosicaoItem? PosicaoMasterSword { get; set; }
        public PosicaoItem InicioDungeon1 { get; set; }
        public PosicaoItem InicioDungeon2 { get; set; }
        public PosicaoItem InicioDungeon3 { get; set; }
        public PosicaoItem? PosicaoPingente1 { get; set; }
        public PosicaoItem? PosicaoPingente2 { get; set; }
        public PosicaoItem? PosicaoPingente3 { get; set; }

        public int[] CustoTerreno { get; set; }

        public Mapa ReinoDeHyrule { get; set; }
        public Mapa Dungeon1 { get; set; }
        public Mapa Dungeon2 { get; set; }
        public Mapa Dungeon3 { get; set; }

        public Problema()
        {
            CasaLink = new PosicaoItem(24, 27);
            EntradaDungeon1 = new PosicaoItem(5, 32);
            EntradaDungeon2 = new PosicaoItem(39, 17);
            EntradaDungeon3 = new PosicaoItem(24, 1);
            EntradaLostWoods = new PosicaoItem(6, 5);
            PosicaoMasterSword = new PosicaoItem(2, 1);

            InicioDungeon1 = new PosicaoItem(14, 26);
            PosicaoPingente1 = new PosicaoItem(13, 3);
            
            InicioDungeon2 = new PosicaoItem(13, 25);
            PosicaoPingente2 = new PosicaoItem(13, 2);
            
            InicioDungeon3 = new PosicaoItem(14, 25);
            PosicaoPingente3 = new PosicaoItem(15, 19);

            ReinoDeHyrule = new Mapa(TipoDeMapa.ReinoDeHyrule);
            Dungeon1 = new Mapa(TipoDeMapa.Dungeon1);
            Dungeon2 = new Mapa(TipoDeMapa.Dungeon2);
            Dungeon3 = new Mapa(TipoDeMapa.Dungeon3);

            CustoTerreno = new int[6] { 10, 20, 100, 150, 180, 10 };
        }
    }
}
