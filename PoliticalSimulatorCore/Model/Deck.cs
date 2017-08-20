using PoliticalSimulatorCore.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.Model
{
    public class Deck
    {
        private const long serialVersionUID = 1L;
        private const int DECK_LIMIT = 30;
        private const int MAX_NUMBER_OF_CARD_IN_DECK = 2;
        private List<Card> cardList = new List<Card>();
        private String name;
        private static Random rng = new Random();
        //	private Stack<Card> deck = new Stack<Card>();

        /**
         * default constructor for the Deck class
         */
        public Deck()
        {
        }

        /**
         * constructor that takes the deck's name
         * @param name
         */
        public Deck(String name)
        {
        }


        ///////Deck Modifying Methods///////

        /**
         * Adds a card to the deck only if the deck has not reached its limit and there arent two of the same card in the deck.
         * @param cardToAdd the card to add
         * @return String containing message
         * @throws DeckFullException
         */
        public String addCard(Card cardToAdd)
        {
            if (getSize() >= DECK_LIMIT)
            {
                throw new DeckFullException();
                //return "The deck is full. Remove a card, then try to add a new card.";
            }
            else if (cardList.Count == 0)
            {
                cardList.Add(cardToAdd);
                return cardToAdd.getName() + " was added to the deck.";
            }
            else
            {
                if (getNumberOfCardInDeck(cardToAdd) < MAX_NUMBER_OF_CARD_IN_DECK)
                {
                    cardList.Add(cardToAdd);
                    return cardToAdd.getName() + " was added to the deck.";
                }
                else
                {
                    return "You cannot have more than 2 of the same cards";
                }
            }
        }

        /**
         * @param cardToCheck the card that you want to check
         * @return the number of that card in the deck
         */
        public int getNumberOfCardInDeck(Card cardToCheck)
        {
            int counter = 0;
            foreach (Card card in cardList)
            {
                if (card.Equals(cardToCheck))
                {
                    counter++;
                }
            }
            return counter;
        }

        /**
         * Remove a specified card from the deck
         * @param card Card to remove
         * @return Removal message
         */
        public String removeCard(Card card)
        {
            if (cardList.Contains(card))
            {
                cardList.Remove(card);
                return card.getName() + " was removed from the deck.";
            }
            else
            {
                return card.getName() + " is not in the deck.";
            }
        }

        ///**
        // * Swap a specified card for another card in the deck
        // * @param card Card to add to deck
        // * @param cardToRemove Card to get removed (swapped)
        // * @return Swap message
        // */
        //public String swapCard(Card card, Card cardToRemove)
        //{
        //    if (cardList.Contains(card))
        //        return ("You can't swap the same card.");
        //    if (cardList.Contains(cardToRemove))
        //    {
        //        cardList.Set(cardList.indexOf(cardToRemove), card);
        //        return card.getName() + " swapped with " + cardToRemove.getName();
        //    }
        //    else
        //    {
        //        return cardToRemove.getName() + " does not exist in the deck.";
        //    }
        //}

        /**
         * @return How many cards are left in the deck
         */
        public String getCardsLeftString()
        {
            return cardList.Count + "/" + DECK_LIMIT + " Cards Left in Deck";
        }

        /**
         * @return the size of the deck
         */
        public int getSize()
        {
            return cardList.Count;
        }

        /**
         * Returns the top card of the deck and removes from the list
         * @return the top card
         */
        public Card getTopCard()
        {
            Card tmp = cardList.First();
            cardList.RemoveAt(0);
            return tmp;
        }

        /**
         * Randomizes the order of Cards in the deck.
         * 
         * Turns out a lot harder in C#
         */
        public void shuffle()
        {
            cardList.Shuffle();
        }


        /**
         * @return The maximum number of decks available
         */
        public static int getLimit()
        {
            return DECK_LIMIT;
        }

        /**
         * @return All cards owned
         */
        public List<String> getStringsOfCards()
        {
            List<String> stringsOfCardsOwned = new List<String>();
            foreach (Card card in cardList)
            {
                stringsOfCardsOwned.Add(card.getName());
            }
            return stringsOfCardsOwned;
        }

        /**
         * @return Max number of Cards in a Deck
         */
        public int getMAX_NUMBER_OF_CARD_IN_DECK()
        {
            return MAX_NUMBER_OF_CARD_IN_DECK;
        }

        /**
         * @return the name of the Deck
         */
        public String getName()
        {
            return name;
        }

        /**
         * @param name The name to set to the Deck
         */
        public void setName(String name)
        {
            this.name = name;
        }

        /**
         * @return true if the deck is full, false if not
         */
        public bool isFull()
        {
            if (cardList.Count == DECK_LIMIT)
            {
                return true;
            }
            return false;
        }

        /**
         * @param cardList List of cards to set to the deck
         */
        public void setCardList(List<Card> cardList)
        {
            this.cardList = cardList;
        }
    }

    public static class ThreadSafeRandom
    {
        [ThreadStatic] private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }

    static class MyExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
