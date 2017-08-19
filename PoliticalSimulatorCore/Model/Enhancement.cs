using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.Model
{
    class Enhancement: Card
    {
        public const String HEALTH = "health";
        public const String CHANCE_TO_ATTACK = "chance to hit";
        public const String ATTACK = "attack";
        public const String FATIGUE = "fatigue";

        private const long serialVersionUID = 1L;
        private String statToModify;
        private int modValue;

        /**
         * Default constructor for Enhancement
         */
        public Enhancement(String name, int fatigueValue, String stat, int modValue, String imgFilePath) : base (name, fatigueValue, imgFilePath)
        {
            this.statToModify = stat;
            this.modValue = modValue;
        }

        public Enhancement()
        {

        }

        /**
         * Deep copy constructor for Enhancement
         */
        public Enhancement(Enhancement c): base(c.getName(), c.getPlayFatigueValue(), c.getImgFilePath())
        {
            this.statToModify = c.getStat();
            this.modValue = c.getModValue();
            // TODO Auto-generated constructor stub
        }

        /**
         * @return statToModify
         */
        public String getStat()
        {
            return statToModify;
        }

        /**
         * @return modValue
         */
        public int getModValue()
        {
            return modValue;
        }
    }
}
