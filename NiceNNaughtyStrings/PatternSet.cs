using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NiceNNaughtyStrings
{
    public class PatternSet
    {
        private IList<IPattern> ListOfPatterns { get; }

        public PatternSet()
        {
            ListOfPatterns = new List<IPattern>() { };
        }

        public PatternSet(List<IPattern> list)
        {
            ListOfPatterns = list;
        }

        public void AddPattern(IPattern pattern)
        {
            ListOfPatterns.Add(pattern);
        }

        public bool Match(string stringToMatch)
        {
            bool allPatternsMatch = true;
            Match match;
            foreach (var pattern in ListOfPatterns)
            {
                match = Regex.Match(stringToMatch, pattern.PatternString);
                if (!match.Success) allPatternsMatch = false;
            }
            return allPatternsMatch;
        }
    }
}