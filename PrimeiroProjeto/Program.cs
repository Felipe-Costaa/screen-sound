// Screen Sound
//List<string> listasDasBandas = new List<string>{"Matanza", "Calypso", "The Beatles"};

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Matanza", new List<int> {10, 9, 9});
bandasRegistradas.Add("Calypso", new List<int>());
bandasRegistradas.Add("The Beatles", new List<int>());
bandasRegistradas.Add("Iron Maiden", new List<int>());
void ExibirLogo()
{
    Console.WriteLine(@"

█▀ █▀▀ █▀█ █▀▀ █▀▀ █▄░█   █▀ █▀█ █░█ █▄░█ █▀▄
▄█ █▄▄ █▀▄ ██▄ ██▄ █░▀█   ▄█ █▄█ █▄█ █░▀█ █▄▀
");
    Console.WriteLine("Bem-vindo ao Screen Sound!");
}

void ExibirOpcoesDoMenu() 
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para exibir todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a media de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    
    switch (opcaoEscolhidaNumerica)
    {
        case 1: 
            RegistrarBanda();
            break;
        case 2:
            MostrarBandasRegistradas();
            break;
        case 3:
            AvaliarBanda();
            break;
        case 4:
            MostrarMediaDaBanda();
            break;
        case -1:
            Console.WriteLine("Saindo...");
            break;
        default:
            Console.WriteLine("Opção inválida, tente novamente.");
            ExibirOpcoesDoMenu();
            break;
    }

}
void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloOpcao("Registro de bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}
void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloOpcao("Exibindo todas as bandas registradas");
    //for (int i = 0; i<listasDasBandas.Count; i++)
    //{
    //    Console.riteLine($"Banda: {listasDasBandas[i]}");
    //};
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    };
    Console.WriteLine("Digite qualquer tecla para continuar...");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}
void ExibirTituloOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}
void AvaliarBanda()
{
    Console.Clear();
    ExibirTituloOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Digite a nota que deseja dar para a banda {nomeDaBanda}: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"A nota {nota} foi registrada para a banda {nomeDaBanda} com sucesso!");
    }
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não está registrada.");
    }
    Thread.Sleep(2000);
    Console.Clear();
}
void MostrarMediaDaBanda()
{ 
    Console.Clear();
    ExibirTituloOpcao("Exibir média da banda");
    Console.Write("Digite o nome da banda que deseja ver a média: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine("Calculando a media da banda...");
        Thread.Sleep(2000);
        int quantidadeNotas = bandasRegistradas[nomeDaBanda].Count();
        int totalNotas = bandasRegistradas[nomeDaBanda].Sum();
        double mediaBanda = (double)totalNotas / quantidadeNotas;
        Console.WriteLine($"A media da banda {nomeDaBanda} é: {mediaBanda}");
    }
    else
    {
        Console.WriteLine("Banda não encontrada!");
        Console.WriteLine("Pressione qualquer tecla para retornar ao menu principal...");
        Console.ReadKey();
    }
}

ExibirOpcoesDoMenu();