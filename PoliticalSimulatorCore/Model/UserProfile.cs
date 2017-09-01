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
        private const int MAX_NUMBER_OF_CARDS_IN_COLLECTION = 2;

        private int wins;

        public int Wins
        {
            get { return wins; }
            set { wins = checkValue(value); }
        }

        private int credits;

        public int Credits
        {
            get { return credits; }
            set
            {
                credits = checkValue(value);
            }
        }

        private int losses;

        public int Losses
        {
            get { return losses; }
            set { losses = checkValue(value); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private bool isFirstLoad;

        public bool IsFirstLoad
        {
            get { return isFirstLoad; }
            set { isFirstLoad = value; }
        }

        private Deck currentDeck;

        public Deck CurrentDeck
        {
            get { return currentDeck; }
            set { currentDeck = value; }
        }

        private List<Pack> packs;

        public List<Pack> Packs
        {
            get { return packs; }
            set { packs = value; }
        }

        private List<Card> collectedCards;

        public List<Card> CollectedCards
        {
            get { return collectedCards; }
            set { collectedCards = value; }
        }

        private string playerImagePath;

        public string PlayerImagePath
        {
            get { return playerImagePath; }
            set { playerImagePath = value; }
        }

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
            playerImagePath = @"Images/defaultPlayer.png";
            IsFirstLoad = true;
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
        public void subtractCredits(int creditsToSubtract)
        {
            this.credits -= creditsToSubtract;
        }

        private int checkValue(int valueToCheck)
        {
            if(valueToCheck < 0)
            {
                return 0;
            }
            return valueToCheck;
        }
    }
}
