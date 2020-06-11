namespace ConnectFour
{
    class Counter
    {
        private string color;
        private char symbol;

        public Counter(string color)
        {
            this.color = color;
            this.symbol = color == "red" ? 'R' : 'Y';
        }

        public char Symbol { get => symbol; set => symbol = value; }
    }
}
