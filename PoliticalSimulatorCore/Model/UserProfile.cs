using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.Model
{
    //TODO: make this an XML class maybe
    [Serializable]
    public class UserProfile
    {
        private const long serialVersionUID = 1L;
        private String name;
        private int wins;
        private int losses;
        private int credits;    //credits the user can use to spend on new card packs
        private Deck currentDeck;
        private bool isFirstLoad;
        private const int MAX_NUMBER_OF_CARDS_IN_COLLECTION = 2;
        private List<Pack> packs;
        private List<Card> collectedCards;
        private String playerImagePath;


        //	maybe one day
        //	private ArrayList <Deck> decks = new ArrayList<Deck>();
        //	private final int MAX_NUMBER_OF_DECKS = 9;


        /// <summary>
        /// Initializes a new instance of the <see cref="T:PoliticalSimulatorCore.Model.UserProfile"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        public UserProfile(String name)
        {
            this.name = name;
            currentDeck = new Deck();
            collectedCards = new List<Card>();
            packs = new List<Pack>();
            credits = 100;
            playerImagePath = "images//defaultPlayer.png";
            setFirstLoad(true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PoliticalSimulatorCore.Model.UserProfile"/> class.
        /// </summary>
        public UserProfile()
        {

        }

        /**
         * @return stringOfCardsOwned collection of cards player has opened
         */
        public List<String> getStringsOfCardsOwned()
        {
            List<String> stringsOfCardsOwned = new List<String>();
            foreach (Card card in collectedCards)
            {
                stringsOfCardsOwned.Add(card.Name);
            }
            return stringsOfCardsOwned;
        }

        /**
         * @Return array of cards owned
         */
        public String[] getCardOwnedNameArray()
        {
            return (String[])getStringsOfCardsOwned().ToArray();
        }

        /**
         * @param numberOfPacks how many packs player is trying to purchase
         * @param totalCost cost of the selected amount of packs
         * @return true if player can afford, false if player failed to afford
         */
        public bool purchasePacks(int numberOfPacks, int totalCost)
        {
            if (totalCost <= credits)
            {
                for (int i = 0; i < numberOfPacks; i++)
                {
                    packs.Add(new Pack());
                }
                subtractCredits(totalCost);
                return true;
            }
            else
            {
                return false;
            }
        }

        /**
         * @Param cardToAdd card to check with player's current collection to see 
         * if they can hold another in their collection
         * @Return true if success, false if fail
         */
        public bool addCard(Card cardToAdd)
        {
            int counter = 0;
            foreach (Card card in collectedCards)
            {
                if (card.Equals(cardToAdd))
                {
                    counter++;
                }
            }
            if (counter < MAX_NUMBER_OF_CARDS_IN_COLLECTION)
            {
                collectedCards.Add(cardToAdd);
                return true;
            }
            else
            {
                return false;
            }
        }

        /**
         * @Return name
         */
        public String toString()
        {
            return name;
        }

        /**
         * @Param creditsToAdd Credits to be added to the user's stats.
         */
        public void addCredits(int creditsToAdd)
        {
            this.credits += creditsToAdd;
        }

        /**
         * @Param creditsToSubtract Credits to be removed from the user's stats.
         */
        private void subtractCredits(int creditsToSubtract)
        {
            this.credits -= creditsToSubtract;
        }

        ///////Getters & Setters///////

        /**
         * @return the name
         */
        public String getName()
        {
            return name;
        }

        /**
         * @param name the name to set
         */
        public void setName(String name)
        {
            this.name = name;
        }

        /**
         * @return the wins
         */
        public int getWins()
        {
            return wins;
        }

        /**
         * @param wins the wins to set
         */
        public void setWins(int wins)
        {
            this.wins = wins;
        }

        /**
         * @return the losses
         */
        public int getLosses()
        {
            return losses;
        }

        /**
         * @param losses the losses to set
         */
        public void setLosses(int losses)
        {
            this.losses = losses;
        }

        /**
         * @return the deck
         */
        public Deck getDeck()
        {
            return currentDeck;
        }

        /**
         * @param deck the deck to set
         */
        public void setDeck(Deck deck)
        {
            this.currentDeck = deck;
        }

        /**
         * @return the collectedCards
         */
        public List<Card> getCollectedCards()
        {
            return collectedCards;
        }

        /**
         * @param collectedCards the collectedCards to set
         */
        public void setCollectedCards(List<Card> collectedCards)
        {
            this.collectedCards = collectedCards;
        }

        /**
         * @return the credits
         */
        public int getCredits()
        {
            return credits;
        }

        /**
         * @param credits the credits to set
         */
        public void setCredits(int credits)
        {
            this.credits = credits;
        }

        /**
         * @return the packs
         */
        public List<Pack> getPacks()
        {
            return packs;
        }

        /**
         * @param packs the packs to set
         */
        public void setPacks(List<Pack> packs)
        {
            this.packs = packs;
        }

        /**
         * Increment wins
         */
        public void addWin()
        {
            wins++;
        }

        /**
         * increment losses
         */
        public void addLoss()
        {
            losses++;
        }

        /**
         * @return the playerImagePath
         */
        public String getPlayerImagePath()
        {
            return playerImagePath;
        }

        /**
         * @param playerImagePath the playerImagePath to set
         */
        public void setPlayerImagePath(String playerImagePath)
        {
            this.playerImagePath = playerImagePath;
        }

        /**
         * @return the isFirstLoad
         */
        public bool IsFirstLoad()
        {
            return isFirstLoad;
        }

        /**
         * @param isFirstLoad the isFirstLoad to set
         */
        public void setFirstLoad(bool isFirstLoad)
        {
            this.isFirstLoad = isFirstLoad;
        }
    }
}
