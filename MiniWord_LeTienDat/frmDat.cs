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
using Microsoft.VisualBasic;
using System.Diagnostics;
using MiniWord_LeTienDat.Froms;
using MiniWord_LeTienDat.Forms;


namespace MiniWord_LeTienDat
{
    public partial class frmDat : Form
    {
        FileOperation fileOperation;
        EditOperation editOperation;
        Timer timer;
        FormFind formFind;
        FormReplace formReplace;
        public EditOperation EditOperation
        {
            get
            {
                return editOperation;
            }

            set
            {
                editOperation = value;
            }
        }


        public frmDat()
        {
            InitializeComponent();
            fonchu();
            fileOperation = new FileOperation();
            editOperation = new EditOperation();
            formFind = new FormFind(this);
            formFind.Editor = rtxbContent;
            fileOperation.InitializeNewFile();
            this.Text = fileOperation.Filename;
            timer = new Timer();
            timer.Tick += Mytimer_Tick;
            timer.Interval = 500;
            rtxbContent.HideSelection = false;
        }

        private void Mytimer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            editOperation.Add_UndoRedo(rtxbContent.Text);
            UpdateView();
        }

        //OpenFileDialog open;
        //SaveFileDialog save;


        void BoldText(RichTextBox rtxb)
        {
            Font newFont = new Font(rtxb.SelectionFont.FontFamily.Name, 
                rtxb.SelectionFont.Size, FontStyle.Bold);
            rtxb.SelectionFont = newFont;
        }

        void ItalicText(RichTextBox rtxb)
        {
            Font newFont = new Font(rtxb.SelectionFont.FontFamily.Name,
                rtxb.SelectionFont.Size, FontStyle.Italic);
            rtxb.SelectionFont = newFont;
        }

        void UnderlineText(RichTextBox rtxb)
        {
            Font newFont = new Font(rtxb.SelectionFont.FontFamily.Name,
                rtxb.SelectionFont.Size, FontStyle.Underline);
            rtxb.SelectionFont = newFont;
        }
        private void btnBold_Click(object sender, EventArgs e)
        {
            BoldText(rtxbContent);
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            ItalicText(rtxbContent);
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            UnderlineText(rtxbContent);
        }

        private void UpdateView()
        {
            this.Text = !fileOperation.IsFileSaved ? fileOperation.Filename + "*" : fileOperation.Filename;
            btnUndo.Enabled = editOperation.CanUndo() ? true : false;
            redoEditMenu.Enabled = editOperation.CanRedo() ? true : false;
            findnextEditMenu.Enabled = findEditMenu.Enabled;
        }

