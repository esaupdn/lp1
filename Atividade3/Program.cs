using System;

class Program
{
    static void Main()
    {
        string mensagemCodificada = Console.ReadLine();
        string mensagemDecodificada = Decodificar(mensagemCodificada);
        Console.WriteLine(mensagemDecodificada);
    }
    static string Decodificar(string mensagem)
    {
        string resultado = "";
        int i = 0;
        while (i < mensagem.Length)
        {      
            if (mensagem[i] == 'p' || mensagem[i] == 'P')
            {
                i++;
                if (i < mensagem.Length)
                {
                    resultado += mensagem[i];
                    i++;
                }
            }
            else
            {     
                resultado += mensagem[i];
                i++;
            }
        }
        return resultado;
    }
}
