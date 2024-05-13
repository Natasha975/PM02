using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
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
	/// Логика взаимодействия для ReportWindow.xaml
	/// </summary>
	public partial class ReportWindow : Window
	{
		public ReportWindow()
		{
			InitializeComponent();
		}

		private void btPoisk_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				DateTime startDate = dpStart.SelectedDate ?? DateTime.MinValue;
				DateTime endDate = dpEnd.SelectedDate ?? DateTime.MaxValue;
				using (var db = new MedicalLaboratoryEntities3())
				{
					int count = db.performed_service.Where(perSer => perSer.execution_date >= startDate && perSer.execution_date <= endDate).Count();
					lbKol.Content = count;
					int countPat = db.performed_service.Where(perSer => perSer.patient_id != null).Count();
					lbKolPat.Content = countPat;
					var query = from perSer in db.performed_service
								join work in db.work_analyzer on perSer.analyzer_id equals work.id
								join ser in db.service on work.service_id equals ser.id
								where perSer.execution_date >= startDate && perSer.execution_date <= endDate
								select new
								{
									Дата = perSer.execution_date,
									Услуга = ser.service_name,

								};
					dgSer.ItemsSource = query.ToList();
				}
			} catch (Exception ex) { MessageBox.Show("Ошибка" + ex.Message); }
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			using (var db = new MedicalLaboratoryEntities3())
			{
				var query = from perSer in db.performed_service
							join work in db.work_analyzer on perSer.analyzer_id equals work.id
							join ser in db.service on work.service_id equals ser.id
							group perSer by new { perSer.execution_date } into g
							select new
							{
								Дата = g.Key.execution_date,
								Количество = g.Count()
							};
				dgSer.ItemsSource = query.ToList();
			}			
		}

		private void btchart_Click(object sender, RoutedEventArgs e)
		{
			ChartWindow window = new ChartWindow();
			window.ShowDialog();
		}
	}
}