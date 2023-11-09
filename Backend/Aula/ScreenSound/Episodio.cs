class Episodio
{
    private List<string> convidados = new List<string>();
    public Episodio(int duracao, int ordem, string titulo) 
    {
        Duracao = duracao;
        Ordem = ordem;
        Titulo = titulo;
    }
    public int Duracao { get;}
    public int Ordem { get;}
    public string Resumo => $"{Ordem} - {Titulo} - ({Duracao} min) - Convidados: {string.Join(", ", convidados)} ";
    public string Titulo { get;}

    public void AdicionarConvidados(string convidado)
    {
        convidados.Add(convidado);
    }
}

