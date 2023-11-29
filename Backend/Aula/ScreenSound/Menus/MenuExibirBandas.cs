using ScreenSound.Modelo;

namespace ScreenSound.Menus;

internal class MenuExibirBandas : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
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
        Console.WriteLine("Pressione qualquer tecla...");
        Console.ReadKey();
        //ExibirOpcoesDoMenu();
    }
}
