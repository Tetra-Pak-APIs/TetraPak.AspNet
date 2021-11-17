using TetraPak.AspNet;
using Xunit;

namespace Tests.TetraPak.AspNet
{
    public class HttpQueryParametersTests
    {
        [Fact]
        public void IsEmpty()
        {
            var qp = new HttpQuery();
            Assert.True(qp.IsEmpty());
            qp.Add("a", "aa");
            Assert.False(qp.IsEmpty());
            qp = new HttpQuery { ["a"] = "aa" };
            Assert.False(qp.IsEmpty());
        }

        [Fact]
        public void StringValue()
        {
            var qp = new HttpQuery { { "a", "aa" } };
            Assert.Equal("a=aa", qp.StringValue);
            Assert.Equal("?a=aa", qp.ToString(true));
            qp = new HttpQuery { ["a"] = null, ["b"] = "bb" };
            Assert.Equal("a&b=bb", qp.StringValue);
            Assert.Equal("?a&b=bb", qp.ToString(true));
        }

        [Fact]
        public void TypeCast()
        {
            HttpQuery qp = "  ? a=aa & b = bb";
            Assert.True(qp.TryGetValue("a", out var value));
            Assert.Equal("aa", value);
            Assert.True(qp.TryGetValue("b", out value));
            Assert.Equal("bb", value);
            Assert.Equal("a=aa&b=bb", qp);
        }

        [Fact]
        public void ContainsKey()
        {
            var qp = new HttpQuery { ["a"] = "aa", ["b"] = "bb" };
            Assert.True(qp.ContainsKey("a"));
            Assert.True(qp.ContainsKey("b"));
            Assert.False(qp.ContainsKey("c"));
        }
    }
}