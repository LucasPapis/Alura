using ScreenSound.Modelo;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuAvaliarAlbum : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Avaliar Banda");
        Console.Write("Digite o nome da banda que deseja avaliar: ");
        string nomeBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeBanda))
        {
            Banda banda = bandasRegistradas[nomeBanda];
            Console.Write($"Qual o album de {banda.Nome} que deseja avaliar? ");
            string nomeAlbum = Console.ReadLine()!;
            if (banda.albums.Any(a => a.Nome.Equals(nomeAlbum)))
            {
                Album album = banda.albums.First(a => a.Nome.Equals(nomeAlbum));
                Console.Write($"Qual a nota que o album {nomeAlbum} merece: ");
                Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
                album.AdicionarNotas(nota);
                Console.WriteLine($"\nA nota {nota.Nota} foi registrada com sucesso para o album {nomeAlbum}.");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine($"\nO album {nomeAlbum} não foi encontrada.");
                Console.WriteLine("Pressione uma tecla para voltar ao menu.");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine($"A banda {nomeBanda} não foi encontrada.");
            Console.WriteLine("Pressione uma tecla para voltar ao menu.");
            Console.ReadKey();
        }
    }
}
