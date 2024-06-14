// See https://aka.ms/new-console-template for more information

using bingo;
using System;
using System.Collections.Generic;
using System.Linq;

class BingoGame
{
    static void Main(string[] args)
    {
        // Parte 2: Criação da cartela
        BingoCard card = new BingoCard();
        Console.WriteLine("Cartela de Bingo:");
        card.DisplayCard();

        // Parte 1: Sorteio das bolas
        List<int> drawnNumbers = new List<int>();
        Random random = new Random();

        while (drawnNumbers.Count < 75)
        {
            Console.WriteLine("Aperte Enter para sortear um número");
            Console.ReadLine();
            int number = random.Next(1, 76);
            if (!drawnNumbers.Contains(number) && number != null)
            {
                drawnNumbers.Add(number);
                Console.WriteLine("Número sorteado: " + number);
            }
            card.DisplayCard();
            SimulateGame(drawnNumbers, card);
        }

        
      
    }

    static void SimulateGame(List<int> drawnNumbers, BingoCard card)
    {
        int[,] markedCard = new int[5, 5];

        for (int i = 0; i < drawnNumbers.Count; i++)
        {
            int number = drawnNumbers[i];

            // Marcar o número na cartela, se existir
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (card.card[row, col] == number)
                    {
                        markedCard[row, col] = 1;
                        Console.WriteLine("Número " + number + " marcado na cartela.");
                    }
                }
            }

            // Verificar se ganhou
            if (CheckWin(markedCard))
            {
                Console.WriteLine("Bingo! Você ganhou com o número " + number);
                return;
            }
        }
    }

    static bool CheckWin(int[,] markedCard)
    {
        for (int i = 0; i < 5; i++)
        {
            // Verificar linhas
            if (Enumerable.Range(0, 5).All(col => markedCard[i, col] == 1))
                return true;

            // Verificar colunas
            if (Enumerable.Range(0, 5).All(row => markedCard[row, i] == 1))
                return true;
        }

        // Verificar diagonais
        if (Enumerable.Range(0, 5).All(i => markedCard[i, i] == 1))
            return true;

        if (Enumerable.Range(0, 5).All(i => markedCard[i, 4 - i] == 1))
            return true;

        return false;
    }
}
