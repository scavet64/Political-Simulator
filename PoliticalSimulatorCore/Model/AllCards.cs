using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.Model
{
    public class AllCards
    {
        private static AllCards instance;
        private List<Card> allCards = new List<Card>();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PoliticalSimulatorCore.Model.AllCards"/> class.
        /// </summary>
        private AllCards()
        {
            //initialize all cards here		
            //name,fatigue,chance,attack,health,type,CardImage,FieldImage
            //Charismatic Cards
            /*-1*/
            //allCards.Add(new Creature("Thonking", 2, 80, 1, 2, Type.CHARASMATIC, "CardImages\\2d4.png", "FieldImages\\hankField.png"));

            /*0*/
            allCards.Add(new Creature("Hank Hill", 2, 80, 1, 2, Type.CHARASMATIC, "CardImages\\hankCard.png", "FieldImages\\hankField.png"));
            /*1*/
            allCards.Add(new Creature("Billy Mays", 2, 90, 4, 2, Type.CHARASMATIC, "CardImages\\billyCard.png", "FieldImages\\BillyMaysField.png"));
            /*2*/
            allCards.Add(new Creature("Esteban Winsmore", 3, 90, 5, 3, Type.CHARASMATIC, "CardImages\\EstebanCard.png", "FieldImages\\EstebanField.png"));
            /*3*/
            allCards.Add(new Creature("Handsome Squidward", 5, 75, 5, 5, Type.CHARASMATIC, "CardImages\\HsquidCard.png", "FieldImages\\handsomeSquidwardField.png"));
            /*4*/
            allCards.Add(new RareCreature("Vladimir Putin", 7, 90, 7, 8, Type.CHARASMATIC, "CardImages\\VladimirPutinCard.png", "FieldImages\\VladPutinField.png"));
            /*5*/
            allCards.Add(new RareCreature("Based God", 2, 100, 4, 5, Type.CHARASMATIC, "CardImages\\lilBCard.png", "FieldImages\\basedGodField.png"));

            //Fighter Cards
            /*6*/
            allCards.Add(new Creature("Butch DeLoria", 2, 85, 3, 1, Type.FIGHTER, "CardImages\\tunnelCard.png", "FieldImages\\tunnelField.png"));
            /*7*/
            allCards.Add(new RareCreature("Champ", 3, 90, 3, 3, Type.FIGHTER, "CardImages\\champCard.png", "FieldImages\\champField.png"));
            /*8*/
            allCards.Add(new Creature("Adam Jensen", 4, 95, 3, 4, Type.FIGHTER, "CardImages\\adamCard.png", "FieldImages\\adamField.png"));
            /*9*/
            allCards.Add(new Creature("Salty Bouncer", 5, 85, 6, 4, Type.FIGHTER, "CardImages\\saltyCard.png", "FieldImages\\saltyField.png"));
            /*10*/
            allCards.Add(new Creature("Sanic", 5, 75, 6, 6, Type.FIGHTER, "CardImages\\sanicCard.png", "FieldImages\\sanicField.png"));
            /*11*/
            allCards.Add(new RareCreature("The Regginator", 7, 85, 7, 9, Type.FIGHTER, "CardImages\\regginatorCard.png", "FieldImages\\regginatorField.png"));

            //Genius Cards
            /*12*/
            allCards.Add(new Creature("Walter White", 3, 85, 3, 4, Type.GENIUS, "CardImages\\waltCard.png", "FieldImages\\waltField.png"));
            /*13*/
            allCards.Add(new Creature("Tony Stark", 5, 85, 5, 7, Type.GENIUS, "CardImages\\tonyCard.png", "FieldImages\\tonyStarkField.png"));
            /*14*/
            allCards.Add(new Creature("Todd Howard", 5, 70, 6, 6, Type.GENIUS, "CardImages\\toddCard.png", "FieldImages\\toddField.png"));
            /*15*/
            allCards.Add(new RareCreature("Gabe Newell", 6, 70, 7, 7, Type.GENIUS, "CardImages\\gabeCard.png", "FieldImages\\gabeField.png"));
            /*16*/
            allCards.Add(new Creature("Bill Nye The Science Guy", 7, 95, 4, 10, Type.GENIUS, "CardImages\\billCard.png", "FieldImages\\billField.png"));
            /*17*/
            allCards.Add(new RareCreature("Rick Sanchez", 7, 80, 7, 10, Type.GENIUS, "CardImages\\rickCard.png", "FieldImages\\rickField.png"));

            //Magic Cards
            /*18*/
            allCards.Add(new Creature("Glass Bones", 2, 90, 6, 1, Type.MAGIC, "CardImages\\glassBonesCard.png", "FieldImages\\glassBonesField.png"));
            /*19*/
            allCards.Add(new Creature("Rock Lobster", 3, 85, 5, 3, Type.MAGIC, "CardImages\\rockCard.png", "FieldImages\\rockField.png"));
            /*20*/
            allCards.Add(new RareCreature("Snoop Dogg", 4, 20, 4, 20, Type.MAGIC, "CardImages\\snoopDoggCard.png", "FieldImages\\snoopDoggField.png"));
            /*21*/
            allCards.Add(new Creature("Mr. Meeseeks", 5, 100, 5, 7, Type.MAGIC, "CardImages\\mrMeeSeeksCard.png", "FieldImages\\mrMeeseeksField.png"));
            /*22*/
            allCards.Add(new Creature("Cromulon", 7, 95, 6, 7, Type.MAGIC, "CardImages\\cromulonCard.png", "FieldImages\\CromulonField.png"));
            /*23*/
            allCards.Add(new RareCreature("Bob Ross", 7, 80, 9, 9, Type.MAGIC, "CardImages\\bobrossCard.png", "FieldImages\\bobRossField.png"));

            //Psycho Cards
            /*24*/
            allCards.Add(new Creature("Blue Eyes Orange Orange", 2, 40, 6, 2, Type.PSYCHO, "CardImages\\OrangeOrangeCard.png", "FieldImages\\OrangeOrange.png"));
            /*25*/
            allCards.Add(new Creature("Old Timer", 2, 85, 2, 4, Type.PSYCHO, "CardImages\\oldTimerCard.png", "FieldImages\\oldTimerField.png"));
            /*26*/
            allCards.Add(new RareCreature("Kim Jong Un", 4, 50, 7, 5, Type.PSYCHO, "CardImages\\kimJongUnCard.png", "FieldImages\\kimJongUnField.png"));
            /*27*/
            allCards.Add(new Creature("Brian Peppers", 4, 75, 6, 5, Type.PSYCHO, "CardImages\\brianPepsCard.png", "FieldImages\\brianPepsField.png"));
            /*28*/
            allCards.Add(new Creature("Trevor Phillips", 5, 70, 6, 7, Type.PSYCHO, "CardImages\\trevorCard.png", "FieldImages\\trevorField.png"));
            /*29*/
            allCards.Add(new RareCreature("Freaky Fred", 7, 85, 6, 8, Type.PSYCHO, "CardImages\\FreakyFredCard.png", "FieldImages\\freakyFredField.png"));

            //Spooky Cards
            /*30*/
            allCards.Add(new Creature("Count Chocula", 2, 85, 2, 1, Type.SPOOKY, "CardImages\\countChocCard.png", "FieldImages\\countchocfield.png"));
            /*31*/
            allCards.Add(new Creature("Spooky Police", 2, 75, 3, 2, Type.SPOOKY, "CardImages\\spookyPoliceCard.png", "FieldImages\\spookyPoliceField.png"));
            /*32*/
            allCards.Add(new RareCreature("Mr. Bones", 3, 95, 1, 10, Type.SPOOKY, "CardImages\\MrBonesCard.png", "FieldImages\\mrbonesField.png"));
            /*33*/
            allCards.Add(new Creature("King Ramsee", 3, 80, 4, 4, Type.SPOOKY, "CardImages\\KingRamsesCard.png", "FieldImages\\kingramsesField.png"));
            /*34*/
            allCards.Add(new Creature("Shrek", 6, 70, 8, 6, Type.SPOOKY, "CardImages\\ShrekCard.png", "FieldImages\\ShrekField.png"));
            /*35*/
            allCards.Add(new RareCreature("Mr. Skeltal", 7, 90, 6, 8, Type.SPOOKY, "CardImages\\mrSkeltalCard.png", "FieldImages\\mrSkeltalField.png"));

            //The Forbidden Cards
            /*36*/
            allCards.Add(new JackCard("Left Arm of Jack Myers", 3, 95, 2, 4, Type.FORBIDDEN, "CardImages\\leftArmOfJack.png", "FieldImages\\leftArmOfJackField.png", 1));
            /*37*/
            allCards.Add(new JackCard("Right Arm of Jack Myers", 3, 95, 2, 4, Type.FORBIDDEN, "CardImages\\rightArmOfJack.png", "FieldImages\\rightArmOfJackField.png", 2));
            /*38*/
            allCards.Add(new JackCard("Left Leg of Jack Myers", 3, 95, 2, 4, Type.FORBIDDEN, "CardImages\\leftLegOfJack.png", "FieldImages\\leftLegOFJackField.png", 3));
            /*39*/
            allCards.Add(new JackCard("Right Leg of Jack Myers", 3, 95, 2, 4, Type.FORBIDDEN, "CardImages\\rightLegOfJack.png", "FieldImages\\rightLegOfJackField.png", 4));
            /*40*/
            allCards.Add(new JackCard("Head of Jack Myers", 3, 95, 2, 4, Type.FORBIDDEN, "CardImages\\headOfJack.png", "FieldImages\\headofJackField.png", 5));

            //Enhancements
            /*41*/
            allCards.Add(new Enhancement("The Rock", 4, Enhancement.FATIGUE, -2, "Enhancement images//EtheRock.png"));
            /*42*/
            allCards.Add(new Enhancement("Airhorn", 2, Enhancement.ATTACK, 3, "Enhancement images//EAirhorn.png"));
            /*43*/
            allCards.Add(new Enhancement("Cheesy Keyboard", 2, Enhancement.ATTACK, -3, "Enhancement images//ECheese.png"));
            /*44*/
            allCards.Add(new Enhancement("Fallout 4", 5, Enhancement.CHANCE_TO_ATTACK, -50, "Enhancement images//Efallout4.png"));
            /*45*/
            allCards.Add(new Enhancement("The Fedora", 2, Enhancement.HEALTH, -2, "Enhancement images//Efedora.png"));
            /*46*/
            allCards.Add(new Enhancement("Monster Energy", 0, Enhancement.FATIGUE, -1, "Enhancement images//EMonster.png"));
            /*47*/
            allCards.Add(new Enhancement("Power Armor", 4, Enhancement.HEALTH, 5, "Enhancement images//Epowerarmor.png"));
            /*48*/
            allCards.Add(new Enhancement("Mom's Spaghetti", 3, Enhancement.CHANCE_TO_ATTACK, -25, "Enhancement images//Espaghetti.png"));
            /*49*/
            allCards.Add(new Enhancement("Stimpack", 2, Enhancement.HEALTH, 3, "Enhancement images//Estimpack.png"));
            /*50*/
            allCards.Add(new Enhancement("Oh Baby a Triple!", 3, Enhancement.ATTACK, 3, "Enhancement images//Etriple.png"));
            /*51*/
            allCards.Add(new Enhancement("Energy Sword", 0, Enhancement.ATTACK, 1, "Enhancement images//Esword.png"));
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>The instance.</returns>
        public static AllCards getInstance()
        {
            if (instance == null)
            {
                instance = new AllCards();
            }
            return instance;
        }

        /// <summary>
        /// Gets all cards.
        /// </summary>
        /// <returns>The all cards.</returns>
        public List<Card> GetAllCards()
        {
            return allCards;
        }

        /// <summary>
        /// Gets the name of the card from.
        /// </summary>
        /// <returns>The card from name.</returns>
        /// <param name="name">Name.</param>
        public Card GetCardFromName(String name)
        {
            foreach (Card card in allCards)
            {
                if (name.Equals(card.Name))
                {
                    return card;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the rare cards list.
        /// </summary>
        /// <returns>The rare cards list.</returns>
        public List<Card> GetRareCardsList()
        {
            List<Card> rareCards = new List<Card>();
            foreach (Card card in allCards)
            {
                if (card is Creature){
                if (((Creature)card) is RareCreature){
                    rareCards.Add(card);
                }
            }
        }
		return rareCards;
	}
}
}
