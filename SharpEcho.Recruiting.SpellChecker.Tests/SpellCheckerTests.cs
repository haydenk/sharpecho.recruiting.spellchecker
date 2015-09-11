using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SharpEcho.Recruiting.SpellChecker.Contracts;
using SharpEcho.Recruiting.SpellChecker.Core;

namespace SharpEcho.Recruiting.SpellChecker.Tests
{

    [TestFixture]
    class SpellCheckerTests
    {

        [TestCase("The quick brown fox jumps over the lazy dog")]
        public void GetWordsFromSentenance(string sentenance)
        {
            List<string> words = Core.SpellChecker.GetWordsFromSentence(sentenance);

            foreach (string word in words)
            {
                Assert.True(sentenance.Contains(word));
            }

            Assert.IsInstanceOf(typeof(List<String>), words);
        }

        [TestCase("Salley sells seashellss by the sea shore.", new string[] {"Salley","seashellss"})]
        public void CheckSentence(string sentence, string[] misspelledWords)
        {
            var spellChecker = new SpellChecker.Core.SpellChecker
                (
                new ISpellChecker[]
                {
                    new MnemonicSpellCheckerIBeforeE(),
                    new DictionaryDotComSpellChecker(),
                }
                );

            foreach (string word in Core.SpellChecker.GetWordsFromSentence(sentence))
            {
                var spellCheckerResult = spellChecker.Check(word);

                if (misspelledWords.Contains(word))
                {
                    Assert.False(spellCheckerResult);
                }
                else
                {
                    Assert.True(spellCheckerResult);
                }
            }

        }

    }

}
