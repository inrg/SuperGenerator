namespace SuperGeneratorX {
    partial class MainForm {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            this.components = new System.ComponentModel.Container();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtContent = new System.Windows.Forms.RichTextBox();
            this.txtPattern = new System.Windows.Forms.RichTextBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.btnGenerat = new System.Windows.Forms.Button();
            this.cbUseCap = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMsg});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 181);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(625, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblMsg
            // 
            this.lblMsg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(32, 17);
            this.lblMsg.Text = "就绪";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(625, 181);
            this.panel2.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.DimGray;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtContent);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtPattern);
            this.splitContainer1.Panel2.Controls.Add(this.panelRight);
            this.splitContainer1.Size = new System.Drawing.Size(625, 181);
            this.splitContainer1.SplitterDistance = 87;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtContent
            // 
            this.txtContent.BackColor = System.Drawing.SystemColors.Control;
            this.txtContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtContent.Location = new System.Drawing.Point(0, 0);
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.Size = new System.Drawing.Size(625, 87);
            this.txtContent.TabIndex = 2;
            this.txtContent.Text = "d51de547-1b9b-45f5-81c3-a88634294a51";
            // 
            // txtPattern
            // 
            this.txtPattern.BackColor = System.Drawing.SystemColors.Control;
            this.txtPattern.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPattern.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPattern.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPattern.Location = new System.Drawing.Point(0, 0);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.ReadOnly = true;
            this.txtPattern.Size = new System.Drawing.Size(478, 90);
            this.txtPattern.TabIndex = 3;
            this.txtPattern.Text = "[a-z0-9]{8}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{12}";
            this.txtPattern.Enter += new System.EventHandler(this.TxtPattern_Enter);
            this.txtPattern.Leave += new System.EventHandler(this.TxtPattern_Leave);
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.tableLayoutPanel1);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(478, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(147, 90);
            this.panelRight.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.cbxType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGenerat, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbUseCap, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(147, 90);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cbxType
            // 
            this.cbxType.BackColor = System.Drawing.SystemColors.Control;
            this.cbxType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Items.AddRange(new object[] {
            "Guid"});
            this.cbxType.Location = new System.Drawing.Point(3, 3);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(141, 20);
            this.cbxType.TabIndex = 2;
            this.cbxType.SelectedIndexChanged += new System.EventHandler(this.CbxType_SelectedIndexChanged);
            // 
            // btnGenerat
            // 
            this.btnGenerat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerat.Location = new System.Drawing.Point(3, 59);
            this.btnGenerat.Name = "btnGenerat";
            this.btnGenerat.Size = new System.Drawing.Size(141, 29);
            this.btnGenerat.TabIndex = 1;
            this.btnGenerat.Text = "生成";
            this.btnGenerat.UseVisualStyleBackColor = true;
            this.btnGenerat.Click += new System.EventHandler(this.BtnGenerator_Click);
            // 
            // cbUseCap
            // 
            this.cbUseCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbUseCap.Location = new System.Drawing.Point(3, 31);
            this.cbUseCap.Name = "cbUseCap";
            this.cbUseCap.Size = new System.Drawing.Size(141, 22);
            this.cbUseCap.TabIndex = 3;
            this.cbUseCap.Text = "使用大写";
            this.cbUseCap.UseVisualStyleBackColor = true;
            this.cbUseCap.CheckStateChanged += new System.EventHandler(this.CbUseCap_CheckStateChanged);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnGenerat;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(625, 203);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "SuperGeneratorX";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblMsg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.RichTextBox txtContent;
        public System.Windows.Forms.RichTextBox txtPattern;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnGenerat;
        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.CheckBox cbUseCap;
    }
}

