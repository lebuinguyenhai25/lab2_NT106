using System.Text;
using System.Text.Json;
using static bai4_lab2.Form1;

namespace bai4_lab2
{
    public partial class Form1 : Form
    {
        private List<SinhVien> sinhViens = new List<SinhVien>();
        private const string filePath = "input4.json";
        int currentIndex = 0;
        public Form1()
        {
            InitializeComponent();
            sinhViens = DocDanhSachSinhVien(filePath);
            if (sinhViens.Count > 0)
            {
                //HienThiThongTinSinhVien(sinhViens[0]);
            }
            sinhViens.Clear();
        }
        public class SinhVien
        {
            public string HoTen { get; set; }
            public int MSSV { get; set; }
            public string DienThoai { get; set; }
            public float DiemMon1 { get; set; }
            public float DiemMon2 { get; set; }
            public float DiemMon3 { get; set; }
            public float DiemTrungBinh => (DiemMon1 + DiemMon2 + DiemMon3) / 3;
        }
        public static void GhiDanhSachSinhVien(string filePath, List<SinhVien> sinhViens)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(sinhViens, options);
            File.WriteAllText(filePath, jsonString);
        }
        public static List<SinhVien> DocDanhSachSinhVien(string filePath)
        {
            if (!File.Exists(filePath)) return new List<SinhVien>();

            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<SinhVien>>(jsonString) ?? new List<SinhVien>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sinhVien = new SinhVien
            {
                HoTen = textBox1.Text,
                MSSV = int.Parse(textBox2.Text),
                DienThoai = textBox3.Text,
                DiemMon1 = float.Parse(textBox4.Text),
                DiemMon2 = float.Parse(textBox5.Text),
                DiemMon3 = float.Parse(textBox6.Text),
            };

            
            int s = 0;
            // định dạng cho sđt
            if (textBox3.Text.Length != 10 || !textBox3.Text.StartsWith("0") || !textBox3.Text.All(char.IsDigit))
            {
                MessageBox.Show("Vui lòng nhập đungs định dạng SĐT!");
                textBox3.Clear();
                s = 1;
            }
            // định dạng cho MSSV
            if(textBox2.Text.Length != 8)
            {
                MessageBox.Show("Vui loòng nhập MSSV đúng 8 số!");
                s = 1;
                textBox2.Clear();
            }
            //định dạng điểm 
            if (0 > float.Parse(textBox4.Text) || float.Parse(textBox4.Text) > 10)
            {
                MessageBox.Show("Vui lòng nhập đúng điểm");
                s = 1;
                textBox4.Clear();
            }
            if (0 > float.Parse(textBox5.Text) || float.Parse(textBox5.Text) > 10)
            {
                MessageBox.Show("Vui lòng nhập đúng điểm");
                s = 1;
                textBox4.Clear();
            }
            if (0 > float.Parse(textBox6.Text) || float.Parse(textBox6.Text) > 10)
            {
                MessageBox.Show("Vui lòng nhập đúng điểm");
                s = 1;
                textBox4.Clear();
            }
            if (s==0)
            {
                sinhViens.Add(sinhVien);
                GhiDanhSachSinhVien(filePath, sinhViens);
                HienThiThongTinSinhVien(sinhVien);
                Ghivaorichbox(sinhVien);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                currentIndex++;
            }
            else
            {
                
                s = s - 1;
            }
            textBox15.Text=currentIndex.ToString();
        }
        private void Ghivaorichbox(SinhVien sinhVien)
        {
            richTextBox1.Text += "Họ và tên: " + sinhVien.HoTen + "\n";
            richTextBox1.Text += "MSSV: " + sinhVien.MSSV.ToString() + "\n";
            richTextBox1.Text += "Điện thoại: " + sinhVien.DienThoai + "\n";
            richTextBox1.Text += "Điểm môn 1: " + sinhVien.DiemMon1.ToString() + "\n";
            richTextBox1.Text += "Điểm môn 2: " + sinhVien.DiemMon2.ToString() + "\n";
            richTextBox1.Text += "Điểm môn 3: " + sinhVien.DiemMon3.ToString() + "\n";
            richTextBox1.Text += "Điểm trung bình: " + sinhVien.DiemTrungBinh.ToString() + "\n" + "\n";
        }
        private void HienThiThongTinSinhVien(SinhVien sinhVien)
        {
            textBox8.Text = sinhVien.HoTen;
            textBox9.Text = sinhVien.MSSV.ToString();
            textBox10.Text = sinhVien.DienThoai;
            textBox11.Text = sinhVien.DiemMon1.ToString();
            textBox12.Text = sinhVien.DiemMon2.ToString();
            textBox13.Text = sinhVien.DiemMon3.ToString();
            textBox14.Text = sinhVien.DiemTrungBinh.ToString();

        }
        
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (currentIndex > 1)
            {
                currentIndex--;
                HienThiThongTinSinhVien(sinhViens[currentIndex-1]);
                
            }
            textBox15.Text = currentIndex.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentIndex < sinhViens.Count)
            {
                currentIndex++;
                HienThiThongTinSinhVien(sinhViens[currentIndex-1]);
                
            }
            textBox15.Text = currentIndex.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Chọn file input để ghi dữ liệu vào";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(ofd.FileName))
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach(string line in richTextBox1.Lines)
                        {
                            if(!line.Contains("Điểm trung bình: "))
                            {
                                sb.Append(line);
                                sb.Append("\n");
                            }
                        }
                        string data= sb.ToString();
                        sw.WriteLine(data);
                    }

                }
            }catch(Exception ex)
            {
                MessageBox.Show("Eror: ", ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Chọn file output để ghi dữ liệu vào";
                if(ofd.ShowDialog()==DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(ofd.FileName))
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach(string line in richTextBox1.Lines)
                        {
                            sb.Append(line);
                            sb.Append("\n");
                        }
                        string data=sb.ToString();
                        sw.WriteLine(data);
                    }
                }
                
            }catch(Exception ex)
            {
                MessageBox.Show("Error: ", ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
