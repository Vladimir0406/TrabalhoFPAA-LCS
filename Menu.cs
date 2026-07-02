using System.Diagnostics;
class Menu()
{
    LCS OperacoesLCS = new();
    public int GetOpcaoMenuInicial()
    {
        Console.Clear();

        Console.WriteLine("=========================");
        Console.WriteLine("      Algoritmo LCS      ");
        Console.WriteLine("=========================\n");
        Console.WriteLine(" 1 - Usar algoritmos LCS");
        Console.WriteLine(" 2 - Comparar LCS");
        Console.WriteLine(" 3 - Sair\n");

        return TratarOpcao(Console.ReadLine(), 3);
    }
    public void ExecutaMenuInicial(int opcao)
    {
        int escolha;
        if (!TratarErro(opcao))
            return;

        switch (opcao)
        {
            case 1:
                do
                {
                    Console.Clear();

                    Console.WriteLine("\n    Versões LCS                        ");
                    Console.WriteLine("=========================================");
                    Console.WriteLine(" 1 - LCS Recursivo Programação dinâmica  ");
                    Console.WriteLine(" 2 - LCS Recursivo com index");
                    Console.WriteLine(" 3 - LCS Recursivo sem index");
                    Console.WriteLine(" 4 - Voltar\n");

                    escolha = TratarOpcao(Console.ReadLine(), 4);

                } while (!TratarErro(escolha) || !ExecutarMenuVersoes(escolha));
                break;
            case 2:
                do
                {
                    Console.Clear();

                    Console.WriteLine("\n    Comparação Algoritmos LCS          ");
                    Console.WriteLine("=========================================\n");
                    Console.WriteLine(" 1 - LCS Recursivo Programação dinâmica  ");
                    Console.WriteLine(" 2 - LCS Recursivo com index");
                    Console.WriteLine(" 3 - LCS Recursivo sem index");
                    Console.WriteLine(" 4 - Voltar\n");

                    Console.Write(" Primeiro algoritmo  : ");
                    escolha = TratarOpcao(Console.ReadLine(), 4);

                    if (escolha == 4)
                    {
                        Console.WriteLine("\n  Voltando a página anterior...");
                        Thread.Sleep(400);
                        break;
                    }

                    int alg;
                    if (TratarErro(escolha))
                        alg = escolha;
                    else
                        continue;

                    Console.Write(" Segundo algoritmo   : ");
                    escolha = TratarOpcao(Console.ReadLine(), 4);

                    if (escolha == 4 || !TratarErro(escolha))
                        break;

                    if (alg != escolha)
                        ExecutarComparacao(alg, escolha);
                    else
                    {
                        Console.WriteLine("\n   Escolhas inválidas, algoritmos iguais.");
                        Console.ReadKey(true);
                    }

                } while (escolha != 4);
                break;
            case 3:
                Console.Write("Finalizando programa.");
                for (int i = 0; i < 4; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(500);
                }
                break;
        }
    }
    public bool ExecutarMenuVersoes(int escolha)
    {
        Stopwatch stopwatch = new();  // Criação de stopwatch para medição do tempo
        string a, b;
        switch (escolha)
        {
            case 1:
                Console.Clear();

                Console.WriteLine("\n  LCS Dinâmico                                 ");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine(" Esse algoritmo LCS é recursivo e utiliza programação dinâmica na abordagem bottom-up que soluciona as versões menores do problema primeiro e armazena as soluções encontradas em uma matriz para evitar os recalculos reduzindo sua complexidade para polinômial.\n");

                Console.Write(" String 1 : ");
                a = Console.ReadLine();
                Console.Write(" String 2 : ");
                b = Console.ReadLine();

                string[,] M1 = new string[a.Length, b.Length];
                int[,] M2 = new int[a.Length, b.Length];

                Console.WriteLine($"\n[{OperacoesLCS.StringPD(a, b, 0, 0, M1)}] é o LCS de tamanho [{OperacoesLCS.IntPD(a, b, 0, 0, M2)}] entre entre string 1 e 2.");

                Console.WriteLine("\n[Pressione alguma tecla para continuar]");
                Console.ReadKey(true);
                break;
            case 2:
                Console.Clear();

                Console.WriteLine("\n  LCS Recursivo Usando Index                   ");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine(" O algoritmo LCS pode ser feito de diversas maneiras, umas delas com o uso de index para controlar as iterações e acessos a substrings. Nesta versão da implementação do algoritmo LCS são utilizados 2 índices para definir o tamanho das substrings, por não usar programação dinâmica essa implementação não suporta comparações entre grandes strings.\n");

                Console.Write(" String 1 : ");
                a = Console.ReadLine();
                Console.Write(" String 2 : ");
                b = Console.ReadLine();

                try
                {
                    stopwatch.Start();
                    Console.WriteLine($"\n[{OperacoesLCS.StringIndex(a, b, 0, 0, "", stopwatch, 5000)}] é o LCS de tamanho [{OperacoesLCS.IntIndex(a, b, 0, 0)}] entre entre string 1 e 2.");
                    stopwatch.Reset();
                }
                catch (TimeoutException)
                {
                    Console.WriteLine($"\nO algoritmo demorou muito tempo para executar [Maior que 5000 milisegundos]");
                }
                Console.WriteLine("\n[Pressione alguma tecla para continuar]");
                Console.ReadKey(true);

                break;
            case 3:
                Console.Clear();

                Console.WriteLine("\n  LCS Recursivo Sem Index                   ");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine(" O algoritmo LCS pode ser feito de diversas maneiras entre elas essa é implementada sem o uso de indexes ou programação dinâmica, essa implementação faz uso do método \"Substring()\" assim retornando a cada chamada uma versão reduzida da string anterior, entretanto possui um desenpenho baixo para comparação entre strings maiores.\n");

                Console.Write(" String 1 : ");
                a = Console.ReadLine();
                Console.Write(" String 2 : ");
                b = Console.ReadLine();

                try
                {
                    stopwatch.Start();
                    Console.WriteLine($"\n[{OperacoesLCS.String(a, b, "", stopwatch, 5000)}] é o LCS de tamanho [{OperacoesLCS.Int(a, b)}] entre entre string 1 e 2.");
                    stopwatch.Reset();
                }
                catch (TimeoutException)
                {
                    Console.WriteLine($"\nO algoritmo demorou muito tempo para executar [Maior que 5000 milisegundos]");
                }
                Console.WriteLine("\n[Pressione alguma tecla para continuar]");
                Console.ReadKey(true);

                break;
            case 4:
                Console.WriteLine("\n  Voltando a página anterior...");
                Thread.Sleep(400);
                return true;
            default:
                return false;
        }
        return false;
    }
    public void ExecutarComparacao(int alg1, int alg2)
    {
        Console.Clear();

        Console.WriteLine("\n    Comparação Algoritmos LCS          ");
        Console.WriteLine("=========================================\n");
        Console.Write(" String 1 : ");
        string a = Console.ReadLine();
        Console.Write(" String 2 : ");
        string b = Console.ReadLine();

        try
        {
            double tempo1 = Cronometrar(alg1, a, b);
            double tempo2 = Cronometrar(alg2, a, b);
            double diferenca = tempo1 - tempo2;

            Console.WriteLine("\n");

            if (diferenca > 0)
                Console.WriteLine($"O algoritmo 1 demora mais tempo em sua execução, [{diferenca:F5}] milisegundos a mais.");
            else if (diferenca < 0)
                Console.WriteLine($"O algoritmo 2 demora mais tempo em sua execução, [{diferenca * -1:F5}] milisegundos a mais.");
            else
                Console.WriteLine("Os dois algoritmos levam o mesmo tempo de execução.");

            Console.ReadKey(true);
        }
        catch (TimeoutException)
        {
            Console.WriteLine($"O algoritmo demorou muito tempo para executar [Maior que 5000 milisegundos]");
            Console.ReadKey(true);
        }
    }
    public double Cronometrar(int alg, string a, string b)
    {
        Stopwatch stopwatch = new(); // Criação de stopwatch para medição do tempo
        string lcsString = "";
        double stringMiliSec = 0, intMiliSec = 0, miliSec = 0;
        int lcsInt = 0;

        Console.WriteLine("\n");

        switch (alg)
        {
            case 1:
                string[,] M1;
                int[,] M2;

                Console.WriteLine(" LCS Dinâmico");
                Console.WriteLine("--------------");
                for (int i = 0; i < 50; i++) // Calculo de tempo média da execução para encontrar o LCS
                {
                    M1 = new string[a.Length, b.Length];

                    stopwatch.Restart();
                    lcsString = OperacoesLCS.StringPD(a, b, 0, 0, M1);
                    stopwatch.Stop();
                    miliSec += stopwatch.Elapsed.TotalMilliseconds;
                }
                stringMiliSec = miliSec / 50;

                miliSec = 0;
                for (int i = 0; i < 50; i++) // Calculo de tempo média da execução para encontrar o tamanho do LCS
                {
                    M2 = new int[a.Length, b.Length];

                    stopwatch.Restart();
                    lcsInt = OperacoesLCS.IntPD(a, b, 0, 0, M2);
                    stopwatch.Stop();
                    miliSec += stopwatch.Elapsed.TotalMilliseconds;
                }
                intMiliSec = miliSec / 50;
                break;
            case 2:
                Console.WriteLine(" LCS Utilizando Index");
                Console.WriteLine("----------------------");
                for (int i = 0; i < 50; i++) // Calculo de tempo média da execução para encontrar o LCS
                {
                    stopwatch.Restart();
                    lcsString = OperacoesLCS.StringIndex(a, b, 0, 0, "", stopwatch, 5000);
                    stopwatch.Stop();
                    miliSec += stopwatch.Elapsed.TotalMilliseconds;
                }
                stringMiliSec = miliSec / 50;

                miliSec = 0;
                for (int i = 0; i < 50; i++) // Calculo de tempo média da execução para encontrar o tamanho do LCS
                {
                    stopwatch.Restart();
                    lcsInt = OperacoesLCS.IntIndex(a, b, 0, 0);
                    stopwatch.Stop();
                    miliSec += stopwatch.Elapsed.TotalMilliseconds;
                }
                intMiliSec = miliSec / 50;
                break;
            case 3:
                Console.WriteLine(" LCS sem Index");
                Console.WriteLine("---------------");
                for (int i = 0; i < 50; i++) // Calculo de tempo média da execução para encontrar o LCS
                {
                    stopwatch.Restart();
                    lcsString = OperacoesLCS.String(a, b, "", stopwatch, 5000);
                    stopwatch.Stop();
                    miliSec += stopwatch.Elapsed.TotalMilliseconds;
                }
                stringMiliSec = miliSec / 50;

                miliSec = 0;
                for (int i = 0; i < 50; i++) // Calculo de tempo média da execução para encontrar o tamanho do LCS
                {
                    stopwatch.Restart();
                    lcsInt = OperacoesLCS.Int(a, b);
                    stopwatch.Stop();
                    miliSec += stopwatch.Elapsed.TotalMilliseconds;
                }
                intMiliSec = miliSec / 50;
                break;
        }
        Console.WriteLine($"{stringMiliSec:F5} milisegundos para encontrar a string [{lcsString}]");
        Console.WriteLine($"{intMiliSec:F5} milisegundos para encontrar o tamanho [{lcsInt}]");
        Console.WriteLine($"{stringMiliSec + intMiliSec:F5} no total.");

        return stringMiliSec + intMiliSec;
    }
    public int TratarOpcao(string s, int maior) // Função que recebe a entrada do usuário e tentar converter pra string
    {
        int opcao;
        if (!int.TryParse(s, out opcao))
            return -1;

        if (opcao >= 1 && opcao <= maior)
            return opcao;

        return 0;
    }
    public bool TratarErro(int opcao)
    {
        if (opcao == -1)
        {
            Console.WriteLine("\n  Formato inválido.");
            Console.ReadKey(true);
            return false;
        }
        if (opcao == 0)
        {
            Console.WriteLine("\n  opção inválida.");
            Console.ReadKey(true);
            return false;
        }
        return true;
    }
}
