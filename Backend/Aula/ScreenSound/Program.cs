List<Episodio> eps = new List<Episodio>()
{
    new Episodio(45,1,"Tecnicas de Facilitação"),
    new Episodio(60, 2, "Tecnicas de Aprendizado")
};
Dictionary<int, List<string>> convidados = new Dictionary<int, List<string>>() 
{
    {0, new List<string>{"Maria", "Marcio", "Lucas" }},
    {1, new List<string>{ "Josué", "Cibele", "Monica" }}
};
int index = 0;
Podcast pod = new Podcast("Lucas", "Podcast Foda");
foreach (Episodio ep in eps)
{
    foreach (var item in convidados[index].ToList())
    {
        ep.AdicionarConvidados(item);
    }
    pod.AdicionarEpisodio(ep);
    index++;
}

pod.ExibirEpsDoPodcast();




