using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace MemoryFindSiara
{
    
    public partial class Form1 : Form
    {
        private const int ButtonWidth = 150;  // Szerokość każdego przycisku
        private const int ButtonHeight = 200;  // Wysokość każdego przycisku
        private const int Rows = 3;
        private const int Columns = 4;
        private const int Padding = 10;
        private int previousCardNumber = 0;
        private int click = 0;
        private int foundCards = 0;

        private System.Timers.Timer timerHideCards;

        private List<Button> buttons = new List<Button>();

        public Form1()
        {
            InitializeComponent();
            GenerateButtons();
            timerHideCards = new System.Timers.Timer();
            timerHideCards.Interval = 500; //500ms delay to show cards
            timerHideCards.Elapsed += timerHideCardsElapsed;
        }

        private void timerHideCardsElapsed(Object source, ElapsedEventArgs e) {
            timerHideCards.Stop();
            previousCardNumber = 0;
            for (int i = 0; i < 12; i++)
            {
                buttons[i].Image = GetButtonImage(i, 0);
            }

            this.Invoke((MethodInvoker)delegate {

                for (int i = 0; i < 12; i++)
                {
                    buttons[i].Click += Button_Click;
                }
            });




        }

        private void GenerateButtons()
        {
            Random random = new Random();
            var positions = GetRandomPositions();

            for (int i = 0; i < 3*4; i++)
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
            int cardNumber = (int)btn.Tag;

            btn.Image = GetButtonImage(cardNumber, 1);
            click += 1;


            switch (cardNumber)
            {
                case 1:
                    if (previousCardNumber == 2) {
                        this.Controls[0].Hide();
                        this.Controls[1].Hide();
                        foundCards++;
                    }

                    break;
                case 2:
                    if (previousCardNumber == 1)
                    {
                        this.Controls[0].Hide();
                        this.Controls[1].Hide();
                        foundCards++;
                    }

                    break;
                case 3:
                    if (previousCardNumber == 4)
                    {
                        this.Controls[2].Hide();
                        this.Controls[3].Hide();
                        foundCards++;
                    }

                    break;
                case 4:
                    if (previousCardNumber == 3)
                    {
                        this.Controls[2].Hide();
                        this.Controls[3].Hide();
                        foundCards++;
                    }

                    break;
                case 5:
                    if (previousCardNumber == 6)
                    {
                        this.Controls[4].Hide();
                        this.Controls[5].Hide();
                        foundCards++;
                    }

                    break;
                case 6:
                    if (previousCardNumber == 5)
                    {
                        this.Controls[4].Hide();
                        this.Controls[5].Hide();
                        foundCards++;
                    }

                    break;
                case 7:
                    if (previousCardNumber == 8)
                    {
                        this.Controls[6].Hide();
                        this.Controls[7].Hide();
                        foundCards++;
                    }

                    break;
                case 8:
                    if (previousCardNumber == 7)
                    {
                        this.Controls[6].Hide();
                        this.Controls[7].Hide();
                        foundCards++;
                    }

                    break;
                case 9:
                    if (previousCardNumber == 10)
                    {
                        this.Controls[8].Hide();
                        this.Controls[9].Hide();
                        foundCards++;
                    }

                    break;
                case 10:
                    if (previousCardNumber == 9)
                    {
                        this.Controls[8].Hide();
                        this.Controls[9].Hide();
                        foundCards++;
                    }

                    break;
                case 11:
                    if (previousCardNumber == 12)
                    {
                        this.Controls[10].Hide();
                        this.Controls[11].Hide();
                        foundCards++;
                    }

                    break;
                case 12:
                    if (previousCardNumber == 11)
                    {
                        this.Controls[10].Hide();
                        this.Controls[11].Hide();
                        foundCards++;
                    }

                    break;
            }

            Debug.WriteLine("Found cards: " + foundCards);
            if (foundCards >= 6)
            {

                DialogResult = MessageBox.Show("Do you want to play again?", "Congratulations, you found Siara!", MessageBoxButtons.YesNo);
                if(DialogResult == DialogResult.No)
                {
                    this.Close();
                }else if(DialogResult == DialogResult.Yes)
                {
                    previousCardNumber = 0;
                    click = 0;
                    foundCards = 0;

                    for (int i = 0; i < 12; i++)
                    {
                        this.Controls[i].Show();
                        buttons[i].Image = GetButtonImage(i, 0);
                    }

                    

                }
        
                
            }

            if (click == 2)
            {
                for(int i = 0; i < 12; i++)
                {
                    buttons[i].Click -= Button_Click;
                }
                timerHideCards.Start();
                click = 0;

            }
            previousCardNumber = cardNumber;

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
                    case 7: return Properties.Resources.Waski;
                    case 8: return Properties.Resources.Waski;
                    case 9: return Properties.Resources.Ryba;
                    case 10: return Properties.Resources.Ryba;
                    case 11: return Properties.Resources.Lipski;
                    case 12: return Properties.Resources.Lipski;
                    // Dodaj kolejne obrazy do kolejnych przypadków
                    default: return Properties.Resources.DefaultImage; // Obraz domyślny
                }
            }

        }
    }
}
