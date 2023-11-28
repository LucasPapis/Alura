namespace ScreenSound.Modelo;

internal class Album
{
    private List<Musica> musicas = new List<Musica>();
    public static int contadorDeObjetos = 0;
    public Album(string nome)
    {
        Nome = nome;
        contadorDeObjetos++;
    }

    public string Nome { get; }
    public int DuracaoTotal => musicas.Sum(m => m.Duracao);
    
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
}

