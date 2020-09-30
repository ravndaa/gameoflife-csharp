using System;
using gameoflife.lib;
using Xunit;

/*
    Sources for making test as they should be:
    - https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test
    - https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
*/
namespace gameoflife.test
{
    public class UnitTest1
    {
        const string input = @"Generation 1:
4 8
........
....*...
...**...
........";

        [Fact]
        public void TestParseInput_OutputStringArray()
        {
            var lib = new GOL();
            var actual = lib.ParseInput(input);

            Assert.IsType<GOLInput>(actual);
        }

        [Fact]
        public void TestParseInput_OutputGenerationValue()
        {
            var lib = new GOL();
            var actual = lib.ParseInput(input);

            Assert.Equal(1, actual.Generation.Value);
        }

        [Fact]
        public void TestParseInput_OutputBoardValue()
        {
            var lib = new GOL();
            var actual = lib.ParseInput(input);

            Assert.Equal(new int[2]{4,8}, actual.BoardSize);
        }

        [Fact]
        public void TestParseInput_OutputBoard()
        {
            var wants = new char[][] {
                new char[] {'.','.','.','.','.','.','.','.'},
                new char[] {'.','.','.','.','*','.','.','.'},
                new char[] {'.','.','.','*','*','.','.','.'},
                new char[] {'.','.','.','.','.','.','.','.'}
            };

            var lib = new GOL();
            var actual = lib.ParseInput(input);

            Assert.Equal(wants, actual.Board);
        }

        [Fact]
        public void TestParseInput_OutputBoardOneLife()
        {
            
            var lib = new GOL();
            var actual = lib.ParseInput(input);

            Assert.Equal('*', actual.Board[1][4]);
        }

         [Fact]
        public void TestCheckForLife_Output() {

        }

    }
}
