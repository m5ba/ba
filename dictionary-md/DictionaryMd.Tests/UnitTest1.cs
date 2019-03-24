using System;
using Xunit;
using Basicalgorithm.Dictionary;
using System.Collections.Generic;

namespace DictionaryMd.Tests
{
    public class UnitTest1
    {
        private readonly IDictionary<int, string> _dict;
        private readonly IDictionary<int, string> _dictLarge;
        private const int n = 200;
        private string[] names = new string[n];

        public UnitTest1()
        {
            _dict = new DictionaryMd<int, string>(100);
            _dict.Add(1,"one");
            _dict.Add(2, "two"); 
            _dict.Add(3, "three");
            _dict.Add(4, "four");

            _dictLarge = new DictionaryMd<int, string>(100);
            for(int i=0;i<n;i++)
            {
                names[i] = $"i={i}";
                _dictLarge.Add(i, names[i]);
            }

        }
        [Fact]
        public void TestSmalDict()
        {
            Assert.NotNull(_dict);
            Assert.Equal("one", _dict[1]);
            Assert.Equal("two", _dict[2]);
            Assert.Equal("three", _dict[3]);
            Assert.Equal("four", _dict[4]);
            Assert.Throws<ArgumentException>(()=>_dict.Add(1,"a"));
        }
        
        [Fact]
        public void TestLargeDict()
        {
            Assert.NotNull(_dictLarge);
            for(int i=0;i<n;i++)
            {
                Assert.Equal(names[i], _dictLarge[i]);
            }
        }    
    }
}
