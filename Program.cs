using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //introductory text & taking legal input from the user
                int gameSelect = 0;
                string gs = "";
                Console.WriteLine("Welcome User, Please Select the Number of a Game to Play:\n");
                Console.WriteLine("1. Blackjack\n");

                while(true)
                {
                    gs = Console.ReadLine();
                    try
                    {
                        gameSelect = Convert.ToInt32(gs);
                    }
                    catch
                    {
                        Console.WriteLine("Please Provide Legal Input\n\n\n");
                        System.Threading.Thread.Sleep(500);
                    }
                    break;
                }

                //Blackjack
                if (gameSelect == 1)
                {

                    //Keeping track of statistics
                    int wins = 0;
                    int losses = 0;
                    int ties = 0;

                    //Arrays to store cards for the player, and the ai
                    Card[] player = new Card[10];
                    Card[] ai = new Card[10];

                    //Clear the screen & write introduction
                    Console.Clear();
                    Console.WriteLine("Blackjack: You are dealt 2 cards, and your goal is to reach the\n" +
                                      "Highest score less than or equal to 21, on any given turn you can\n" +
                                      "Choose to hit (take a card), or stay (fold). Aces are high.\n");
                    //Store round and exit data
                    int round = 1;
                    bool playerBlackJackOrBust = false;

                    //Main loop
                    while(true)
                    {
                        Console.WriteLine("Wins: " + wins + "\n" +
                                          "Losses: " + losses + "\n" +
                                          "Ties: " + ties + "\n");

                        //Reset deck & shuffle between rounds
                        Deck deck = new Deck();
                        deck.shuffle();

                        //Create the ai object, and it's related variables
                        BlackjackAI blackjackAI = new BlackjackAI();
                        ai[0] = deck.getCard();
                        ai[1] = deck.getCard();
                        int aiPointer = 2;
                        int aiValue = ai[0].getValue() + ai[1].getValue();
                        blackjackAI.addToHand(ai[0].getValue());
                        blackjackAI.addToHand(ai[1].getValue());
                        bool aiBustOrBlackJack = false;

                        //Setting things up for the player
                        Console.WriteLine("Hand " + round+"\n");
                        player[0] = deck.getCard();
                        player[1] = deck.getCard();
                        int playerPointer = 2;
                        int playerVal = player[0].getValue() + player[1].getValue();
                        string cards = "Cards: " + player[0].toString() + ", " + player[1].toString();
                        Console.WriteLine(cards);

                        //Player's loop
                        while(playerVal<21)
                        {
                            Console.Write("Hit or stay? ");
                            string choice = Console.ReadLine();

                            //Case for if the player chooses to hit
                            if (choice.ToLower().Equals("hit"))
                            {

                                /*Draws a card from the deck, moves the pointer in the deck, then
                                * Uses an integer pointer to manage current position in the deck,
                                * and the valid length of the array
                                */

                                player[playerPointer] = deck.getCard();
                                cards += ", " + player[playerPointer].toString();
                                playerVal += player[playerPointer].getValue();
                                playerPointer++;
                                Console.WriteLine(cards);a

                                //Logic for checking for a bust or blackjack
                                if(playerVal > 21)
                                {
                                    Console.WriteLine("Bust! You lose!\n");
                                    playerBlackJackOrBust = true;
                                    losses++;
                                }
                                else if(playerVal == 21)
                                {
                                    Console.WriteLine("Blackjack! You win!\n");
                                    playerBlackJackOrBust = true;
                                    wins++;
                                }
                            }
                            //Standard Case
                            else
                            {
                                playerBlackJackOrBust = false;
                                break;
                            }
                        }

                        //Checks for a win or loss, and then assigns the player the propper statistic
                        if(playerBlackJackOrBust)
                        {
                            round++;
                            System.Threading.Thread.Sleep(500);
                            continue;
                        }

                        //Checking if the AI got a blackjack, and ending the round in this case
                        if(aiValue == 21)
                        {
                            Console.WriteLine("AI Blackjacked! You lose!");
                            losses++;
                            round++;
                            System.Threading.Thread.Sleep(500);
                            continue;
                        }

                        //AI's loop, follows the same steps as player loop, but does not output the data
                        while (aiValue < 21)
                        {
                            if(blackjackAI.chooseIfHit())
                            {
                                Console.WriteLine("AI Chooses to hit...");
                                System.Threading.Thread.Sleep(500);
                                ai[aiPointer] = deck.getCard();
                                blackjackAI.addToHand(ai[aiPointer].getValue());
                                aiValue += ai[aiPointer].getValue();
                                aiPointer++;

                                if(aiValue > 21)
                                {
                                    Console.WriteLine("AI Bust! You Win!");
                                    aiBustOrBlackJack = true;
                                    losses++;
                                }
                                else if(aiValue == 21)
                                {
                                    Console.WriteLine("AI Blackjacked! You Lose!");
                                    aiBustOrBlackJack = true;
                                    wins++;
                                }
                            }
                            else
                            {
                                Console.WriteLine("AI chooses to stay...");
                                System.Threading.Thread.Sleep(500);
                                break;
                            }
                        }

                        if(aiBustOrBlackJack)
                        {
                            round++;
                            System.Threading.Thread.Sleep(500);
                            continue;
                        }

                        //final logic to check for a win/loss/tie, and updating score
                        if(playerVal > aiValue)
                        {
                            Console.WriteLine("You Won! " + playerVal + "-" + aiValue);
                            wins++;
                        }
                        else if(aiValue > playerVal)
                        {
                            Console.WriteLine("You Lost! " + aiValue + "-" + playerVal);
                            losses++;
                        }
                        else
                        {
                            Console.WriteLine("Tie! " + playerVal + "-" + aiValue);
                            ties++;
                        }

                        //ending the round by clearing the screen and updating round counter
                        round++;
                        System.Threading.Thread.Sleep(500);
                        Console.Clear();
                    }
                }

                //Gin Rummy
                else if(gameSelect == 2)
                {

                    //Stats
                    int wins = 0;
                    int losses = 0;
                    int ties = 0;

                    //Array for the player's Hand
                    Card[] player = new Card[11];

                    //Arrays for the ai to use
                    Card[] AIFinal = new Card[11];
                    Card[] AIMedPriority = new Card[11];
                    Card[] AITopPriority = new Card[11];

                    //Round counter
                    int round = 1;
                    
                    //Main Loop
                    while(true)
                    {
                        Console.WriteLine("Wins: " + wins + "\n" +
                                          "Losses: " + losses + "\n" +
                                          "Ties: " + ties + "\n");
                        //TODO: implement game
                    }
                }
            }
        }
    }
}