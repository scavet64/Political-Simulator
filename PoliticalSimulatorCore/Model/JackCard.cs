using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.Model
{
    public class JackCard: RareCreature
    {
        private const long serialVersionUID = 1L;
        private int pieceNumber;

        /**
         * Default constructor for the god card Jack
         */
        public JackCard(String name, int fatigueValue, int chanceToHit, int attack, int health, Type type,
                String imgFilePath, String fieldImgPath, int pieceNumber): base(name, fatigueValue, chanceToHit, attack, health, type, imgFilePath, fieldImgPath)
        {
            this.pieceNumber = pieceNumber;
        }

        public JackCard()
        {

        }

        /**
         * Deep copy constructor for the god card Jack
         */
        public JackCard(JackCard rc):base(rc)
        {
            this.pieceNumber = rc.getPieceNumber();
        }

        /**
         * @return the pieceNumber
         */
        public int getPieceNumber()
        {
            return pieceNumber;
        }

        /**
         * @param pieceNumber the pieceNumber to set
         */
        public void setPieceNumber(int pieceNumber)
        {
            this.pieceNumber = pieceNumber;
        }
    }
}
