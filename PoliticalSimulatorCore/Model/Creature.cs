using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.Model
{
    [Serializable]
    public class Creature : Card
    {

#region Properties

        private const long serialVersionUID = 1L;
        private int attackValue;
        private int healthValue;
        private int attackFatigueValue;
        private int chanceToHit;
        private Type creatureType;
        private String fieldImgPath;

        /// <summary>
        /// Gets or sets the attack value.
        /// </summary>
        /// <value>The attack value.</value>
        public int AttackValue
        {
            get
            {
                return attackValue;
            }
            set
            {
                attackValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the health value.
        /// </summary>
        /// <value>The health value.</value>
		public int HealthValue
		{
			get
			{
                return healthValue;
			}
			set
			{
                healthValue = value;
			}
		}

        /// <summary>
        /// Gets or sets the attack fatigue value.
        /// </summary>
        /// <value>The attack fatigue value.</value>
		public int AttackFatigueValue
		{
			get
			{
                return attackFatigueValue;
			}
			set
			{
				attackFatigueValue = value;
			}
		}

        /// <summary>
        /// Gets or sets the chance to hit.
        /// </summary>
        /// <value>The chance to hit.</value>
		public int ChanceToHit
		{
			get
			{
                return chanceToHit;
			}
			set
			{
                chanceToHit = value;
			}
		}

        /// <summary>
        /// Gets or sets the type of the creature.
        /// </summary>
        /// <value>The type of the creature.</value>
		public Type CreatureType
		{
			get
			{
				return creatureType;
			}
			set
			{
				creatureType = value;
			}
		}

		/// <summary>
		/// Gets or sets the type of the creature.
		/// </summary>
		/// <value>The type of the creature.</value>
		public string FieldImgPath
		{
			get
			{
				return fieldImgPath;
			}
			set
			{
				fieldImgPath = value;
			}
		}

#endregion

        /**
         * default original creature constructor
         * @param name name of creature
         * @param fatigueValue fatigue of creature
         * @param chanceToHit chance to hit
         * @param attack attack value
         * @param health health value
         * @param type type of creature
         * @param imgFilePath filepath pointing to the card image
         * @param fieldImgPath filepath pointing to the field image
         */
        public Creature(String name, int fatigueValue, int chanceToHit, int attack, int health, Type type, String imgFilePath, String fieldImgPath) : base (name, fatigueValue, imgFilePath)
        {
            int attackFatigueValue = fatigueValue;
            //int attackFatigueValue = fatigueValue / 2;
            if (attackFatigueValue <= 0) attackFatigueValue = 1;
            this.attackFatigueValue = attackFatigueValue;
            this.attackValue = attack;
            this.healthValue = health;
            this.creatureType = type;
            this.chanceToHit = chanceToHit;
            this.fieldImgPath = fieldImgPath;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PoliticalSimulatorCore.Model.Creature"/> class.
        /// </summary>
        public Creature() {}

        /// <summary>
        /// Calculates the attack fatigue.
        /// </summary>
        /// <param name="fatigueValue">Fatigue value.</param>
        private void calcAttackFatigue(int fatigueValue)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PoliticalSimulatorCore.Model.Creature"/> class.
        /// </summary>
        /// <param name="c">C.</param>
        public Creature(Creature c): base (c.Name, c.PlayFatigueValue, c.ImageFilePath)
        {
            this.attackValue = c.attackValue;
            this.attackFatigueValue = c.attackFatigueValue;
            this.healthValue = c.healthValue;
            this.creatureType = c.CreatureType;
            this.chanceToHit = c.ChanceToHit;
            this.fieldImgPath = c.FieldImgPath;
        }
    }
}
