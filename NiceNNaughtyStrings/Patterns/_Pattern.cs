using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiceNNaughtyStrings
{
    public abstract class Pattern : IPattern
    {
        public abstract string PatternString { get; }
        protected abstract string SetPattern();
    }
}
