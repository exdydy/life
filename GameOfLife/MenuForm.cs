using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class MenuForm : Form
    {
        GameForm currentgame;
        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Application.Exit();
                    break;
                case Keys.Enter:
                    ButtonOk_Click(sender, e);
                    break;
            }
        }

        private void TextBoxWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void TextBoxHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            currentgame = new GameForm(TextBoxWidth.Text == "" ? 10 : Convert.ToInt32(TextBoxWidth.Text),
                TextBoxHeight.Text == "" ? 10 :Convert.ToInt32(TextBoxHeight.Text));
            currentgame.Show();
            Hide();
        }

        private void ButtonAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("v1.00\n\nAutors:\n\n Sidorov Timofei\n\n Shvetsova Viktoria\n\n\n      TUSUR 2017");
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
