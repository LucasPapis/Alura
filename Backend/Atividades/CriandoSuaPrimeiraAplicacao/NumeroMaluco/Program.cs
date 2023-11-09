string titulo,resposta;
int numeroEscolhido,numeroFake1,numeroFake2,numeroFake3,opcaoEscolhida;
int ultimoNumeroGerado = 0;
bool conversao;
bool gameOver = false;

titulo = @"
███╗░░██╗██╗░░░██╗███╗░░░███╗███████╗██████╗░░█████╗░  ███╗░░░███╗░█████╗░██╗░░░░░██╗░░░██╗░█████╗░░█████╗░
████╗░██║██║░░░██║████╗░████║██╔════╝██╔══██╗██╔══██╗  ████╗░████║██╔══██╗██║░░░░░██║░░░██║██╔══██╗██╔══██╗
██╔██╗██║██║░░░██║██╔████╔██║█████╗░░██████╔╝██║░░██║  ██╔████╔██║███████║██║░░░░░██║░░░██║██║░░╚═╝██║░░██║
██║╚████║██║░░░██║██║╚██╔╝██║██╔══╝░░██╔══██╗██║░░██║  ██║╚██╔╝██║██╔══██║██║░░░░░██║░░░██║██║░░██╗██║░░██║
██║░╚███║╚██████╔╝██║░╚═╝░██║███████╗██║░░██║╚█████╔╝  ██║░╚═╝░██║██║░░██║███████╗╚██████╔╝╚█████╔╝╚█████╔╝
╚═╝░░╚══╝░╚═════╝░╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚═╝░╚════╝░  ╚═╝░░░░░╚═╝╚═╝░░╚═╝╚══════╝░╚═════╝░░╚════╝░░╚════╝░";



void ExibeTitulo()
{
    Console.WriteLine(titulo);
    Console.Write("\nVou escolher um numero entre 1 e 100! \nConsegue adivinhar qual é?\n\n");
}

int GerarNumero()
{
    int numeroAleatorio = 0;
    bool teste = true;
    Random rand = new Random();
    while (teste)
    {
        numeroAleatorio = rand.Next(1, 101);
        if (numeroAleatorio == ultimoNumeroGerado)
        {
            numeroAleatorio = rand.Next(1, 101);
        }
        else
        {
            teste = false;
        }
    }
    ultimoNumeroGerado = numeroAleatorio;
    return numeroAleatorio;
}

void EmbaralharArray(int[] array)
{
    // Embaralhe os elementos do array usando o algoritmo de Fisher-Yates
    Random random = new Random();
    //Percorre de maneira inversa o array
    for (int i = array.Length - 1; i > 0; i--)
    {
        int j = random.Next(0, i + 1); //Gera um numero aleatório entre 0 e o indice atual
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}

void ExibeRespostas()
{
    while (!gameOver)
    {
        numeroEscolhido = GerarNumero();
        numeroFake1 = GerarNumero();
        numeroFake2 = GerarNumero();
        numeroFake3 = GerarNumero();

        int[] opcoes = { numeroFake1, numeroEscolhido, numeroFake2, numeroFake3 };
        List<int> numerosVistos = new List<int>();
        EmbaralharArray(opcoes);
        for (int i = 0; i < opcoes.Length; i++)
        {

            Console.WriteLine($"Opção {i+1}: {opcoes[i]}");
        }

        Console.Write("Ecolha uma opção: ");
        resposta = Console.ReadLine()!;

        conversao = int.TryParse(resposta, out opcaoEscolhida);
        if (conversao)
        {
            if (opcaoEscolhida >= 1 && opcaoEscolhida <= opcoes.Length)
            {
                if (opcoes[opcaoEscolhida -1] == numeroEscolhido)
                {
                    Console.WriteLine("\nParabéns, você é um vidente e acertou o numero que eu escolhi!");
                    gameOver = true;
                }
                else
                {
                    Console.WriteLine("\nHmm, ainda não acertou... \nTenta de novo e vai na fé, agora vc acerta!\n");
                    gameOver = false;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida.");
                gameOver = false;
            }
        }
        else
        {
            Console.WriteLine("Só é permitido selecionar uma opção acima.");
            gameOver = false;
        }
    }
}


ExibeTitulo();
ExibeRespostas();