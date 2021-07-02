using System.Collections.Generic;
using System.Linq;
using TetraPak;
using Xunit;

namespace TestProject1
{
    public class TypeHelperTests
    {
        [Fact]
        public void IsCollectionOfKeyValuePairs()
        {
            var dictionary = new Dictionary<string, object>
            {
                ["a"] = "Hello World",
                ["b"] = true,
                ["c"] = 42
            };
            
            Assert.True(dictionary.IsCollectionOf<KeyValuePair<string,object>>(out var items));
            var itemsArray = items.ToArray();
            Assert.Equal(3, itemsArray.Length);
            Assert.Contains(itemsArray, pair => pair.Key == "a" && (string) pair.Value == "Hello World");
            Assert.Contains(itemsArray, pair => pair.Key == "b" && (bool) pair.Value == true);
            Assert.Contains(itemsArray, pair => pair.Key == "c" && (int) pair.Value == 42);
        }
    }
}