using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 定义初始的全局变量
        /// </summary>
        string explorerPath = "";
        string treeViewPath = "";
        /// <summary>
        /// 点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_open_Click(object sender, EventArgs e)
        {
           
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = folderBrowserDialog.SelectedPath;
                    explorerPath = path;
                    treeViewPath = path;
                    this.textBox_path.Text = path;
                    this.treeView_list.Nodes.Clear();
                    getExplorerView(null, path);
                }
         
          
        }
        /// <summary>
        /// 单层遍历，仅显示当前目录下的文件夹和文件
        /// </summary>
        /// <param name="path"></param>
        private void getFolderView(string path)
        {
            explorerPath = path;
            textBox_path.Text = explorerPath;
            try
            {
                this.listView_show.Items.Clear();
                DirectoryInfo TheFolder = new DirectoryInfo(path);
                //遍历文件夹
                foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
                {
                    this.listView_show.Items.Add("【" + NextFolder.Name + "】");

                }
                //遍历文件
                foreach (FileInfo NextFile in TheFolder.GetFiles())
                    this.listView_show.Items.Add(NextFile.Name); //再添加文件大小显示
            }
            catch(Exception)
            {

            }
           
        }       
        /**
         * 遍历方案： -- 深度优先遍历
         * 1.获取当前目录下的所有文件夹
         * 2.将第一个目录添加到treeView节点，并返回该节点的 TreeNode对象 
         * 3.递归将返回到treeNode对象传递进去，还有子级目录的文件夹名称
         * 4.循环
         * 5.深度结束条件：子级目录为空 
         * 问题，第一层根节点怎么传值？ 解决 传一个 null
         */ 

        /// <summary>
        /// 遍历函数
        /// </summary>
        /// <param name="path"></param>        
        private void getExplorerView(TreeNode node,string path)
        {
            try
            {
                TreeNode newnode = null;
                DirectoryInfo TheFolder = new DirectoryInfo(path);
                //遍历文件夹
                foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
                {
                    newnode = addTreeViewLevelNode(node, NextFolder.Name); //添加一个节点
                    getExplorerView(newnode, NextFolder.FullName);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("路径不存在");
            }

           
        }

        /// <summary>
        /// 目录遍历函数
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private TreeNode addTreeViewLevelNode(TreeNode node, string name)
        {
            TreeNode levelNode = new TreeNode();
            levelNode.Text = name;
            if (node == null)
            {
                treeView_list.Nodes.Add(levelNode);
            }
            else
            {              
                levelNode.Text = name;
                node.Nodes.Add(levelNode);
            }
            return levelNode;
        }
        /// <summary>
        /// treeView节点点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>          
        private void treeView_list_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string newPath = "";
            TreeNode node = null;                   
            try
            {
                node = e.Node.Parent;
                newPath = e.Node.Text;   
                while (true)
                {
                    newPath = newPath.Insert(0, node.Text + "\\"); //node.Text+"\\"                 
                    node = node.Parent;        
                }                
            }
            catch (NullReferenceException)
            {
           
            }
            if (!newPath.Equals(""))
            {
                explorerPath = newPath.Insert(0, treeViewPath + "\\");                            
                getFolderView(explorerPath);//遍历该层文件 
            }           
        }
        /// <summary>
        /// 处理listView中目录点击展开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
      
        private void listView_show_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                string filename = this.listView_show.SelectedItems[0].SubItems[0].Text;
                if (filename.StartsWith("【")) //目录处理方式
                {
                    filename = filename.Replace("【", "");
                    filename = filename.Replace("】", "");
                    string newPath = explorerPath + "\\" + filename;
                    getFolderView(newPath);//遍历该层文件                    
                }
                else //文件处理方式
                {                 
                    string newPath = explorerPath + "\\" + filename;    
                    //显示文件大小
                    int size = getFileSize(newPath);
                    if(size > 1024*1024)
                    {
                        toolStripStatusLabel3.Text = ((float)size / (1024 * 1024)).ToString("F1") +"GB";
                    }
                    else if (size>1024)
                    {
                        toolStripStatusLabel3.Text = ((float)size / 1024).ToString("F1") + "MB";
                    }
                    else
                    {
                        toolStripStatusLabel3.Text = size + "KB";
                         
                    }
                    OpenFile(newPath); 
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                //MessageBox.Show(ex.ToString());
            }          
           
        }
        /// <summary>
        /// 后退按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_back_Click(object sender, EventArgs e)
        {
            try
            {
                string newPath = explorerPath.Substring(0, explorerPath.LastIndexOf("\\"));
                getFolderView(newPath);
            }catch(ArgumentOutOfRangeException)
            {
            }           
        }
        /// <summary>
        /// 打开文件，仅支持文本文件，而且文件大小小于1MB
        /// </summary>
        /// <param name="path"></param>
        private void OpenFile(string path)
        {            
            if(getFileSize(path)<1000 && getFileType(path)) //如果文件小于1000KB，并且后缀为文本文件类型
            {                
                Read_line(path);
            }
            else if (getFileSize(path) < 5000 && getPicFileType(path))
            {
                openPic(path);
            }
        }
        /// <summary>
        /// 读取文本文件 - 自动换行
        /// </summary>
        /// <param name="path"></param>
        public void Read_line(string path)
        {
            this.richTextBox_txtShow.Visible = true;
            this.pictureBox1.Visible = false;
            this.richTextBox_txtShow.Clear();
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                this.richTextBox_txtShow.Text += line.ToString() + "\n";
            }
            sr.Close();
        }
        /// <summary>
        /// 打开一幅图像，前提是先将之前的文本控件隐藏，然后显示图片控件
        /// </summary>
        /// <param name="path"></param>
        private void openPic(string path)
        {
            this.richTextBox_txtShow.Visible = false;
            this.pictureBox1.Visible = true;           
            this.pictureBox1.ImageLocation = path;
        }
        /// <summary>
        /// 获取文件的大小
        /// </summary>
        /// <param name="path"></param>
        private int getFileSize(string path)
        {
            try
            {
                FileInfo fi = new FileInfo(path); //返回的是字节大小
                float x = ((float)fi.Length / 1024);
                int result = (int)(x + 1);
                return result;
            }
            catch (FileNotFoundException)
            {
                return 0;
            }
            
        }
        /// <summary>
        /// 获取文件类型是否是文本类型，主要是判断文件后缀。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool getFileType(string path)
        {
           
            string fileType = path.Substring(path.LastIndexOf(".")+1, path.Length - path.LastIndexOf(".") -1);
            string[] type = { "txt", "xml", "ini", "conf", "java", "cs", "sql", "html", "js", "css", "c", "h", "cpp","py" };

            for (int i = 0; i < type.Length;i++ )
            {
                if (fileType.Equals(type[i]))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 获取文件类型是否为图片，主要是根据文件后缀判断
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool getPicFileType(string path)
        {
            string fileType = path.Substring(path.LastIndexOf(".") + 1, path.Length - path.LastIndexOf(".") - 1);
            string[] type = { "jpg", "jpeg", "png", "bmp", "ico", "gif" };
            for (int i = 0; i < type.Length; i++)
            {
                if (fileType.Equals(type[i]))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 定时器-状态栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatuUpdate(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();//时间
            toolStripStatusLabel2.Text = "共"+this.listView_show.Items.Count+"个项目"; //文件数          
        }
        /// <summary>
        /// 转到
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_go_Click(object sender, EventArgs e)
        {
            string path = this.textBox_path.Text;
            explorerPath = path;
            treeViewPath = path;            
            this.treeView_list.Nodes.Clear();
            getExplorerView(null, path);
        }
        /// <summary>
        /// 文件删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = this.listView_show.SelectedItems[0].SubItems[0].Text;
                string newPath = explorerPath + "\\" + filename;
                if (!filename.Equals(""))
                {
                    DialogResult r1 = MessageBox.Show("是否永久删除该文件？", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (r1.ToString() == "Yes")
                    {
                        //删除文件                   
                        File.Delete(newPath);
                        getFolderView(explorerPath);
                    }

                    else if (r1.ToString().Equals("No"))
                    {
                        return;
                    }
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("暂时不允许删除目录");
            }
            
        }
        /// <summary>
        /// 拷贝按钮点击事件,目前仅针对文件，文件夹不可以
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        string copy_path = "";
        string copy_name = "";
        private void button_copy_Click(object sender, EventArgs e)
        {
            this.button_parse.Enabled = true;
            copy_name = this.listView_show.SelectedItems[0].SubItems[0].Text;
            copy_path = explorerPath + "\\" + copy_name;
        }
        /// <summary>
        /// 剪切按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        string cut_path = "";
        string cut_name = "";
        private void button_cut_Click(object sender, EventArgs e)
        {
            this.button_parse.Enabled = true;
            cut_name = this.listView_show.SelectedItems[0].SubItems[0].Text;
            cut_path = explorerPath + "\\" + cut_name;
        }
        /// <summary>
        /// 粘贴按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        string parse_path = "";
        private void button_parse_Click(object sender, EventArgs e)
        {
            try
            {
                parse_path = explorerPath;
                if (!copy_path.Equals(""))
                {
                    File.Copy(copy_path, parse_path + "\\" + copy_name);
                    getFolderView(parse_path);
                    copy_path = "";
                }

                else if (!cut_path.Equals(""))
                {
                    File.Move(cut_path, parse_path + "\\" + cut_name);
                    getFolderView(parse_path);
                    cut_path = "";
                }
            }catch(Exception)
            {
                MessageBox.Show("目前支持对文件操作");
            }
            
           
        }      

    }
}
