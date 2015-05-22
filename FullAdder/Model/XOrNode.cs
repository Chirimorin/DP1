﻿using FullAdder.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.Model
{
    class XOrNode : Node
    {
        public override bool Value
        {
            get
            {
                bool[] inputs = getInputs();

                return inputs[0] ^ inputs[1];
            }
            set { }
        }

        public XOrNode()
        {
            maxInputs = 2;
        }

        public static void registerSelf()
        {
            NodeFactory.registerNode("XOR", typeof(XOrNode));
        }
    }
}
