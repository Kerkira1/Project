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
    public partial class LevelForm : Form
    {
        private static LevelForm _instance;
        public static LevelForm Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new LevelForm();
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
        public LevelForm()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            First_MazeForm.Instance.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Second_MazeForm.Instance.Show();
        }
    }
}
