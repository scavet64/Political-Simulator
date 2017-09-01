using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.Model
{
    [Serializable]
    public class Enhancement: Card
    {
        public const String HEALTH = "health";
        public const String CHANCE_TO_ATTACK = "chance to hit";
        public const String ATTACK = "attack";
        public const String FATIGUE = "fatigue";

        private const long serialVersionUID = 1L;
        private String statToModify;
        private int modValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PoliticalSimulatorCore.Model.Enhancement"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="fatigueValue">Fatigue value.</param>
        /// <param name="stat">Stat.</param>
        /// <param name="modValue">Mod value.</param>
        /// <param name="imgFilePath">Image file path.</param>
        public Enhancement(String name, int fatigueValue, String stat, int modValue, String imgFilePath) : base (name, fatigueValue, imgFilePath)
        {
            this.statToModify = stat;
            this.modValue = modValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PoliticalSimulatorCore.Model.Enhancement"/> class.
        /// </summary>
        public Enhancement()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PoliticalSimulatorCore.Model.Enhancement"/> class.
        /// </summary>
        /// <param name="c">C.</param>
        public Enhancement(Enhancement c): base(c.Name, c.PlayFatigueValue, c.ImageFilePath)
        {
            this.statToModify = c.getStat();
            this.modValue = c.getModValue();
            // TODO Auto-generated constructor stub
        }

        /// <summary>
        /// Gets the stat.
        /// </summary>
        /// <returns>The stat.</returns>
        public String getStat()
        {
            return statToModify;
        }

        /// <summary>
        /// Gets the mod value.
        /// </summary>
        /// <returns>The mod value.</returns>
        public int getModValue()
        {
            return modValue;
        }
    }
}
