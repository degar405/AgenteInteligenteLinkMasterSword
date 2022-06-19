using AgenteInteligenteLinkMasterSword.src.EstruturacaoProblema;

Problema problema = new();

Console.WriteLine("DUNGEONS");
Console.WriteLine();
#region DUNGEONS
if (problema.PosicaoPingente1 != null)
{
    Console.WriteLine("Dungeon 1");

    BuscaAestrela busca = new(problema.Dungeon1, problema.InicioDungeon1, problema.PosicaoPingente1, problema.CustoTerreno);

    List<PosicaoItem>? melhorCaminho = busca.EncontrarMelhorCaminho(out int custoDoCaminho);

    Console.WriteLine("Quantidade de quadrados: " + melhorCaminho.Count);
    Console.Write("Caminho: ");
    foreach (var posicao in melhorCaminho)
    {
        Console.Write("(" + posicao.Coluna + ", " + posicao.Linha + "), ");
    }

    Console.WriteLine();
    Console.WriteLine("Custo do caminho: " + custoDoCaminho);
    Console.WriteLine();

    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
    Console.WriteLine();
}

if (problema.PosicaoPingente2 != null)
{
    Console.WriteLine("Dungeon 2");

    BuscaAestrela busca = new(problema.Dungeon2, problema.InicioDungeon2, problema.PosicaoPingente2, problema.CustoTerreno);

    List<PosicaoItem>? melhorCaminho = busca.EncontrarMelhorCaminho(out int custoDoCaminho);

    Console.WriteLine("Quantidade de quadrados: " + melhorCaminho.Count);
    Console.Write("Caminho: ");
    foreach (var posicao in melhorCaminho)
    {
        Console.Write("(" + posicao.Coluna + ", " + posicao.Linha + "), ");
    }

    Console.WriteLine();
    Console.WriteLine("Custo do caminho: " + custoDoCaminho);
    Console.WriteLine();

    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
    Console.WriteLine();
}

if (problema.PosicaoPingente3 != null)
{
    Console.WriteLine("Dungeon 3");

    BuscaAestrela busca = new(problema.Dungeon3, problema.InicioDungeon3, problema.PosicaoPingente3, problema.CustoTerreno);

    List<PosicaoItem>? melhorCaminho = busca.EncontrarMelhorCaminho(out int custoDoCaminho);

    Console.WriteLine("Quantidade de quadrados: " + melhorCaminho.Count);
    Console.Write("Caminho: ");
    foreach (var posicao in melhorCaminho)
    {
        Console.Write("(" + posicao.Coluna + ", " + posicao.Linha + "), ");
    }

    Console.WriteLine();
    Console.WriteLine("Custo do caminho: " + custoDoCaminho);
    Console.WriteLine();

    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
    Console.WriteLine();
}
#endregion

Console.WriteLine("REINO DE HYRULE");
Console.WriteLine();
#region REINO DE HYRULE
if (true)
{
    Console.WriteLine("Melhor Caminho da Casa do Link até a Dungeon 1");

    BuscaAestrela busca = new(problema.ReinoDeHyrule, problema.CasaLink, problema.EntradaDungeon1, problema.CustoTerreno);

    List<PosicaoItem>? melhorCaminho = busca.EncontrarMelhorCaminho(out int custoDoCaminho);

    Console.WriteLine("Quantidade de quadrados: " + melhorCaminho.Count);
    Console.Write("Caminho: ");
    foreach (var posicao in melhorCaminho)
    {
    Console.Write("(" + posicao.Coluna + ", " + posicao.Linha + "), ");
    }

    Console.WriteLine();
    Console.WriteLine("Custo do caminho: " + custoDoCaminho);
    Console.WriteLine();

    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
    Console.WriteLine();
}

if (true)
{
    Console.WriteLine("Melhor Caminho da Casa do Link até a Dungeon 2");

    BuscaAestrela busca = new(problema.ReinoDeHyrule, problema.CasaLink, problema.EntradaDungeon2, problema.CustoTerreno);

    List<PosicaoItem>? melhorCaminho = busca.EncontrarMelhorCaminho(out int custoDoCaminho);

    Console.WriteLine("Quantidade de quadrados: " + melhorCaminho.Count);
    Console.Write("Caminho: ");
    foreach (var posicao in melhorCaminho)
    {
        Console.Write("(" + posicao.Coluna + ", " + posicao.Linha + "), ");
    }

    Console.WriteLine();
    Console.WriteLine("Custo do caminho: " + custoDoCaminho);
    Console.WriteLine();

    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
    Console.WriteLine();
}

