using System;

class Program
{
    static int MenorValor(int[,] matriz)
    {
        int menor = matriz[0, 0];
        int linhas = matriz.GetLength(0);
        int colunas = matriz.GetLength(1);

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                if (matriz[i, j] < menor)
                {
                    menor = matriz[i, j];
                }
            }
        }
        return menor;
    }

    static int MaiorValor(int[,] matriz)
    {
        int maior = matriz[0, 0];
        int linhas = matriz.GetLength(0);
        int colunas = matriz.GetLength(1);

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                if (matriz[i, j] > maior)
                {
                    maior = matriz[i, j];
                }
            }
        }
        return maior;
    }

    // 3. Função que conta quantas vezes
    static int ContarOcorrencias(int[,] matriz, int x)
    {
        int contador = 0;
        int linhas = matriz.GetLength(0);
        int colunas = matriz.GetLength(1);

        for (int i = 0; i < linhas; i++)
        {
            for (int j = 0; j < colunas; j++)
            {
                if (matriz[i, j] == x)
                {
                    contador++;
                }
            }
        }
        return contador;
    }

    static void Main(string[] args)
    {
        // Exemplo de uso
        int[,] matriz = {
            { 5, 2, 8 },
            { 1, 7, 3 },
            { 9, 4, 2 }
        };

        Console.WriteLine("Menor valor da matriz: " + MenorValor(matriz));
        Console.WriteLine("Maior valor da matriz: " + MaiorValor(matriz));

        Console.Write("Digite um número X para contar na matriz: ");
        int x = int.Parse(Console.ReadLine());
        Console.WriteLine($"O número {x} aparece {ContarOcorrencias(matriz, x)} vezes na matriz.");
    }
}
