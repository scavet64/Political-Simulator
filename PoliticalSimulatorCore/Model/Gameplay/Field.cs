using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.Model {
    class Field : List<Creature> {
        public Field(int capacity) : base(capacity) {
        }
    }
}
