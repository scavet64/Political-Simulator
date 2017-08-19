using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.Model
{
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
        public readonly static Type FIGHTER = new Type(TypeEnum.Fighter, TypeEnum.Genius, TypeEnum.Charasmatic);
        public readonly static Type PSYCHO = new Type(TypeEnum.Psycho, TypeEnum.Spooky, TypeEnum.Magic);
        public readonly static Type MAGIC = new Type(TypeEnum.Magic, TypeEnum.Psycho, TypeEnum.Genius);
        public readonly static Type GENIUS = new Type(TypeEnum.Genius, TypeEnum.Magic, TypeEnum.Fighter);
        public readonly static Type CHARASMATIC = new Type(TypeEnum.Charasmatic, TypeEnum.Fighter, TypeEnum.Psycho);
        public readonly static Type SPOOKY = new Type(TypeEnum.Spooky, TypeEnum.Charasmatic, TypeEnum.Psycho);
        public readonly static Type FORBIDDEN = new Type(TypeEnum.Forbidden, TypeEnum.none, TypeEnum.none);

        private TypeEnum highlyEffective;
        private TypeEnum notVeryEffective;
        protected TypeEnum Self { get; private set; }


        private Type(TypeEnum self, TypeEnum highlyEffective, TypeEnum notVeryEffective)
        {
            this.Self = self;
            this.highlyEffective = highlyEffective;
            this.notVeryEffective = notVeryEffective;
        }

        /**
         * @param typeToCompare type to check for changes from other types
         * @return int value for attack change due to types
         */
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

        /**
         * @param typeToCompare Type to be checked for bonus effects on damage exchange
         */
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

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Type compareType = (Type)obj;

            return compareType.Self == Self;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Self.GetHashCode();
        }
    }
}
