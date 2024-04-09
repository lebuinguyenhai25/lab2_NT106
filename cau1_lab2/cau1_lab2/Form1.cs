namespace cau1_lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Chọn file đầu vào";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        string content = sr.ReadToEnd();
                        richTextBox1.Text = content;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }


        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd =new OpenFileDialog();
                ofd.Title = "Chọn file đầu ra";
                if(ofd.ShowDialog()==DialogResult.OK)
                {
                    string filePath=ofd.FileName;
                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        string uperContent = richTextBox1.Text.ToUpper();
                        richTextBox1.Text = uperContent;
                        sw.Write(uperContent);
                    }
                    MessageBox.Show("ghi file thành công");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Không tìm thấy file" + ex.Message);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
