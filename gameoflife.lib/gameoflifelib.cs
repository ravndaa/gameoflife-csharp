using System;
using System.Text.RegularExpressions;

namespace gameoflife.lib
{
    // Game of life library.
    public class GOL
    {
        // outputs a object with header, boardsize and board.
        public GOLData ParseInput(string input)
        {
            var s = input.Split('\n');
            var generation = new Generation { Raw = s[0], Value = GetGenerationValue(s[0]) };
            var boardsize = GetRowsAndColumns(s[1]);

            var board = GetBoard(s, boardsize[0]);
            var output = new GOLData { Generation = generation, BoardSize = boardsize, Board = board };
            return output;
        }

        //
        private char[][] GetBoard(string[] s, int rows)
        {
            int rowss = rows + 2; // hakk
            var ss = s[2..rowss];

            var output = new char[ss.Length][];
            for (int i = 0; i < ss.Length; i++)
            {
                output[i] = ss[i].Replace("\r", "").ToCharArray();
            }

            return output;
        }

        //
        private int GetGenerationValue(string s)
        {
            var regexPattern = @"Generation (\d+):";
            var result = int.Parse(Regex.Match(s, regexPattern).Groups[1].ToString());

            return result;
        }

        // 
        private static int[] GetRowsAndColumns(string s)
        {
            var res = new int[2];

            var regexPattern = @"((\d+)\s(\d+))";
            var result = Regex.Match(s, regexPattern);

            res[0] = int.Parse(result.Groups[2].ToString());
            res[1] = int.Parse(result.Groups[3].ToString());

            return res;
        }
    }
}
