namespace ScreenSound.Modelo;

internal class Podcast
{
    private List<Episodio> eps = new List<Episodio>();
    public Podcast(string host, string nome) 
    {
        Host = host;
        Nome = nome;
    }
    public string Host { get;}
    public string Nome { get;}
    public int TotalEpisodios => eps.Count;

    public void AdicionarEpisodio(Episodio ep)
    {
        eps.Add(ep);
    }

    public void ExibirEpsDoPodcast()
    {
        Console.WriteLine($"Apresentado por: {Host}");
        Console.WriteLine($"Total de episódios: {TotalEpisodios}");
        Console.WriteLine($"Lista de episódios do podcast {Nome}:\n");
        foreach (Episodio ep in eps.OrderBy(e => e.Ordem))
        {
            Console.WriteLine($"Episodio: {ep.Ordem} - {ep.Titulo}");
            Console.WriteLine($"Duração: {ep.Duracao}min");
            Console.WriteLine($"Resumo: {ep.Resumo}\n");
        }
    }
}

