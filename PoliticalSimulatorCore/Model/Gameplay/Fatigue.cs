using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.Model.Game_Model {
    public class Fatigue {

        #region Constants

        private const int START_FATIGUE = 5;
        private const int MAX_FATIGUE_FOR_GAME = 10;

        #endregion

        #region Fields

        private int maxFatigueForTurn;

        #endregion

        #region Properties

        public int CurrentFatigueForTurn { get; set; }

        #endregion

        #region Constructor

        public Fatigue() {
            CurrentFatigueForTurn = START_FATIGUE;
            maxFatigueForTurn = START_FATIGUE;
        }

        #endregion

        #region Public Methods

        public bool UseFatigue(int fatigue) {
            if (fatigue > CurrentFatigueForTurn) {
                return false;
            } else {
                CurrentFatigueForTurn -= fatigue;
                return true;
            }
        }

        public bool TooFatigued(int fatigue) {
            return fatigue > CurrentFatigueForTurn;
        }

        public void Increment() {
            if (maxFatigueForTurn < MAX_FATIGUE_FOR_GAME) {
                maxFatigueForTurn++;
            }
            CurrentFatigueForTurn = maxFatigueForTurn;
        }

        #endregion

    }
}
