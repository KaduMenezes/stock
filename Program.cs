using System;
using System.Collections.Generic;

class Produto
{
    public string Nome { get; set; }
    public int Quantidade { get; set; }
}

class Program
{
    static List<Produto> estoque = new List<Produto>
    {
        new Produto { Nome = "Laptop", Quantidade = 10 },
        new Produto { Nome = "Smartphone", Quantidade = 20 },
        new Produto { Nome = "Tablet", Quantidade = 15 },
        new Produto { Nome = "Headphones", Quantidade = 30 },
        new Produto { Nome = "Câmera", Quantidade = 25 }
    };

    static void Main()
    {
        int escolha;
        do
        {
            MostrarMenu();
            escolha = LerEscolha();

            switch (escolha)
            {
                case 1:
                    MostrarEstoque();
                    break;
                case 2:
                    AdicionarProduto();
                    break;
                case 3:
                    RemoverProduto();
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Escolha inválida. Tente novamente.");
                    break;
            }

        } while (escolha != 4);
    }

    static void MostrarMenu()
    {
        Console.WriteLine("==== Controle de Estoque ====");
        Console.WriteLine("1. Mostrar Estoque");
        Console.WriteLine("2. Adicionar Produto");
        Console.WriteLine("3. Remover Produto");
        Console.WriteLine("4. Sair");
    }

    static int LerEscolha()
    {
        Console.Write("Escolha uma opção: ");
        int escolha = Convert.ToInt32(Console.ReadLine());
        return escolha;
    }

    static void MostrarEstoque()
    {
        Console.WriteLine("\n=== Estoque Atual ===");
        foreach (var produto in estoque)
        {
            Console.WriteLine($"{produto.Nome}: {produto.Quantidade} unidades");
        }
        Console.WriteLine("=====================\n");
    }

    static void AdicionarProduto()
    {
        Console.WriteLine("\n=== Adicionar Produto ===");
        MostrarEstoque();

        Console.Write("Digite o nome do produto que deseja adicionar: ");
        string nome = Console.ReadLine();

        Produto produtoExistente = estoque.Find(p => p.Nome == nome);

        if (produtoExistente != null)
        {
            Console.Write("Digite a quantidade a ser adicionada: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            produtoExistente.Quantidade += quantidade;
            Console.WriteLine("Estoque atualizado com sucesso!\n");
        }
        else
        {
            Console.WriteLine("Produto não encontrado.\n");
        }
    }

    static void RemoverProduto()
    {
        Console.WriteLine("\n=== Remover Produto ===");
        MostrarEstoque();

        Console.Write("Digite o nome do produto que deseja remover: ");
        string nome = Console.ReadLine();

        Produto produtoExistente = estoque.Find(p => p.Nome == nome);

        if (produtoExistente != null)
        {
            Console.Write("Digite a quantidade a ser removida: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            if (quantidade <= produtoExistente.Quantidade)
            {
                produtoExistente.Quantidade -= quantidade;
                Console.WriteLine("Estoque atualizado com sucesso!\n");
            }
            else
            {
                Console.WriteLine("Quantidade insuficiente em estoque.\n");
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado.\n");
        }
    }
}
