using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Desktop_App
{
	/// <summary>
	/// Логика взаимодействия для ChartWindow.xaml
	/// </summary>
	public partial class ChartWindow : Window
	{
		private double[] temp = { 10, 30, 21, 14, 13, 15, 20, 10 };
		public SeriesCollection SeriesCollection { get; set; }
		public List<string> Labels { get; set; }
		public ChartWindow()
		{
			InitializeComponent();
			using (var db = new MedicalLaboratoryEntities())
			{
				double? sum = db.service.Where(S => S.mean_deviation != null).Sum(S => S.mean_deviation);
				int count = db.service.Where(S => S.mean_deviation != null).Count();

				if (sum != null)
				{
					double? srOtk = sum/count;
					lbSrOtk.Content = $"Ср. отклонение: {srOtk}";
				}
				var values = new List<string>();
				values = db.work_analyzer.Select(s => s.result.ToString()).ToList();
				var dates = new List<string>();
				dates = db.work_analyzer.Select(d => d.order_received_date.ToString()).ToList();
				var mylineseries = new LineSeries
				{
					Title = "PC",
					LineSmoothness = 0,
					PointGeometry = null,
					Values = new  ChartValues<double>(temp)
				};
				SeriesCollection = new SeriesCollection { mylineseries };
				Labels = dates;
			}
			DataContext = this;
		}
	}
}