using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;
class Program
{ // Sugestão de tempo limite?
    static void Main(string[] args)
    {
        Menu inicializador = new();
        int opcao;
        do
        {
            opcao = inicializador.GetOpcaoMenuInicial();
            if (inicializador.TratarErro(opcao))
                inicializador.ExecutaMenuInicial(opcao);
        } while (opcao != 3);
    }
}
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
                        break;

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
                Console.WriteLine("Finalizando programa.");
                Thread.Sleep(500);
                break;
        }
    }
    public bool ExecutarMenuVersoes(int escolha)
    {
        Stopwatch stopwatch = new();
        string a, b;
        switch (escolha)
        {
            case 1:
                Console.Clear();

                Console.WriteLine("\n  LCS Dinâmico                                 ");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine(" O algoritmo LCS com programação dinâmica .....\n");

                Console.Write(" String 1 : ");
                a = Console.ReadLine();
                Console.Write(" String 2 : ");
                b = Console.ReadLine();

                string[,] M1 = new string[a.Length, b.Length];
                int[,] M2 = new int[a.Length, b.Length];

                Console.WriteLine($"\n[{OperacoesLCS.StringPD(a, b, 0, 0, M1)}] é o LCS de tamanho [{OperacoesLCS.IntPD(a, b, 0, 0, M2)}] entre entre string 1 e 2");

                Console.WriteLine("\n[Pressione alguma tecla para continuar]");
                Console.ReadKey(true);
                break;
            case 2:
                Console.Clear();

                Console.WriteLine("\n  LCS Recursivo Usando Index                   ");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine(" O algoritmo LCS pode ser feito de diversas maneiras umas delas com index .....\n");

                Console.Write(" String 1 : ");
                a = Console.ReadLine();
                Console.Write(" String 2 : ");
                b = Console.ReadLine();

                try
                {
                    stopwatch.Start();
                    Console.WriteLine($"\n[{OperacoesLCS.StringIndex(a, b, 0, 0, "", stopwatch, 5000)}] é o LCS de tamanho [{OperacoesLCS.IntIndex(a, b, 0, 0)}] entre entre string 1 e 2");
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
                Console.WriteLine(" O algoritmo LCS pode ser feito de diversas maneiras umas delas sem index .....\n");

                Console.Write(" String 1 : ");
                a = Console.ReadLine();
                Console.Write(" String 2 : ");
                b = Console.ReadLine();

                try
                {
                    stopwatch.Start();
                    Console.WriteLine($"\n[{OperacoesLCS.String(a, b, "", stopwatch, 5000)}] é o LCS de tamanho [{OperacoesLCS.Int(a, b)}] entre entre string 1 e 2");
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
        Stopwatch stopwatch = new();
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
                for (int i = 0; i < 50; i++)
                {
                    M1 = new string[a.Length, b.Length];

                    stopwatch.Restart();
                    lcsString = OperacoesLCS.StringPD(a, b, 0, 0, M1);
                    stopwatch.Stop();
                    miliSec += stopwatch.Elapsed.TotalMilliseconds;
                }
                stringMiliSec = miliSec / 50;

                miliSec = 0;
                for (int i = 0; i < 50; i++)
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
                for (int i = 0; i < 50; i++)
                {
                    stopwatch.Restart();
                    lcsString = OperacoesLCS.StringIndex(a, b, 0, 0, "", stopwatch, 5000);
                    stopwatch.Stop();
                    miliSec += stopwatch.Elapsed.TotalMilliseconds;
                }
                stringMiliSec = miliSec / 50;

                miliSec = 0;
                for (int i = 0; i < 50; i++)
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
                for (int i = 0; i < 50; i++)
                {
                    stopwatch.Restart();
                    lcsString = OperacoesLCS.String(a, b, "", stopwatch, 5000);
                    stopwatch.Stop();
                    miliSec += stopwatch.Elapsed.TotalMilliseconds;
                }
                stringMiliSec = miliSec / 50;

                miliSec = 0;
                for (int i = 0; i < 50; i++)
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
    public int TratarOpcao(string s, int maior)
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
class LCS()
{   // LCS Dinâmico que retorna a maior subsequência 
    public string StringPD(string A, string B, int iA, int iB, string[,] solucao)
    {   // Condição de parada
        if (iA >= A.Length || iB >= B.Length) // Caso esteja no final de qualquer uma das strings retornal null
            return "";

        if (solucao[iA, iB] != null) // Verificação se o calculo ja foi realizado
            return solucao[iA, iB];

        if (A[iA] == B[iB]) // Operação relevante de comparação
            return solucao[iA, iB] = A[iA] + StringPD(A, B, iA + 1, iB + 1, solucao); // Adiciona o caractere encontrado e chama a função avançando um caractere nas duas strings
        else
        {   // strings que criam a arvore de opções
            string a = StringPD(A, B, iA + 1, iB, solucao); // Caminho da arvore reduzindo a string A
            string b = StringPD(A, B, iA, iB + 1, solucao); // Caminho da arvore reduzindo a string B
            return solucao[iA, iB] = a.Length > b.Length ? a : b; // Retorna a sting que encontrou a maior subsequência
        }
    }
    // LCS Dinâmico que retorna o tamanho int
    public int IntPD(string A, string B, int iA, int iB, int[,] solucao)
    {   // Condição de parada
        if (iA >= A.Length || iB >= B.Length)  // Caso esteja no final de qualquer uma das strings retornal null
            return 0;

        if (solucao[iA, iB] > 0) // Verificação se o calculo ja foi realizado
            return solucao[iA, iB];

        if (A[iA] == B[iB]) // Operação relevante de comparação
            return solucao[iA, iB] = 1 + IntPD(A, B, iA + 1, iB + 1, solucao); // Aumenta 1 no contador e chama a função avançando um caractere nas duas strings
        else // Chamado que cria a arvore de opções passando as strings que com um caractere a menos em cada chamado e retorna a maior substring encontrada
            return solucao[iA, iB] = Math.Max(IntPD(A, B, iA + 1, iB, solucao), IntPD(A, B, iA, iB + 1, solucao));
    }
    // LCS que retorna a maior subsequência usando index
    public string StringIndex(string A, string B, int iA, int iB, string palavra)
    {   // Condição de parada
        if (iA >= A.Length || iB >= B.Length) // Para caso chegue no final de qualquer string retornando null
            return "";

        if (A[iA] == B[iB]) // Operação relevante 
            return A[iA] + StringIndex(A, B, iA + 1, iB + 1, palavra); // Adiciona o caractere encontrado na matrix e chama a função avançando um caractere nas duas strings
        else
        {   // strings que criam a arvore de opções
            string a1 = StringIndex(A, B, iA + 1, iB, palavra); // Caminho da arvore reduzindo a string A
            string a2 = StringIndex(A, B, iA, iB + 1, palavra); // Caminho da arvore reduzindo a string B
            return a1.Length > a2.Length ? a1 : a2; // Retorna a sting que encontrou a maior subsequência
        }
    }
    // LCS que retorna a maior subsequência usando index Com sobrecarga para monitoramento de tempo de execução
    public string StringIndex(string A, string B, int iA, int iB, string palavra, Stopwatch tempo, int limiteMilisec)
    {
        if (tempo.Elapsed.TotalMilliseconds >= limiteMilisec)
            throw new TimeoutException();

        // Condição de parada
        if (iA >= A.Length || iB >= B.Length) // Para caso chegue no final de qualquer string retornando null
            return "";

        if (A[iA] == B[iB]) // Operação relevante 
            return A[iA] + StringIndex(A, B, iA + 1, iB + 1, palavra, tempo, limiteMilisec); // Adiciona o caractere encontrado na matrix e chama a função avançando um caractere nas duas strings
        else
        {   // strings que criam a arvore de opções
            string a1 = StringIndex(A, B, iA + 1, iB, palavra, tempo, limiteMilisec); // Caminho da arvore reduzindo a string A
            string a2 = StringIndex(A, B, iA, iB + 1, palavra, tempo, limiteMilisec); // Caminho da arvore reduzindo a string B
            return a1.Length > a2.Length ? a1 : a2; // Retorna a sting que encontrou a maior subsequência
        }
    }
    // LCS que retorna o tamanho usando index
    public int IntIndex(string A, string B, int iA, int iB)
    {   // Condição de parada
        if (iA >= A.Length || iB >= B.Length) // Para caso chegue no final de qualquer string retornando 0
            return 0;

        if (A[iA] == B[iB]) // Operação relevante
            return 1 + IntIndex(A, B, iA + 1, iB + 1); // Aumenta 1 no contador e chama a função avançando um caractere nas duas strings
        else // Cria arvore de opções reduzindo um caractere em cada string e retorna o maior tamanho de subsequência encontrado
            return Math.Max(IntIndex(A, B, iA + 1, iB), IntIndex(A, B, iA, iB + 1));
    }
    // LCS Retornando a maior subsequência sem index
    public string String(string A, string B, string palavra)
    {   // Condição de parada
        if (A.Length == 0 || B.Length == 0) // Para caso chegue no final de qualquer string retornando null
            return "";

        if (A[0] == B[0]) // Operação relevante 
            return A[0] + String(A.Substring(1), B.Substring(1), palavra);  // Retorna a string encontrada e chama a função avançando um caractere nas duas strings
        else
        {   // strings que criam a arvore de opções
            string a1 = String(A.Substring(1), B, palavra); // Caminho da arvore reduzindo a string A
            string a2 = String(A, B.Substring(1), palavra); // Caminho da arvore reduzindo a string B
            return a1.Length > a2.Length ? a1 : a2; // Retorna a sting que encontrou a maior subsequência
        }
    }
    // LCS Retornando a maior subsequência sem index Com sobrecarga para monitoramento de tempo de execução
    public string String(string A, string B, string palavra, Stopwatch tempo, int limiteMilisec)
    {
        if (tempo.Elapsed.TotalMilliseconds >= limiteMilisec)
            throw new TimeoutException();

        // Condição de parada
        if (A.Length == 0 || B.Length == 0) // Para caso chegue no final de qualquer string retornando null
            return "";

        if (A[0] == B[0]) // Operação relevante 
            return A[0] + String(A.Substring(1), B.Substring(1), palavra, tempo, limiteMilisec);  // Retorna a string encontrada e chama a função avançando um caractere nas duas strings
        else
        {   // strings que criam a arvore de opções
            string a1 = String(A.Substring(1), B, palavra, tempo, limiteMilisec); // Caminho da arvore reduzindo a string A
            string a2 = String(A, B.Substring(1), palavra, tempo, limiteMilisec); // Caminho da arvore reduzindo a string B
            return a1.Length > a2.Length ? a1 : a2; // Retorna a sting que encontrou a maior subsequência
        }
    }
    // LCS Retornando o tamanho sem index
    public int Int(string A, string B)
    {   // Condição de parada
        if (A.Length == 0 || B.Length == 0)
            return 0;

        if (A[0] == B[0]) // Operação relevante
            return 1 + Int(A.Substring(1), B.Substring(1));  // Aumenta 1 no contador e chama a função avançando um caractere nas duas strings
        else // Cria arvore de opções reduzindo um caractere em cada string e retorna o maior tamanho de subsequência encontrado
            return Math.Max(Int(A.Substring(1), B), Int(A, B.Substring(1)));
    }
}
