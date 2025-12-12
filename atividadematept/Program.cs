using System;
using System.IO;

namespace MatrizGrafo
{
    class Grafo
    {
        private int[,] matriz;
        private int n;

        public Grafo(int tamanho)
        {
            n = tamanho;
            matriz = new int[n, n];
        }

        public void carregarArquivo(string nomeArquivo)
        {
            if (File.Exists(nomeArquivo))
            {
                string[] linhas = File.ReadAllLines(nomeArquivo);
                for (int i = 0; i < n; i++)
                {
                    string[] valores = linhas[i].Split(',');
                    for (int j = 0; j < n; j++)
                    {
                        matriz[i, j] = int.Parse(valores[j]);
                    }
                }
            }
            else
            {
                Console.WriteLine("Arquivo nao encontrado.");
            }
        }

        public void imprimirMatriz(int[,] m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(m[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public int[,] getMatriz()
        {
            return matriz;
        }

        public void verificarReflexiva()
        {
            bool reflexiva = true;
            for (int i = 0; i < n; i++)
            {
                if (matriz[i, i] == 0)
                {
                    Console.WriteLine("Nao e reflexiva. Falha no vertice: " + (i + 1));
                    reflexiva = false;
                }
            }
            if (reflexiva) Console.WriteLine("O grafo e Reflexivo.");
        }

        public void verificarSimetrica()
        {
            bool simetrica = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matriz[i, j] != matriz[j, i])
                    {
                        Console.WriteLine("Nao e simetrica. Diferenca entre " + (i + 1) + " e " + (j + 1));
                        simetrica = false;
                        return; 
                    }
                }
            }
            if (simetrica) Console.WriteLine("O grafo e Simetrico.");
        }

        public int[,] calcularR2()
        {
            int[,] r2 = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (matriz[i, k] == 1 && matriz[k, j] == 1)
                        {
                            r2[i, j] = 1;
                        }
                    }
                }
            }
            return r2;
        }

        public void verificarTransitividade()
        {
            int[,] r2 = calcularR2();
            bool transitiva = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (r2[i, j] == 1 && matriz[i, j] == 0)
                    {
                        Console.WriteLine("Nao e transitiva. Falta aresta direta de " + (i + 1) + " para " + (j + 1));
                        transitiva = false;
                    }
                }
            }
            if (transitiva) Console.WriteLine("O grafo e Transitivo.");
        }

        public int[,] calcularRInfinito()
        {
            int[,] rInf = new int[n, n];
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    rInf[i, j] = matriz[i, j];
                }
            }

            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (rInf[i, j] == 1 || (rInf[i, k] == 1 && rInf[k, j] == 1))
                        {
                            rInf[i, j] = 1;
                        }
                    }
                }
            }
            return rInf;
        }
    }
}