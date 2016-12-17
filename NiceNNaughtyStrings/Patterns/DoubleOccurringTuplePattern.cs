using System;

namespace NiceNNaughtyStrings
{
    public class DoubleOccurringTuplePattern : Pattern
    {
        private int _nrInTuple;
        public override string PatternString { get; }

        public DoubleOccurringTuplePattern(int nrInTuple)
        {
            _nrInTuple = nrInTuple;
            PatternString = SetPattern();
        }

        protected override string SetPattern()
        {
            //string addition = (_nrInTuple > 1) ? @".*\1" : @"\1";
            //return @"(\w{" + _nrInTuple + "})" + addition;
            return @"(\w)\1";
        }
    }
}
