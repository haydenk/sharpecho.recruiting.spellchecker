using System;

using SharpEcho.Recruiting.SpellChecker.Contracts;
using SharpEcho.Recruiting.SpellChecker.Core;

namespace SharpEcho.Recruiting.SpellCheckerConsole
{
    /// <summary>
    /// Thank you for your interest in a position at SharpEcho.  The following are the "requirements" for this project:
    /// 
    /// 1. Implent Main() below so that a user can input a sentence.  Each word in that
    ///    sentence will be evaluated with the SpellChecker, which returns true for a word
    ///    that is spelled correctly and false for a word that is spelled incorrectly.  Display
    ///    out each *distnict* word that is misspelled.  That is, if a user uses the same misspelled
    ///    word more than once, simply output that word one time.
    ///    
    ///    Example:
    ///    Please enter a sentence: Salley sells seashellss by the seashore.  The shells Salley sells are surely by the sea.
    ///    Misspelled words: Salley seashellss
    ///    
    /// 2. The concrete implementation of SpellChecker depends on two other implementations of ISpellChecker, DictionaryDotComSpellChecker
    ///    and MnemonicSpellCheckerIBeforeE.  You will need to implement those classes.  See those classes for details.
    ///    
    /// 3. There are covering unit tests in the SharpEcho.Recruiting.SpellChecker.Tests library that should be implemented as well.
    /// </summary>
    class Program
    {
        /// <summary>
        /// This application is intended to allow a user enter some text (a sentence)
        /// and it will display a distinct list of incorrectly spelled words
        /// </summary>
        static void Main()
        {
            Console.Write("Please enter a sentence: ");
            var sentence = Console.ReadLine();

            // first break the sentence up into words, 
            // then iterate through the list of words using the spell checker
            // capturing distinct words that are misspelled

            // use this spellChecker to evaluate the words
            var spellChecker = new SpellChecker.Core.SpellChecker
                (
                    new ISpellChecker[]
                    { 
                        new MnemonicSpellCheckerIBeforeE(),
                        new DictionaryDotComSpellChecker(),
                    }
                );

            int wordErrors = 0;

            foreach (string word in SpellChecker.Core.SpellChecker.GetWordsFromSentence(sentence))
            {
                if (!spellChecker.Check(word))
                {
                    wordErrors++;
                    Console.WriteLine("'" + word + "' appears to be misspelled!");
                }
            }

            if (wordErrors == 0)
            {
                Console.WriteLine("No errors found in: " + sentence);
            }

        }
    }
}
