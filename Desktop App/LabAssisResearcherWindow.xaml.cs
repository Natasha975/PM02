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

namespace Desktop_App
{
	/// <summary>
	/// Логика взаимодействия для LabAssisResearcherWindow.xaml
	/// </summary>
	public partial class LabAssisResearcherWindow : Window
	{
		private user currentUser;
		public LabAssisResearcherWindow(user users)
		{
			InitializeComponent();
			currentUser = users;
		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			lbUserLastname.Content = currentUser.lastname;
			lbUserName.Content = currentUser.name;
			using (var db = new MedicalLaboratoryEntities3())
			{
				var query = from work in db.work_analyzer	
							join ser in db.service on work.service_id equals ser.id
							join an in db.analyzer on work.analyzer_id equals an.id
							select new
							{
								Код = ser.code,
								Название = ser.service_name,
								Стоимость = ser.cost,
								Результат = work.result,
								Анализатор = an.name,
							};
				dgService.ItemsSource = query.ToList();
			}
		}

		private void nazad_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = new MainWindow();
			mainWindow.Show();
			this.Hide();
		}
	}
}
