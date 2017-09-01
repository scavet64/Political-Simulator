using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.Controller {
    class LogController {

        #region Constant Strings

        public const string NO_SPACE_ON_FIELD = "There is no room to play that creature.";
	    public const string CARD_NOT_IN_HAND = "You do not have that card in your hand.";
	    public const string HAND_TOO_FULL = "Your hand is full!";
	    public const string EMPTY_DECK = "You are out of cards!";
	    public const string CARD_PLAYED = "Card was played successfully.";
	    public const string FATIGUED = "You are too fatigued to do that.";
	    public const string NO_CARD_AT_LOCATION = "There is no card at that position.";
	    public const string NOT_RARE = "You can only apply a spell to a rare card.";
	    public const string CREATURES_ON_FIELD = "Opposing field is not empty.";
	    public const string FATIGUE_LOWER_BOUND = "You cannot modify a creature below 1 fatigue cost.";
	    public const string ATTACK_MISSED = "Attack missed!";
	    public const string JACK_FTW = "All five limbs of Jack combine into the master Jack!";

        #endregion
    }
}
