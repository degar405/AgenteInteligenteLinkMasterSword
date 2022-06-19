using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AgenteInteligenteLinkMasterSword.src.Comum
{
    public static class LeitorDeMapa
    {
        public static int[,] GeraMatriz(TipoDeMapa tipoDeMapa)
        {
            string arquivo = ConfigurationManager.AppSettings[Enum.GetName(typeof(TipoDeMapa), tipoDeMapa)];

            using (StreamReader sr = new StreamReader(arquivo))
            {
                string? linha;
                linha = sr.ReadLine();
                if (linha == null) return null;

                int[] dimensoesMatriz = linha.Split(',').ToList().Select(x => int.Parse(x)).ToArray();
                if (dimensoesMatriz.Length != 2) return null;

                int[,] matriz = new int[dimensoesMatriz[0], dimensoesMatriz[1]];
                int linhasLidas = 0;
                while ((linha = sr.ReadLine()) != null)
                {
                    int[] itensLinha = linha.Split(',').ToList().Select(x => int.Parse(x)).ToArray();
                    if (itensLinha.Length != dimensoesMatriz[1]) return null;
                    for (int item = 0; item < itensLinha.Length; item++)
                    {
                        matriz[linhasLidas, item] = itensLinha[item];
                    }
                    linhasLidas++;
                }

                if (linhasLidas != dimensoesMatriz[0]) return null;
                return matriz;
            }
        }
    }
}
