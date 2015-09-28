using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeLists
{
    public class RangeList
    {

        /// <summary>
        /// Takes a string of consolidated numbers e.g &quot;1-3,6,8-10&quot; and translates the numbers into a list of ranges.
        /// </summary>
        /// <param name="text">a string of consolidated numbers e.g &quot;1-3,6,8-10&quot;</param>
        /// <returns>A List of RangeMinMax values.</returns>
        public static List<RangeMinMax> GetRangeList(string text)
        {
            return GetRangeList(ParseSortConsolidatedIntegerList(text));
        }

        /// <summary>
        /// Takes a list of numbers and generates a list of ranges.
        /// </summary>
        /// <param name="numbers">A list of integers. The values must be pre-sorted in ascending order.</param>
        /// <returns>A list of ranges. Where each range defines a minimum value and a maximum value. A range defines 
        /// a series of consecutive numbers that appear in the original list of numbers.</returns>
        public static List<RangeMinMax> GetRangeList(List<int> numbers)
        {
            List<RangeMinMax> ranges = new List<RangeMinMax>();

            foreach(int number in numbers)
            {
                if(ranges.Count > 0)
                {
                    if((ranges[ranges.Count - 1].Max + 1) == number)
                    {
                        ranges[ranges.Count - 1].Add(number);
                        continue;
                    }
                }

                ranges.Add(new RangeMinMax(number, number));
            }

            return ranges;
        }

        /// <summary>
        /// Takes a list of ranges and converts them to a string.
        /// </summary>
        /// <param name="ranges">A list of RangeMinMax values.</param>
        /// <returns>A string</returns>
        public static string RangeListToString(List<RangeMinMax> ranges)
        {
            StringBuilder sb = new StringBuilder();

            foreach (RangeMinMax range in ranges)
            {
                if (sb.Length > 0) sb.Append(",");
                sb.Append(range.ToString());
            }

            return sb.ToString();
        }


        /// <summary>
        /// Take a list of integer values and generate a compact string that describes the list. e.g. 1,2,3,6,8,9,10 translates to 1-3,6,8-10
        /// </summary>
        /// <param name="numbers">A list of integer values. The list does not have to be in order.</param>
        /// <returns>A compact string that describes the list.</returns>
        public static string ListNumbersToConsolidatedString(List<int> numbers)
        {
            List<int> copy = numbers.Select(x => x).OrderBy(x => x).ToList();

            return RangeListToString(GetRangeList(copy));
        }



        /// <summary>
        /// Parses a string comprising of a consolidated list of numbers and sorts the numbers into ascending order and returns the list.
        /// </summary>
        /// <param name="text">A string comprising a consolidated list of numbers. For example &quot;5,1-3,8,10,15-18&quot;</param>
        /// <returns>A list of integers in ascending order.</returns>
        public static List<int> ParseSortConsolidatedIntegerList(string text)
        {
            List<int> list = new List<int>();

            string[] segments = text.Split(new char[] { ',' });

            foreach (string segment in segments)
            {
                RangeMinMax range = new RangeMinMax(segment);
                list.AddRange(range.GetValues());
            }

            return list.OrderBy(x => x).ToList();
        }

        /// <summary>
        /// Inspects the string text for valid characters. Performs a simple pre-screen test to see if the string may be parseable.
        /// </summary>
        /// <param name="text"></param>
        /// <returns><code>true</code> if the text contains valid characters for a range list. A <code>true</code> does not guarantee that the string is actually parseable.</returns>
        public static bool IsValidCharacters(string text)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(text, @"^[0-9,\- ]+$");
        }
    }
}
