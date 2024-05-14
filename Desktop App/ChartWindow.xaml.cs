using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Desktop_App
{
	/// <summary>
	/// Логика взаимодействия для ChartWindow.xaml
	/// </summary>
	public partial class ChartWindow : Window
	{
		//public SeriesCollection SeriesCollection { get; set; }
		//public List<string> Labels { get; set; }
		//private double _trend;
		//private double[] temp = { 1, 3, 2, 4, -3, 5, 2, 1 };
		public SeriesCollection SeriesCollection { get; set; }
		public List<string> Labels { get; set; }
		public ChartWindow()
		{
			InitializeComponent();
			//using (var db = new MedicalLaboratoryEntities3())
			//{
			//	double? sum = db.service.Where(S => S.mean_deviation != null).Sum(S => S.mean_deviation);
			//	int count = db.service.Where(S => S.mean_deviation != null).Count();

			//	if (sum != null)
			//	{
			//		double? srOtk = sum/count;
			//		lbSrOtk.Content = $"Ср. отклонение: {srOtk}";
			//	}

			//	//// Получаем список значений среднеквадратичных отклонений из таблицы
			//	//var values = db.service.Select(s => s.mean_deviation).ToList();

			//	//// Вычисляем среднеквадратичное отклонение
			//	//double stdDev = CalculateStandardDeviation(values);

			//	//// Выводим результат в текстовый блок
			//	//txtResult.Text = stdDev.ToString();
			//}



			//LineSeries mylineseries = new LineSeries();

			//mylineseries.Title = "PC";

			//mylineseries.LineSmoothness = 0;

			//mylineseries.PointGeometry = null;

			//Labels =new List<string> { "1", "3", "2", "4", "-3", "5", "2", "1" };

			//mylineseries.Values = new ChartValues<double>(temp);
			//SeriesCollection = new SeriesCollection { };
			//SeriesCollection.Add(mylineseries);
			//_trend = 19;
			//linestart();
			//DataContext = this;


			using (var db = new MedicalLaboratoryEntities3())
			{
				var values = db.service.Select(s => s.mean_deviation).ToList();
				var stdDev = CalculateStandardDeviation(values);
				lbSrOtk.Content = stdDev.ToString();

				var dates = db.work_analyzer.Select(d => d.ToString()).ToList();
				var valuesForGraph = db.service.Select(v => v.mean_deviation).ToList();

				var mylineseries = new LineSeries
				{
					Title = "PC",
					LineSmoothness = 0,
					PointGeometry = null,
					Values = new ChartValues<double>(valuesForGraph)
				};

				SeriesCollection = new SeriesCollection { mylineseries };
				Labels = dates;
			}

			DataContext = this;


		}
		private double CalculateStandardDeviation(List<double> values)
		{
			double mean = values.Average();
			double sumOfSquaresOfDifferences = 0;

			foreach (var value in values)
			{
				sumOfSquaresOfDifferences += Math.Pow(value - mean, 2);
			}

			double variance = sumOfSquaresOfDifferences / (values.Count - 1);
			return Math.Sqrt(variance);
		}
	}
}