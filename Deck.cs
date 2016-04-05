using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class Deck
    { 
        private Card[] deck = new Card[52]; //Contains 13 cards in 4 suits
        private int pointer = -1; //Starts the pointer at -1, as the method adjusts the pointer first, fencepost design

        //constructer creates a new sorted deck
        public Deck()
        {
            this.sort();
        }

        //Uses a random value to shuffle the deck
        public void shuffle()
        {
            Random rand = new Random();
            int rVal = 0;
            for(int i = 0; i <= 51; i++)
            {
                rVal = rand.Next(51);
                swapCard(this.deck, i, rVal);
            }
        }

        //Creates a new, sorted deck
        public void sort()
        {
            int count = 0;
            String[] faces = { "Hearts", "Diamonds", "Clubs", "Spades" };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    deck[count] = new Card(faces[i], j);
                    count++;
                }
            }
        }

        //Gets a new card and moves the pointer
        public Card getCard()
        {
            pointer++;
            return deck[pointer];
        }

        //returns the deck as a string
        public string toString()
        {
            string sDeck = "[";
            for (int i = 0; i < 51; i++)
            {
                sDeck += deck[i].toString() + ", ";
            }
            sDeck += deck[51].toString() + "]";
            return sDeck;
        }

        //inter-class method to swap 2 cards in the array
        private void swapCard(Card[] c, int index1, int index2)
        {
            Card temp = c[index2];
            c[index2] = c[index1];
            c[index1] = temp;
        }
    }
}