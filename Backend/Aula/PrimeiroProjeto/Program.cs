//Screen Sound
using System.Xml;

string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
string logo = @"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░";
//List<string> bandas = new List<string> {"AC/DC","The Beatles","Creedence Clearwater Revival"};
Dictionary<string,List<int>> bandasRegistradas = new Dictionary<string,List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int> { 10, 8, 6 });
bandasRegistradas.Add("The Beatles", new List<int>());


void ExibirLogo()
{
    Console.Clear();
    Console.WriteLine(logo);
    Console.WriteLine(mensagemDeBoasVindas);
}
void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas"); 
    Console.WriteLine("Digite 3 para avaliar uma banda"); 
    Console.WriteLine("Digite 4 para exibir a média de uma banda"); 
    Console.WriteLine("Digite 0 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            ExibirBandas(true);
            break;
        case 3:
            AvaliarBanda();
            break;
        case 4:
            MediaBanda();
            break;
        case 0:
            Console.WriteLine("Você escolheu sair... ");
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

    void RegistrarBanda()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        bandasRegistradas.Add(nomeDaBanda,new List<int>());
        Console.WriteLine($"A banda {nomeDaBanda} foi resgistrada com sucesso!");
        Thread.Sleep(2000);
        ExibirOpcoesDoMenu();
    }

    void ExibirBandas(bool opcaoDoMenu)
    {
        Console.Clear();
        ExibirTituloDaOpcao("Bandas registradas");

        //for (int i = 0; i < bandasRegistradas.Keys.Count; i++)
        //{
        //    Console.WriteLine($"{i + 1} - {bandasRegistradas[i]}");
        //}
        int index = 0;
        foreach (string banda in bandasRegistradas.Keys)
        {
            index++;
            Console.WriteLine($"{index} - {banda}");
        }
        Console.Write("\n");
        if ( opcaoDoMenu )
        {
            Console.WriteLine("Pressione qualquer tecla...");
            Console.ReadKey();
            ExibirOpcoesDoMenu();
        }
       
    }

    void ExibirTituloDaOpcao(string titulo)
    {
        int qtdLetras = titulo.Length;
        string asterisco = string.Empty.PadLeft(qtdLetras,'*');
        Console.WriteLine(asterisco);
        Console.WriteLine(titulo);
        Console.WriteLine(asterisco + "\n");
    }
    void AvaliarBanda()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Avaliar Banda");
        ExibirBandas(false);
        Console.Write("Digite o nome da banda que deseja avaliar: ");
        string nomeBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeBanda))
        {
            Console.Write($"Qual a nota que a banda {nomeBanda} merece: ");
            bool inteiro = int.TryParse(Console.ReadLine()!, out int nota);
            if (inteiro)
            {
                bandasRegistradas[nomeBanda].Add(nota);
                Console.WriteLine($"A nota {nota} foi registrada com sucesso.");
                Thread.Sleep(2000);
                ExibirOpcoesDoMenu();
            }
            else
            {
                Console.WriteLine("A nota deve ser um numero inteiro.");
                Thread.Sleep(2000);
                AvaliarBanda();
            }
           
        }
        else
        {
            Console.WriteLine($"A banda {nomeBanda} não foi encontrada.");
            Console.WriteLine("Pressione uma tecla para voltar ao menu.");
            Console.ReadKey();
            ExibirOpcoesDoMenu();
        }
    }

    void MediaBanda()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Média da banda");
        ExibirBandas(false);
        Console.Write("Digite o nome de uma banda para ver sua média de avaliações: ");
        string nomeBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeBanda))
        {
            double mediaBanda = bandasRegistradas[nomeBanda].Average();
            Console.WriteLine($"Avaliação da banda {nomeBanda}: nota {mediaBanda}");
            Thread.Sleep(4000);
            ExibirOpcoesDoMenu();
        }
        else
        {
            Console.WriteLine($"A banda {nomeBanda} não foi encontrada.");
            Console.WriteLine("Pressione uma tecla para voltar ao menu.");
            Console.ReadKey();
            ExibirOpcoesDoMenu();
        }
    }
}

ExibirOpcoesDoMenu();


