using AgenteInteligenteLinkMasterSword.src.Comum;
using AgenteInteligenteLinkMasterSword.src.EstruturacaoProblema;

Problema problema = new();

#region Cálculo dos melhores caminhos
if (problema.PosicaoPingente1 == null || problema.PosicaoPingente2 == null || problema.PosicaoPingente3 == null || problema.PosicaoMasterSword == null)
    return;

BuscaAestrela buscaDungeon1 = new(problema.Dungeon1, problema.InicioDungeon1, problema.PosicaoPingente1, problema.CustoTerreno);
List<PosicaoItem>? melhorCaminhoDungeon1 = buscaDungeon1.EncontrarMelhorCaminho(out _); ;

BuscaAestrela buscaDungeon2 = new(problema.Dungeon2, problema.InicioDungeon2, problema.PosicaoPingente2, problema.CustoTerreno);
List<PosicaoItem>? melhorCaminhoDungeon2 = buscaDungeon2.EncontrarMelhorCaminho(out _);

BuscaAestrela buscaDungeon3 = new(problema.Dungeon3, problema.InicioDungeon3, problema.PosicaoPingente3, problema.CustoTerreno);
List<PosicaoItem>? melhorCaminhoDungeon3 = buscaDungeon3.EncontrarMelhorCaminho(out _);

BuscaAestrela buscaClD1 = new(problema.ReinoDeHyrule, problema.CasaLink, problema.EntradaDungeon1, problema.CustoTerreno);
List<PosicaoItem>? melhorCaminhoClD1 = buscaClD1.EncontrarMelhorCaminho(out int custoDoCaminhoClD1);

BuscaAestrela buscaClD2 = new(problema.ReinoDeHyrule, problema.CasaLink, problema.EntradaDungeon2, problema.CustoTerreno);
List<PosicaoItem>? melhorCaminhoClD2 = buscaClD2.EncontrarMelhorCaminho(out int custoDoCaminhoClD2);

BuscaAestrela buscaClD3 = new(problema.ReinoDeHyrule, problema.CasaLink, problema.EntradaDungeon3, problema.CustoTerreno);
List<PosicaoItem>? melhorCaminhoClD3 = buscaClD3.EncontrarMelhorCaminho(out int custoDoCaminhoClD3);

BuscaAestrela buscaD1D2 = new(problema.ReinoDeHyrule, problema.EntradaDungeon1, problema.EntradaDungeon2, problema.CustoTerreno);
List<PosicaoItem>? melhorCaminhoD1D2 = buscaD1D2.EncontrarMelhorCaminho(out int custoDoCaminhoD1D2);

BuscaAestrela buscaD1D3 = new(problema.ReinoDeHyrule, problema.EntradaDungeon1, problema.EntradaDungeon3, problema.CustoTerreno);
List<PosicaoItem>? melhorCaminhoD1D3 = buscaD1D3.EncontrarMelhorCaminho(out int custoDoCaminhoD1D3);

BuscaAestrela buscaD2D3 = new(problema.ReinoDeHyrule, problema.EntradaDungeon2, problema.EntradaDungeon3, problema.CustoTerreno);
List<PosicaoItem>? melhorCaminhoD2D3 = buscaD2D3.EncontrarMelhorCaminho(out int custoDoCaminhoD2D3);

BuscaAestrela buscaClLw = new(problema.ReinoDeHyrule, problema.CasaLink, problema.EntradaLostWoods, problema.CustoTerreno);
List<PosicaoItem>? melhorCaminhoClLw = buscaClLw.EncontrarMelhorCaminho(out _);

BuscaAestrela buscaLwMs = new(problema.ReinoDeHyrule, problema.EntradaLostWoods, problema.PosicaoMasterSword, problema.CustoTerreno);
List<PosicaoItem>? melhorCaminhoLwMs = buscaLwMs.EncontrarMelhorCaminho(out _);
#endregion

