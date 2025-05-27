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
    public partial class CodeForm : Form

    {
        private Label[,] grid;
        private int rows = 5, cols = 5;
        private int currentRow = 0, currentCol = 0;
        private string answer;
        private List<string> wordList;


        private static CodeForm _instance;
        public static CodeForm Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new CodeForm();
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
        public CodeForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            LoadWords();
            GenerateLabels();
            StartNewGame();

            this.KeyPress += WordleForm_KeyPress;
            this.KeyDown += WordleForm_KeyDown;
        }

        private void LoadWords()
        {
            wordList = new List<string>
                {"ГРОЗА", "МЕЧТА",  "КРЫША", "ЗЕРНО", "ПТИЦА",  "ВЕТЕР",  "РУЧКА",  "ДВЕРЬ",  "СОКОЛ",  "БУКЕТ",  "ПЕСНЯ",  "ТУЧКА",
                 "ЛАСКА", "ОСЕНЬ", "СТАЛЬ", "ПЯТНО", "ШАПКА",  "ЯГОДА", "БЕЛКА", "КНИГА", "ТАБАК", "ГЛИНА", "БЕРЕГ", "ФАКЕЛ",
                 "ПЛИТА", "МЕТРО", "ОТЕЛЬ", "ЭКРАН", "ПЕСОК", "БАШНЯ", "ЗОЛОТО", "ГОСТЬ", "ХУТОР", "ТРАВА", "ЗЕФИР", "ИКОНА", "ОГОНЬ",
                 "ОКЕАН","НИТКА", "ЯКОРЬ", "САПОГ", "ЧЕСТЬ", "ЗЕБРА", "ФИКУС"
                };
        }

        private void StartNewGame()
        {
            var rnd = new Random();
            answer = wordList[rnd.Next(wordList.Count)];
            currentRow = currentCol = 0;
            ClearGrid();
        }

        public void GenerateLabels()
        {
            grid = new Label[rows, cols];
            int width = 50, height = 50, space = 10;
            int rowWidth = cols * width + (cols - 1) * space;
            int x0 = (this.ClientSize.Width - rowWidth) / 2;
            int y = 60;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var lbl = new Label
                    {
                        Text = "",
                        Size = new Size(width, height),
                        TextAlign = ContentAlignment.MiddleCenter,
                        BorderStyle = BorderStyle.FixedSingle,
                        Font = new Font("Arial", 20, FontStyle.Bold),
                        Location = new Point(x0 + j * (width + space), y)
                    };
                    this.Controls.Add(lbl);
                    grid[i, j] = lbl;
                }
                y += height + space;
            }
        }

        private void ClearGrid()
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    grid[i, j].Text = "";
                    grid[i, j].BackColor = SystemColors.Control;
                }
        }

        private void WordleForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (currentRow >= rows) return;

            char key = char.ToUpper(e.KeyChar);
            if (char.IsLetter(key) && currentCol < cols)
            {
                grid[currentRow, currentCol].Text = key.ToString();
                currentCol++;
            }
            else if (e.KeyChar == '\r')
            {
                TrySubmit();
            }
        }

        private void WordleForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (currentRow >= rows) return;
            if (e.KeyCode == Keys.Back && currentCol > 0)
            {
                currentCol--;
                grid[currentRow, currentCol].Text = "";
            }
        }

        private void TrySubmit()
        {
            if (currentCol < cols) return;


            var guess = string.Concat(
                Enumerable.Range(0, cols).Select(c => grid[currentRow, c].Text)
            );



            for (int c = 0; c < cols; c++)
            {
                char ch = guess[c];
                var lbl = grid[currentRow, c];
                if (answer[c] == ch)
                    lbl.BackColor = Color.Green;
                else if (answer.Contains(ch))
                    lbl.BackColor = Color.Goldenrod;
                else
                    lbl.BackColor = Color.LightGray;
            }

            if (guess == answer)
            {
                MessageBox.Show("Поздравляем! Вы угадали слово.", "Win", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentRow = rows; // блокируем ввод
            }
            else
            {
                currentRow++;
                currentCol = 0;
                if (currentRow >= rows)
                    MessageBox.Show($"Игра окончена. Загаданное слово: {answer}", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
