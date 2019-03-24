using System;
using Xunit;
using Basicalgorithm.Dictionary;
using System.Collections.Generic;

namespace DictionaryMd.Tests
{
    public class UnitTest1
    {
        private IDictionary<int, string> _dict;

        public UnitTest1()
        {
            _dict = new DictionaryMd<int, string>(100);
            _dict.Add(1,"one");
            _dict.Add(2, "two");
            _dict.Add(3, "three");
            _dict.Add(4, "four");

        }
        [Fact]
        public void Test1()
        {
            Assert.NotNull(_dict);
            Assert.Equal("one", _dict[1]);
            Assert.Equal("two", _dict[2]);
            Assert.Equal("three", _dict[3]);
            Assert.Equal("four", _dict[4]);

        }
    }
}
