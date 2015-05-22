﻿using FullAdder.Controller;
using FullAdder.Factory;
using FullAdder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.Model
{
    public class OutputNode : Node
    {
        public override bool Value
        {
            get 
            {
                bool[] inputs = getInputs();

                return inputs[0];
            }
            set { }
        }

        public OutputNode()
        {
            maxInputs = 1;

            MainWindowViewModel.Instance.RegisterOutput(this);
        }

        public static void registerSelf()
        {
            NodeFactory.registerNode("PROBE", typeof(OutputNode));
        }
    }
}
