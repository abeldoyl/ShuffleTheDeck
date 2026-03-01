/*
Abel Doyle
RCET 2265
Spring Semester 2026
ConvertandValidate
https://github.com/abeldoyl/ShuffleTheDeck.git
*/

namespace ShuffleTheDeck
{
    internal class Program
    {
        static bool[,] drawnCards = new bool[5, 15];

        static void Main(string[] args)
        {
            int cardcount = 0;
            string userInput = "";
            do
            {
                Console.Clear();

                if (cardcount < 75)
                {
                    Console.WriteLine("Press \"enter\" to Draw a new ball\n"
                    + "Press \"Q\" at any time to quit\n"
                    + "Press \"C\" to clear the board at any time");
                    DrawBall();
                    cardcount++;
                }
                else
                {
                    Console.WriteLine("All balls have been drawn");
                    Console.WriteLine("Press \"Q\" to quit");
                    Console.WriteLine("Press \"C\" to clear the board to start a new game");
                }
                Console.WriteLine($"Ball Count: {cardcount}");
                Display();
                userInput = Console.ReadLine(); //Fixed double drawn balls issue
                if (userInput == "c" || userInput == "C")
                {
                    ClearDrawBalls();
                    cardcount = 0;
                }

            } while (userInput != "Q" && userInput != "q" == true);
            Console.Clear();
            Console.WriteLine("Have a nice day");
            //pause
            Console.Read();
        }


        static void Display()
        {
            int padding = 5;
            int prettyNumber = 0;
            string placeHolder = "";
            string columnSeperator = " |";
            string currentRow = "";
            //print heading row
            string[] heading = { "B", "I", "N", "G", "O" };
            foreach (string thing in heading)
            {
                Console.Write(thing.PadLeft(padding) + columnSeperator);
            }
            Console.WriteLine();

            // print the rest of the rows
            for (int number = 1; number <= 15; number++)
            {
                //assemble the row
                for (int letter = 0; letter < 5; letter++)
                {
                    if (drawnCards[letter, number - 1])
                    {
                        prettyNumber = number + (letter * 15); //offset the number by the letter column
                        currentRow += prettyNumber.ToString().PadLeft(padding) + columnSeperator;
                    }
                    else
                    {
                        currentRow += placeHolder.PadLeft(padding) + columnSeperator;
                    }
                }
                Console.WriteLine(currentRow);
                currentRow = ""; //reset 
            }
        }

        static void DrawBall()
        {
            int letter = 0, number = 0;
            do
            {
                letter = RandomNumberZeroTo(4);
                number = RandomNumberZeroTo(14);

            } while (drawnCards[letter, number]);

            drawnCards[letter, number] = true;

        }
        /// <summary>
        /// Get a random integer from 0 to max inclusive.
        /// </summary>
        /// <param name="max"></param>
        /// <returns>integer</returns>
        static private int RandomNumberZeroTo(int max)
        {
            int range = max + 1; //make max inclusive
            Random rand = new Random();
            return rand.Next(range);

        }

        static void ClearDrawBalls()
        {
            for (int letter = 0; letter < 5; letter++)
            {
                for (int number = 0; number < 15; number++)
                {
                    drawnCards[letter, number] = false;
                }
            }

        }
    }

}