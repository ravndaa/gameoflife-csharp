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

        // testing wrong inputs, and check that we handle it by throwing exceptions we want.
        [Theory]
        [ClassData(typeof(WrongTestInputData))]
        public void TestParseInput_WrongInputStrings(string input, Type customtype, string exceptionmessage){
            

            var ex = Record.Exception(() => GOL.ParseInput(input));
            Assert.IsType(customtype,ex);
            Assert.Equal(exceptionmessage, ex.Message);
        }

    }
}