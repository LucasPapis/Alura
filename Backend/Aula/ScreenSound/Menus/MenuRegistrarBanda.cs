using ScreenSound.Modelo;

namespace ScreenSound.Menus;

internal class MenuRegistrarBanda : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        bandasRegistradas.Add(nomeDaBanda, new Banda(nomeDaBanda));
        Console.WriteLine($"A banda {nomeDaBanda} foi resgistrada com sucesso!");
        Thread.Sleep(2000);
        //ExibirOpcoesDoMenu();
    }
}
