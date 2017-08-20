using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.Model
{
    public class Pack
    {
        private const long serialVersionUID = 1L;
        private List<Card> cardsInPack;
        private const int MAX_CARDS_IN_PACK = 5;
        private Random rng;

        public Pack()
        {
            cardsInPack = new List<Card>(MAX_CARDS_IN_PACK);
            populatePack();
        }

        /**
         * Adds the max number of cards to a pack. Always at least one rare card in each pack.
         */
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
            //		for(int i = 0; i < (MAX_CARDS_IN_PACK-1); i++){
            //			if(allCards.get(rng.nextInt(allCards.size())) instanceof RareCreature){
            //				
            //			}
            //			cardsInPack.add(allCards.get(rng.nextInt(allCards.size())));
            //		}
            //always have at least 1 rare card in pack
            cardsInPack.Add(rareCards[(rng.Next(rareCards.Count))]);
        }

        /**
         * @return the cardsInPack
         */
        public List<Card> getCardsInPack()
        {
            return cardsInPack;
        }

        /**
         * @param cardsInPack the cardsInPack to set
         */
        public void setCardsInPack(List<Card> cardsInPack)
        {
            this.cardsInPack = cardsInPack;
        }

        /**
         * @return the cARDS_IN_PACK
         */
        public int getMAX_CARDS_IN_PACK()
        {
            return MAX_CARDS_IN_PACK;
        }
    }
}
