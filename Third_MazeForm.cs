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
    public partial class Third_MazeForm : Form
    {
        private static Third_MazeForm _instance;
        public static Third_MazeForm Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new Third_MazeForm();
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
        public Third_MazeForm()
        {
            InitializeComponent();
            StartCursorLocation();

        }
        private void StartCursorLocation()
        {
            Cursor.Position = PointToScreen(panel2.Location);
        }

        private void label106_MouseEnter(object sender, EventArgs e)
        {
            StartCursorLocation();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            MessageBox.Show("Поздравляем, вы прошли лабиринт!!", "Победа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
