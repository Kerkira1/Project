using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class TagGameForm : Form
    {
        private static TagGameForm _instance;
        public static TagGameForm Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new TagGameForm();
                }
                else
                {
                    //Если пользователь пытается повторно открыть форму
                    MessageBox.Show("Окно уже открыто.",
                        "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return _instance;
            }
        }
        List<Button> buttons = new List<Button>();
        public TagGameForm()
        {
            InitializeComponent();
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
            buttons.Add(button10);
            buttons.Add(button11);
            buttons.Add(button12);
            buttons.Add(button13);
            buttons.Add(button14);
            buttons.Add(button15);
            buttons.Add(button16);
            ShuffleButtons();
            panel1_Resize(null, null);
        }
        private void ShuffleButtons()
        {
            List<int> numbers = new List<int>();
            for (int i = 1; i <= 15; i++)
            {
                numbers.Add(i);
            }

            Random rand = new Random();
            for (int i = numbers.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                int temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }

            for (int i = 0; i < 15; i++)
            {
                buttons[i].Text = numbers[i].ToString();
                buttons[i].Visible = true;
            }


        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            for (int i = 0; i < 16; i++)
            {
                int x, y;
                y = i / 4;
                x = i - y * 4;
                buttons[i].Top = y * panel1.Height / 4;
                buttons[i].Left = x * panel1.Width / 4;
                buttons[i].Width = panel1.Width / 4;
                buttons[i].Height = panel1.Height / 4;
                buttons[i].Font = new Font("Arial", panel1.Height / 10, FontStyle.Bold);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int tag = Convert.ToInt32(btn.Tag);
            tag--;
            int y1 = tag / 4;
            int x1 = tag - y1 * 4;
            int ya, yb;
            int xr, xl;
            ya = y1 - 1;
            yb = y1 + 1;
            xl = x1 - 1;
            xr = x1 + 1;
            if (xr < 4)
            {
                int right = y1 * 4 + xr;
                if (!buttons[right].Visible)
                {
                    buttons[right].Visible = true;
                    buttons[tag].Visible = false;
                    buttons[right].Text = buttons[tag].Text;
                }

            }
            if (xl >= 0)
            {
                int left = y1 * 4 + xl;
                if (!buttons[left].Visible)
                {
                    buttons[left].Visible = true;
                    buttons[tag].Visible = false;
                    buttons[left].Text = buttons[tag].Text;
                }
            }
            if (ya >= 0)
            {
                int above = ya * 4 + x1;
                if (!buttons[above].Visible)
                {
                    buttons[above].Visible = true;
                    buttons[tag].Visible = false;
                    buttons[above].Text = buttons[tag].Text;
                }
            }
            if (yb < 4)
            {
                int below = yb * 4 + x1;
                if (!buttons[below].Visible)
                {
                    buttons[below].Visible = true;
                    buttons[tag].Visible = false;
                    buttons[below].Text = buttons[tag].Text;
                }
            }
        }
    }
}
