using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.Model {
    public class Field : List<Creature> {
        public Field(int capacity) : base(capacity) {
        }
    }
}
