namespace SQL
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.mySqlConnection1 = new Devart.Data.MySql.MySqlConnection();
            this.buttonGraph = new System.Windows.Forms.Button();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.chartTemperature = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperature)).BeginInit();
            this.SuspendLayout();
            // 
            // mySqlConnection1
            // 
            this.mySqlConnection1.ConnectionString = "Host=localhost;Database=feladat;";
            this.mySqlConnection1.Name = "mySqlConnection1";
            this.mySqlConnection1.Owner = this;
            // 
            // buttonGraph
            // 
            this.buttonGraph.Location = new System.Drawing.Point(106, 297);
            this.buttonGraph.Name = "buttonGraph";
            this.buttonGraph.Size = new System.Drawing.Size(148, 44);
            this.buttonGraph.TabIndex = 0;
            this.buttonGraph.Text = "Feltöltés";
            this.buttonGraph.UseVisualStyleBackColor = true;

            // 
            // labelTemperature
            // 
            this.labelTemperature.AutoSize = true;
            this.labelTemperature.Location = new System.Drawing.Point(165, 215);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(35, 13);
            this.labelTemperature.TabIndex = 1;
            this.labelTemperature.Text = "label1";
            // 
            // chartTemperature
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTemperature.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTemperature.Legends.Add(legend1);
            this.chartTemperature.Location = new System.Drawing.Point(420, 98);
            this.chartTemperature.Name = "chartTemperature";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 2;
            this.chartTemperature.Series.Add(series1);
            this.chartTemperature.Size = new System.Drawing.Size(300, 300);
            this.chartTemperature.TabIndex = 2;
            this.chartTemperature.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartTemperature);
            this.Controls.Add(this.labelTemperature);
            this.Controls.Add(this.buttonGraph);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperature)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Devart.Data.MySql.MySqlConnection mySqlConnection1;
        private System.Windows.Forms.Button buttonGraph;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemperature;
        private System.Windows.Forms.Timer timer;
    }
}

