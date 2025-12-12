class Program
{
    static void Main()
    {
        Console.WriteLine("Digite a largura da cidade (em metros):");
        int largura = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite a altura da cidade (em metros):");
        int altura = int.Parse(Console.ReadLine());

        int[,] cidade = new int[largura, altura];

        Console.WriteLine("Digite a quantidade de raios registrados:");
        int n = int.Parse(Console.ReadLine());

        bool mitoQuebrado = false;

        Console.WriteLine("Digite as coordenadas X Y de cada raio:");
        for (int i = 0; i < n; i++)
        {
            string[] entrada = Console.ReadLine().Split();
            int x = int.Parse(entrada[0]);
            int y = int.Parse(entrada[1]);

            cidade[x, y]++; 

            if (cidade[x, y] > 1)
            {
                mitoQuebrado = true;
            }
        }

        if (mitoQuebrado)
        {
            Console.WriteLine("Mito quebrado: já caiu raio no mesmo lugar!");
        }
        else
        {
            Console.WriteLine("Mito confirmado: nenhum raio caiu duas vezes no mesmo lugar.");
        }
    }
}
