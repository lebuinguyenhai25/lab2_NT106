namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectionFile = new OpenFileDialog();
            selectionFile.ShowDialog();
            FileStream fs = new FileStream(selectionFile.FileName, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            MessageBox.Show("Bạn đã chọn file");
        }
    }
}
