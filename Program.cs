using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Resolutor de Sistemas Lineares (Escalonamento) ---");
        
        // 1. Solicitar o tamanho do sistema
        Console.Write("Digite o tamanho do sistema (ex: 3 para 3x3): ");
        int n = int.Parse(Console.ReadLine());

        if (n > 10 || n < 2) {
            Console.WriteLine("Tamanho inválido. Escolha entre 2 e 10.");
            return;
        }

        double[,] matriz = new double[n, n + 1];

        // 2. Solicitar coeficientes e termos independentes
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"A[{i + 1},{j + 1}]: ");
                matriz[i, j] = double.Parse(Console.ReadLine());
            }
            Console.Write($"Termo independente B[{i + 1}]: ");
            matriz[i, n] = double.Parse(Console.ReadLine());
        }

        // 3. Imprimir sistema original
        Console.WriteLine("\n--- Sistema Original ---");
        ImprimirMatriz(matriz, n);

        // 4. Escalonamento (Eliminação de Gauss)
        for (int i = 0; i < n; i++)
        {
            // Pivoteamento simples (troca de linha se o pivô for zero)
            if (matriz[i, i] == 0)
            {
                for (int k = i + 1; k < n; k++)
                {
                    if (matriz[k, i] != 0)
                    {
                        TrocarLinhas(matriz, i, k, n);
                        break;
                    }
                }
            }

            // Transformar elementos abaixo do pivô em zero
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

        // 4. Imprimir sistema escalonado
        Console.WriteLine("\n--- Sistema Escalonado ---");
        ImprimirMatriz(matriz, n);

        // 5 & 6. Substituição regressiva e Verificação de SI/SPI
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

            if (Math.Abs(m[i, i]) < 1e-10) // Próximo de zero
            {
                if (Math.Abs(m[i, n] - soma) < 1e-10)
                    Console.WriteLine("\nResultado: Sistema Possível e Indeterminado (SPI) - Infinitas Soluções.");
                else
                    Console.WriteLine("\nResultado: Sistema Incompatível (SI) - Não tem solução.");
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