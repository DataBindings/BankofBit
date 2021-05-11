using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utility
{
    /// <summary>
    /// Number Tools - Represents tools used to manipulate numbers.
    /// </summary>
    public static class NumberTools
    {
        /// <summary>
        /// Calcuates the difference between 2 dates.
        /// </summary>
        /// <param name="firstDate">The date to subtract from.</param>
        /// <param name="secondDate">The date to subtract by.</param>
        /// <returns>The number of days between the first date minus the second date.</returns>
        public static int DaysBetween(DateTime firstDate, DateTime secondDate)
        {
            int numberOfDays = (firstDate - secondDate).Days;
            return numberOfDays;
        }

        public static string RemoveSpecialCharactors(string input)
        {
            return Regex.Replace(input, "[^a-zA-Z0-9]", string.Empty);
        }
    }
}