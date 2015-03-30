using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AccountabilityNotePad
{
    public partial class aaafrm : Form
    {
        public aaafrm()
        {
            InitializeComponent();
        }

        private void aaafrm_Load(object sender, EventArgs e)
        {
            editor1.TextPreviewKeyDownEvent +=new EventHandler<PreviewKeyDownEventArgs>(editor1_TextPreviewKeyDownEvent);
            editor1.ToolStripItemClickedEvent +=new EventHandler<ToolStripItemClickedEventArgs>(editor1_ToolStripItemClickedEvent);
        }

        void editor1_ToolStripItemClickedEvent(object sender, ToolStripItemClickedEventArgs e)
        {
            MessageBox.Show(e.ClickedItem.Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int StrtIndx = editor1.DocumentText.IndexOf("<BODY>", StringComparison.OrdinalIgnoreCase) + 6;
            int EndIndx = editor1.DocumentText.IndexOf("</BODY>", StringComparison.OrdinalIgnoreCase) - StrtIndx;
            label1.Text = editor1.DocumentText.Remove(0, StrtIndx).Remove(EndIndx);
        }

        private void editor1_TextPreviewKeyDownEvent(object sender, PreviewKeyDownEventArgs e)
        {
            //MessageBox.Show(editor1.BodyText);
            editor1.Validate();
        }

        
        private void editor1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            editor1.BodyHtml = "ll";
        }

        private void editor1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void editor1_ValidatedEvent(object sender, EventArgs e)
        {
            MessageBox.Show(editor1.BodyText + "!");
        }
    }
}