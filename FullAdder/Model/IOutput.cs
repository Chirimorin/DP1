using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAdder.Model
{
    public interface IOutput
    {
        void addInput(bool value);
        void reset();
    }
}
