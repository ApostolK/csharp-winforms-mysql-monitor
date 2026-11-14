using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Devart.Data.MySql;
namespace SQL
{
    public partial class Form1 : Form
    {
        private MySQLHelper dbHelper = new MySQLHelper();
  
        private Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            InitializeChart();

           
            timer.Interval = 10 * 60 * 1000; 
            timer.Tick += Timer_Tick;
            timer.Start();


            GenerateAndSaveTemperature();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            GenerateAndSaveTemperature();
        }

        private void GenerateAndSaveTemperature()
        {
            decimal temperature = Math.Round((decimal)(rand.NextDouble() * (24.0 - 16.0) + 16.0), 1);
            labelTemperature.Text = $"Jelenlegi hőmérséklet: {temperature} °C";
            dbHelper.InsertTemperature(temperature);
        }

        private void buttonGraph_Click(object sender, EventArgs e)
        {
            LoadGraphData();
        }

        private void InitializeChart()
        {
            chartTemperature.Series.Clear();
            chartTemperature.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea();
            chartTemperature.ChartAreas.Add(chartArea);

            Series series = new Series
            {
                Name = "Hőmérséklet",
                ChartType = SeriesChartType.Line,
                Color = Color.Red,
                BorderWidth = 2
            };
            chartTemperature.Series.Add(series);
        }

        private void LoadGraphData()
        {
            DataTable data = dbHelper.GetLastHourData();
            Series series = chartTemperature.Series["Hőmérséklet"];
            series.Points.Clear();

            foreach (DataRow row in data.Rows)
            {
                DateTime time = Convert.ToDateTime(row["Date"]);
                decimal temp = Convert.ToDecimal(row["Homerseklet"]);
                series.Points.AddXY(time, temp);
            }
        }


    }
}
