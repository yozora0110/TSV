using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace TSV資料檔讀取程式
{
    public partial class frmTSVFile : Form
    {// --- 以下貼在 public partial class frmTSVFile : Form { 裡面 ---

        WordCollection _WordList = new WordCollection(); // 宣告單字清單集合 
        frmAbout about = new frmAbout(); // 宣告關於視窗 

        public frmTSVFile()
        {
            InitializeComponent();
        }

        // 1. 表單載入預設文字 
        private void frmTSVFile_Load(object sender, EventArgs e)
        {
            tsslMessage.Text = "請開啟檔案";
        }

        // 2. 更新 ListView 的內容 
        private void UpdateListView()
        {
            lvwWord.BeginUpdate(); // 暫停重繪 
            lvwWord.Items.Clear(); // 清除 ListView 的所有項目 

            foreach (WordItem item in _WordList)
            {
                ListViewItem lvi = new ListViewItem(item.Word);
                lvi.SubItems.Add(item.Phonogram);
                lvi.SubItems.Add(item.SoundPath);
                lvi.SubItems.Add(item.Explain);
                lvwWord.Items.Add(lvi);
            }
            lvwWord.EndUpdate(); // 恢復重繪 
        }

        // 3. File -> Open (讀取檔案) 
        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "TSV files (*.tsv)|*.tsv|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.Title = "開啟檔案";
            ofd.InitialDirectory = Application.StartupPath;

            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                // 讀取檔案並且將每一行的資料放入字串陣列 (指定 UTF8 編碼)
                string[] lines = File.ReadAllLines(ofd.FileName, Encoding.UTF8);
                // 載入資料
                _WordList.LoadFromStringArray(lines);
                // 更新畫面
                UpdateListView();
                this.tsslMessage.Text = $"{_WordList.Count}單字已成功載入";
            }
        }

        // 4. File -> Exit (離開) 
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 5. Help -> About (關於) 
        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            about.ShowDialog(this);
        }

        // 6. 視窗關閉前的防呆確認 
        private void frmTSVFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("確定要離開嗎?", "離開", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                e.Cancel = true; // 取消關閉 
            }
        }
    }
}
