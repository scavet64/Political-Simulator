using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.Model
{
    [Serializable]
    /// <summary>
    /// Type Class
    /// </summary>
    public class Type
    {

        private const int HIGHLY_EFFECTIVE_MODIFIER = 2;
        private const int NOT_VERY_EFFECTIVE_MODIFIER = -2;
        private const String HIGHLY_EFFECTIVE_STRING = "Attack was highly effective!\n";
        private const String NOT_VERY_EFFECTIVE_STRING = "Attack was not very effective\n";

        protected enum TypeEnum { Fighter, Psycho, Magic, Genius, Charasmatic, Spooky, Forbidden, none }

        /// <summary>
        /// The fighter.
        /// </summary>
        public readonly static Type FIGHTER = new Type(TypeEnum.Fighter, TypeEnum.Genius, TypeEnum.Charasmatic);
        /// <summary>
        /// The psycho.
        /// </summary>
        public readonly static Type PSYCHO = new Type(TypeEnum.Psycho, TypeEnum.Spooky, TypeEnum.Magic);
        /// <summary>
        /// The magic.
        /// </summary>
        public readonly static Type MAGIC = new Type(TypeEnum.Magic, TypeEnum.Psycho, TypeEnum.Genius);
        /// <summary>
        /// The genius.
        /// </summary>
        public readonly static Type GENIUS = new Type(TypeEnum.Genius, TypeEnum.Magic, TypeEnum.Fighter);
        /// <summary>
        /// The charasmatic.
        /// </summary>
        public readonly static Type CHARASMATIC = new Type(TypeEnum.Charasmatic, TypeEnum.Fighter, TypeEnum.Psycho);
        /// <summary>
        /// The spooky.
        /// </summary>
        public readonly static Type SPOOKY = new Type(TypeEnum.Spooky, TypeEnum.Charasmatic, TypeEnum.Psycho);
        /// <summary>
        /// The forbidden.
        /// </summary>
        public readonly static Type FORBIDDEN = new Type(TypeEnum.Forbidden, TypeEnum.none, TypeEnum.none);

        private TypeEnum highlyEffective;
        private TypeEnum notVeryEffective;
        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        /// <value>The self.</value>
        protected TypeEnum Self { get; private set; }

        public string getName()
        {
            return Self.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:PoliticalSimulatorCore.Model.Type"/> class.
        /// </summary>
        /// <param name="self">Self.</param>
        /// <param name="highlyEffective">Highly effective.</param>
        /// <param name="notVeryEffective">Not very effective.</param>
        private Type(TypeEnum self, TypeEnum highlyEffective, TypeEnum notVeryEffective)
        {
            this.Self = self;
            this.highlyEffective = highlyEffective;
            this.notVeryEffective = notVeryEffective;
        }

        /// <summary>
        /// Applies the modifier.
        /// </summary>
        /// <returns>The modifier.</returns>
        /// <param name="typeToCompare">Type to compare.</param>
        public int applyModifier(Type typeToCompare)
        {
            TypeEnum opposingType = typeToCompare.Self;
            if (opposingType.Equals(highlyEffective))
            {
                return HIGHLY_EFFECTIVE_MODIFIER;
            }
            else if (opposingType.Equals(notVeryEffective) || opposingType.Equals(this.ToString()))
            {
                return NOT_VERY_EFFECTIVE_MODIFIER;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Modifiers the string.
        /// </summary>
        /// <returns>The string.</returns>
        /// <param name="typeToCompare">Type to compare.</param>
        public String modifierString(Type typeToCompare)
        {
            String opposingType = typeToCompare.ToString();
            if (opposingType.Equals(highlyEffective))
            {
                return HIGHLY_EFFECTIVE_STRING;
            }
            else if (opposingType.Equals(notVeryEffective) || opposingType.Equals(this.ToString()))
            {
                return NOT_VERY_EFFECTIVE_STRING;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="T:PoliticalSimulatorCore.Model.Type"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="T:PoliticalSimulatorCore.Model.Type"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current
        /// <see cref="T:PoliticalSimulatorCore.Model.Type"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Type compareType = (Type)obj;

            return compareType.Self == Self;
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="T:PoliticalSimulatorCore.Model.Type"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            return Self.GetHashCode();
        }
    }
}
