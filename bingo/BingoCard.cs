using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bingo
{
   public class BingoCard
    {
        
    public int[,] card = new int[5, 5];

        public BingoCard()
        {
            Random random = new Random();
            List<int> numbers;

            // Generate numbers for each column
            for (int col = 0; col < 5; col++)
            {
                numbers = Enumerable.Range(col * 15 + 1, 15).OrderBy(x => random.Next()).Take(5).ToList();
                for (int row = 0; row < 5; row++)
                {
                    card[row, col] = numbers[row];
                }
            }
            // Set the center space to 0 (free space)
            card[2, 2] = 0;
        }

        public void DisplayCard()
        {
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (card[row, col] == 0)
                        Console.Write(" F ");
                    else
                        Console.Write($"{card[row, col],2} ");
                }
                Console.WriteLine();
            }
        }
    }
}

