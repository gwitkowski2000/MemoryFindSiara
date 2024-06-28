using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MemoryFindSiara
{
    public partial class Form1 : Form
    {
        private const int ButtonSize = 80;  // Rozmiar każdego przycisku
        private const int Rows = 3;
        private const int Columns = 5;
        private const int Padding = 10;

        private List<Button> buttons = new List<Button>();

        public Form1()
        {
            InitializeComponent();
            GenerateButtons();
        }

        private void GenerateButtons()
        {
            Random random = new Random();
            var positions = GetRandomPositions();

            for (int i = 0; i < 15; i++)
            {
                Button btn = new Button
                {
                    Size = new Size(ButtonSize, ButtonSize),
                    Location = positions[i],
                    Tag = i + 1  // Przechowywanie numeru przycisku
                };

                // Przypisanie obrazu do przycisku
                btn.Image = GetButtonImage(i);

                btn.Click += Button_Click;
                buttons.Add(btn);
                this.Controls.Add(btn);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int buttonNumber = (int)btn.Tag;
            MessageBox.Show($"Kliknięto przycisk {buttonNumber}");
        }

        private List<Point> GetRandomPositions()
        {
            var points = new List<Point>();

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    points.Add(new Point(col * (ButtonSize + Padding), row * (ButtonSize + Padding)));
                }
            }

            return points.OrderBy(p => Guid.NewGuid()).ToList();
        }

        private Image GetButtonImage(int index)
        {
            // Przykład: ładowanie obrazów z plików
            string[] imageFiles = Directory.GetFiles(@"C:\Path\To\Images\", "*.png");
            if (index < imageFiles.Length)
            {
                return Image.FromFile(imageFiles[index]);
            }
            else
            {
                // Domyślny obraz, jeśli brak odpowiedniego pliku
                return Image.FromFile(@"C:\Path\To\Images\default.png");
            }
        }
    }
}
