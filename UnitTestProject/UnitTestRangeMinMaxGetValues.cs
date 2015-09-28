using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

using RangeLists;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestRangeMinMaxGetValues
    {
        [TestMethod]
        public void TestGetValuesWithThreeAdds()
        {
            RangeMinMax range = new RangeMinMax();
            range.Add(5);
            range.Add(8);
            range.Add(7); // NOTE : we did NOT add a 6.

            List<int> expected = new List<int> { 5, 6, 7, 8 };
            // NOTE : The 6 is expected because GetValues is intended to get all values within the Min to Max range
            // not just the values that were added.

            CollectionAssert.AreEqual(expected, range.GetValues(), "GetValues");
        }
    }
}
