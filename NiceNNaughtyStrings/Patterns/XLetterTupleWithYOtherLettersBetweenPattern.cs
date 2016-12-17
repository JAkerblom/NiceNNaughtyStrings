using System;

namespace NiceNNaughtyStrings
{
    public class XLetterTupleWithYOtherLettersBetweenPattern : Pattern
    {
        private int _nrInTuple;
        private int _nrInBetween;
        public override string PatternString { get; }

        public XLetterTupleWithYOtherLettersBetweenPattern(int nrInTuple, int nrInBetween)
        {
            _nrInTuple = nrInTuple;
            _nrInBetween = nrInBetween;
            PatternString = SetPattern();
        }

        protected override string SetPattern()
        {
            // @"(\w{1})(\w{1})\1"
            string str = @"(\w{" + _nrInTuple + @"})(\w{" + _nrInBetween + @"})\1";

            return str;
        }
    }
}