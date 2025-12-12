using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TrabalhoComputacao
{
    // --- ESTRUTURA DA BANDA ---
    public class Banda
    {
        public string Nome { get; set; }
        public string Genero { get; set; }
        public int Integrantes { get; set; }
        public int Ranking { get; set; }

        // Formatação bonita para exibir na tela
        public override string ToString()
        {
            return $"Rank: {Ranking} | Nome: {Nome} | Gênero: {Genero} | Integrantes: {Integrantes}";
        }
    }

    class Program
    {
        // Lista que guarda as bandas na memória
        static List<Banda> bandas = new List<Banda>();
        // Nome do arquivo onde os dados serão salvos
        static string caminhoArquivo = "bandas.txt";

        static void Main(string[] args)
        {
            int opcao = 0;
            do
            {
                // --- MENU PRINCIPAL ---
                Console.Clear();
                Console.WriteLine("=== GESTÃO DE BANDAS (Prof. Matheus Franco) ===");
                Console.WriteLine("1 - Cadastrar Banda (a)");
                Console.WriteLine("2 - Listar todas (b)");
                Console.WriteLine("3 - Salvar em Arquivo (c)");
                Console.WriteLine("4 - Carregar do Arquivo (c/i)");
                Console.WriteLine("5 - Buscar por Ranking (d)");
                Console.WriteLine("6 - Buscar por Gênero (e)");
                Console.WriteLine("7 - Buscar por Nome (f)");
                Console.WriteLine("8 - Excluir Banda (g)");
                Console.WriteLine("9 - Alterar Banda (h)");
                Console.WriteLine("0 - Sair");
                Console.Write("\nEscolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1: CadastrarBanda(); break;
                        case 2: ListarBandas(); break;
                        case 3: SalvarDados(); break;
                        case 4: CarregarDados(); break;
                        case 5: BuscarPorRanking(); break;
                        case 6: BuscarPorGenero(); break;
                        case 7: BuscarPorNome(); break;
                        case 8: ExcluirBanda(); break;
                        case 9: AlterarBanda(); break;
                        case 0: Console.WriteLine("Saindo..."); break;
                        default: Console.WriteLine("Opção inválida!"); break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, digite um número.");
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 0);
        }

        // a) Cadastrar Banda
        static void CadastrarBanda()
        {
            Console.Clear();
            Banda b = new Banda();
            Console.WriteLine("--- CADASTRO DE BANDA ---");
            
            Console.Write("Nome da Banda: ");
            b.Nome = Console.ReadLine();
            
            Console.Write("Gênero Musical: ");
            b.Genero = Console.ReadLine();
            
            Console.Write("Número de Integrantes: ");
            int integrantes;
            while(!int.TryParse(Console.ReadLine(), out integrantes)) 
                Console.Write("Número inválido. Digite novamente: ");
            b.Integrantes = integrantes;

            Console.Write("Posição no Ranking: ");
            int ranking;
            while (!int.TryParse(Console.ReadLine(), out ranking))
                Console.Write("Número inválido. Digite novamente: ");
            b.Ranking = ranking;

            bandas.Add(b);
            Console.WriteLine("\nBanda cadastrada com sucesso!");
        }

        // b) Listar Todas
        static void ListarBandas()
        {
            Console.Clear();
            Console.WriteLine("--- LISTA DE BANDAS ---");
            if (bandas.Count == 0)
            {
                Console.WriteLine("Nenhuma banda cadastrada.");
                return;
            }

            // Ordena pelo ranking antes de mostrar
            var listaOrdenada = bandas.OrderBy(x => x.Ranking).ToList();

            foreach (var b in listaOrdenada)
            {
                Console.WriteLine(b.ToString());
            }
        }

        // c) Salvar Dados
        static void SalvarDados()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(caminhoArquivo))
                {
                    foreach (var b in bandas)
                    {
                        // Formato: Nome|Genero|Integrantes|Ranking
                        sw.WriteLine($"{b.Nome}|{b.Genero}|{b.Integrantes}|{b.Ranking}");
                    }
                }
                Console.WriteLine($"Dados salvos com sucesso em '{caminhoArquivo}'.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao salvar: {e.Message}");
            }
        }

        // c) Carregar Dados
        static void CarregarDados()
        {
            if (File.Exists(caminhoArquivo))
            {
                try
                {
                    bandas.Clear(); // Limpa a lista atual para não duplicar
                    using (StreamReader sr = new StreamReader(caminhoArquivo))
                    {
                        string linha;
                        while ((linha = sr.ReadLine()) != null)
                        {
                            string[] dados = linha.Split('|');
                            if (dados.Length == 4)
                            {
                                Banda b = new Banda
                                {
                                    Nome = dados[0],
                                    Genero = dados[1],
                                    Integrantes = int.Parse(dados[2]),
                                    Ranking = int.Parse(dados[3])
                                };
                                bandas.Add(b);
                            }
                        }
                    }
                    Console.WriteLine("Dados carregados com sucesso!");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro ao ler arquivo: {e.Message}");
                }
            }
            else
            {
                Console.WriteLine("Arquivo de dados não encontrado. Cadastre novas bandas e salve.");
            }
        }

        // d) Buscar por Ranking
        static void BuscarPorRanking()
        {
            Console.Write("\nDigite a posição do ranking que deseja buscar: ");
            if (int.TryParse(Console.ReadLine(), out int rank))
            {
                var encontradas = bandas.Where(b => b.Ranking == rank).ToList();
                if (encontradas.Count > 0)
                    encontradas.ForEach(x => Console.WriteLine(x.ToString()));
                else
                    Console.WriteLine("Nenhuma banda encontrada nesta posição.");
            }
        }

        // e) Buscar por Gênero
        static void BuscarPorGenero()
        {
            Console.Write("\nDigite o gênero musical: ");
            string genero = Console.ReadLine().ToLower();
            
            var encontradas = bandas.Where(b => b.Genero.ToLower().Contains(genero)).ToList();

            if (encontradas.Count > 0)
                encontradas.ForEach(x => Console.WriteLine(x.ToString()));
            else
                Console.WriteLine("Nenhuma banda encontrada com este gênero.");
        }

        // f) Buscar por Nome
        static void BuscarPorNome()
        {
            Console.Write("\nDigite o nome da banda: ");
            string nome = Console.ReadLine().ToLower();
            
            var encontrada = bandas.FirstOrDefault(b => b.Nome.ToLower() == nome);

            if (encontrada != null)
                Console.WriteLine(encontrada.ToString());
            else
                Console.WriteLine("Banda não encontrada.");
        }

        // g) Excluir Banda
        static void ExcluirBanda()
        {
            Console.Write("\nDigite o nome da banda para excluir: ");
            string nome = Console.ReadLine();
            
            // Busca ignorando maiúsculas/minúsculas
            var banda = bandas.FirstOrDefault(b => b.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (banda != null)
            {
                bandas.Remove(banda);
                Console.WriteLine($"Banda '{banda.Nome}' removida com sucesso.");
            }
            else
            {
                Console.WriteLine("Banda não encontrada para exclusão.");
            }
        }

        // h) Alterar Banda
        static void AlterarBanda()
        {
            Console.Write("\nDigite o nome da banda que deseja alterar: ");
            string nome = Console.ReadLine();
            
            var banda = bandas.FirstOrDefault(b => b.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (banda != null)
            {
                Console.WriteLine($"\nBanda encontrada: {banda.Nome}");
                Console.WriteLine("Digite os novos dados (ou repita os antigos):");

                Console.Write("Novo Nome: ");
                banda.Nome = Console.ReadLine();

                Console.Write("Novo Gênero: ");
                banda.Genero = Console.ReadLine();

                Console.Write("Novo Nº Integrantes: ");
                if(int.TryParse(Console.ReadLine(), out int integ)) banda.Integrantes = integ;

                Console.Write("Novo Ranking: ");
                if(int.TryParse(Console.ReadLine(), out int rank)) banda.Ranking = rank;

                Console.WriteLine("Dados atualizados com sucesso.");
            }
            else
            {
                Console.WriteLine("Banda não encontrada.");
            }
        }
    }
}