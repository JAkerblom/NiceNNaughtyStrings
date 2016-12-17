using System;

namespace NiceNNaughtyStrings
{
    public class XVowelsPattern : Pattern
    {
        private int _from;
        private int _to;
        public override string PatternString { get; }

        public XVowelsPattern(int from = 0, int to = 5)
        {
            _from = from;
            _to = to;
            PatternString = SetPattern();
        }

        protected override string SetPattern()
        {
            var str = "";
            if (_to == -1)
                str = @"(.*[aeiou].*){" + _from + ",}";
            else
                str = @"(.*[aeiou].*){" + _from + "," + _to + "}";

            return str;
        }
    }
}