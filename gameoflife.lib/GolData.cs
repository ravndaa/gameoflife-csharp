namespace gameoflife.lib
{
    // Trying to use struct => https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/choosing-between-class-and-struct
    public struct GolData
    {
        public int Generation { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public char[][] Board { get; set; }
    }

}