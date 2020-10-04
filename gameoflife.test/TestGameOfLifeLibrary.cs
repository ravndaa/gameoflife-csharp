using System;
using Xunit;
using gameoflife.lib;

/*
    Sources for making test as they should be:
    - https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test
    - https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
*/

namespace gameoflife.test
{

    public class UnitTestGOLLibrary
    {

        [Fact]
        public void TestParseInput_OutputGOLDataStruct()
        {

            string correctGeneration1input = @"Generation 1:
4 8
........
....*...
...**...
........";

            char[][] correctGeneration1Board = new char[][] {
                new char[] {'.','.','.','.','.','.','.','.'},
                new char[] {'.','.','.','.','*','.','.','.'},
                new char[] {'.','.','.','*','*','.','.','.'},
                new char[] {'.','.','.','.','.','.','.','.'}
            };
            GolData correctParsedGeneration1input = new GolData { Generation = 1, Width = 8, Height = 4, Board = correctGeneration1Board };

            var parsedGen1output = GOL.ParseInput(correctGeneration1input);

            Assert.Equal(correctParsedGeneration1input.Generation, parsedGen1output.Generation);
            Assert.Equal(correctParsedGeneration1input.Height, parsedGen1output.Height);
            Assert.Equal(correctParsedGeneration1input.Width, parsedGen1output.Width);
            Assert.Equal(correctParsedGeneration1input.Board, parsedGen1output.Board);
        }

        [Fact]
        public void TestParseInput_Emptyinput()
        {
            var input = "";
            Assert.Throws<IncorrectInputFormat>(() => GOL.ParseInput(input));
        }



        [Theory]
        [ClassData(typeof(CustomTestInputData))]
        public void TestParseInput_BoardSizes(string input, int height, int width)
        {

            var parsedGen1output = GOL.ParseInput(input);

            Assert.Equal(height, parsedGen1output.Height);
            Assert.Equal(width, parsedGen1output.Width);
        }

        [Fact]
        public void TestParseInput_WhenInputGenerationIsWrong()
        {
            string input = @"Generation E:
4 8
........
....*...
...**...
........";
            var ex = Record.Exception(() => GOL.ParseInput(input));
            Assert.IsType<IncorrectInputFormat>(ex);
            Assert.Equal("Generation line is wrong format", ex.Message);

        }

        [Fact]
        public void TestParseInput_WhenInputBoardWidthIsWrong()
        {
            string input = @"Generation 1:
5 E
........
....*...
...**...
........";
            var ex = Record.Exception(() => GOL.ParseInput(input));
            Assert.IsType<IncorrectInputFormat>(ex);
            Assert.Equal("Board width not found", ex.Message);

        }

        [Fact]
        public void TestParseInput_WhenInputBoardHeightIsWrong()
        {
            string input = @"Generation 1:
E 6
........
....*...
...**...
........";
            var ex = Record.Exception(() => GOL.ParseInput(input));
            Assert.IsType<IncorrectInputFormat>(ex);
            Assert.Equal("Board height not found", ex.Message);

        }

        [Fact]
        public void TestParseInput_WhenInputBoardDoesNotMatchHeightIsWrong() {
            string input = @"Generation 1:
4 8
........
....*...
...**...";
            var ex = Record.Exception(() => GOL.ParseInput(input));
            Assert.IsType<IncorrectInputFormat>(ex);
            Assert.Equal("input length = 3 not equal to supplied board height = 4", ex.Message);
        }

        [Fact]
        public void TestParseInput_WhenInputBoardDoesNotMatchWidthIsWrong() {
            string input = @"Generation 1:
4 9
........
....*...
...**...
........";
            var ex = Record.Exception(() => GOL.ParseInput(input));
            Assert.IsType<IncorrectInputFormat>(ex);
            Assert.Equal("board width for line:0 is not 9", ex.Message);
        }


    }
}