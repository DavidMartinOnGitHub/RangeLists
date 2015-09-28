using System;
using System.Collections.Generic;
using System.Linq;

using RangeLists;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject3
{
    [TestClass]
    public class UnitTestRangeMinMaxAdd
    {
        [TestMethod]
        public void TestAddTwoValues()
        {
            RangeMinMax range = new RangeMinMax();
            range.Add(5);
            range.Add(8);

            Assert.AreEqual(5, range.Min, "Min");
            Assert.AreEqual(8, range.Max, "Max");
        }

        [TestMethod]
        public void TestAddThreeValues()
        {
            RangeMinMax range = new RangeMinMax();
            range.Add(5);
            range.Add(8);
            range.Add(1);

            Assert.AreEqual(1, range.Min, "Min");
            Assert.AreEqual(8, range.Max, "Max");
        }
    }
}
