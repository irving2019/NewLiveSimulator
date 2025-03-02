using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace NewLiveSimulator
{
    public partial class Form1 : Form
    {
        private int currentGeneration = 0;
        private Graphics graphics;
        private int resolution;
        private bool[,] field;
        private int rows;
        private int cols;
        private string screenshotDirectory = Path.Combine(Application.StartupPath, "C:\\Screen");
        int count = 0;

        public Form1()
        {
            InitializeComponent();

            if (!Directory.Exists(screenshotDirectory))
            {
                Directory.CreateDirectory(screenshotDirectory);
            }
            UpdateScreenshotList();
        }

        private void StartGame()
        {
            if (timer1.Enabled)
            {
                return;
            }

            currentGeneration = 0;
            Text = $"Поколение: {currentGeneration}";

            nudResolution.Enabled = false;
            nudDensity.Enabled = false;
            resolution = (int)nudResolution.Value;

            rows = pictureBox1.Height / resolution;
            cols = pictureBox1.Width / resolution;
            field = new bool[cols, rows];

            Random random = new Random();

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    field[x, y] = random.Next((int)nudDensity.Value) == 0;
                }
            }

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            timer1.Start();
        }

        private void StopGame()
        {
            if (!timer1.Enabled)
            {
                return;
            }
            timer1.Stop();

            nudResolution.Enabled = true;
            nudDensity.Enabled = true;
        }

        private void ContinueGame()
        {
            if (timer1.Enabled)
            {
                return;
            }
            timer1.Start();

            nudResolution.Enabled = false;
            nudDensity.Enabled = false;
        }

        private void SlowDownGame()
        {
            if (timer1.Interval != 0)
            {
                timer1.Interval += 5;
            }
        }

        private void SpeedUpGame()
        {
            if (timer1.Interval != 0)
            {
                timer1.Interval -= 5;
            }

        }

        private void TakeScreenshot(Rectangle bounds)
        {
            Bitmap screen = new Bitmap(bounds.Width, bounds.Height);
            using (Graphics g = Graphics.FromImage(screen))
            {
                g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
            }

            count++;
            string fileName = $"Live_{count}.png";
            string filePath = Path.Combine(screenshotDirectory, fileName);
            screen.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
            pictureBox2.Image = screen;
        }

        private void UpdateScreenshotList()
        {
            listBox1.Items.Clear();
            var screenshots = Directory.GetFiles(screenshotDirectory, "*.png");

            foreach (var screenshot in screenshots)
            {
                listBox1.Items.Add(Path.GetFileName(screenshot));
            }
        }

        private void ListBox1_DoubleClick(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem != null)
            {
                string fileName = listBox1.SelectedItem.ToString();
                string filePath = Path.Combine(screenshotDirectory, fileName);

                if (File.Exists(filePath))
                {
                    try
                    {
                        Process.Start(filePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при открытии файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Файл не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void NextGeneration()
        {
            graphics.Clear(Color.Black);

            var newField = new bool[cols, rows];

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    var NeighboursCount = CountNeighbours(x, y);
                    var hasLive = field[x, y];

                    if (!hasLive && NeighboursCount == 3)
                    {
                        newField[x, y] = true;
                    }
                    else if (hasLive && (NeighboursCount < 2 || NeighboursCount > 3))
                    {
                        newField[x, y] = false;
                    }
                    else
                    {
                        newField[x, y] = hasLive;
                    }

                    if (hasLive)
                    {
                        graphics.FillRectangle(Brushes.Crimson, x * resolution, y * resolution, resolution, resolution);
                    }
                }
            }
            field = newField;
            pictureBox1.Refresh();
            Text = $"Поколение: {++currentGeneration}";
        }

        private int CountNeighbours(int x, int y)
        {
            int count = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int col = (x + i + cols) % cols;
                    int row = (y + j + rows) % rows;
                    bool isSelfChecking = col == x && row == y;
                    var hasLive = field[col, row];

                    if (hasLive && !isSelfChecking)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void Startbtn_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void Stopbtn_Click(object sender, EventArgs e)
        {
            StopGame();
        }

        private void Continuebtn_Click(object sender, EventArgs e)
        {
            ContinueGame();
        }

        private void SlowDown_Click(object sender, EventArgs e)
        {
            SlowDownGame();
        }

        private void SpeedUp_Click(object sender, EventArgs e)
        {
            SpeedUpGame();
        }

        private void Screenbtn_Click(object sender, EventArgs e)
        {
            using (var selectAreaForm = new SelectAreaForm())
            {
                if (selectAreaForm.ShowDialog() == DialogResult.OK)
                {
                    TakeScreenshot(selectAreaForm.SelectedArea);
                    UpdateScreenshotList();
                }
            }
        }
        public class SelectAreaForm : Form
        {
            private Rectangle selectedArea;
            private Point startPoint;

            public Rectangle SelectedArea => selectedArea;

            public SelectAreaForm()
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.BackColor = Color.White;
                this.Opacity = 0.5;
                this.DoubleBuffered = true;
                this.MouseDown += SelectAreaForm_MouseDown;
                this.MouseMove += SelectAreaForm_MouseMove;
                this.MouseUp += SelectAreaForm_MouseUp;
            }

            private void SelectAreaForm_MouseDown(object sender, MouseEventArgs e)
            {
                startPoint = e.Location;
            }

            private void SelectAreaForm_MouseMove(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    int x = Math.Min(startPoint.X, e.X);
                    int y = Math.Min(startPoint.Y, e.Y);
                    int width = Math.Abs(startPoint.X - e.X);
                    int height = Math.Abs(startPoint.Y - e.Y);

                    selectedArea = new Rectangle(x, y, width, height);
                    this.Invalidate();
                }
            }

            private void SelectAreaForm_MouseUp(object sender, MouseEventArgs e)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                if (selectedArea != Rectangle.Empty)
                {
                    using (var brush = new SolidBrush(Color.FromArgb(128, Color.Black)))
                    {
                        e.Graphics.FillRectangle(brush, selectedArea);
                    }
                }
            }
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                var x = e.Location.X / resolution;
                var y = e.Location.Y / resolution;
                var ValidationPassed = ValidateMousePosition(x, y);
                if (ValidationPassed)
                {
                    field[x, y] = true;
                    DrawCell(x, y);
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                var x = e.Location.X / resolution;
                var y = e.Location.Y / resolution;
                var ValidationPassed = ValidateMousePosition(x, y);
                if (ValidationPassed)
                {
                    field[x, y] = false;
                    DrawCell(x, y);
                }
            }
        }

        private void DrawCell(int x, int y)
        {
            var hasLive = field[x, y] ? Brushes.Crimson : Brushes.Black;
            graphics.FillRectangle(hasLive, x * resolution, y * resolution, resolution, resolution);
            pictureBox1.Refresh();
        }

        private bool ValidateMousePosition(int x, int y)
        {
            return x >= 0 && y >= 0 && x < cols && y < rows;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = $"Поколение: {currentGeneration}";
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string selectedFile = Path.Combine(screenshotDirectory, listBox1.SelectedItem.ToString());
                pictureBox2.Image = Image.FromFile(selectedFile);
            }
        }
    }

}