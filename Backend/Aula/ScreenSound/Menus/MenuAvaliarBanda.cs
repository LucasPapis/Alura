using ScreenSound.Modelo;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuAvaliarBanda : Menu
{
    public void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        Console.Clear();
        ExibirTituloDaOpcao("Avaliar Banda");
        //ExibirBandas(false,bandasRegistradas);
        Console.Write("Digite o nome da banda que deseja avaliar: ");
        string nomeBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeBanda))
        {
            Console.Write($"Qual a nota que a banda {nomeBanda} merece: ");
            //bool inteiro = int.TryParse(Console.ReadLine()!, out int nota);
            //if (inteiro)
            //{
            Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
            Banda banda = bandasRegistradas[nomeBanda];
            banda.AdicionarNotas(nota);
            Console.WriteLine($"A nota {nota.Nota} foi registrada com sucesso.");
            Thread.Sleep(2000);
            //}
            //else
            //{
            //    Console.WriteLine("A nota deve ser um numero inteiro.");
            //    Thread.Sleep(2000);
            //    AvaliarBanda();
            //}

        }
        else
        {
            Console.WriteLine($"A banda {nomeBanda} não foi encontrada.");
            Console.WriteLine("Pressione uma tecla para voltar ao menu.");
            Console.ReadKey();
        }
    }
}

