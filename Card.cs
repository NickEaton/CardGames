using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    class Card
    {
        private string face; //Face of the card, IE heart, spade, etc.
        private int cardNum; //Numeric value used for internal assignment and checking
        private int cardVal; //Value of the card the player cares about

        public string getFace()
        {
            return face;
        }

        public void setFace(string nFace)
        {
            if(nFace.ToLower().Equals("hearts") || nFace.ToLower().Equals("clubs") ||
               nFace.ToLower().Equals("spades") || nFace.ToLower().Equals("diamonds"))
            {
                char[] temp = nFace.ToCharArray();
                face = temp[0].ToString().ToUpper() + nFace.Substring(1).ToLower();
            }

            //Throw an exception if an illegal face value is passed
            else
            {
                throw new OverflowException("Illegal Argument, " + nFace + " is not a legal parameter");
            }
        }

        //returns the internal value
        public int getCardNumeric()
        {
            return cardNum;
        }

        //chainging internal value
        public void setCardNumeric(int val)
        {
            if(val > 0 && val <= 13)
            {
                cardNum = val;
            }
            else
            {
                throw new OverflowException("Value out of range");
            }
        }

        //returns the actual computed value of the card
        public int getValue()
        {
            if(cardNum >= 11)
            {
                return 10;
            }
            if(cardNum ==1 )
            {
                return 11;
            }
            return cardNum;
        }

        //value output to the user
        public string getRealCard()
        {
            if(cardNum == 11)
            {
                return "Jack";
            }
            else if(cardNum == 12)
            {
                return "Queen";
            }
            else if(cardNum == 13)
            {
                return "King";
            }
            else if(cardNum == 1)
            {
                return "Ace";
            }
            return "" + cardNum;
        }

        //Constructer
        public Card(string face, int val)
        {
            this.face = face;
            this.cardNum = val;
        }

        //Printable method
        public String toString()
        {
            return "[" + this.getRealCard() + " of " + this.getFace()+"]";
        }
    }
}