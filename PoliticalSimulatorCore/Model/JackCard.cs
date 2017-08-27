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

        /// <summary>
        /// Gets or sets the piece number.
        /// </summary>
        /// <value>The piece number.</value>
        public int PieceNumber
        {
            get
            {
                return pieceNumber;
            }
            set
            {
                pieceNumber = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PoliticalSimulatorCore.Model.JackCard"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="fatigueValue">Fatigue value.</param>
        /// <param name="chanceToHit">Chance to hit.</param>
        /// <param name="attack">Attack.</param>
        /// <param name="health">Health.</param>
        /// <param name="type">Type.</param>
        /// <param name="imgFilePath">Image file path.</param>
        /// <param name="fieldImgPath">Field image path.</param>
        /// <param name="pieceNumber">Piece number.</param>
        public JackCard(String name, int fatigueValue, int chanceToHit, int attack, int health, Type type,
                String imgFilePath, String fieldImgPath, int pieceNumber): base(name, fatigueValue, chanceToHit, attack, health, type, imgFilePath, fieldImgPath)
        {
            this.pieceNumber = pieceNumber;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PoliticalSimulatorCore.Model.JackCard"/> class.
        /// </summary>
        public JackCard()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PoliticalSimulatorCore.Model.JackCard"/> class.
        /// </summary>
        /// <param name="rc">Rc.</param>
        public JackCard(JackCard rc):base(rc)
        {
            this.pieceNumber = rc.PieceNumber;
        }
    }
}
