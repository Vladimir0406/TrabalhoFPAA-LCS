using System.Diagnostics;
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