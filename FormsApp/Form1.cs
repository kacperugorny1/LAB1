using LAB1;
namespace FormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool dont_count = false;
            textBox4.Text = "";
            textBox5.Text = "";
            if (!Int32.TryParse(textBox1.Text, out int count))
            {
                textBox5.Text += "Liczba przedmiotów jest b³êdna\r\n";
                dont_count = true;
            }
            if (!Int32.TryParse(textBox2.Text, out int capacity))
            {
                textBox5.Text += "Pojemnoœæ plecaka jest b³êdna\r\n";
                dont_count = true;
            }

            if (!Int32.TryParse(textBox3.Text, out int seed))
            {
                textBox5.Text += "Seed jest b³êdny\r\n";
                dont_count = true;
            }
            if (dont_count) return;

            Problem prb = new(count, seed);
            textBox4.Text = prb.ToString().Replace("\n", Environment.NewLine);
            Result res = prb.Solve(capacity);
            textBox5.Text = res.ToString().Replace("\n", Environment.NewLine);

        }

    }
}
