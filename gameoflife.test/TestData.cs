using System.Collections;
using System.Collections.Generic;
using gameoflife.lib;


/*

- https://hamidmosalla.com/2017/02/25/xunit-theory-working-with-inlinedata-memberdata-classdata/

*/
namespace gameoflife.test
{
    public class CustomTestInputData : IEnumerable<object[]>
    {
        // todo: auto generate this data.
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { @"Generation 1:
4 8
........
....*...
...**...
........", 4, 8 };
            yield return new object[] { @"Generation 1:
12 12
............
........*...
.......**...
............
............
............
............
............
............
............
............
............", 12, 12 };
            yield return new object[] { @"Generation 1:
3 100
....................................................................................................
....................................................................................................
....................................................................................................", 3, 100 };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }



    public class WrongTestInputData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { @"Generation e:
4 8
........
....*...
...**...
........", typeof(IncorrectInputFormat), "Generation line is wrong format" };

            yield return new object[] { @"Generation 1:
48
........
....*...
...**...
........", typeof(IncorrectInputFormat), "Incorrect boardsize line." };

            yield return new object[] { @"Generation 1:
4 E
........
....*...
...**...
........", typeof(IncorrectInputFormat), "Board width not found" };

            yield return new object[] { @"Generation 1:
E 8
........
....*...
...**...
........", typeof(IncorrectInputFormat), "Board height not found" };

            yield return new object[] { @"Generation 1:
4 8
........
....*...
...**...", typeof(IncorrectInputFormat), "input length = 3 not equal to supplied board height = 4" };

            yield return new object[] { @"Generation 1:
4 9
........
....*...
...**...
........", typeof(IncorrectInputFormat), "board width for line:0 is not 9" };

            yield return new object[] { @"Generation 1:
4 8
........
....*S..
...**...
........", typeof(IncorrectBoardCharacters), "row 1 contains character = S" };
        }



        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }


    //
    //
    //

    public class TestDataNextGeneration : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {  new GolData { Generation = 1, Width = 8, Height = 4, Board = new char[][] {
                new char[] {'.','.','.','.','.','.','.','.'},
                new char[] {'.','.','.','.','.','.','.','.'},
                new char[] {'.','.','.','*','*','.','.','.'},
                new char[] {'.','.','.','.','.','.','.','.'} }}, 2, 8, 4, new char[][] {
                new char[] {'.','.','.','.','.','.','.','.'},
                new char[] {'.','.','.','.','.','.','.','.'},
                new char[] {'.','.','.','.','.','.','.','.'},
                new char[] {'.','.','.','.','.','.','.','.'} }
            };
            // OK if only Rule : As a dead cell I will regain life if i have exactly three neighbours
           yield return new object[] {  new GolData { Generation = 1, Width = 8, Height = 4, Board = new char[][] {
                new char[] {'.','.','.','.','.','.','.','.'},
                new char[] {'.','.','.','.','*','.','.','.'},
                new char[] {'.','.','.','*','*','.','.','.'},
                new char[] {'.','.','.','.','.','.','.','.'} }}, 2, 8, 4, new char[][] {
                new char[] {'.','.','.','.','.','.','.','.'},
                new char[] {'.','.','.','*','.','.','.','.'},
                new char[] {'.','.','.','.','.','.','.','.'},
                new char[] {'.','.','.','.','.','.','.','.'} }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}