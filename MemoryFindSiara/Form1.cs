using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MemoryFindSiara
{
    public partial class Form1 : Form
    {
        private const int ButtonWidth = 150;  // Szerokość każdego przycisku
        private const int ButtonHeight = 200;  // Wysokość każdego przycisku
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
                    Size = new Size(ButtonWidth, ButtonHeight),
                    Location = positions[i],
                    Tag = i + 1  // Przechowywanie numeru przycisku
                   
                };

                // Przypisanie obrazu do przycisku
                btn.Image = GetButtonImage(i, 0);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.Black;
                
                btn.Click += Button_Click;
                buttons.Add(btn);
                this.Controls.Add(btn);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int buttonNumber = (int)btn.Tag;

            btn.Image = GetButtonImage(buttonNumber, 1);

           // MessageBox.Show($"Kliknięto przycisk {buttonNumber}");
        }

        private List<Point> GetRandomPositions()
        {
            var points = new List<Point>();

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    points.Add(new Point(col * (ButtonWidth + Padding), row * (ButtonHeight + Padding)));
                }
            }

            return points.OrderBy(p => Guid.NewGuid()).ToList();
        }

        private Image GetButtonImage(int index, int step)
        {
            if(step == 0)
            {
                return Properties.Resources.DefaultImage;
            }
            else
            {
                switch (index)
                {
                    //case 0: return Properties.Resources.killer;
                    case 1: return Properties.Resources.killer;
                    case 2: return Properties.Resources.killer;
                    case 3: return Properties.Resources.JoseArcadioMorales;
                    case 4: return Properties.Resources.JoseArcadioMorales;
                    case 5: return Properties.Resources.Siara;
                    case 6: return Properties.Resources.Siara;
                    // Dodaj kolejne obrazy do kolejnych przypadków
                    default: return Properties.Resources.DefaultImage; // Obraz domyślny
                }
            }

        }
    }
}
