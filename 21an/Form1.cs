using System.Collections.Generic;

namespace _21an
{
    public partial class Form1 : Form
    {
        public bool TaEttKort = false;
        public bool AvslutaRundan = false;

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
        public int Checker(int UserPoints, int ComputerPoints) // 0 = ingen vann. 1 = spelaren vann. 2 = datorn vann.
        {
            if (UserPoints > 21)
            {
                return 2;
            }
            if (ComputerPoints > 21)
            {
                return 1;
            }
            return 0;
        }
        public int FinalChecker(int UserPoints, int ComputerPoints)
        {
            int OldChecker = Checker(UserPoints, ComputerPoints);
            if (OldChecker != 0)
            {
                if (OldChecker == 1)
                {
                    MessageBox.Show("Du vann grattis");
                    return 1;
                }
                if (OldChecker == 2)
                {
                    MessageBox.Show("Du förlorade");
                    return 2;
                }
            }
            else if (UserPoints > ComputerPoints)
            {
                MessageBox.Show("Du vann grattis");
                return 1;
            }
            else if (ComputerPoints > UserPoints)
            {
                MessageBox.Show("Du förlorade");
                return 2;
            }
            return 0;

        }
        public void WriteTotalPoints(int UserPoints, int ComputerPoints)
        {
            ComputerTotalPoints.Text = ComputerPoints.ToString();
            UserTotalPoints.Text = UserPoints.ToString();
        }


        public Form1()
        {
            InitializeComponent();
        }
        public async Task Wait()
        {
            while(!TaEttKort | !AvslutaRundan)
            {
                await Task.Delay(100).ConfigureAwait(false);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            bool kör = true;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;

            int UserPoints = GivePoints(true, 2);
            int ComputerPoints = GivePoints(false, 2);
            WriteTotalPoints(UserPoints, ComputerPoints);

            while (kör)
            {

                await Wait();

                //Fråga användaren om han vill ta mer kort.
                if (TaEttKort)
                {
                    UserPoints += GivePoints(true);
                    ComputerPoints += GivePoints(false);
                    WriteTotalPoints(UserPoints, ComputerPoints);
                    TaEttKort = false;
                }
                if (AvslutaRundan)
                {
                    while(ComputerPoints < UserPoints)
                    {
                        ComputerPoints += GivePoints(false);
                        WriteTotalPoints(UserPoints, ComputerPoints);
                    }
                    TaEttKort = false; 
                    if (FinalChecker(UserPoints,ComputerPoints) != 0) { kör = false; }
                }
                int vinst = Checker(UserPoints, ComputerPoints);
                if (vinst != 0)
                {
                    if(vinst == 1)
                    {
                        MessageBox.Show("Du vann grattis");
                    }
                    if(vinst == 2)
                    {
                        MessageBox.Show("Du förlorade");
                    }
                    kör = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TaEttKort = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AvslutaRundan = true;
        }
    }
}
