using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _20_grafika
{
    public partial class Form1 : Form
    {
        private bool isLedon = false;
        private Image ledon;
        private Image ledoff;


        public Form1()
        {
            InitializeComponent();
            SetupChart();

            ledon = Image.FromFile("ledon.png");
            ledoff = Image.FromFile("ledoff.png");
            ledon = Image.FromFile(Application.StartupPath + @"\ledon.png");
            ledoff = Image.FromFile(Application.StartupPath + @"\ledoff.png");
            ledoff = Properties.Resources.ledoff;
            Console.WriteLine($"ledon.png betöltve: {ledon != null}");
            Console.WriteLine($"ledoff.png betöltve: {ledoff != null}");

            isLedon = false;
            pictureBox1.Image = ledoff;

            if(File.Exists("status.txt"))
            {
                string[] lines = File.ReadAllLines("status.txt");
                if(lines.Length > 0)
                {
                    string lastLine = lines[lines.Length - 1];
                    isLedon = lastLine.Contains("LED ON");
                }
            }

            LoadLastStatus();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.Gray;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            button1.BackColor = SystemColors.Control;

            isLedon = !isLedon;
            Console.WriteLine($"LED állapot: {isLedon}");

            pictureBox1.Image = isLedon ? ledon : ledoff;
            pictureBox1.Refresh();

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string logEntry = $"{timestamp} - LED {(isLedon ? "ON" : "OFF")}";
            File.AppendAllText("status.txt", logEntry + Environment.NewLine);

            LogStatus();
        }

        private void LogStatus()
        {
            string path = "status.txt";
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string status = isLedon ? "ON" : "OFF";

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{timestamp} - LED: {status}");
            }
        }

        private void LoadLastStatus()
        {
            string path = "status.txt";

            if (File.Exists(path))
            {
                string lastLine = File.ReadLines(path).LastOrDefault();

                if (lastLine != null && lastLine.Contains("LED: ON"))
                {
                    isLedon = true;
                    pictureBox1.Image = ledon;
                }
            }
        }

        private void SetupChart()
        {
            chart1.Series.Clear();

            Series series = new Series("LED Status");
            series.ChartType = SeriesChartType.StepLine;
            series.BorderWidth = 2;
            series.Color = Color.Black;

            series.Points.AddXY(1, 0);
            series.Points.AddXY(2, 1);
            series.Points.AddXY(3, 1);
            series.Points.AddXY(4, 0);
            series.Points.AddXY(5, 0);
            series.Points.AddXY(6, 1);
            series.Points.AddXY(7, 1);
            series.Points.AddXY(8, 0);

            chart1.Series.Add(series);

            chart1.ChartAreas[0].AxisY.Minimum = -0.5;
            chart1.ChartAreas[0].AxisY.Maximum = 1.5;
            chart1.ChartAreas[0].AxisY.Interval = 1;
            chart1.ChartAreas[0].AxisX.Interval = 1;
        }

        private Timer timer;
        private int timeIndex = 0;

        private void Timer_Tick(object sender, EventArgs e)

        {
            Console.WriteLine($"Timer tick: {timeIndex}");
            try
            {
                string[] lines = File.ReadAllLines("status.exe");

                if (lines.Length > 0)
                {
                    string lastLine = lines[lines.Length - 1];
                    bool isLedOn = lastLine.Contains("LED ON");

                    chart1.Series[0].Points.AddXY(timeIndex, isLedOn ? 1 : 0);

                    if (chart1.Series[0].Points.Count > 20)
                        chart1.Series[0].Points.RemoveAt(0);

                    timeIndex++;

                    chart1.Series[0].Points.AddXY(timeIndex, isLedOn ? 1 : 0);
                    timeIndex++;

                    if (chart1.Series[0].Points.Count > 20)
                    {
                        chart1.Series[0].Points.RemoveAt(0);
                    }

                    chart1.ChartAreas[0].AxisX.Minimum = timeIndex - 20;
                    chart1.ChartAreas[0].AxisX.Maximum = timeIndex;
                    chart1.ChartAreas[0].AxisX.Interval = 1;

                    chart1.ChartAreas[0].AxisY.Minimum = 0;
                    chart1.ChartAreas[0].AxisY.Maximum = 1;
                    chart1.ChartAreas[0].AxisY.Interval = 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba a fájl beolvasásakor:" + ex.Message);
            }





        }



    }
}
