﻿using CircuitSimulator.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.Model
{
    public class NAndNode : Node
    {
        public NAndNode()
        {
            maxInputs = 2;
        }

        public override bool calculateInput()
        {
            bool[] inputs = getInputs();

            return !(inputs[0] && inputs[1]);
        }

        public static void registerSelf()
        {
            NodeFactory.registerNode("NAND", typeof(NAndNode));
        }
    }
}
