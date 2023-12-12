using ScreenSound.Modelos;

namespace ScreenSound.Modelo;

internal class Banda : IAvaliavel
{
    private List<Album> albums = new List<Album>();
    private List<Avaliacao> notas = new List<Avaliacao>();

    public IEnumerable<Album> Albuns => albums;

    public Banda(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; }
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
    public void AdicionarAlbum(Album album)
    {
        albums.Add(album);
    }
    public void AdicionarNotas(Avaliacao lNotas)
    {
        notas.Add(lNotas);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia da banda {Nome}");
        foreach (Album album in Albuns)
        {
            Console.WriteLine($"Álbum: {album.Nome} ({album.DuracaoTotal})");
        }
    }
}