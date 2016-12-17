using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;

namespace NiceNNaughtyStrings.Tests
{
    [TestFixture]
    public class When_file_with_strings_is_read
    {
        private string _stringRepo;
        private PatternSet _patternSet;

        [SetUp]
        public void SetUpListOfStrings()
        {
            //_stringRepo = Properties.Resources.niceAndNaughtyStrings;
            _stringRepo = Properties.Resources.niceAndNaughty2;

            _patternSet = new PatternSet(new List<IPattern>()
            {
                new XVowelsPattern(from: 3, to: -1),
                new DoubleOccurringTuplePattern(nrInTuple: 1),
                new SubstringPattern(action: "Exclude", substringsToMatch: new List<string>() { "ab", "cd", "pq", "xy" }),
                //new DoubleOccurringTuplePattern(nrInTuple: 2),
                //new XLetterTupleWithYOtherLettersBetweenPattern(nrInTuple: 1, nrInBetween: 1)
            });
        }

        [Test]
        public void It_should_be_able_to_calculate_number_of_nice_strings()
        {
            var nrOfNiceStrings = 0;
            using (StringReader sr = new StringReader(_stringRepo))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (_patternSet.Match(line)) nrOfNiceStrings++;
                }
            }

            nrOfNiceStrings.Should().Be(236);
        }
    }
}
