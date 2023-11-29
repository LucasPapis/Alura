using ScreenSound.Modelo;

namespace ScreenSound.Menus;

internal class Menu
{
    public void ExibirTituloDaOpcao(string titulo)
    {
        int qtdLetras = titulo.Length;
        string asterisco = string.Empty.PadLeft(qtdLetras, '*');
        Console.WriteLine(asterisco);
        Console.WriteLine(titulo);
        Console.WriteLine(asterisco + "\n");
    }

    public virtual void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        Console.Clear();
    }
}
