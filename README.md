# Objetivo

Este repositório foi desenvolvido para o estudo de Análise de Algoritmos e Abordagens Algorítmicas, com foco em Programação Dinâmica e no problema da Maior Subsequência Comum (*Longest Common Subsequence* – LCS).

Os principais objetivos do projeto são:

- Aplicar técnicas de projeto de algoritmos, em especial Programação Dinâmica, na solução de um problema clássico.
- Comparar diferentes implementações do algoritmo LCS.
- Desenvolver habilidades de análise, modelagem, implementação e apresentação técnica.

# LCS

O LCS (*Longest Common Subsequence*), ou Maior Subsequência Comum, é um problema clássico da Ciência da Computação cujo objetivo é encontrar a maior subsequência presente em duas ou mais sequências. Uma subsequência é formada por elementos que aparecem na mesma ordem da sequência original, mas não precisam estar em posições consecutivas.

Por exemplo, considerando as strings **"AGGTAB"** e **"GXTXAYB"**, a LCS é **"GTAB"**, pois esses caracteres aparecem na mesma ordem em ambas as strings e formam a maior subsequência comum, embora existam outros caracteres entre eles.

O problema do LCS possui diversas aplicações práticas, como comparação de arquivos e documentos, sistemas de controle de versão, bioinformática para comparação de sequências de DNA e proteínas, além de outras áreas que necessitam identificar similaridades entre sequências.

A solução mais utilizada para esse problema emprega Programação Dinâmica, construindo uma matriz que armazena as soluções dos subproblemas até obter a maior subsequência comum entre as sequências analisadas.

# Tecnologias

- C#
- .NET
- Visual Studio Code

# Código

O projeto possui três implementações do algoritmo LCS, sendo que cada uma delas apresenta duas variações: uma responsável por retornar a subsequência comum e outra por retornar apenas o tamanho da LCS.

1. **Programação Dinâmica (Bottom-Up)**
   - Implementação clássica do problema LCS. Utiliza uma matriz para armazenar os resultados dos subproblemas (memoização), evitando recálculos desnecessários. É a abordagem mais eficiente do projeto, sendo capaz de processar entradas de grande tamanho com bom desempenho.

2. **Recursiva com uso de índices**
   - Implementação recursiva que utiliza índices para controlar a posição atual em cada string. Como não emprega Programação Dinâmica, diversos subproblemas são recalculados, reduzindo significativamente seu desempenho para entradas maiores.

3. **Recursiva utilizando Substring()**
   - Implementação recursiva que utiliza o método `Substring()` para gerar novas substrings a cada chamada recursiva. Além de não utilizar Programação Dinâmica, cria novas strings constantemente, aumentando o consumo de memória e tornando seu desempenho inferior ao das demais implementações.

# Estrutura do projeto

O projeto está organizado em módulos responsáveis por diferentes funcionalidades:

- **LCS:** Contém as seis implementações do algoritmo LCS, incluindo as versões que retornam a subsequência e as que retornam apenas o seu tamanho.
- **Menu:** Responsável pela interação com o usuário, seleção das implementações e controle da execução e da cronometragem dos algoritmos.
- **Program:** Contém o ponto de entrada da aplicação e a inicialização do sistema.

# Complexidade

A complexidade do problema da Maior Subsequência Comum (LCS) depende da quantidade de sequências consideradas e da abordagem utilizada para resolvê-lo.

Para o caso clássico, em que são comparadas apenas duas strings de tamanhos **m** e **n**, a solução baseada em Programação Dinâmica possui complexidade de tempo e espaço **O(mn)** sendo, portanto, um algoritmo de tempo polinomial.

Entretanto, quando o problema é generalizado para a comparação simultânea de um número arbitrário de sequências, encontrar a maior subsequência comum torna-se um problema **NP-Hard**, não sendo conhecida uma solução de tempo polinomial para esse caso.

| Implementação | Tempo | Espaço |
|---------------|:-----:|:-------:|
| Programação Dinâmica | O(mn) | O(mn) |
| Recursiva com índices | Exponencial | O(m+n) |
| Recursiva com `Substring()` | Exponencial | Superior à versão com índices devido à criação de novas strings |

# Como executar

1. Clone o repositório.
2. Abra o projeto em uma IDE compatível com C#.
3. Compile a aplicação.
4. Execute o programa.
5. Escolha a implementação desejada através do menu.