if (true)
{
    Console.WriteLine("Melhor Caminho da Casa do Link até a Dungeon 3");

    BuscaAestrela busca = new(problema.ReinoDeHyrule, problema.CasaLink, problema.EntradaDungeon3, problema.CustoTerreno);

    List<PosicaoItem>? melhorCaminho = busca.EncontrarMelhorCaminho(out int custoDoCaminho);

    Console.WriteLine("Quantidade de quadrados: " + melhorCaminho.Count);
    Console.Write("Caminho: ");
    foreach (var posicao in melhorCaminho)
    {
        Console.Write("(" + posicao.Coluna + ", " + posicao.Linha + "), ");
    }

    Console.WriteLine();
    Console.WriteLine("Custo do caminho: " + custoDoCaminho);
    Console.WriteLine();

    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
    Console.WriteLine();
}

if (true)
{
    Console.WriteLine("Melhor Caminho da Dungeon 1 até a Dungeon 2");

    BuscaAestrela busca = new(problema.ReinoDeHyrule, problema.EntradaDungeon1, problema.EntradaDungeon2, problema.CustoTerreno);

    List<PosicaoItem>? melhorCaminho = busca.EncontrarMelhorCaminho(out int custoDoCaminho);

    Console.WriteLine("Quantidade de quadrados: " + melhorCaminho.Count);
    Console.Write("Caminho: ");
    foreach (var posicao in melhorCaminho)
    {
        Console.Write("(" + posicao.Coluna + ", " + posicao.Linha + "), ");
    }

    Console.WriteLine();
    Console.WriteLine("Custo do caminho: " + custoDoCaminho);
    Console.WriteLine();

    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
    Console.WriteLine();
}

if (true)
{
    Console.WriteLine("Melhor Caminho da Dungeon 1 até a Dungeon 3");

    BuscaAestrela busca = new(problema.ReinoDeHyrule, problema.EntradaDungeon1, problema.EntradaDungeon3, problema.CustoTerreno);

    List<PosicaoItem>? melhorCaminho = busca.EncontrarMelhorCaminho(out int custoDoCaminho);

    Console.WriteLine("Quantidade de quadrados: " + melhorCaminho.Count);
    Console.Write("Caminho: ");
    foreach (var posicao in melhorCaminho)
    {
        Console.Write("(" + posicao.Coluna + ", " + posicao.Linha + "), ");
    }

    Console.WriteLine();
    Console.WriteLine("Custo do caminho: " + custoDoCaminho);
    Console.WriteLine();

    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
    Console.WriteLine();
}

if (true)
{
    Console.WriteLine("Melhor Caminho da Dungeon 2 até a Dungeon 3");

    BuscaAestrela busca = new(problema.ReinoDeHyrule, problema.EntradaDungeon2, problema.EntradaDungeon3, problema.CustoTerreno);

    List<PosicaoItem>? melhorCaminho = busca.EncontrarMelhorCaminho(out int custoDoCaminho);

    Console.WriteLine("Quantidade de quadrados: " + melhorCaminho.Count);
    Console.Write("Caminho: ");
    foreach (var posicao in melhorCaminho)
    {
        Console.Write("(" + posicao.Coluna + ", " + posicao.Linha + "), ");
    }

    Console.WriteLine();
    Console.WriteLine("Custo do caminho: " + custoDoCaminho);
    Console.WriteLine();

    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
    Console.WriteLine();
}

if (true)
{
    Console.WriteLine("Melhor Caminho da Casa do Link até Lost Woods");

    BuscaAestrela busca = new(problema.ReinoDeHyrule, problema.CasaLink, problema.EntradaLostWoods, problema.CustoTerreno);

    List<PosicaoItem>? melhorCaminho = busca.EncontrarMelhorCaminho(out int custoDoCaminho);

    Console.WriteLine("Quantidade de quadrados: " + melhorCaminho.Count);
    Console.Write("Caminho: ");
    foreach (var posicao in melhorCaminho)
    {
        Console.Write("(" + posicao.Coluna + ", " + posicao.Linha + "), ");
    }

    Console.WriteLine();
    Console.WriteLine("Custo do caminho: " + custoDoCaminho);
    Console.WriteLine();

    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
    Console.WriteLine();
}

if (true)
{
    Console.WriteLine("Melhor Caminho de Lost Woods até a Master Sword");

    BuscaAestrela busca = new(problema.ReinoDeHyrule, problema.EntradaLostWoods, problema.PosicaoMasterSword, problema.CustoTerreno);

    List<PosicaoItem>? melhorCaminho = busca.EncontrarMelhorCaminho(out int custoDoCaminho);

    Console.WriteLine("Quantidade de quadrados: " + melhorCaminho.Count);
    Console.Write("Caminho: ");
    foreach (var posicao in melhorCaminho)
    {
        Console.Write("(" + posicao.Coluna + ", " + posicao.Linha + "), ");
    }

    Console.WriteLine();
    Console.WriteLine("Custo do caminho: " + custoDoCaminho);
    Console.WriteLine();

    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
    Console.WriteLine();
}
#endregion