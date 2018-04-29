using System;
using Xunit;
using Roman2ArabicNumbers;

namespace Roman2ArabicNumbersTest
{
    public class ProgramTest
    {
        private readonly Program _program;

        public ProgramTest()
        {
            _program = new Program();
        }
        [Fact]
        public void Test1()
        {
            int result = Program.RomanParser(string.Empty);
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("MCDXXXI", 1431)]
        [InlineData("CDXLIX", 449)]
        [InlineData("CCCLV", 355)]
        public void Test2(string value, int expected)
        {
            int result = Program.RomanParser(value);
            Assert.True(result == expected);
        }
    }
}
