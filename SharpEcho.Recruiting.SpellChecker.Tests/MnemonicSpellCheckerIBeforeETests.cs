using NUnit.Framework;
using SharpEcho.Recruiting.SpellChecker.Contracts;
using SharpEcho.Recruiting.SpellChecker.Core;

namespace SharpEcho.Recruiting.SpellChecker.Tests
{
    [TestFixture]
    class MnemonicSpellCheckerIBeforeETests
    {
        private ISpellChecker _spellChecker;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _spellChecker = new MnemonicSpellCheckerIBeforeE();
        }

        private static readonly object[] CorrectWordCases =
        {
            new object[] {"believe"},
            new object[] {"fierce"},
            new object[] {"collie"},
            new object[] {"die"},
            new object[] {"friend"},
            new object[] {"deceive"},
            new object[] {"ceiling"},
            new object[] {"receipt"},
            new object[] {"science"},
        };

        private static readonly object[] IncorrectWordCases =
        {
            new object[] {"heir"},
            new object[] {"protein"},
            new object[] {"seeing"},
            new object[] {"their"},
            new object[] {"veil"},
        };

        [Test, TestCaseSource("CorrectWordCases")]
        public void Check_Word_That_Contains_I_Before_E_Is_Spelled_Correctly(string word)
        {
            Assert.True(_spellChecker.Check(word));
        }

        [Test, TestCaseSource("IncorrectWordCases")]
        public void Check_Word_That_Contains_I_Before_E_Is_Spelled_Incorrectly(string word)
        {
            Assert.False(_spellChecker.Check(word));
        }      
    }
}
