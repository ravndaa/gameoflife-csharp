namespace gameoflife.lib
{
    // rename with a bettername..
    public class GOLData {
        public Generation Generation {get;set;}
        public int[] BoardSize {get;set;} // x and y
        public char[][] Board {get;set;} 
    }

    public class Generation {
        public string Raw {get;set;}
        public int Value {get;set;}
    }
}