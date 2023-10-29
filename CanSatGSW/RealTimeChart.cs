using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CanSat_GSW
{
    public partial class RealTimeChart : UserControl
    {
        Random r;

        Dictionary<ChartArea, List<Series>> chartData;

        public int MaxPoints = 30;  // 2 minutes

        private int count = 0;

        public RealTimeChart()
        {
            InitializeComponent();

            r = new Random();
            chartData = new Dictionary<ChartArea, List<Series>>();
        }

        public void setTitle(string title)
        {
            chart1.Titles[0].Text = title;
        }

        public void AddChart(string xLabel, string yLabel, string seriesName, SeriesChartType type)
        {
            string chartName = "chart" + chart1.ChartAreas.Count;
            chart1.ChartAreas.Add(chartName);
            chart1.ChartAreas[chartName].AxisX.Title = xLabel;
            chart1.ChartAreas[chartName].AxisX.TitleForeColor = Color.White;
            chart1.ChartAreas[chartName].AxisY.Title = yLabel;
            chart1.ChartAreas[chartName].AxisY.TitleForeColor = Color.White;
            chart1.ChartAreas[chartName].BackColor = Color.Black;
            chart1.ChartAreas[chartName].BorderColor = Color.White;

            chart1.ChartAreas[chartName].AxisX.LineColor = Color.White;
            chart1.ChartAreas[chartName].AxisX.MajorGrid.LineColor = Color.Gray;
            chart1.ChartAreas[chartName].AxisX.LabelStyle.ForeColor = Color.White;
            chart1.ChartAreas[chartName].AxisX.LabelStyle.Format = "#.###";

            chart1.ChartAreas[chartName].AxisY.LineColor = Color.White;
            chart1.ChartAreas[chartName].AxisY.MajorGrid.LineColor = Color.Gray;
            chart1.ChartAreas[chartName].AxisY.LabelStyle.ForeColor = Color.White;
            chart1.ChartAreas[chartName].AxisY.LabelStyle.Format = "#.###";

            chart1.Series.Add(seriesName);
            chart1.Series[seriesName].ChartArea = chartName;
            chart1.Series[seriesName].ChartType = type;

            if (!chartData.ContainsKey(chart1.ChartAreas[chartName]))
                chartData.Add(chart1.ChartAreas[chartName], new List<Series> { chart1.Series[seriesName] });
            else
                chartData[chart1.ChartAreas[chartName]].Add(chart1.Series[seriesName]);
        }

        public void AddLineToChart(string chartName, string seriesName, SeriesChartType type)
        {
            chart1.Series.Add(seriesName);
            chart1.Series[seriesName].ChartArea = chartName;
            chart1.Series[seriesName].ChartType = type;

            chartData[chart1.ChartAreas[chartName]].Add(chart1.Series[seriesName]);
        }

        public void AddPoint<x_type, y_type>(x_type x, y_type y, string seriesName)
        {
            chart1.Series[seriesName].Points.AddXY(x, y);
            if (chart1.Series[seriesName].Points.Count > MaxPoints) chart1.Series[seriesName].Points.RemoveAt(0);

            if (count++ > 2)
                RecalculateAxesScales();
        }

        public void AddRandomPoint(string seriesName)
        {
            if (chart1.Series[seriesName].Points.Count > 0)
                chart1.Series[seriesName].Points.AddXY(count++, chart1.Series[seriesName].Points[chart1.Series[seriesName].Points.Count - 1].YValues[0] + (r.NextDouble() - 0.5));
            else
                chart1.Series[seriesName].Points.AddXY(count++, r.NextDouble());

            if (chart1.Series[seriesName].Points.Count > MaxPoints) chart1.Series[seriesName].Points.RemoveAt(0);

            if (count > 2)
                RecalculateAxesScales();
        }

        public void AddRandomPoints()
        {
            foreach (ChartArea chart in chart1.ChartAreas)
            {
                foreach (Series series in chartData[chart])
                {
                    if (series.Points.Count > 0)
                        series.Points.AddXY(count++, series.Points[series.Points.Count - 1].YValues[0] + (r.NextDouble() - 0.5));
                    else
                        series.Points.AddXY(count++, r.NextDouble());

                    if (series.Points.Count > MaxPoints) series.Points.RemoveAt(0);
                }
            }

            count++;

            if (count > 2)
                RecalculateAxesScales();
        }

        private void RecalculateAxesScales()
        {
            foreach (ChartArea chart in chart1.ChartAreas)
            {
                double minY = double.MaxValue;
                double maxY = double.MinValue;

                double minX = double.MaxValue;
                double maxX = double.MinValue;

                foreach (Series series in chartData[chart])
                {
                    foreach (DataPoint p in series.Points)
                    {
                        foreach (double y in p.YValues)
                        {
                            if (p.YValues[0] <= minY)
                                minY = p.YValues[0];

                            if (p.YValues[0] >= maxY)
                                maxY = p.YValues[0];

                            if (p.XValue <= minX)
                                minX = p.XValue;

                            if (p.XValue >= maxX)
                                maxX = p.XValue;
                        }
                    }
                }

                if (maxY - minY > 0)
                {
                    chart.AxisY.Minimum = minY * 0.999;
                    chart.AxisY.Maximum = maxY * 1.001;
                }

                if (maxX - minX > 0)
                {
                    chart.AxisX.Minimum = minX;
                    chart.AxisX.Maximum = maxX;
                }
            }
        }

        public void Clear()
        {
            foreach (Series series in chart1.Series)
            {
                series.Points.Clear();
            }

            count++;
        }
    }
}
