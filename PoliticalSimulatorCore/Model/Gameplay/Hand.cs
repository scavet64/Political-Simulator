using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalSimulatorCore.Model {
    public class Hand : List<Card> {
        public Hand(int capacity) : base(capacity) {
        }
    }
}
