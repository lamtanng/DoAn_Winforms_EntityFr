using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LiveCharts.Helpers;
using Axis = LiveCharts.Wpf.Axis;

namespace DemoDoAn
{
    public class bieuDoChart
    {
        public void Chart_Salary(Chart salary, string ten_series, string Ten_cot, double giatri)
        {
            // này là biểu đồ cột 
            salary.Series[ten_series].Points.AddXY(Ten_cot, giatri);
        }
        public void load_bieu_do_mien(LiveCharts.WinForms.CartesianChart chart)
        {
            ChartValues<double> xAxisValues = new ChartValues<double> { 0, 5, 10 };
            ChartValues<double> yAxisValues = new ChartValues<double> { 10, 20, 25 };

            chart.AxisX.Clear(); // Xóa các cột trục X hiện có
            chart.AxisY.Clear(); // Xóa các cột trục Y hiện có
            chart.AxisX.Add(new Axis { Title = "Điểm", MinValue = 0, MaxValue = 10 });
            chart.AxisY.Add(new Axis { Title = "Số lượng", MinValue = 0, MaxValue = 100 });
            ChartValues<ObservablePoint> dataPoints = new ChartValues<ObservablePoint>();
            for (int i = 0; i < xAxisValues.Count; i++)
                dataPoints.Add(new ObservablePoint(xAxisValues[i], yAxisValues[i]));

            chart.Series.Clear(); // Xóa các chuỗi dữ liệu hiện có
            chart.Series.Add(new LineSeries { Title = "Dữ liệu", Values = dataPoints });
        }
    }
}
