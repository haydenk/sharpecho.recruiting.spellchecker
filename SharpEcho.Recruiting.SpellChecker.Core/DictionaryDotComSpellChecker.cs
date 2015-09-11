using System.Net;
using SharpEcho.Recruiting.SpellChecker.Contracts;

namespace SharpEcho.Recruiting.SpellChecker.Core
{
    /// <summary>
    /// This is a dictionary based spell checker that uses dictionary.com to determine if
    /// a word is spelled correctly
    /// 
    /// The URL to do this looks like this: http://dictionary.reference.com/browse/<word/>
    /// where <word/> is the word to be checked
    /// 
    /// Example: http://dictionary.reference.com/browse/SharpEcho would lookup the word SharpEcho
    /// 
    /// We look for something in the response that gives us a clear indication whether the
    /// word is spelled correctly or not
    /// </summary>
    public class DictionaryDotComSpellChecker : ISpellChecker
    {
        public bool Check(string word)
        {
            WebRequest request = WebRequest.CreateHttp("http://dictionary.reference.com/browse/" + word);
            WebResponse response = request.GetResponse();

            bool foundWord = response.ResponseUri.AbsolutePath != "/misspelling";

            response.Close();

            return foundWord;
        }
    }
}
