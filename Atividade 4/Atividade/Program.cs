
using System;
using System.Linq;

class Program
{
    #region Exercício 1
    static int SomaVetor(int[] vetor) => vetor.Sum();
    #endregion

    #region Exercício 2
    static int ContaImpares(int[] vetor) => vetor.Count(x => x % 2 != 0);
    #endregion

    #region Exercício 3
    static double MenorElemento(double[] vetor) => vetor.Min();
    #endregion

    #region Exercício 4
    static double MaiorElemento(double[] vetor) => vetor.Max();
    #endregion

    #region Exercício 5
    static char[] DNAComplementar(char[] dna)
    {
        char[] comp = new char[dna.Length];
        for (int i = 0; i < dna.Length; i++)
        {
            comp[i] = dna[i] switch
            {
                'A' => 'T',
                'T' => 'A',
                'C' => 'G',
                'G' => 'C',
                _   => '?'
            };
        }
        return comp;
    }
    #endregion

    #region Exercício 6
    static void SorteioBusca(int n, int procurar)
    {
        Random rnd = new Random();
        int[] vetor = new int[n];
        for (int i = 0; i < n; i++)
            vetor[i] = rnd.Next(1, 101);

        Console.WriteLine("Vetor sorteado: " + string.Join(", ", vetor));

        int pos = Array.IndexOf(vetor, procurar);
        Console.WriteLine(pos >= 0
            ? $"Número {procurar} encontrado na posição {pos}"
            : $"Número {procurar} não encontrado.");
    }
    #endregion

    #region Exercício 7
    static int[] MultiplicaVetores(int[] v1, int[] v2)
    {
        int[] res = new int[v1.Length];
        for (int i = 0; i < v1.Length; i++)
            res[i] = v1[i] * v2[i];
        return res;
    }
    #endregion

    #region Exercício 8
    static int ContaOcorrencias(int[] vetor, int valor) =>
        vetor.Count(x => x == valor);
    #endregion

    #region Exercício 9
    static string InverteVetor(char[] vetor)
    {
        char[] invertido = new char[vetor.Length];
        for (int i = 0; i < vetor.Length; i++)
            invertido[i] = vetor[vetor.Length - 1 - i];

        return new string(invertido);
    }
    #endregion

    #region Exercício 10
    static void FrequenciaDado(int[] lancamentos)
    {
        for (int face = 1; face <= 6; face++)
        {
            int qtd = 0;
            for (int i = 0; i < lancamentos.Length; i++)
                if (lancamentos[i] == face)
                    qtd++;

            Console.WriteLine($"Face {face}: {qtd} ocorrências");
        }
    }
    #endregion

    #region Exercício 11
    static string DecodificaLinguaP(string msg)
    {
        string resultado = "";
        for (int i = 0; i < msg.Length; i++)
        {
            if (msg[i] == 'p' && i + 1 < msg.Length)
            {
                resultado += msg[i + 1];
                i++;
            }
            else
            {
                resultado += msg[i];
            }
        }
        return resultado;
    }
    #endregion

    #region Exercício 12
    static double NotaFinalCarnaval(double[] notas)
    {
        var ordenadas = notas.OrderBy(x => x).ToArray();
        return ordenadas[1] + ordenadas[2] + ordenadas[3]; // soma das 3 centrais
    }
    #endregion

    // ---------------- MAIN ----------------
    static void Main()
    {
        Console.WriteLine("=== Lista de Exercícios Vetores - C# ===");

        int[] v = { 1, 2, 3, 4, 5 };
        Console.WriteLine("Ex1 - Soma vetor: " + SomaVetor(v));
        Console.WriteLine("Ex2 - Qtd ímpares: " + ContaImpares(v));
        Console.WriteLine("Ex3 - Menor elemento: " + MenorElemento(new double[] { 3.2, 7.5, 1.9 }));
        Console.WriteLine("Ex4 - Maior elemento: " + MaiorElemento(new double[] { 3.2, 7.5, 1.9 }));
        Console.WriteLine("Ex5 - DNA comp: " + new string(DNAComplementar(new char[] { 'A', 'T', 'G', 'C' })));
        SorteioBusca(10, 5);
        Console.WriteLine("Ex7 - Multiplica vetores: " + string.Join(", ", MultiplicaVetores(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 })));
        Console.WriteLine("Ex8 - Contagem valor 2: " + ContaOcorrencias(v, 2));
        Console.WriteLine("Ex9 - Inverso vetor: " + InverteVetor(new char[] { 'O', 'L', 'A' }));
        FrequenciaDado(new int[] { 1, 2, 3, 2, 6, 6, 1, 5 });
        Console.WriteLine("Ex11 - Decodificado: " + DecodificaLinguaP("pUpm pfpiplpmpe plpepgpapl"));
        Console.WriteLine("Ex12 - Nota Carnaval: " + NotaFinalCarnaval(new double[] { 6.4, 8.2, 8.2, 7.4, 9.1 }));
    }
}
