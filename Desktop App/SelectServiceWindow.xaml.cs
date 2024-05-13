using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Threading;

namespace Desktop_App
{
	/// <summary>
	/// Логика взаимодействия для SelectServiceWindow.xaml
	/// </summary>
	public partial class SelectServiceWindow : Window
	{
		private DispatcherTimer timer;
		public SelectServiceWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			using (var db = new MedicalLaboratoryEntities3())
			{
				cbSer.ItemsSource = db.service.ToList();
				cbAn.ItemsSource = db.analyzer.ToList();
				cbSer.DisplayMemberPath = "service_name";
				cbAn.DisplayMemberPath = "name";
			}
		}

		private void btIss_Click(object sender, RoutedEventArgs e)
		{
			timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(10);
			timer.Tick += Timer_Tick;
			timer.Start();
			using (var db = new MedicalLaboratoryEntities3())
			{
				try
				{
					var newWork = new work_analyzer();
					int maxIdVisitor = db.work_analyzer.Max(u => u.id) + 1;
					var selectedAn = (analyzer)cbAn.SelectedItem;
					newWork.analyzer_id = selectedAn.id;
					newWork.order_received_date = DateTime.Now;
					var dateTime = DateTime.Now;
					var timeSpan = dateTime.TimeOfDay;
					var timeString = timeSpan.ToString();
					newWork.order_received_time = timeSpan;
					newWork.order_execution_time_sec_ = 10;
					var selectedSer = (service)cbSer.SelectedItem;
					newWork.service_id = selectedSer.id;
					newWork.result = "Исследование";
					newWork.status = "Отправлена на исследование";
					try
					{
						db.work_analyzer.Add(newWork);
						db.SaveChanges();
						MessageBox.Show("Услуга отправлена на анализатор!");
					}
					catch
					{
						MessageBox.Show("Услуга не может быть отправлена на анализатор!");
					}
				}
				catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
			}
		}
		private void Timer_Tick(object sender, EventArgs e)
		{
			MessageBox.Show("Результат положителен");
			timer.Stop();
		}
	}
}
