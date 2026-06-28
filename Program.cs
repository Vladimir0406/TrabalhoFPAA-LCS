using System;
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