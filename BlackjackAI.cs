using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{

    /*A rudimentary AI to simulate the house player in blackjack
    * Uses simple numerics to calculate the moves, with a bit of
    * randomness thrown in to make it less predictable
    */
    class BlackjackAI
    {

        //Field used to calculate the AI's move
        private int handVal;

        //Very simple constructor, waiting to be dealt a hand
        public BlackjackAI()
        {
            handVal = 0;
        }

        //Accessor of the handVal field
        public int getHandVal()
        {
            return handVal;
        }

        //"Deals" a card to the AI
        public void addToHand(int val)
        {
            handVal += val;
        }
        
        //Algorithm to choose if the AI will hit or stay, and returning this choice
        public bool chooseIfHit()
        {
            if(handVal < 15)
            {
                return true;
            }
            else if(handVal >= 15 && handVal <18)
            {
                Random r = new Random();
                if(r.Next(2) == 0)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
