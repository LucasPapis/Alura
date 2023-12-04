using ScreenSound.Menus;
using ScreenSound.Modelo;
using ScreenSound.Modelos;


internal class Program
{
    private static void Main(string[] args)
    {
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

        Dictionary<int, Menu> opcoes = new Dictionary<int, Menu>();
        opcoes.Add(1, new MenuRegistrarBanda());
        opcoes.Add(2, new MenuRegistrarAlbum());
        opcoes.Add(3, new MenuExibirBandas());
        opcoes.Add(4, new MenuAvaliarBanda());
        opcoes.Add(5, new MenuAvaliarAlbum());        
        opcoes.Add(6, new MenuExibirDetalhes());
        opcoes.Add(0, new MenuSair());


        void ExibirLogo()
        {
            Console.Clear();
            Console.WriteLine(logo);
            Console.WriteLine(mensagemDeBoasVindas);
            Console.WriteLine($"\nTotal de objetos album criados: {Album.contadorDeObjetos}\n");
        }
        void ExibirOpcoesDoMenu()
        {
            ExibirLogo();
            Console.WriteLine("\nDigite 1 para registrar uma banda");
            Console.WriteLine("Digite 2 para registrar o album de uma banda");
            Console.WriteLine("Digite 3 para mostrar todas as bandas");
            Console.WriteLine("Digite 4 para avaliar uma banda");
            Console.WriteLine("Digite 5 para avaliar o album de uma banda");
            Console.WriteLine("Digite 6 para exibir detalhes de uma banda");
            Console.WriteLine("Digite 0 para sair");

            Console.Write("\nDigite a sua opção: ");
            string opcaoEscolhida = Console.ReadLine()!;
            bool opcaoNumero = int.TryParse(opcaoEscolhida, out int opcaoEscolhidaNumerica);
            if (opcaoNumero && opcoes.ContainsKey(opcaoEscolhidaNumerica))
            {
                Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
                menuASerExibido.Executar(bandasRegistradas);
                if (opcaoEscolhidaNumerica > 0)
                {
                    ExibirOpcoesDoMenu();
                }
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }

            //switch (opcaoEscolhidaNumerica)
            //{
            //    case 1:
            //        MenuRegistrarBanda menu1 = new MenuRegistrarBanda();
            //        menu1.Executar(bandasRegistradas);
            //        ExibirOpcoesDoMenu();
            //        break;
            //    case 2:
            //        MenuRegistrarAlbum menu2 = new MenuRegistrarAlbum();
            //        menu2.Executar(bandasRegistradas);
            //        ExibirOpcoesDoMenu();
            //        break;
            //    case 3:
            //        MenuExibirBandas menu3 = new MenuExibirBandas();
            //        menu3.Executar(bandasRegistradas);
            //        ExibirOpcoesDoMenu();
            //        break;
            //    case 4:
            //        MenuAvaliarBanda menu4 = new MenuAvaliarBanda();
            //        menu4.Executar(bandasRegistradas);
            //        ExibirOpcoesDoMenu();
            //        break;
            //    case 5:
            //        Console.Clear();
            //        MenuExibirDetalhes menu5 = new MenuExibirDetalhes();
            //        //ExibirBandas(false);
            //        menu5.Executar(bandasRegistradas);
            //        ExibirOpcoesDoMenu();
            //        break;
            //    case 0:
            //        Console.WriteLine("Você escolheu sair... ");
            //        break;
            //    default:

            //        break;
            //}
        }
        ExibirOpcoesDoMenu();
    }
}