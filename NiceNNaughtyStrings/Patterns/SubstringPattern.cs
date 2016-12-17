using System;
using System.Collections.Generic;

namespace NiceNNaughtyStrings
{
    public class SubstringPattern : Pattern
    {
        private string _action;
        private IList<string> _substringsToMatch;
        public override string PatternString { get; }

        public SubstringPattern(string action, IList<string> substringsToMatch)
        {
            _action = action;
            _substringsToMatch = substringsToMatch;
            PatternString = SetPattern();
        }

        protected override string SetPattern()
        {
            // @"(ab|cd|pq|xy)+"
            // @"^((?!(es|on)).)*$";

            string str = "";
            foreach (var substr in _substringsToMatch)
                str += substr + "|";

            str = str.TrimEnd('|');
            if (_action == "Exclude")
                str = "^((?!(" + str + ")).)*$";
            else if (_action == "Include")
                str = "(" + str + ")+";

            return str;
        }
    }
}