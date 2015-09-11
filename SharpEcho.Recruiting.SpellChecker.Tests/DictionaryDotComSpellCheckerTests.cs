using NUnit.Framework;

using SharpEcho.Recruiting.SpellChecker.Contracts;
using SharpEcho.Recruiting.SpellChecker.Core;

namespace SharpEcho.Recruiting.SpellChecker.Tests
{
    [TestFixture]
    class DictionaryDotComSpellCheckerTests
    {
        private ISpellChecker _spellChecker;

        [TestFixtureSetUp]
        public void TestFixureSetUp()
        {
            _spellChecker = new DictionaryDotComSpellChecker();
        }

        private static readonly object[] NotMisspelledWordCases =
        {
            new object[] {"North"},
            new object[] {"East"},
            new object[] {"South"},
            new object[] {"West"},
        };

        private static readonly object[] MisspelledWordCases =
        {
            new object[] {"SharpEcho"},
            new object[] {"DullRoar"},
        };

        [Test, TestCaseSource("MisspelledWordCases")]
        public void Check_That_SharpEcho_Is_Misspelled(string word)
        {
            Assert.False(_spellChecker.Check(word));
        }

        [Test, TestCaseSource("NotMisspelledWordCases")]
        public void Check_That_South_Is_Not_Misspelled(string word)
        {
            Assert.True(_spellChecker.Check(word));
        }

    }
}
