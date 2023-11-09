namespace ScreenSound.Modelo;

internal class Musica
{
    public Musica(Banda artista, string nome)
    {
        Artista = artista;
        Nome = nome;
    }

    public string Nome  { get; }
    public Banda Artista  { get; }
    public int Duracao { get; set; }
    public bool Disponivel { get; set; }

    //public string DescricaoResumida
    //{
    //    get
    //    {
    //        return $"A música {Nome} pertence a banda {Artista}";
    //    }
    //}
    //Atribuido quando uma propriedade só possui get, dá no mesmo da função de cima
    public string DescricaoResumida => $"A música {Nome} pertence a banda {Artista.Nome}";

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Artista: {Artista.Nome}");
        Console.WriteLine($"Duração: {Duracao}");
        if (Disponivel)
        {
            Console.WriteLine($"Disponível no plano");
        }
        else
        {
            Console.WriteLine("Não dispónível nesse plano");
        }
        Console.WriteLine(DescricaoResumida);
        Console.WriteLine("\n");
    }
}
