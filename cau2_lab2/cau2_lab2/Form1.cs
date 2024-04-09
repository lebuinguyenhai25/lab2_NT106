namespace cau2_lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở hộp thoại chọn file
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Chọn file đầu vào";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Lấy thông tin file
                    string filePath = ofd.FileName;
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        string fileName = Path.GetFileName(filePath);
                        long fileSize = new FileInfo(filePath).Length;
                        string fileUrl = filePath;
                        int lineCount = 0;
                        int wordCount = 0;
                        int charCount = 0;

                        // Đọc nội dung file
                        using (StreamReader sr = new StreamReader(filePath))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                lineCount++;
                                string[] words = line.Split(' ');
                                wordCount += words.Length;
                                charCount += line.Replace(" ", "").Length;
                            }
                        }

                        // Hiển thị thông tin file
                        textBox1.Text = fileName;
                        textBox2.Text = fileSize.ToString() + " bytes";
                        textBox3.Text = fileUrl;
                        textBox4.Text = lineCount.ToString();
                        textBox5.Text = wordCount.ToString();
                        textBox6.Text = charCount.ToString();

                        // Hiển thị nội dung file
                        string fileContent = File.ReadAllText(filePath);
                        if (!string.IsNullOrEmpty(fileContent))
                        {
                            richTextBox1.Text = fileContent;
                        }
                        else
                        {
                            richTextBox1.Text = "File trống hoặc không thể đọc được!";
                        }

                        // Thực hiện các chức năng tiếp theo
                        // ...

                    }
                    else
                    {
                        MessageBox.Show("Hãy chọn một file trước ");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: Xảy ra lỗi trong quá trình xử lý file. Vui lòng xem chi tiết: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
