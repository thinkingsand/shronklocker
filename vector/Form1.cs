namespace vector
{
    public partial class ransom : Form
    {
        public ransom()
        {
            InitializeComponent();
        }

        public TimeSpan countObj = new TimeSpan(3, 0, 0, 0);
        public TimeSpan decrementSpan = new TimeSpan(0, 0, 1);
        public DateTime dateObj = DateTime.Now;

        private void Form1_Load(object sender, EventArgs e)
        {
            dateObj = dateObj.AddDays(3);
            string targDate = dateObj.ToString("MM/dd/yyyy");
            string targTime = dateObj.ToString("hh:mm:ss");
            timeLabel.Text = targDate + "\r\n" + targTime;

            timer1.Start();

        }

        private void payButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Invalid gender");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            countObj = countObj.Subtract(decrementSpan);
            timeLeftLabel.Text = (countObj.ToString(@"d\:hh\:mm\:ss"));
        }
    }
}