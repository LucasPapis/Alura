namespace ScreenSound.Modelos;

internal class Avaliacao
{
    public Avaliacao(int nota)
    {
        if (nota <= 0) nota = 0;
        if (nota >= 10) nota = 10;
        Nota = nota;
    }
    public int Nota { get;}

    public static Avaliacao Parse(string texto)
    {
        bool parse = int.TryParse(texto, out int nota);
        if (!parse)
        {
            nota = 0;
        }
        return new Avaliacao(nota);
    }
}