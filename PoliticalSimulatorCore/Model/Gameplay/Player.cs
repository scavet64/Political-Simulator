using PoliticalSimulatorCore.Model.Game_Model;

namespace PoliticalSimulatorCore.Model {
    class Player {

        #region Properties

        public UserProfile Profile { get; set; }

        public Fatigue PlayerFatigue { get; set; }

        public Field Field { get; set; }

        public Hand Hand { get; set; }

        public int Health { get; set; }

        #endregion

        public Player(UserProfile profile, int maxFieldSize, int maxHandSize, int startHealth) {
            Profile = profile;
            PlayerFatigue = new Fatigue();
            Field = new Field(maxFieldSize);
            Hand = new Hand(maxHandSize);
            Health = startHealth;
        }
    }
}
