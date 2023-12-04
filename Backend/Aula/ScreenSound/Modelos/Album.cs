using ScreenSound.Modelos;

namespace ScreenSound.Modelo;

internal class Album : IAvaliavel
{
    private List<Musica> musicas = new List<Musica>();
    public static int contadorDeObjetos = 0;
    private List<Avaliacao> notas = new List<Avaliacao>();
    public Album(string nome)
    {
        Nome = nome;
        contadorDeObjetos++;
    }

    public string Nome { get; }
    public int DuracaoTotal => musicas.Sum(m => m.Duracao);

    public double Media
    {
        get
        {
            if (notas.Count == 0)
            {
                return 0;
            }
            else
            {
                return notas.Average(a => a.Nota);
            }
        }
    }

    public void AdicionaMusica(Musica musica)
    {
        musicas.Add(musica);
    }

    public void ExibirMusicasDoAlbum()
    {
        Console.WriteLine($"Lista de musicas do albúm {Nome}:\n");
        foreach (Musica musica in musicas)
        {
            Console.WriteLine($"Musica: {musica.Nome}");
        }
        Console.WriteLine($"\nDuração total do album: {DuracaoTotal} segundos");
    }

    public void AdicionarNotas(Avaliacao nota)
    {
        notas.Add(nota);
    }
}

