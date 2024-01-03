using System.Globalization;
using System.Net;

namespace Atividades_requisicao_trycatch;
internal class Program
{
    internal static void Main(string[] args)
    {
        //ReqHttp();
        //TryDivisao();
        //ListaInteiros();
        //ObjetoNulo();
    }

    private static void ReqHttp()
    {
        string url = " https://www.cheapshark.com/api/1.0/deals";
        try
        {
            using (HttpClient client = new())
            {
                //O mais simples
                //string response = await client.GetStringAsync(url);
                //Console.WriteLine(response);

                //Minha prefrencia e o que eu acredito ser mais correto
                HttpResponseMessage response;
                response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"{response.Content.ReadAsStringAsync().Result}");
                }
                else
                {
                    Console.WriteLine($"{response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro desconhecido: {ex.Message}");
        }
        
    }

    private static void TryDivisao()
    {
        try
        {
            int a, b = 0;
            int resultado = 0;
            Console.Write("Digite um numero: ");
            a = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nDigite outro numero para realizar a divisão: ");
            b = Convert.ToInt32(Console.ReadLine());

            resultado = a / b;

            Console.WriteLine($"{a} / {b} = {resultado}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao dividir: {ex.Message}");
        }
    }

    private static void ListaInteiros()
    {
        try
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int inexistente = array[32];
            Console.WriteLine(inexistente);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    private static void ObjetoNulo()
    {
        try
        {
            ClasseSimples classeSimples = null;
            classeSimples.Metodo();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}