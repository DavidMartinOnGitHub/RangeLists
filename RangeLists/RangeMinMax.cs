using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeLists
{
    /// <summary>
    /// A class to contain Minimum and Maximum values.
    /// </summary>
    public class RangeMinMax
    {
        /// <summary>
        /// Default constructor. Not generally useful. Assigns the Min property to Int32.MaxValue and the Max property to Int32.MinValue.
        /// </summary>
        public RangeMinMax()
        {
            this.Min = Int32.MaxValue;
            this.Max = Int32.MinValue;
        }

        /// <summary>
        /// RangeMinMax constructor that accepts the min and max values.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public RangeMinMax(int min, int max)
        {
            this.Min = min;
            this.Max = max;
        }

        /// <summary>
        /// A RangeMinMax constructor that accepts a List of integer values. The Minimum/Maximum values on the list become the objects Min/Max properties.
        /// </summary>
        /// <param name="values">A list of integer values.</param>
        public RangeMinMax(List<int> values)
        {
            this.Min = values.Min();
            this.Max = values.Max();
        }

        /// <summary>
        /// A RangeMinMax constructor that takes a string of the form &quote;5-8&quot; or &quot;6&quot;. In the former the Min is 5 and the Max is 8. In the later, both the Min and Max values will be 6.
        /// </summary>
        /// <param name="text">A string of the form &quote;5-8&quot; or &quot;6&quot;.</param>
        public RangeMinMax(string text)
        {
            this.Min = Int32.MaxValue;
            this.Max = Int32.MinValue;

            int dashcount = text.Count(x => (x == '-'));
            List<int> values = text.Split(new char[] { '-', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => Int32.Parse(x)).ToList();

            if (dashcount > 1) values[0] = -values[0];
            if (dashcount == 1 && values.Count == 1) values[0] = -values[0];
            if (dashcount == 3) values[1] = -values[1];

            Add(values);
        }

        /// <summary>
        /// The Minimum value of the range.
        /// </summary>
        public int Min { get; private set; }

        /// <summary>
        /// The Maximum value of the range.
        /// </summary>
        public int Max { get; private set; }


        /// <summary>
        /// Add an item. If the value is smaller than the current Min, then a new Min is assigned. If the value is larger than Max then a new Max value is assigned.
        /// </summary>
        /// <param name="value">An integer value.</param>
        public void Add(int value)
        {
            if (this.Min > value) this.Min = value;
            if (this.Max < value) this.Max = value;
        }

        /// <summary>
        /// Add several values. The minimum and maximum values on the incoming list are considered as new Min and Max candidates.
        /// </summary>
        /// <param name="values">A list of integer values.</param>
        public void Add(List<int> values)
        {
            Add(values.Min());
            Add(values.Max());
        }

        /// <summary>
        /// Gets a list of all integers between the Min and Max values.
        /// </summary>
        /// <returns>A list of all the integers between Min and Max (inclusive).</returns>
        public List<int> GetValues()
        {
            List<int> list = new List<int>();

            for (int value = this.Min; value <= this.Max; value++)
            {
                list.Add(value);
            }

            return list;
        }


        /// <summary>
        /// A string representation of the range. For example &quot;5-8&quot; or &quot;6&quot; for a range where the Min and Max both equal 6.
        /// </summary>
        /// <returns>A string representation of the range.</returns>
        public override string ToString()
        {
            if (this.Min == this.Max) return this.Min.ToString();

            return string.Format("{0}-{1}", this.Min, this.Max);
        }
    }
}
