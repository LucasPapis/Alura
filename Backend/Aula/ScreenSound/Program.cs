using ScreenSound.Modelo;
using ScreenSound.Modelos;

string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
string logo = @"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░";

Banda ira = new Banda("Ira");
Banda beatles = new Banda("The Beatles");
List<int> notasIra = new List<int>() { 10, 8, 6 };
foreach (int nota in notasIra)
{
    ira.AdicionarNotas(new Avaliacao(nota));
}

//List<string> bandas = new List<string> {"AC/DC","The Beatles","Creedence Clearwater Revival"};
Dictionary<string, Banda> bandasRegistradas = new Dictionary<string, Banda>();
bandasRegistradas.Add(ira.Nome, ira);
bandasRegistradas.Add(beatles.Nome, beatles);


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
    Console.WriteLine("Digite 2 para registrar o album de uma banda");
    Console.WriteLine("Digite 3 para mostrar todas as bandas");
    Console.WriteLine("Digite 4 para avaliar uma banda");
    Console.WriteLine("Digite 5 para exibir a média de uma banda");
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
            RegistrarAlbum();
            break;
        case 3:
            ExibirBandas(true);
            break;
        case 4:
            AvaliarBanda();
            break;
        case 5:
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
        bandasRegistradas.Add(nomeDaBanda, new Banda(nomeDaBanda));
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
        if (opcaoDoMenu)
        {
            Console.WriteLine("Pressione qualquer tecla...");
            Console.ReadKey();
            ExibirOpcoesDoMenu();
        }

    }

    void RegistrarAlbum()
    {
        Console.Clear();
        ExibirTituloDaOpcao("Registro de álbuns");
        Console.Write("Digite a banda cujo álbum deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.Write("Agora digite o título do álbum: ");
            string tituloAlbum = Console.ReadLine()!;
            Banda banda = bandasRegistradas[nomeDaBanda];
            banda.AdicionarAlbum(new Album(tituloAlbum));
            Console.WriteLine($"O álbum {tituloAlbum} de {nomeDaBanda} foi registrado com sucesso!");
            Thread.Sleep(4000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        ExibirOpcoesDoMenu();
    }

    void ExibirTituloDaOpcao(string titulo)
    {
        int qtdLetras = titulo.Length;
        string asterisco = string.Empty.PadLeft(qtdLetras, '*');
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
                Banda banda = bandasRegistradas[nomeBanda];
                banda.AdicionarNotas(new Avaliacao(nota));
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
            Banda banda = bandasRegistradas[nomeBanda];
            double mediaBanda = banda.Media;

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


