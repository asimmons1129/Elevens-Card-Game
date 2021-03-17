using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise9
{
    public class ElevensBoard
    {
        #region Fields
        private const int BOARD_SIZE = 9;

        private Card[] CardField;

        private Deck deck;

        private const bool I_AM_DEBUGGING = false;
        #endregion

        #region Constructors

        public ElevensBoard()
        {
            CardField = new Card[BOARD_SIZE];
            deck = new Deck();
            if (I_AM_DEBUGGING)
            {
                deck.Print();
                Console.WriteLine(" ");
            }
            dealMyCards();
            
        }
        #endregion

        #region Methods

        public void newGame()
        {
            deck.Shuffle();
            dealMyCards();
        }

        public int size()
        {
            return BOARD_SIZE;
        }

        public bool isEmpty()
        {
            for (int k = 0; k < BOARD_SIZE; k++)
            {
                if (CardField[k] != null)
                {
                    return false;
                }
            }
            return true;
        }

        public bool containsPairSum11(List<int> selectedCardIndex)
        {
            if(selectedCardIndex.Count < 2)
            {
                return false;
            }
            Card c1, c2;
            for(int i=0; i<selectedCardIndex.Count; i++)
            {
                c1 = CardField[selectedCardIndex[i]];
                if(selectedCardIndex.Count > i + 1)
                {
                    for(int j=i+1; j<selectedCardIndex.Count; j++)
                    {
                        c2 = CardField[selectedCardIndex[j]];
                        if(c1.getScore() + c2.getScore() == 11)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool containsJQK(List<int> selectedCardIndex)
        {
            if(selectedCardIndex.Count < 3)
            {
                return false;
            }
            bool jack = false;
            bool queen = false;
            bool king = false;
            for(int i=0; i<selectedCardIndex.Count; i++)
            {
                Card c = CardField[i];
                if(c.Rank == "Jack")
                {
                    jack = true;
                }
                if(c.Rank == "Queen")
                {
                    queen = true;
                }
                if(c.Rank == "King")
                {
                    king = true;
                }
            }
            return jack && queen && king;
        }

        public bool isLegal(List<int> selectedCardIndex)
        {
            if(selectedCardIndex.Count == 2 && containsPairSum11(selectedCardIndex))
            {
                return true;
            }
            if(selectedCardIndex.Count == 3 && containsJQK(selectedCardIndex))
            {
                return true;
            }
            return false;
        }

        public bool anotherPlayIsPossible()
        {
            List<int> selectedCardIndex = new List<int>();
            for(int i=0; i<CardField.Length; i++)
            {
                if(CardField[i] != null)
                {
                    selectedCardIndex.Add(i);
                }
            }
            return containsPairSum11(selectedCardIndex) || containsJQK(selectedCardIndex);
        }

        public void dealMyCards()
        {
            for (int i = 0; i < CardField.Length; i++)
            {
                CardField[i] = deck.TakeTopCard();
                CardField[i].FlipOver();
            }
        }

        public void replaceSelectedCards(List<int> selectedCards)
        {
            foreach (int k in selectedCards)
            {
                deal(k);
            }
        }

        public void deal(int k)
        {
            CardField[k] = deck.TakeTopCard();
            CardField[k].FlipOver();
        }

        public Card cardAt(int k)
        {
            return CardField[k];
        }

        public List<int> CardIndexes()
        {
            List<int> selected = new List<int>();
            for (int k = 0; k < BOARD_SIZE; k++)
            {
                if (CardField[k] != null)
                {
                    selected.Add(k);
                }
            }
            return selected;
        }

        public String printBoardCards()
        {
            String s = "";
            for (int k = 0; k < BOARD_SIZE; k++)
            {
                s = s + k + ": " + CardField[k].Rank + " of " + CardField[k].Suit + "\n";
            }
            return s;
        }

        public bool gameIsWon()
        {
            if (deck.Empty)
            {
                foreach (Card c in CardField)
                {
                    if (c != null)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

            


        #endregion




    }
}
