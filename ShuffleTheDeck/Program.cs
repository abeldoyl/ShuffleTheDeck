/*
Abel Doyle
RCET 2265
Spring Semester 2026
ShuffleTheDeck
https://github.com/abeldoyl/ShuffleTheDeck.git
*/

namespace ShuffleTheDeck
{
    internal class Program
    {
        static bool[,] drawnCards = new bool[4, 13];

        static void Main(string[] args)
        {
            int cardcount = 0;
            string userInput = "";
            do
            {
                Console.Clear();

                if (cardcount < 52)
                {
                    Console.WriteLine("Press \"enter\" to Draw a new card\n"
                    + "Press \"Q\" at any time to quit\n"
                    + "Press \"C\" to clear the board" +
                    " and reshuffle the deck at any time");
                    DrawCard();
                    cardcount++;
                }
                else
                {
                    Console.WriteLine("All cards have been drawn");
                    Console.WriteLine("Press \"Q\" to quit");
                    Console.WriteLine("Press \"C\" to clear the board " +
                        "and reshuffle the deck to start a new game");
                }
                Console.WriteLine($"Card Count: {cardcount}");
                Display();
                userInput = Console.ReadLine(); //Fixed double drawn cards issue
                if (userInput == "c" || userInput == "C")
                {
                    ClearDrawCards();
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
            int padding = 7;
            string prettyRank = "";
            string placeHolder = "";
            string columnSeperator = " |";
            string currentRow = "";

            string[] heading = { "Heart", "Spade", "Diamond", "Club" };

            // Print row header with proper colors
            for (int i = 0; i < heading.Length; i++)
            {
                SetSuitColor(i);
                Console.Write(heading[i].PadLeft(padding) + columnSeperator);
                Console.ResetColor();
            }
            Console.WriteLine();

            // Display cards drawn
            for (int number = 1; number <= 13; number++)
            {
                for (int suits = 0; suits < 4; suits++)
                {
                    SetSuitColor(suits);

                    if (drawnCards[suits, number - 1])
                    {
                        // switch case for cards to show A, K, Q, and J
                        switch (number)
                        {
                            case 1:
                                prettyRank = "A";
                                break;
                            case 11:
                                prettyRank = "J";
                                break;
                            case 12:
                                prettyRank = "Q";
                                break;
                            case 13:
                                prettyRank = "K";
                                break;
                            default:
                                prettyRank = number.ToString();
                                break;
                        }

                        Console.Write(prettyRank.PadLeft(padding) + columnSeperator);
                    }
                    else
                    {
                        Console.Write(placeHolder.PadLeft(padding) + columnSeperator);
                    }

                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }

        // Method to assign suit colors
        static void SetSuitColor(int suitIndex)
        {
            switch (suitIndex)
            {
                case 0: // Heart Suit Color
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 1: // Spade Suit Color
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case 2: // Diamond Suit Color
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 3: // Club Suit Color
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
            }
        }

        // Method to draw cards
        static void DrawCard()
        {
            int suit = 0, number = 0;
            do
            {
                suit = RandomNumberZeroTo(3);
                number = RandomNumberZeroTo(12);

            } while (drawnCards[suit, number]);

            drawnCards[suit, number] = true;

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

        static void ClearDrawCards()
        {
            for (int suit = 0; suit < 4; suit++)
            {
                for (int number = 0; number < 13; number++)
                {
                    drawnCards[suit, number] = false;
                }
            }

        }
    }

}