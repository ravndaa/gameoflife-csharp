using System;
using Xunit;
using gameoflife.lib;

/*
    Sources for making test as they should be:
    - https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test
    - https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
*/

namespace gameoflife.test {

    public class UnitTestGOLLibrary {
        private readonly string correctGeneration1input = "Generation 1:\n4 8\n........\n....*...\n...**...\n........\n";
        private readonly string wrongFirstlineGeneration1input = "Generation E:\n4 8\n........\n....*...\n...**...\n........\n";
        private readonly string wrongSecondlineGeneration1input = "Generation 1:\nE 8\n........\n....*...\n...**...\n........\n";
        private readonly string wrongLenghtOfColumnsGeneration1input = "Generation 1:\n4 8\n.......\n....*...\n...**...\n........\n"; // one dott is missing.
        //private readonly string correctGeneration2output = "Generation 2:\n4 8\n........\n...**...\n...**...\n........\n";
        private static readonly char[][] correctGeneration1Board= new char[][] {
                new char[] {'.','.','.','.','.','.','.','.'},
                new char[] {'.','.','.','.','*','.','.','.'},
                new char[] {'.','.','.','*','*','.','.','.'},
                new char[] {'.','.','.','.','.','.','.','.'}
        };
        private readonly GolData correctParsedGeneration1input = new GolData {Generation=1, Width=8, Height=4, Board=correctGeneration1Board};

        [Fact]
        public void TestParseInput_OutputGOLDataStruct() {
            var parsedGen1output = GOL.ParseInput(correctGeneration1input);

            Assert.Equal(correctParsedGeneration1input.Generation,parsedGen1output.Generation);
            Assert.Equal(correctParsedGeneration1input.Height,parsedGen1output.Height);
            Assert.Equal(correctParsedGeneration1input.Width,parsedGen1output.Width);
            Assert.Equal(correctParsedGeneration1input.Board,parsedGen1output.Board);
        }

        // test if correct error is thrown.
        // extend to check error message.
        [Fact]
        public void TestParseInput_WhenInputisWrong() {
            Assert.Throws<Exception>(() => GOL.ParseInput(wrongFirstlineGeneration1input));
            Assert.Throws<Exception>(() => GOL.ParseInput(wrongSecondlineGeneration1input));
            Assert.Throws<Exception>(() => GOL.ParseInput(wrongLenghtOfColumnsGeneration1input));
        }

    }
}