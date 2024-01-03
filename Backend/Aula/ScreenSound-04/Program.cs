using (HttpClient client = new())
{
	try
	{
        string response = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        Console.WriteLine(response);
    }
	catch (Exception ex)
	{
		Console.WriteLine($"Deu merda. {ex.Message}");
	}
}