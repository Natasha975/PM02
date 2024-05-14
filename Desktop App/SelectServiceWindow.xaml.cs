using System;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using System.Text.Json;
using System.IO;

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
			using (var db = new MedicalLaboratoryEntities())
			{
				cbSer.ItemsSource = db.service.ToList();
				cbAn.ItemsSource = db.analyzer.ToList();
				cbSer.DisplayMemberPath = "service_name";
				cbAn.DisplayMemberPath = "name";
			}
		}
		private async void btIss_Click(object sender, RoutedEventArgs e)
		{
			timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(10);
			timer.Tick += Timer_Tick;
			timer.Start();
			using (var db = new MedicalLaboratoryEntities())
			{
				try
				{
					int maxIdWork = db.work_analyzer.Max(u => u.id) + 1;
					var selectedAn = (analyzer)cbAn.SelectedItem;
					var dateTime = DateTime.Now;
					var timeSpan = dateTime.TimeOfDay;
					var timeString = timeSpan.ToString();
					var selectedSer = (service)cbSer.SelectedItem;

					var newWork = new work_analyzer 
					{
						id = maxIdWork,
						analyzer_id = selectedAn.id,
						order_received_date = DateTime.Now,
						order_received_time = timeSpan,
						order_execution_time_sec_ = 10,
						service_id = selectedSer.id,
						result = 12,
						status = "Отправлена на исследование",
					};
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
					using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
					{
						work_analyzer tom = new work_analyzer(maxIdWork, selectedAn.id, DateTime.Now, timeSpan, 10, selectedSer.id, "Отправлена на исследование");
						await JsonSerializer.SerializeAsync<work_analyzer>(fs, tom);
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