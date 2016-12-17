using NUnit.Framework;
using FluentAssertions;
using System.Collections.Generic;

namespace NiceNNaughtyStrings.Tests
{
    [TestFixture]
    public class When_random_string_is_read
    {
        private PatternSet _patternSet;

        [SetUp]
        public void SetUp()
        {
            _patternSet = new PatternSet();
        }

        [TestCase(3, "abejhyjk", false)]
        [TestCase(3, "abejhjk", false)]
        [TestCase(3, "abejhyjko", true)]
        [TestCase(3, "abejhyjiuko", true)]
        public void It_should_be_able_to_identify_strings_with_vowels(int nrOfVowels, string str, bool outcome)
        {
            _patternSet.AddPattern(new XVowelsPattern(from: nrOfVowels));
            bool matchResult = _patternSet.Match(str);
            matchResult.Should().Be(outcome);
        }

        [TestCase(1, "abehejk", false)]
        [TestCase(1, "ajbehejk", false)]
        [TestCase(1, "abeehjk", true)]
        [TestCase(1, "abehjk", false)]
        [TestCase(1, "abehjkk", true)]
        [TestCase(1, "kabehjk", false)]
        [TestCase(2, "eeabeehjk", true)]
        [TestCase(2, "eeeabeehjk", true)]
        [TestCase(2, "eeeabehjk", false)]
        public void It_should_be_able_to_identify_tuples_of_letters(int tupleCount, string str, bool outcome)
        {
            _patternSet.AddPattern(new DoubleOccurringTuplePattern(nrInTuple: tupleCount));
            bool matchResult = _patternSet.Match(str);
            matchResult.Should().Be(outcome);
        }

        [TestCase("abfeowik", "Exclude", false, "ab", "cd", "pq", "xy")]
        [TestCase("acfeowik", "Exclude", true, "ab", "cd", "pq", "xy")]
        [TestCase("cddwqpq", "Include", true, "ab", "cd", "pq", "xy")]
        public void It_should_be_able_to_match_on_a_set_of_strings(string str, string action, bool outcome, params string[] strings)
        {
            IList<string> subStrings = new List<string>();
            foreach (var sub in strings) subStrings.Add(sub);
            _patternSet.AddPattern(new SubstringPattern(action: action, substringsToMatch: subStrings));
            bool matchResult = _patternSet.Match(str);
            matchResult.Should().Be(outcome);
        }

        [TestCase("testswq", 1, 1, true)]
        [TestCase("teqtswq", 1, 1, false)]
        [TestCase("tesststssaatwq", 2, 3, true)]
        [TestCase("tesstttssaatwq", 2, 3, true)]
        public void It_should_be_able_to_match_letter_tuple_w_other_letters_inbetween(string str, int tupleSize, int inBetweenSize , bool outcome)
        {
            _patternSet.AddPattern(new XLetterTupleWithYOtherLettersBetweenPattern(nrInTuple: tupleSize, nrInBetween: inBetweenSize));
            bool matchResult = _patternSet.Match(str);
            matchResult.Should().Be(outcome);
        }
    }
}
