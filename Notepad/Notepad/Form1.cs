using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Notepad
{
    public partial class MainNotepadForm : Form
    {
        public MainNotepadForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();     //Either works just as well.
        }

        private void helToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("All rights reserved by Lord Moiz.\nContact: Lord_Moiz@gmail.com", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MainRichBox.Text = ""; //Alternative to below.
            MainRichBox.Clear();    //To Clear the text for a new file.
        }

        private void printPrToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void strikeThroughToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichBox.SelectionFont = new Font(MainRichBox.Font, FontStyle.Strikeout);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichBox.Undo();
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = true;
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichBox.Redo();
            redoToolStripMenuItem.Enabled = false;
            undoToolStripMenuItem.Enabled = true;
        }

        private void MainRichBox_TextChanged(object sender, EventArgs e)
        {
            if(MainRichBox.Text.Length>0)             
            {
                undoToolStripMenuItem.Enabled = true;  //if all enabled.
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                selectAllToolStripMenuItem.Enabled = true;
                boldToolStripMenuItem.Enabled = true;
                italicToolStripMenuItem.Enabled = true;
                normalTextToolStripMenuItem.Enabled = true;
                strikeThroughToolStripMenuItem.Enabled = true;
                underlineToolStripMenuItem.Enabled = true;
            }                                                               //That's some messy code .-.
            else
            {
                boldToolStripMenuItem.Enabled = false;
                italicToolStripMenuItem.Enabled = false;
                normalTextToolStripMenuItem.Enabled = false;
                strikeThroughToolStripMenuItem.Enabled = false;
                underlineToolStripMenuItem.Enabled = false;
                selectAllToolStripMenuItem.Enabled = false;  //else all disabled.
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                undoToolStripMenuItem.Enabled = false;
                redoToolStripMenuItem.Enabled = false;
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichBox.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichBox.SelectedText = "";   //Let the text equal to nothing, as in delete all text.
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichBox.SelectAll();
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichBox.Text = MainRichBox.Text += DateTime.Now;
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichBox.SelectionFont = new Font(MainRichBox.Font, FontStyle.Bold);
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichBox.SelectionFont = new Font(MainRichBox.Font, FontStyle.Italic);
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichBox.SelectionFont = new Font(MainRichBox.Font, FontStyle.Underline);
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = MainRichBox.SelectionFont;
            if (fd.ShowDialog() == DialogResult.OK)
                MainRichBox.SelectionFont = fd.Font;
        }

        private void normalTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichBox.SelectionFont = new Font(MainRichBox.Font, FontStyle.Regular);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
                MainRichBox.LoadFile(op.FileName, RichTextBoxStreamType.PlainText);
            this.Text = op.FileName;


        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Text Documents(*.txt)|*.txt|All Files(*.*)|*.*";
            if (sv.ShowDialog() == DialogResult.OK)
                MainRichBox.SaveFile(sv.FileName, RichTextBoxStreamType.PlainText);
            this.Text = sv.FileName;
        }

        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cr = new ColorDialog();
            if(cr.ShowDialog() == DialogResult.OK)
                MainRichBox.BackColor = cr.Color;
        }

        private void fontColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog col = new ColorDialog();
            col.ShowDialog();
            MainRichBox.SelectionColor = col.Color;
        }

        
        /*private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Maybe later.
        }*/
    }
}
