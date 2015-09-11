using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using SharpEcho.Recruiting.SpellChecker.Contracts;

namespace SharpEcho.Recruiting.SpellChecker.Core
{
    /// <summary>
    /// This is a top level spell checker that is used by clients, it internally manages
    /// several spell checkers that it uses to evaluate whether a word is spelled correctly
    /// or not
    /// </summary>
    public class SpellChecker : ISpellChecker
    {
        private readonly ISpellChecker[] _spellCheckers;

        public SpellChecker(ISpellChecker[] spellCheckers)
        {
            _spellCheckers = spellCheckers;
        }

        /// <summary>
        /// Iterates through all the internal spell checkers and returns false if
        /// any one of them finds a word to be misspelled
        /// </summary>
        /// <param name="word">Word to check</param>
        /// <returns>True if all spell checkers agree that a word is spelled correctly, false otherwise</returns>
        public bool Check(string word)
        {
            return _spellCheckers.All(spellChecker => spellChecker.Check(word));
        }

        public static List<string> GetWordsFromSentence(string sentence)
        {
            return Regex
                .Split(sentence, @"\b[\s,\.-:;]*")
                .Where(x => !string.IsNullOrEmpty(x))
                .ToList();
        }
    }
}
