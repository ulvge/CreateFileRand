namespace CreateFileRand {
    partial class CreateFileRand {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.tb_imageSavePath = new System.Windows.Forms.TextBox();
            this.tb_selectImagePath = new System.Windows.Forms.Button();
            this.bt_switch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_intval = new System.Windows.Forms.TextBox();
            this.bt_intval = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(28, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "文件保存目录";
            // 
            // tb_imageSavePath
            // 
            this.tb_imageSavePath.Location = new System.Drawing.Point(158, 145);
            this.tb_imageSavePath.Name = "tb_imageSavePath";
            this.tb_imageSavePath.Size = new System.Drawing.Size(199, 21);
            this.tb_imageSavePath.TabIndex = 24;
            // 
            // tb_selectImagePath
            // 
            this.tb_selectImagePath.Location = new System.Drawing.Point(374, 138);
            this.tb_selectImagePath.Name = "tb_selectImagePath";
            this.tb_selectImagePath.Size = new System.Drawing.Size(64, 32);
            this.tb_selectImagePath.TabIndex = 22;
            this.tb_selectImagePath.Text = "选择";
            this.tb_selectImagePath.UseVisualStyleBackColor = true;
            this.tb_selectImagePath.Click += new System.EventHandler(this.tb_selectImagePath_Click);
            // 
            // bt_switch
            // 
            this.bt_switch.Location = new System.Drawing.Point(193, 238);
            this.bt_switch.Name = "bt_switch";
            this.bt_switch.Size = new System.Drawing.Size(64, 32);
            this.bt_switch.TabIndex = 22;
            this.bt_switch.Text = "启动";
            this.bt_switch.UseVisualStyleBackColor = true;
            this.bt_switch.Click += new System.EventHandler(this.bt_switch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(28, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "写文件间隔(ms)";
            // 
            // tb_intval
            // 
            this.tb_intval.Location = new System.Drawing.Point(158, 60);
            this.tb_intval.Name = "tb_intval";
            this.tb_intval.Size = new System.Drawing.Size(99, 21);
            this.tb_intval.TabIndex = 24;
            // 
            // bt_intval
            // 
            this.bt_intval.Location = new System.Drawing.Point(374, 53);
            this.bt_intval.Name = "bt_intval";
            this.bt_intval.Size = new System.Drawing.Size(64, 32);
            this.bt_intval.TabIndex = 22;
            this.bt_intval.Text = "确认";
            this.bt_intval.UseVisualStyleBackColor = true;
            this.bt_intval.Click += new System.EventHandler(this.bt_intval_Click);
            // 
            // CreateFileRand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 315);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_intval);
            this.Controls.Add(this.tb_imageSavePath);
            this.Controls.Add(this.bt_switch);
            this.Controls.Add(this.bt_intval);
            this.Controls.Add(this.tb_selectImagePath);
            this.MaximizeBox = false;
            this.Name = "CreateFileRand";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "随机生成文件";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CreateFileRand_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_imageSavePath;
        private System.Windows.Forms.Button tb_selectImagePath;
        private System.Windows.Forms.Button bt_switch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_intval;
        private System.Windows.Forms.Button bt_intval;
    }
}