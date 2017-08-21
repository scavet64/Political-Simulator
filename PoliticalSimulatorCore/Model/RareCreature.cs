using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.Model
{
    public class RareCreature: Creature
    {
        private const long serialVersionUID = 1L;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PoliticalSimulatorCore.Model.RareCreature"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="fatigueValue">Fatigue value.</param>
        /// <param name="chanceToHit">Chance to hit.</param>
        /// <param name="attack">Attack.</param>
        /// <param name="health">Health.</param>
        /// <param name="type">Type.</param>
        /// <param name="imgFilePath">Image file path.</param>
        /// <param name="fieldImgPath">Field image path.</param>
        public RareCreature(String name, int fatigueValue, int chanceToHit, int attack, int health, Type type, String imgFilePath, String fieldImgPath): base(name, fatigueValue, chanceToHit, attack, health, type, imgFilePath, fieldImgPath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PoliticalSimulatorCore.Model.RareCreature"/> class.
        /// </summary>
        public RareCreature()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PoliticalSimulatorCore.Model.RareCreature"/> class.
        /// </summary>
        /// <param name="rc">Rc.</param>
        public RareCreature(RareCreature rc): base(rc.getName(), rc.getPlayFatigueValue(), rc.getChanceToHit(), rc.getAttackValue(), rc.getHealthValue(),
                    rc.getType(), rc.getImgFilePath(), rc.getFieldImgPath())
        {
        }
    }
}
