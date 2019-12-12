using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BEAGLEBONE.GPIO;

namespace GPIOTest
{   
    public partial class Form1 : Form
    {
        GPIO gpio;

        const GPIOPin IN1 = GPIOPin.GPIO1_12;
        const GPIOPin OUT1 = GPIOPin.GPIO1_16;

        uint tPushed = 0;
        uint tUnpushed = 0;

        byte morseChar = 1;
        byte[] codeMorse = new byte[27] {5, 24, 26, 12, 2, 18, 14, 16, 4, 23, 13, 20, 7, 6, 15, 22, 29, 10, 8, 3, 9, 17, 11, 25, 27, 28, 85};
        char[] codeText = new char[28] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '.', '_' };
        
        public Form1()
        {
            InitializeComponent();
            this.Text += System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            gpio = new GPIO();
            gpio.SetDirection(IN1, Direction.Input);
            gpio.SetDirection(OUT1, Direction.Output);
            tmrPOLL.Enabled = true;
        }

        private void tmrPOLL_Tick(object sender, EventArgs e)
        {
            if (gpio.GetBit(IN1))
            {
                // Button Unpushed
                rbIN1.Checked = false;
                tUnpushed += 100; //ms

                if (tPushed != 0)
                {
                    if (tPushed < 400)
                    {
                        this.morseCodeBox.Text += ".";
                        morseChar = (byte)(morseChar << 1);
                    }
                    else
                    {
                        this.morseCodeBox.Text += "-";
                        morseChar = (byte)((morseChar << 1) + 1);
                    }
                    tPushed = 0;
                }

                
                if (tUnpushed == 800)
                {
                    if (morseChar != 1)
                    {
                        this.morseCodeBox.Text += "/";

                        byte codeIndex = 27;
                        byte i;
                        for (i = 0; i < 27; i++)
                        {
                            if (codeMorse[i] == morseChar)
                            {
                                codeIndex = i;
                                break;
                            }
                        }
                        this.textCodeBox.Text += codeText[codeIndex];
                        morseChar = 1;
                    }
                }
                else if (tUnpushed == 2000)
                {
                    this.morseCodeBox.Text += "  /";
                    this.textCodeBox.Text += " ";
                }
            }
            else
            {
                // Button Pushed
                rbIN1.Checked = true;
                tPushed += 100; //ms

                if (tUnpushed != 0)
                {
                    tUnpushed = 0;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}