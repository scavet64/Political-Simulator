using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.Model
{
    [Serializable]
    public class Pack
    {
        public const int MAX_CARDS_IN_PACK = 5;
        private const long serialVersionUID = 1L;

        private List<Card> cardsInPack;
        private Random rng;

        /// <summary>
        /// Gets or sets the cards in pack.
        /// </summary>
        /// <value>The cards in pack.</value>
        public List<Card> CardsInPack
        {
            get{
                return cardsInPack;
            }
            set{
                cardsInPack = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PoliticalSimulatorCore.Model.Pack"/> class.
        /// </summary>
        public Pack()
        {
            cardsInPack = new List<Card>(MAX_CARDS_IN_PACK);
            populatePack();
        }

        /// <summary>
        /// Populates the pack. Always at least one rare in the pack
        /// </summary>
        private void populatePack()
        {
            List<Card> allCards = AllCards.getInstance().GetAllCards();
    
            List<Card> rareCards = AllCards.getInstance().GetRareCardsList();
            rng = new Random();
            int i = 0;
            while (i < (MAX_CARDS_IN_PACK - 1))
            {
                //first round of randomization
                Card cardToAdd = allCards[(rng.Next(allCards.Count))];
                if (cardToAdd is RareCreature){
                    if (rng.Next(100) >= 40)
                    {
                        cardsInPack.Add(cardToAdd);
                        i++;
                    }
                }else{
                    cardsInPack.Add(cardToAdd);
                    i++;
                }
            }
            //always have at least 1 rare card in pack
            cardsInPack.Add(rareCards[(rng.Next(rareCards.Count))]);
        }
    }
}
