namespace FileExplorer
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeView_list = new System.Windows.Forms.TreeView();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.button_open = new System.Windows.Forms.Button();
            this.listView_show = new System.Windows.Forms.ListView();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.button_back = new System.Windows.Forms.Button();
            this.richTextBox_txtShow = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_copy = new System.Windows.Forms.Button();
            this.button_cut = new System.Windows.Forms.Button();
            this.button_parse = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_go = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView_list
            // 
            this.treeView_list.Location = new System.Drawing.Point(12, 68);
            this.treeView_list.Name = "treeView_list";
            this.treeView_list.Size = new System.Drawing.Size(232, 626);
            this.treeView_list.TabIndex = 0;
            this.treeView_list.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_list_AfterSelect);
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(41, 12);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(753, 21);
            this.textBox_path.TabIndex = 1;
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(769, 38);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(75, 23);
            this.button_open.TabIndex = 2;
            this.button_open.Text = "打开";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // listView_show
            // 
            this.listView_show.Location = new System.Drawing.Point(250, 68);
            this.listView_show.Name = "listView_show";
            this.listView_show.Size = new System.Drawing.Size(622, 363);
            this.listView_show.TabIndex = 3;
            this.listView_show.UseCompatibleStateImageBehavior = false;
            this.listView_show.View = System.Windows.Forms.View.List;
            this.listView_show.SelectedIndexChanged += new System.EventHandler(this.listView_show_SelectedIndexChanged_1);
            // 
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(12, 39);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(75, 23);
            this.button_back.TabIndex = 4;
            this.button_back.Text = "后退";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // richTextBox_txtShow
            // 
            this.richTextBox_txtShow.Location = new System.Drawing.Point(250, 437);
            this.richTextBox_txtShow.Name = "richTextBox_txtShow";
            this.richTextBox_txtShow.Size = new System.Drawing.Size(622, 257);
            this.richTextBox_txtShow.TabIndex = 5;
            this.richTextBox_txtShow.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(398, 437);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(324, 257);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // button_copy
            // 
            this.button_copy.Location = new System.Drawing.Point(148, 39);
            this.button_copy.Name = "button_copy";
            this.button_copy.Size = new System.Drawing.Size(75, 23);
            this.button_copy.TabIndex = 7;
            this.button_copy.Text = "复制";
            this.button_copy.UseVisualStyleBackColor = true;
            this.button_copy.Click += new System.EventHandler(this.button_copy_Click);
            // 
            // button_cut
            // 
            this.button_cut.Location = new System.Drawing.Point(292, 40);
            this.button_cut.Name = "button_cut";
            this.button_cut.Size = new System.Drawing.Size(75, 23);
            this.button_cut.TabIndex = 8;
            this.button_cut.Text = "剪切";
            this.button_cut.UseVisualStyleBackColor = true;
            this.button_cut.Click += new System.EventHandler(this.button_cut_Click);
            // 
            // button_parse
            // 
            this.button_parse.Enabled = false;
            this.button_parse.Location = new System.Drawing.Point(448, 39);
            this.button_parse.Name = "button_parse";
            this.button_parse.Size = new System.Drawing.Size(75, 23);
            this.button_parse.TabIndex = 9;
            this.button_parse.Text = "粘贴";
            this.button_parse.UseVisualStyleBackColor = true;
            this.button_parse.Click += new System.EventHandler(this.button_parse_Click);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(619, 38);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 10;
            this.button_delete.Text = "删除";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 694);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(887, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 17);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.StatuUpdate);
            // 
            // button_go
            // 
            this.button_go.Location = new System.Drawing.Point(801, 12);
            this.button_go.Name = "button_go";
            this.button_go.Size = new System.Drawing.Size(75, 23);
            this.button_go.TabIndex = 12;
            this.button_go.Text = "转到";
            this.button_go.UseVisualStyleBackColor = true;
            this.button_go.Click += new System.EventHandler(this.button_go_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.button_go;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(887, 716);
            this.Controls.Add(this.button_go);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_parse);
            this.Controls.Add(this.button_cut);
            this.Controls.Add(this.button_copy);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.richTextBox_txtShow);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.listView_show);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.treeView_list);
            this.Name = "Form1";
            this.Text = "资源管理器";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_list;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.ListView listView_show;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.RichTextBox richTextBox_txtShow;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_copy;
        private System.Windows.Forms.Button button_cut;
        private System.Windows.Forms.Button button_parse;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_go;
    }
}

