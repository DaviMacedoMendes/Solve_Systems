using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Resolutor de Sistemas Lineares (Escalonamento) ---");
        
        Console.Write("Digite o tamanho do sistema (ex: 3 para 3x3): ");
        int n = int.Parse(Console.ReadLine());

        if (n > 10 || n < 2) {
            Console.WriteLine("Tamanho inválido. Tamanho permitido: Min. 3 | Max. 10.");
            return;
        }

        double[,] matriz = new double[n, n + 1]; //Armazena a quantidade de linhas e colunas do sistema

        //Faz a atribuicao dos coeficiente e termos independentes
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"A[{i + 1},{j + 1}]: ");
                matriz[i, j] = double.Parse(Console.ReadLine()); //Coeficientes
            }
            Console.Write($"Termo independente B[{i + 1}]: ");
            matriz[i, n] = double.Parse(Console.ReadLine()); //Termo independente
        }

        Console.WriteLine("\n--- Sistema Original ---");
        ImprimirMatriz(matriz, n); //Mostra ao usuario o sistema original

        //Faz a verificacao se o pivo e zero ou nao
        for (int i = 0; i < n; i++)
        {
            if (matriz[i, i] == 0) //Se algum for zero
            {
                for (int k = i + 1; k < n; k++) //Procura nas linhas abaixo
                {
                    if (matriz[k, i] != 0) //Realiza a troca com a linha que nao for zero
                    {
                        TrocarLinhas(matriz, i, k, n);
                        break;
                    }
                }
            }

            for (int k = i + 1; k < n; k++)
            {
                if (matriz[i, i] == 0) continue; 
                double fator = matriz[k, i] / matriz[i, i];
                for (int j = i; j <= n; j++)
                {
                    matriz[k, j] -= fator * matriz[i, j];
                }
            }
        }
        Console.WriteLine("\n--- Sistema Escalonado ---");
        ImprimirMatriz(matriz, n); //Mostra o Sistema Escalonado

        ResolverSistema(matriz, n);
    }

    static void ResolverSistema(double[,] m, int n)
    {
        double[] x = new double[n];
        for (int i = n - 1; i >= 0; i--)
        {
            double soma = 0;
            for (int j = i + 1; j < n; j++)
            {
                soma += m[i, j] * x[j];
            }

            if (Math.Abs(m[i, i]) < 1e-10)
            {
                if (Math.Abs(m[i, n] - soma) < 1e-10)
                    Console.WriteLine("\nResultado: Sistema Possível e Indeterminado (SPI) - Infinitas Soluções.");
                else
                    Console.WriteLine("\nResultado: Sistema Impossível (SI) - Não tem solução.");
                return;
            }

            x[i] = (m[i, n] - soma) / m[i, i];
        }

        Console.WriteLine("\n--- Solução ---");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"X{i + 1} = {Math.Round(x[i], 4)}");
        }
    }

    static void ImprimirMatriz(double[,] m, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                Console.Write($"{m[i, j], 8:F2} ");
                if (j == n - 1) Console.Write("| ");
            }
            Console.WriteLine();
        }
    }

    static void TrocarLinhas(double[,] m, int row1, int row2, int n)
    {
        for (int j = 0; j <= n; j++)
        {
            double temp = m[row1, j];
            m[row1, j] = m[row2, j];
            m[row2, j] = temp;
        }
    }
}