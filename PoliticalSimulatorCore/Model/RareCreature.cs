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

        /**
         * Constructor for RareCreature
         */
        public RareCreature(String name, int fatigueValue, int chanceToHit, int attack, int health, Type type, String imgFilePath, String fieldImgPath): base(name, fatigueValue, chanceToHit, attack, health, type, imgFilePath, fieldImgPath)
        {
        }

        public RareCreature()
        {

        }

        /**
         * Deep copy constructor for RareCreature
         */
        public RareCreature(RareCreature rc): base(rc.getName(), rc.getPlayFatigueValue(), rc.getChanceToHit(), rc.getAttackValue(), rc.getHealthValue(),
                    rc.getType(), rc.getImgFilePath(), rc.getFieldImgPath())
        {
        }
    }
}
