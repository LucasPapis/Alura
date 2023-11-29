using ScreenSound.Modelo;

namespace ScreenSound.Menus;

internal class MenuExibirDetalhes : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Média da banda");
        Console.Write("Digite o nome da banda que deseja conhecer melhor: ");
        string nomeBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeBanda))
        {
            Banda banda = bandasRegistradas[nomeBanda];
            //double mediaBanda = banda.Media;
            Console.WriteLine($"\nAvaliação da banda {nomeBanda} é {banda.Media}.");
            Thread.Sleep(4000);
            //ExibirOpcoesDoMenu();
        }
        else
        {
            Console.WriteLine($"A banda {nomeBanda} não foi encontrada.");
            Console.WriteLine("Pressione uma tecla para voltar ao menu.");
            Console.ReadKey();
            //ExibirOpcoesDoMenu();
        }
    }
}

