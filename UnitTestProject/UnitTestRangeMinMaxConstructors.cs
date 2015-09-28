using System;
using System.Collections.Generic;
using System.Linq;

using RangeLists;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestRangeMinMaxConstructors
    {
        [TestMethod]
        public void TestRangeMinMaxText()
        {
            string text;
            RangeMinMax range;

            List<string> items = new List<string> { "1", "5-7", "-1", "-1-5", "-6--5" };

            text = items[0];
            range = new RangeMinMax(text);
            Assert.AreEqual(1, range.Min, string.Format("Min '{0}'", text));
            Assert.AreEqual(1, range.Max, string.Format("Max '{0}'", text));

            text = items[1];
            range = new RangeMinMax(text);
            Assert.AreEqual(5, range.Min, string.Format("Min '{0}'", text));
            Assert.AreEqual(7, range.Max, string.Format("Max '{0}'", text));

            text = items[2];
            range = new RangeMinMax(text);
            Assert.AreEqual(-1, range.Min, string.Format("Min '{0}'", text));
            Assert.AreEqual(-1, range.Max, string.Format("Max '{0}'", text));

            text = items[3];
            range = new RangeMinMax(text);
            Assert.AreEqual(-1, range.Min, string.Format("Min '{0}'", text));
            Assert.AreEqual(5, range.Max, string.Format("Max '{0}'", text));

            text = items[4];
            range = new RangeMinMax(text);
            Assert.AreEqual(-6, range.Min, string.Format("Min '{0}'", text));
            Assert.AreEqual(-5, range.Max, string.Format("Max '{0}'", text));

        }

        [TestMethod]
        public void TestRangeMinMaxTextWithSpaces()
        {
            // This is basically the exact same test as TestRangeMinMaxText but the input text has additional spaces
            string text;
            RangeMinMax range;

            List<string> items = new List<string> { "1", "5 - 7", "-1", "-1 - 5", "-6 - -5" };

            text = items[0];
            range = new RangeMinMax(text);
            Assert.AreEqual(1, range.Min, string.Format("Min '{0}'", text));
            Assert.AreEqual(1, range.Max, string.Format("Max '{0}'", text));

            text = items[1];
            range = new RangeMinMax(text);
            Assert.AreEqual(5, range.Min, string.Format("Min '{0}'", text));
            Assert.AreEqual(7, range.Max, string.Format("Max '{0}'", text));

            text = items[2];
            range = new RangeMinMax(text);
            Assert.AreEqual(-1, range.Min, string.Format("Min '{0}'", text));
            Assert.AreEqual(-1, range.Max, string.Format("Max '{0}'", text));

            text = items[3];
            range = new RangeMinMax(text);
            Assert.AreEqual(-1, range.Min, string.Format("Min '{0}'", text));
            Assert.AreEqual(5, range.Max, string.Format("Max '{0}'", text));

            text = items[4];
            range = new RangeMinMax(text);
            Assert.AreEqual(-6, range.Min, string.Format("Min '{0}'", text));
            Assert.AreEqual(-5, range.Max, string.Format("Max '{0}'", text));

        }



        [TestMethod]
        public void TestRangeMinMaxUsingMinMaxValues()
        {
            RangeMinMax range = new RangeMinMax(5, 9);
            Assert.AreEqual(5, range.Min, "Min");
            Assert.AreEqual(9, range.Max, "Max");
        }

        [TestMethod]
        public void TestRangeMinMaxUsingListValues()
        {

            RangeMinMax range = new RangeMinMax(new List<int>{7, 9, 6});
            Assert.AreEqual(6, range.Min, "Min");
            Assert.AreEqual(9, range.Max, "Max");
        }

    }
}
