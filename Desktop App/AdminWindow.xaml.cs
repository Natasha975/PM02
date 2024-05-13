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
	/// Логика взаимодействия для AdminWindow.xaml
	/// </summary>
	public partial class AdminWindow : Window
	{
		private user currentUser;
		public AdminWindow(user users)
		{
			InitializeComponent();
			currentUser = users;
		}
		private void AdminWindow_Loaded(object sender, RoutedEventArgs e)
		{
			//using (var db = new MedicalLaboratoryEntities1())
			//{
			//	cmbTitleSong.ItemsSource = db.Album.ToList();
			//	cmbTitleSong.DisplayMemberPath = "Title";
			//}
			//LoadData();
			lbUserLastname.Content = currentUser.lastname;
			lbUserName.Content = currentUser.name;
		}
		private void nazad_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = new MainWindow();
			mainWindow.Show();
			Close();
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			ReportWindow window = new ReportWindow();
			window.ShowDialog();
        }
    }
}
