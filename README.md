# 🧮 Resolutor de Sistemas Lineares (Método do Escalonamento)

Este projeto é uma aplicação de console desenvolvida em **C#** que resolve sistemas de equações lineares de até $10 \times 10$ utilizando o **Método da Eliminação de Gauss** (Escalonamento). 

O software foi projetado para transformar uma matriz aumentada em sua forma escalonada (triangular superior) e realizar a substituição regressiva para encontrar as incógnitas.

## 🚀 Funcionalidades

- **Entrada Dinâmica:** O usuário define o tamanho do sistema ($N \times N$) e insere os coeficientes.
- **Processamento Matemático:**
    - Realiza o escalonamento da matriz original.
    - Implementa **pivoteamento simples** para evitar divisões por zero.
    - Executa a **substituição regressiva** para determinar os valores de $X_1, X_2, \dots, X_n$.
- **Classificação de Sistemas:**
    - **SPD:** Sistema Possível e Determinado (Solução única).
    - **SPI:** Sistema Possível e Indeterminado (Infinitas soluções).
    - **SI:** Sistema Incompatível (Nenhuma solução).
- **Interface de Console:** Exibição clara da matriz original e da matriz após o escalonamento.

## 🛠️ Tecnologias Utilizadas

- **Linguagem:** C#
- **Framework:** .NET SDK 8.0 (ou superior)
- **Ambiente de Desenvolvimento:** Linux / VS Code

## 📖 Exemplo de Uso
Ao iniciar, o programa solicitará o tamanho do sistema e os coeficientes linha por linha.

# Exemplo de entrada ($3 \times 3$):
```Plaintext
3x + 2y - 1z = 1
2x - 2y + 4z = -2
-1x + 0.5y - 1z = 0
```

## 📋 Como Executar o Projeto

Certifique-se de ter o SDK do .NET instalado.

1. **Clone o repositório:**
   ```bash
   git clone [https://github.com/seu-usuario/nome-do-repositorio.git](https://github.com/seu-usuario/nome-do-repositorio.git)

