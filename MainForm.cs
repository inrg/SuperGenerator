using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
    
namespace SuperGeneratorX {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();

            cbxType.Items.Add("GUID");
            cbxType.DataSource = ConfigurationManager.AppSettings.AllKeys;
        }

        string _generatorString = string.Empty;
        private void Generator() {
            _generatorString = SuperGenerator.From(txtPattern.Text.Trim()).Make();
            txtContent.Text = cbUseCap.Checked ? _generatorString.ToUpper() : _generatorString;
            Clipboard.SetDataObject(txtContent.Text);

            lblMsg.Text = @"已成功复制到剪切板，可以直接使用CTRL+V粘贴到其它地方。";
        }

        private void BtnGenerator_Click(object sender, EventArgs e) {
            Generator();
        }

        private void TxtContentOnMouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                
                notifyIcon1.ShowBalloonTip(1000, "SuperGenerator", "内容已经复制到系统剪切板", ToolTipIcon.Info);
            }
        }

        private void TxtPattern_Enter(object sender, EventArgs e) {
            txtPattern.BackColor = Color.White;
        }

        private void TxtPattern_Leave(object sender, EventArgs e) {
            txtPattern.BackColor = SystemColors.Control;
        }

        private void CbxType_SelectedIndexChanged(object sender, EventArgs e) {
            txtPattern.Text = ConfigurationManager.AppSettings[(string)cbxType.SelectedItem];
            Generator();
        }

        private void CbUseCap_CheckStateChanged(object sender, EventArgs e) {
            txtContent.Text = cbUseCap.Checked ? _generatorString.ToUpper() : _generatorString;
        }
    }
}
