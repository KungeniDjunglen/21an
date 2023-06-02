namespace _21an
{
    public partial class Form1 : Form
    {
        static int DraKort()
        {
            Random rng = new Random();
            int number = rng.Next(1, 11);
            return number;
        }
        public int GivePoints(bool Who, int times = 1)
        {
            int points = 0;
            int LastPoint = 0;

            for (int i = 0; i < times; i++)
            {
                LastPoint = DraKort();
                points += LastPoint;
                if (Who)
                {
                    UserLastPoints.Text = LastPoint.ToString();
                }
                else
                {
                    ComputerLastPoints.Text = LastPoint.ToString();
                }
            }
            return points;
        }
        public bool Checker(int UserPoints, int ComputerPoints)
        {
            if (UserPoints > 21)
            {

            }
            return false;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool kör = true;
            button2.BackColor = Color.White;

            int UserPoints = GivePoints(true, 2);
            int ComputerPoints = GivePoints(false, 2);

            while (kör)
            {
                kör = false;
            }


        }
    }
}