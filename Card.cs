using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise9
{
    /// <summary>
    /// A playing card
    /// </summary>
    public class Card
    {
        #region Fields
        string rank;
        string suit;
        bool faceUp;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a card with the given rank and suit
        /// </summary>
        /// <param name="rank">the rank</param>
        /// <param name="suit">the suit</param>
        public Card(string rank, string suit)
        {
            this.rank = rank;
            this.suit = suit;
            faceUp = false;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the card rank
        /// </summary>
        public string Rank 
        {
            get { return rank; }
        }

        /// <summary>
        /// Gets the card suit
        /// </summary>
        public string Suit 
        {
            get { return suit; }
        }

        /// <summary>
        /// Gets whether or not the card is face up
        /// </summary>
        public bool FaceUp 
        {
            get { return faceUp; }
        }

        
        #endregion

        #region Public methods

        /// <summary>
        /// Flips the card over
        /// </summary>
        public void FlipOver() 
        {
            faceUp = !faceUp;
        }

        public int getScore()
        {
            int pointValue = 0;
            if(rank == "Ace")
            {
                pointValue = 1;
            }else if(rank == "Two")
            {
                pointValue = 2;
            }
            else if (rank == "Three")
            {
                pointValue = 3;
            }
            else if (rank == "Four")
            {
                pointValue = 4;
            }
            else if (rank == "Five")
            {
                pointValue = 5;
            }
            else if (rank == "Six")
            {
                pointValue = 6;
            }
            else if (rank == "Seven")
            {
                pointValue = 7;
            }
            else if (rank == "Eight")
            {
                pointValue = 8;
            }
            else if (rank == "Nine")
            {
                pointValue = 9;
            }
            else if (rank == "Ten")
            {
                pointValue = 10;
            }
            else if (rank == "Jack")
            {
                pointValue = 11;
            }
            else if (rank == "Queen")
            {
                pointValue = 12;
            }
            else if (rank == "King")
            {
                pointValue = 13;
            }
            return pointValue;
        }

        #endregion
    }
}
