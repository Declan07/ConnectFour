namespace ConnectFour
{
    class Player
    {
        private string color;
        private string name;

        public Player(string name)
        {
            this.name = name;
        }

        public void setColor(string color)
        {
            this.color = color;
        }
        public string getColor()
        {
            return this.color;
        }
        public string getName()
        {
            return this.name;
        }
    }
}