List<PosicaoItem>?[] melhoresCaminhosDeDungeons = new List<PosicaoItem>?[] { melhorCaminhoDungeon1, melhorCaminhoDungeon2, melhorCaminhoDungeon3 };

OrdemDeVisitacao ordemDeVisitacao = new();

ordemDeVisitacao.AdicionarCaminho(PontosVisitacaoHyrule.CasaDoLink, PontosVisitacaoHyrule.Dungeon1, melhorCaminhoClD1, custoDoCaminhoClD1);
ordemDeVisitacao.AdicionarCaminho(PontosVisitacaoHyrule.CasaDoLink, PontosVisitacaoHyrule.Dungeon2, melhorCaminhoClD2, custoDoCaminhoClD2);
ordemDeVisitacao.AdicionarCaminho(PontosVisitacaoHyrule.CasaDoLink, PontosVisitacaoHyrule.Dungeon3, melhorCaminhoClD3, custoDoCaminhoClD3);
ordemDeVisitacao.AdicionarCaminho(PontosVisitacaoHyrule.Dungeon1, PontosVisitacaoHyrule.Dungeon2, melhorCaminhoD1D2, custoDoCaminhoD1D2);
ordemDeVisitacao.AdicionarCaminho(PontosVisitacaoHyrule.Dungeon1, PontosVisitacaoHyrule.Dungeon3, melhorCaminhoD1D3, custoDoCaminhoD1D3);
ordemDeVisitacao.AdicionarCaminho(PontosVisitacaoHyrule.Dungeon2, PontosVisitacaoHyrule.Dungeon3, melhorCaminhoD2D3, custoDoCaminhoD2D3);

PontosVisitacaoHyrule[] melhorOrdemDeVisitacao = ordemDeVisitacao.CalcularMelhorOrdemDeVisitacao();

ExibidorDeCaminhos exibidorHyrule = new(problema.ReinoDeHyrule, problema.CasaLink, problema.PosicaoMasterSword, problema.CustoTerreno);
ExibidorDeCaminhos exibidorDungeon1 = new(problema.Dungeon1, problema.InicioDungeon1, problema.PosicaoPingente1, problema.CustoTerreno);
ExibidorDeCaminhos exibidorDungeon2 = new(problema.Dungeon2, problema.InicioDungeon2, problema.PosicaoPingente2, problema.CustoTerreno);
ExibidorDeCaminhos exibidorDungeon3 = new(problema.Dungeon3, problema.InicioDungeon3, problema.PosicaoPingente3, problema.CustoTerreno);

ExibidorDeCaminhos[] exibidoresDungeons = new ExibidorDeCaminhos[] { exibidorDungeon1, exibidorDungeon2, exibidorDungeon3 };

Console.OutputEncoding = System.Text.Encoding.Unicode;

for (int i = 1; i < melhorOrdemDeVisitacao.Length; i++)
{
    List<PosicaoItem>? caminhoHyrule = ordemDeVisitacao.ConsultarCaminho(melhorOrdemDeVisitacao[i - 1], melhorOrdemDeVisitacao[i]);
    if (caminhoHyrule == null) return;
    exibidorHyrule.AplicarCaminho(caminhoHyrule);

    if (melhorOrdemDeVisitacao[i] != PontosVisitacaoHyrule.CasaDoLink)
    {
        List<PosicaoItem>? caminhoDungeon = melhoresCaminhosDeDungeons[(int)melhorOrdemDeVisitacao[i] - 1];
        if (caminhoDungeon == null) return;

        ExibidorDeCaminhos exibidorDungeon = exibidoresDungeons[(int)melhorOrdemDeVisitacao[i] - 1];
        exibidorDungeon.AtualizarCusto(exibidorHyrule.Custo);
        exibidorDungeon.AplicarCaminho(caminhoDungeon, true);

        exibidorHyrule.AtualizarCusto(exibidorDungeon.Custo);
    }
}

exibidorHyrule.AplicarCaminho(melhorCaminhoClLw);
exibidorHyrule.AplicarCaminho(melhorCaminhoLwMs);