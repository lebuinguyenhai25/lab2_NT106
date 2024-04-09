using System;
using System.IO;
using System.Windows.Forms;
namespace lab2_cau7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateTreeView();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Lấy đường dẫn của node được chọn
            string selectedPath = e.Node.Tag.ToString();

            // Kiểm tra xem node có phải là file hay không
            if (File.Exists(selectedPath))
            {
                // Nếu là file, kiểm tra loại file
                string extension = Path.GetExtension(selectedPath);

                // Kiểm tra loại file
                if (extension != null)
                {
                    extension = extension.ToLower();

                    // Kiểm tra nếu là file hình ảnh
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
                    {
                        // Nếu là file hình ảnh, hiển thị hình ảnh trong RichTextBox
                        try
                        {
                            Image img = Image.FromFile(selectedPath);
                            Clipboard.SetImage(img);
                            richTextBox1.Paste();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        // Nếu là file văn bản, hiển thị nội dung của file
                        try
                        {
                            using (StreamReader reader = new StreamReader(selectedPath))
                            {
                                string fileContent = reader.ReadToEnd();
                                richTextBox1.Text = fileContent;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }
        private void PopulateTreeView()
        {
            TreeNode rootNode;

            // Lấy danh sách các ổ đĩa trên máy tính
            foreach (string drive in Directory.GetLogicalDrives())
            {
                rootNode = new TreeNode(drive);
                treeView1.Nodes.Add(rootNode);
                rootNode.Tag = drive;

                // Thêm thư mục con cho mỗi ổ đĩa
                try
                {
                    foreach (string directory in Directory.GetDirectories(drive))
                    {
                        DirectoryInfo dir = new DirectoryInfo(directory);
                        TreeNode node = new TreeNode(dir.Name);
                        rootNode.Nodes.Add(node);
                        node.Tag = directory;

                        // Thêm tất cả các file con cho mỗi thư mục
                        foreach (string file in Directory.GetFiles(directory))
                        {
                            FileInfo fileInfo = new FileInfo(file);
                            TreeNode fileNode = new TreeNode(fileInfo.Name);
                            node.Nodes.Add(fileNode);
                            fileNode.Tag = file;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
