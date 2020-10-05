using System;

namespace gameoflife.lib
{

    //  execptions
    public class IncorrectInputFormat : Exception
    {
        public IncorrectInputFormat() { }
        public IncorrectInputFormat(string message) : base(message) { }
        public IncorrectInputFormat(string message, Exception inner) : base(message, inner) { }
    }

    public class IncorrectBoardCharacters : Exception
    {
        public IncorrectBoardCharacters() { }
        public IncorrectBoardCharacters(string message) : base(message) { }
        public IncorrectBoardCharacters(string message, Exception inner) : base(message, inner) { }
    }
}