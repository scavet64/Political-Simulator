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
        //Constants
        private const long serialVersionUID = 1L;
        private const int DECK_LIMIT = 30;
        private const int MAX_NUMBER_OF_CARD_IN_DECK = 2;

        //Variables
        private List<Card> cardList = new List<Card>();
        private String name;
        private static Random rng = new Random();
        //	private Stack<Card> deck = new Stack<Card>();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PoliticalSimulatorCore.Model.Deck"/> class.
        /// </summary>
        public Deck()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PoliticalSimulatorCore.Model.Deck"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        public Deck(String name)
        {
        }

		/// <summary>
		/// Adds a card to the deck only if the deck has not reached its limit and there arent two of the same card in the deck.
		/// </summary>
		/// <returns>The card.</returns>
		/// <param name="cardToAdd">Card to add.</param>
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
                return cardToAdd.Name + " was added to the deck.";
            }
            else
            {
                if (getNumberOfCardInDeck(cardToAdd) < MAX_NUMBER_OF_CARD_IN_DECK)
                {
                    cardList.Add(cardToAdd);
                    return cardToAdd.Name + " was added to the deck.";
                }
                else
                {
                    return "You cannot have more than 2 of the same cards";
                }
            }
        }

        /// <summary>
        /// Gets the number of card in deck.
        /// </summary>
        /// <returns>The number of card in deck.</returns>
        /// <param name="cardToCheck">Card to check.</param>
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

        /// <summary>
        /// Removes the card.
        /// </summary>
        /// <returns>The card.</returns>
        /// <param name="card">Card.</param>
        public String removeCard(Card card)
        {
            if (cardList.Contains(card))
            {
                cardList.Remove(card);
                return card.Name + " was removed from the deck.";
            }
            else
            {
                return card.Name + " is not in the deck.";
            }
        }

        ///Commented this code out because it doesnt convert well into c# and im not sure why we would every use it.
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

        /// <summary>
        /// Gets the cards left string.
        /// </summary>
        /// <returns>The cards left string.</returns>
        public String getCardsLeftString()
        {
            return cardList.Count + "/" + DECK_LIMIT + " Cards Left in Deck";
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <returns>The size.</returns>
        public int getSize()
        {
            return cardList.Count;
        }

        /// <summary>
        /// Gets the top card.
        /// </summary>
        /// <returns>The top card.</returns>
        public Card getTopCard()
        {
            Card tmp = cardList.First();
            cardList.RemoveAt(0);
            return tmp;
        }

        /// <summary>
        /// Shuffle this instance.
        /// </summary>
        public void shuffle()
        {
            cardList.Shuffle();
        }

        /// <summary>
        /// Gets the limit.
        /// </summary>
        /// <returns>The limit.</returns>
        public static int getLimit()
        {
            return DECK_LIMIT;
        }

        /// <summary>
        /// Gets the strings of cards.
        /// </summary>
        /// <returns>The strings of cards.</returns>
        public List<String> getStringsOfCards()
        {
            List<String> stringsOfCardsOwned = new List<String>();
            foreach (Card card in cardList)
            {
                stringsOfCardsOwned.Add(card.Name);
            }
            return stringsOfCardsOwned;
        }

        /// <summary>
        /// Gets the max number of card in deck.
        /// </summary>
        /// <returns>The max number of card in deck.</returns>
        public int getMAX_NUMBER_OF_CARD_IN_DECK()
        {
            return MAX_NUMBER_OF_CARD_IN_DECK;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns>The name.</returns>
        public String getName()
        {
            return name;
        }

        /// <summary>
        /// Sets the name of the deck
        /// </summary>
        /// <param name="name">Name.</param>
        public void setName(String name)
        {
            this.name = name;
        }

        /// <summary>
        /// Checks to see if the deck is full.
        /// </summary>
        /// <returns><c>true</c>, if the deck is full, <c>false</c> otherwise.</returns>
        public bool isFull()
        {
            if (cardList.Count == DECK_LIMIT)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sets the card list.
        /// </summary>
        /// <param name="cardList">Card list.</param>
        public void setCardList(List<Card> cardList)
        {
            this.cardList = cardList;
        }
    }

    /// <summary>
    /// Thread safe random.
    /// </summary>
    public static class ThreadSafeRandom
    {
        [ThreadStatic] private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }

    /// <summary>
    /// My extensions.
    /// </summary>
    static class MyExtensions
    {
        /// <summary>
        /// Shuffle the specified list.
        /// </summary>
        /// <returns>The shuffle.</returns>
        /// <param name="list">List.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
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
