using System;
using System.Text;

class Program
{
    static void Main()
    {
        string entrada = Console.ReadLine();
        var saida = new StringBuilder();

        for (int i = 0; i < entrada.Length; i++)
        {
            if (entrada[i] == 'p' && i + 1 < entrada.Length && entrada[i + 1] != ' ')
            {
                saida.Append(entrada[i + 1]);
                i++;
            }
            else
            {
                saida.Append(entrada[i]);
            }
        }

        Console.WriteLine(saida.ToString());
    }
}
