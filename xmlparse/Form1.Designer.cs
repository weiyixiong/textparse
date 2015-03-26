namespace xmlparse
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
            this.TB_parsed_text = new System.Windows.Forms.TextBox();
            this.btn_parse = new System.Windows.Forms.Button();
            this.choiceFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Filepath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TB_parsed_text
            // 
            this.TB_parsed_text.Location = new System.Drawing.Point(627, 35);
            this.TB_parsed_text.Multiline = true;
            this.TB_parsed_text.Name = "TB_parsed_text";
            this.TB_parsed_text.Size = new System.Drawing.Size(429, 376);
            this.TB_parsed_text.TabIndex = 1;
            // 
            // btn_parse
            // 
            this.btn_parse.Location = new System.Drawing.Point(468, 252);
            this.btn_parse.Name = "btn_parse";
            this.btn_parse.Size = new System.Drawing.Size(113, 44);
            this.btn_parse.TabIndex = 2;
            this.btn_parse.Text = "→ xml";
            this.btn_parse.UseVisualStyleBackColor = true;
            this.btn_parse.Click += new System.EventHandler(this.btn_parse_Click);
            // 
            // choiceFile
            // 
            this.choiceFile.Location = new System.Drawing.Point(468, 77);
            this.choiceFile.Name = "choiceFile";
            this.choiceFile.Size = new System.Drawing.Size(155, 59);
            this.choiceFile.TabIndex = 3;
            this.choiceFile.Text = "选择待转换文件";
            this.choiceFile.UseVisualStyleBackColor = true;
            this.choiceFile.Click += new System.EventHandler(this.choiceFile_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "文件位置：";
            // 
            // Filepath
            // 
            this.Filepath.Location = new System.Drawing.Point(116, 97);
            this.Filepath.Name = "Filepath";
            this.Filepath.Size = new System.Drawing.Size(346, 28);
            this.Filepath.TabIndex = 5;
            this.Filepath.Text = "C:\\123213.txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1122, 495);
            this.Controls.Add(this.Filepath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.choiceFile);
            this.Controls.Add(this.btn_parse);
            this.Controls.Add(this.TB_parsed_text);
            this.Name = "Form1";
            this.Text = "xmlparse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_parsed_text;
        private System.Windows.Forms.Button btn_parse;
        private System.Windows.Forms.Button choiceFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Filepath;
    }
}

