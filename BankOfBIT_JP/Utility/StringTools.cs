using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Utility
{
    /// <summary>
    /// String Tools - Represents tools used to manipulate strings.
    /// </summary>
    public static class StringTools
    {
        /// <summary>
        /// Removes the selected phrase from a string.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="phrase">The phrase to remove.</param>
        /// <returns>The string without the selected phrase.</returns>
        public static string RemovePhrase(string input, string phrase)
        {
            int index = input.IndexOf(phrase);
            string returnPhrase = "RemovePhraseError";

            if (index != -1)
            {
                returnPhrase = input.Remove(index);
            }

            return returnPhrase;
        }
        
        public static string RemoveSpecialCharactors(string input)
        {
            return Regex.Replace(input, "[^a-zA-Z0-9-.]", string.Empty);
        }
    }
}
