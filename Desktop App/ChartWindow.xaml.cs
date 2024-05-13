using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
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
		public SeriesCollection SeriesCollection { get; set; }
		public List<string> Labels { get; set; }
		private double _trend;
		private double[] temp = { 1, 3, 2, 4, -3, 5, 2, 1 };
		public ChartWindow()
		{
			InitializeComponent();
			using (var db = new MedicalLaboratoryEntities3())
			{
				double? sum = db.service.Where(S => S.mean_deviation != null).Sum(S => S.mean_deviation);
				int count = db.service.Where(S => S.mean_deviation != null).Count();

				if (sum != null)
				{
					double? srOtk = sum/count;
					lbSrOtk.Content = $"Ср. отклонение: {srOtk}";
				}

				//// Получаем список значений среднеквадратичных отклонений из таблицы
				//var values = db.service.Select(s => s.mean_deviation).ToList();

				//// Вычисляем среднеквадратичное отклонение
				//double stdDev = CalculateStandardDeviation(values);

				//// Выводим результат в текстовый блок
				//txtResult.Text = stdDev.ToString();
			}



			LineSeries mylineseries = new LineSeries();

			mylineseries.Title = "PC";

			mylineseries.LineSmoothness = 0;

			mylineseries.PointGeometry = null;

			Labels =new List<string> { "1", "3", "2", "4", "-3", "5", "2", "1" };

			mylineseries.Values = new ChartValues<double>(temp);
			SeriesCollection = new SeriesCollection { };
			SeriesCollection.Add(mylineseries);
			_trend = 19;
			linestart();
			DataContext = this;
		}
		private double CalculateStandardDeviation(List<double> values)
		{
			double mean = values.Average();
			double sumOfSquaresOfDifferences = 0;

			foreach (double value in values)
			{
				sumOfSquaresOfDifferences += Math.Pow(value - mean, 2);
			}

			double variance = sumOfSquaresOfDifferences / (values.Count - 1);
			double stdDev = Math.Sqrt(variance);

			return stdDev;
		}
		public void linestart()
		{
			Task.Run(() =>
			{
				var r = new Random();
				while (true)
				{
					Thread.Sleep(3000);
					_trend = r.Next(0, 5);
					//Update the UI elements of the form in the worker thread through Dispatcher
					Application.Current.Dispatcher.Invoke(() =>
					{
						//Update the abscissa time
						Labels.Add(DateTime.Now.ToString());
						Labels.RemoveAt(0);
						//Update the ordinate data
						SeriesCollection[0].Values.Add(_trend);
						SeriesCollection[0].Values.RemoveAt(0);
					});
				}
			});
		}
	}
}
