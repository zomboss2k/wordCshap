using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniWord_LeTienDat;

namespace MiniWord_LeTienDat.Forms
{
    public partial class FormReplace : Form
    {
        FindNextSearch qry = new FindNextSearch();
        public RichTextBox Editor;
        public EditOperation editOperation;
        public FindNextSearch Qry
        {
            get
            {
                return qry;
            }

            set
            {
                qry = value;
            }
        }
        public FormReplace()
        {
            InitializeComponent();
        }

        private void FormReplace_Load(object sender, EventArgs e)
        {
            DisableButtons();
            rDown.Checked = true;
        }



        private void DisableButtons()
        {
            if (txtFind.Text.Length == 0)
            {
                btnFind.Enabled = btnReplace.Enabled = btnReplaceAll.Enabled = false;
            }
            else
            {
                btnFind.Enabled = btnReplace.Enabled = btnReplaceAll.Enabled = true;
            }
        }

        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            DisableButtons();
        }
        public void UpdateSearchQuery()
        {
            qry.SearchString = txtFind.Text;
            qry.Direction = rUp.Checked ? "UP" : "DOWN";
            qry.MatchCase = chkMatchCase.Checked;
            qry.Content = Editor.Text;
            qry.Position = Editor.SelectionStart;
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            UpdateSearchQuery();
            FindNextResult result = editOperation.FindNext(this.Qry);
            if (result.SearchStatus)
                this.Editor.Select(result.SelectionStart, txtFind.Text.Length);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (Editor.SelectionLength == 0)
                btnFind.PerformClick();
            else
                Editor.SelectedText = txtReplace.Text;
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            Editor.Text = Editor.Text.Replace(txtFind.Text, txtReplace.Text);
        }
    }
}
