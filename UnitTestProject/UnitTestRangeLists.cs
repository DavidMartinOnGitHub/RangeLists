using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

using RangeLists;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestRangeLists
    {
        [TestMethod]
        public void TestFullRoundTripParseAndBackToString()
        {
            string expected = "0-2,4,6-8,11-12,16";
            const string text = "0,  1,  2,  4,  6,  7,  8, 11, 12, 16";

            List<int> numbers = RangeLists.RangeList.ParseSortConsolidatedIntegerList(text);

            List<RangeMinMax> ranges = RangeLists.RangeList.GetRangeList(numbers);

            string actual = RangeLists.RangeList.RangeListToString(ranges);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetRangeListUsingTextAndBackToString()
        {
            string expected = "0-2,4,6-8,11-12";
            const string text = "0,  1,  2,  4,  6,  7,  8, 11, 12";

            List<RangeMinMax> ranges = RangeLists.RangeList.GetRangeList(text);

            string actual = RangeLists.RangeList.RangeListToString(ranges);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestParseAndSort()
        {
            string text = "0-2,4,6-8,11-12";
            List<int> expected = new List<int> { 0, 1, 2, 4, 6, 7, 8, 11, 12};

            List<int> actual = RangeLists.RangeList.ParseSortConsolidatedIntegerList(text);

            CollectionAssert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestGetRangeList()
        {
            List<int> numbers = new List<int> { 0, 1, 2, 4, 6, 7, 8 }; // consolidates to "0-2,4,6-8"

            List<RangeMinMax> list = RangeLists.RangeList.GetRangeList(numbers);


            Assert.AreEqual(3, list.Count, "Verify list length");

            Assert.AreEqual(0, list[0].Min, "Verify [0].Min");
            Assert.AreEqual(2, list[0].Max, "Verify [0].Max");

            Assert.AreEqual(4, list[1].Min, "Verify [1].Min");
            Assert.AreEqual(4, list[1].Max, "Verify [1].Max");

            Assert.AreEqual(6, list[2].Min, "Verify [2].Min");
            Assert.AreEqual(8, list[2].Max, "Verify [2].Max");
        }

        [TestMethod]
        public void TestLegalPositiveCases()
        {
            string text = "0,2,4,6,8";
            Assert.IsTrue(RangeList.IsValidCharacters(text), text);

            text = "0-2,4,6-8";
            Assert.IsTrue(RangeList.IsValidCharacters(text), text);

            text = " 0-2 , 4 ,6 - 8 ";
            Assert.IsTrue(RangeList.IsValidCharacters(text), text);
        }

        [TestMethod]
        public void TestLegalNegativeCases()
        {
            string text = "0,+2,4,6,8";
            Assert.IsFalse(RangeList.IsValidCharacters(text), text);

            text = "0-2*,4,6-8";
            Assert.IsFalse(RangeList.IsValidCharacters(text), text);
            text = "0-2,U4,6-8";
            Assert.IsFalse(RangeList.IsValidCharacters(text), text);

            text = "abcdef";
            Assert.IsFalse(RangeList.IsValidCharacters(text), text);
        }

    }
}
