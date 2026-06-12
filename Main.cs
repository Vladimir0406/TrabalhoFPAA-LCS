using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        Console.Write("String 1 para comparação :");
        string a = Console.ReadLine();
        Console.Write("String 2 para comparação :");
        string b = Console.ReadLine();

        Console.WriteLine("\nLCS TIPOS");
        Console.WriteLine("LCS sem index retornando int e string.");
        Console.WriteLine("Maior subsequencia [" + LCS(a, b, "") + "] de tamanho: " + LCS(a, b));

        Console.WriteLine("\nLCS com index retornando int e string.");
        Console.WriteLine("Maior subsequencia [" + LCS(a, b, 0, 0, "") + "] de tamanho: " + LCS(a, b, 0, 0));

        Console.WriteLine("\nLCS Em programação dinâmica.");
        int[,] M = new int[a.Length, b.Length];
        string[,] Ms = new string[a.Length, b.Length];
        Console.WriteLine("Maior subsequência [" + LCSPD(a, b, 0, 0, Ms) + "]");
        Console.WriteLine("Tamanho da maior subsequência: " + LCSPD(a, b, 0, 0, M));
    }

    // LCS Dinâmico que retorna string
    static string LCSPD(string A, string B, int iA, int iB, string[,] solucao)
    {
        if (iA >= A.Length || iB >= B.Length)
            return "";

        if (solucao[iA, iB] != null)
            return solucao[iA, iB];

        if (A[iA] == B[iB])
            return solucao[iA, iB] = A[iA] + LCSPD(A, B, iA + 1, iB + 1, solucao);
        else
        {
            string a = LCSPD(A, B, iA + 1, iB, solucao);
            string b = LCSPD(A, B, iA, iB + 1, solucao);
            return solucao[iA, iB] = a.Length > b.Length ? a : b;
        }
    }

    // LCS Dinâmico que retorna int
    static int LCSPD(string A, string B, int iA, int iB, int[,] solucao)
    {
        if (iA >= A.Length || iB >= B.Length)
            return 0;
        if (solucao[iA, iB] > 0)
            return solucao[iA, iB];

        if (A[iA] == B[iB])
            return solucao[iA, iB] = 1 + LCSPD(A, B, iA + 1, iB + 1, solucao);
        else
            return solucao[iA, iB] = Math.Max(LCSPD(A, B, iA + 1, iB, solucao), LCSPD(A, B, iA, iB + 1, solucao));
    }

    // LCS que retorna a palavra usando index
    static string LCS(string A, string B, int iA, int iB, string palavra)
    {
        if (iA >= A.Length || iB >= B.Length)
            return "";
        if (A[iA] == B[iB])
            return A[iA] + LCS(A, B, iA + 1, iB + 1, palavra);
        else
        {
            string a1 = LCS(A, B, iA + 1, iB, palavra);
            string a2 = LCS(A, B, iA, iB + 1, palavra);
            return a1.Length > a2.Length ? a1 : a2;
        }
    }

    // LCS que retorna o tamanho usando index
    static int LCS(string A, string B, int iA, int iB)
    {
        if (iA >= A.Length || iB >= B.Length)
            return 0;
        // if(solução[])
        if (A[iA] == B[iB])
            return 1 + LCS(A, B, iA + 1, iB + 1);
        else
            return Math.Max(LCS(A, B, iA + 1, iB), LCS(A, B, iA, iB + 1));
    }

    // LCS Retornando a palavra
    static string LCS(string A, string B, string palavra)
    {
        if (A.Length == 0 || B.Length == 0)
            return "";

        if (A[0] == B[0])
            return A[0] + LCS(A.Substring(1), B.Substring(1), palavra);
        else
        {
            string a1 = LCS(A.Substring(1), B, palavra);
            string a2 = LCS(A, B.Substring(1), palavra);
            return a1.Length > a2.Length ? a1 : a2;
        }
    }

    // LCS Retornando o tamanho
    static int LCS(string A, string B)
    {
        if (A.Length == 0 || B.Length == 0)
            return 0;
        if (A[0] == B[0])
            return 1 + LCS(A.Substring(1), B.Substring(1));
        else
            return Math.Max(LCS(A.Substring(1), B), LCS(A, B.Substring(1)));
    }
}
