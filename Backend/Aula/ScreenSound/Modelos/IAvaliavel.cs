namespace ScreenSound.Modelos;

internal interface IAvaliavel
{
    void AdicionarNotas(Avaliacao nota);
    double Media { get; }
}
