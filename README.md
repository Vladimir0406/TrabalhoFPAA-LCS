# TrabalhoFPAA-LCS
&nbsp;&nbsp;&nbsp;Um repositório para estudo de análise de algoritmos e abordagem algorítmicas focado em Programação Dinâmica, especificadamente sobre o algoritmo LCS (Longest Common Subsequence).
&nbsp;&nbsp;&nbsp;O LCS (*Longest Common Subsequence*), ou Maior Subsequência Comum, é um problema clássico da Ciência da Computação cujo objetivo é encontrar a maior subsequência presente em duas ou mais sequências. Uma subsequência é formada por elementos que aparecem na mesma ordem na string original mas não necessitam estar em posições consecutivas.

&nbsp;&nbsp;&nbsp;Por exemplo, considerando as strings **"AGGTAB"** e **"GXTXAYB"**, a LCS é **"GTAB"**, pois esses caracteres aparecem na mesma ordem em ambas as strings e são a maior sequência, embora existam outros caracteres entre eles.

&nbsp;&nbsp;&nbsp;O problema do LCS possui diversas aplicações práticas, como comparação de arquivos e documentos, sistemas de controle de versão, bioinformática para comparação de sequências de DNA e proteínas, além de outras áreas que necessitam identificar similaridades entre sequências.

&nbsp;&nbsp;&nbsp;A solução mais utilizada para esse problema emprega programação dinâmica, construindo uma matriz que armazena as soluções dos subproblemas até obter a maior subsequência comum entre as sequências analisadas. 

# Código
&nbsp;&nbsp;&nbsp;O código presente neste repositório possui 3 formas de implementação do algoritmo LCS e cada implementação com 2 variações uma responsável por encontrar o LCS propriamente dito e a outra que retorna apenas o tamanho do LCS.
   1 - Programação dinâmica
       Essa implementação é a comum utilizada para o problema lcs, ela conta com duas matrizes para o armazenamento das strings passadas pelo usuário e para a memoização(armazenamento de resultados para evitar os recalculos causados pela recursão), está é a implementação mais eficiente e consegue tratar longas entradas de dados sem problemas.
   2 - Uso de index
       