        private void OpenProgram()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text(*.rtf)|*.rtf";
            openFile.InitialDirectory = "D:";
            openFile.Title = "Open File";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                rtxbContent.TextChanged -= rtxbContent_TextChanged;
                rtxbContent.Text = fileOperation.OpenFile(openFile.FileName);
                rtxbContent.TextChanged += rtxbContent_TextChanged;
                UpdateView();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenProgram();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenProgram();
        }

        private void SaveFile()
        {
            SaveFileDialog fileSave = new SaveFileDialog();
            fileSave.Filter = "Text(*.rtf)|*.rtf";
            if (fileSave.ShowDialog() == DialogResult.OK)
            {
                fileOperation.SaveFile(fileSave.FileName, rtxbContent.Lines);
                UpdateView();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!fileOperation.IsFileSaved)
            {
                if (!this.Text.Contains("Untitled.rtf"))
                {
                    fileOperation.SaveFile(fileOperation.FileLocation, rtxbContent.Lines);
                    UpdateView();
                }
                else
                {
                    SaveFile();
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (!fileOperation.IsFileSaved)
            {
                if (!this.Text.Contains("Untitled.rtf"))
                {
                    fileOperation.SaveFile(fileOperation.FileLocation, rtxbContent.Lines);
                    UpdateView();
                }
                else
                {
                    SaveFile();
                }
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void exitFileMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rtxbContent_TextChanged(object sender, EventArgs e)
        {
            fileOperation.IsFileSaved = false;
            if (editOperation.RtxbContentTextChangeRequired)
            {
                timer.Start();
            }
            else
            {
                editOperation.RtxbContentTextChangeRequired = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void NewFile()
        {
            if (fileOperation.IsFileSaved)
            {
                rtxbContent.Text = "";
                fileOperation.InitializeNewFile();
                UpdateView();
            }
            else
            {
                DialogResult result = MessageBox.Show("Do you need save changes to " + fileOperation.Filename, "Word", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (fileOperation.Filename.Contains("Untitled"))
                    {
                        SaveFileDialog newFileSave = new SaveFileDialog();
                        newFileSave.Filter = "Text(*.rtf)|*.rtf";
                        if (newFileSave.ShowDialog() == DialogResult.OK)
                        {
                            fileOperation.SaveFile(newFileSave.FileName, rtxbContent.Lines);
                            UpdateView();
                        }
                    }
                    else
                    {
                        fileOperation.SaveFile(fileOperation.FileLocation, rtxbContent.Lines);
                        UpdateView();
                    }

                }
                else if (result == DialogResult.No)
                {
                    rtxbContent.Text = "";
                    fileOperation.InitializeNewFile();
                    UpdateView();
                }
            }
        }

        private void newFileMenu_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void rtxbContent_SelectionChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            rtxbContent.Text = editOperation.UndoClicked();
            UpdateView();
        }

        private void undoEditMenu_Click(object sender, EventArgs e)
        {
            rtxbContent.Text = editOperation.UndoClicked();
            UpdateView();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            rtxbContent.Text = editOperation.RedoClicked();
            UpdateView();
        }

        private void redoEditMenu_Click(object sender, EventArgs e)
        {
            rtxbContent.Text = editOperation.RedoClicked();
            UpdateView();
        }

        private void cutEditMenu_Click(object sender, EventArgs e)
        {
            rtxbContent.Cut();
            pasteEditMenu.Enabled = true;
        }

        private void copyEditMenu_Click(object sender, EventArgs e)
        {
            rtxbContent.Copy();
            pasteEditMenu.Enabled = true;
        }

        private void pasteEditMenu_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
                rtxbContent.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxbContent.Text = rtxbContent.Text.Remove(rtxbContent.SelectionStart, rtxbContent.SelectionLength);
        }

        private void findEditMenu_Click(object sender, EventArgs e)
        {
            if (formFind == null)
            {
                formFind = new FormFind(this);
                formFind.Editor = rtxbContent;
            }
            formFind.Show();
        }

        private void findnextEditMenu_Click(object sender, EventArgs e)
        {
            formFind.UpdateSearchQuery();
            if (formFind.Qry.SearchString.Length == 0)
            {
                formFind.Show();
            }
            else
            {
                FindNextResult result = editOperation.FindNext(formFind.Qry);
                if (result.SearchStatus)
                    rtxbContent.Select(result.SelectionStart, formFind.Qry.SearchString.Length);
            }
        }
        private void fonchu()
        {
            foreach (FontFamily f in FontFamily.Families)
            {
                cbxSelectFont.Items.Add(f.Name);
            }
        }
        String nameFont = "Times New Roman";
        float fontSize = 14;

        private void cbxSelectFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            nameFont = cbxSelectFont.SelectedItem.ToString();
            rtxbContent.SelectionFont = new Font(nameFont, fontSize);
        }

        private void cbxNumberFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            fontSize = float.Parse(cbxNumberFont.SelectedItem.ToString());
            rtxbContent.SelectionFont = new Font(nameFont, fontSize);
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog textcolor = new ColorDialog();
            textcolor.ShowDialog();
            rtxbContent.SelectionColor = textcolor.Color;
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            ColorDialog textcolor = new ColorDialog();
            textcolor.ShowDialog();
            rtxbContent.SelectionBackColor = textcolor.Color;
        }

        private void frmDat_Load(object sender, EventArgs e)
        {

        }

        private void replaceEditMenu_Click(object sender, EventArgs e)
        {
            if (formReplace == null)
            {
                formReplace = new FormReplace();
                formReplace.Editor = rtxbContent;
                formReplace.editOperation = editOperation;
            }
            formReplace.Show();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            //Process.Start("https://www.facebook.com/dat.oiiii");
            Process.Start("https://www.google.com/search?source=hp&ei=5y7vWtHkJsrxvgT34reADg&q=notepad+using+c%23&oq=notepad+using+c%23&gs_l=psy-ab.3..0j0i22i30k1l9.100016.102766.0.103103.18.14.0.0.0.0.277.2296.0j5j6.11.0....0...1.1.64.psy-ab..7.11.2293.0..35i39k1j0i131k1j0i3k1.0.vqO-K4vUFLU");

        }
        int a = 899;
        int b = 456;

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            a = a - 100;
            b = b - 60;
            rtxbContent.ZoomFactor = rtxbContent.ZoomFactor / 1.2f;
            rtxbContent.Size = new System.Drawing.Size(a, b);
            rtxbContent.Top = rtxbContent.Top + 30;
            rtxbContent.Left = rtxbContent.Left + 50;
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            a = a + 100;
            b = b + 60;
            rtxbContent.ZoomFactor = rtxbContent.ZoomFactor * 1.2f;
            rtxbContent.Size = new System.Drawing.Size(a, b);
            rtxbContent.Top = rtxbContent.Top + 30;
            rtxbContent.Left = rtxbContent.Left + 50;
        }

        private void UpdateStatus()
        {
            int pos = rtxbContent.SelectionStart;
            int line = rtxbContent.GetLineFromCharIndex(pos) + 1;
            int col = pos - rtxbContent.GetFirstCharIndexOfCurrentLine() + 1;

            status.Text = "Ln " + line + ", Col " + col;
        }

        private void btnEmoji_Click(object sender, EventArgs e)
        {
            listEmoji.Visible = true;
        }
        int id = 0;
        private void listEmoji_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listEmoji.FocusedItem == null) return;
            id = listEmoji.SelectedIndices[0];
            Clipboard.SetImage(imageList1.Images[id]);
            rtxbContent.Paste();
            listEmoji.Visible = false;
        }

        private void btnImages_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            String path = file.FileName;
            Clipboard.SetImage(Image.FromFile(path));
            rtxbContent.Paste();
        }
    }
}
