﻿using System;
using System.Linq.Expressions;
using MinhaBiblioteca;
class Program {

	static void Main() 
	{
		Console.WriteLine("Escreva a sequencia de dna");
		string dna = Console.ReadLine().ToLower();
		
		bool contem = false;
		for (int i = 0; i < dna.Length; i++)
		{
			
			if (i < dna.Length - 2 && dna[i] == 'a' && dna[i + 1] == 't' && dna[i + 2] == 'g')
			{
				Console.WriteLine("Contém!");
				contem = true;
			}
		}
		
		if (!contem)
		{
			Console.WriteLine("A sequência não contém o start codon 'ATG'");
		}
	}
	
	
	static void exercicio01() {
		Console.WriteLine("Insira o número de linhas e colunas das matrizes de desmatamento: ");
		string[] input = Console.ReadLine().Split(' ');
		int linhas = int.Parse(input[0]);
		int colunas = int.Parse(input[1]);
		
		int[,] matriz_antiga = new int[linhas, colunas];
		int[,] matriz_nova = new int[linhas, colunas];
		
		gerarMatriz(matriz_antiga);
		gerarMatriz(matriz_nova);
		
		double areaDesmatadaAnterior = 0;
		double areaDesmatadaAtual = 0;
		
		double percentualAreaDesmatadaAnterior;
		double percentualAreaDesmatadaAtual;
		
		
		double aumentoDeDesmatamento = 0.0;
		
		for (int i = 0; i < linhas; i++)
		{
			for (int j = 0; j < colunas; j++)
			{
				if (matriz_antiga[i, j] == 0) areaDesmatadaAnterior += 1;
				if (matriz_nova[i, j] == 0) areaDesmatadaAtual += 1;
			}
		}
		
		Console.WriteLine(areaDesmatadaAnterior / (linhas * colunas));
		
		percentualAreaDesmatadaAnterior = (areaDesmatadaAnterior / (linhas * colunas)) * 100; 
		percentualAreaDesmatadaAtual = (areaDesmatadaAtual / (linhas * colunas)) * 100; 
		aumentoDeDesmatamento = percentualAreaDesmatadaAtual - percentualAreaDesmatadaAnterior;
		
		Console.WriteLine("Área desmatada Anterior X Atual: " + areaDesmatadaAnterior + " X " + areaDesmatadaAtual);
		Console.WriteLine("Percentual desmatada Anterior X Atual: " + $"{percentualAreaDesmatadaAnterior:F1}" + " X " + $"{percentualAreaDesmatadaAtual}");
		
		if (aumentoDeDesmatamento > 0) {
			Console.WriteLine("Houve um aumento do desmatamento de " + aumentoDeDesmatamento + " por cento");
		} else if (aumentoDeDesmatamento < 0)  {
			Console.WriteLine("Houve descrescimo do desmatamento de " + aumentoDeDesmatamento + " por cento");
		} else {
			Console.WriteLine("Não houve aumento");
		}
		
	}
	
	public static void gerarMatriz(int[,] matriz)
	{
		int linhas = matriz.GetLength(0);
		int cols = matriz.GetLength(1);
		Random rand = new Random();  // criando o gerador de aleatorios
		Console.WriteLine("Gerando matriz...");
		for (int i = 0; i < linhas; i++)
		{
			for (int j = 0; j < cols; j++)
			{
				matriz[i, j] = rand.Next(2);
			}// fim for j
		}// fim for i
	}

}
