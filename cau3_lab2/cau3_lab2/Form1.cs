using System.IO;
using System.Text.RegularExpressions;
namespace cau3_lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string filePath = "";
        private void button1_Click(object sender, EventArgs e)
        {   //chọn file và hiển thị nội dung của file vào richtextbox1
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn File";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                try
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        richTextBox1.Text = sr.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi đọc file: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn file trước!");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (filePath != "")
            {
                try
                {
                  
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Title = "Chọn file để ghi vào";
                    if(sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamReader sr = new StreamReader(filePath))
                        {
                            // Tính toán các hàm và xuất output ra richtextbox1 và file output
                            string input = sr.ReadToEnd();
                            string[] bieuThucs = Regex.Split(input, @"\r?\n"); // Tách các biểu thức
                            using (StreamWriter sw = new StreamWriter(sfd.FileName))
                            {
                                richTextBox1.Clear();
                                foreach (string bieuThuc in bieuThucs)
                                {
                                    // Tính toán kết quả
                                    double result = Xuliketqua(bieuThuc);
                                    // Ghi kết quả ra file và richtextbox
                                    sw.WriteLine($"{bieuThuc} = {result}");
                                    richTextBox1.Text += $"{bieuThuc} = {result}\n";
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chọn file để ghi kết quả");
                    }   
                    
                }catch(Exception ex)
                {
                    MessageBox.Show("Error:", ex.Message);
                }
            }
        }
        public double Xuliketqua(string bieuThuc)
        {
            // Sử dụng Shunting-yard algorithm để tính toán biểu thức
            Stack<double> operands = new Stack<double>();
            Stack<char> operators = new Stack<char>();

            foreach (char c in bieuThuc)
            {
                if (Char.IsDigit(c))
                {
                    // Đẩy số vào stack operands
                    operands.Push(c - '0');
                }
                else if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    // Xử lý toán tử
                    while (operators.Count > 0 && Precedence(operators.Peek()) >= Precedence(c))
                    {
                        double right = operands.Pop();
                        double left = operands.Pop();
                        char op = operators.Pop();
                        operands.Push(Calculate(left, right, op));
                    }
                    operators.Push(c);
                }
                else if (c == '(')
                {
                    // Đẩy dấu ngoặc mở vào stack operators
                    operators.Push(c);
                }
                else if (c == ')')
                {
                    // Xử lý dấu ngoặc đóng
                    while (operators.Peek() != '(')
                    {
                        double right = operands.Pop();
                        double left = operands.Pop();
                        char op = operators.Pop();
                        operands.Push(Calculate(left, right, op));
                    }
                    operators.Pop(); // Bỏ dấu ngoặc mở
                }
            }

            // Tính toán các toán tử còn lại
            while (operators.Count > 0)
            {
                double right = operands.Pop();
                double left = operands.Pop();
                char op = operators.Pop();
                operands.Push(Calculate(left, right, op));
            }

            return operands.Pop();
        }
        private double Calculate(double left, double right, char op)
        {
            switch (op)
            {
                case '+':
                    return left + right;
                case '-':
                    return left - right;
                case '*':
                    return left * right;
                case '/':
                    return left / right;
                default:
                    throw new InvalidOperationException("Invalid operator");
            }
        }
        private int Precedence(char c)
        {
            switch (c)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                default:
                    return 0;
            }
        }

    }
}
