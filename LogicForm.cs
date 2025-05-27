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
    public partial class LogicForm : Form
    {
        private static LogicForm _instance;
        public static LogicForm Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new LogicForm();
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
        public LogicForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TagGameForm.Instance.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CodeForm.Instance.Show();
        }
    }
}
