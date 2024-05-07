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
	/// Логика взаимодействия для LabAssistantWindow.xaml
	/// </summary>
	public partial class LabAssistantWindow : Window
	{
		private user currentUser;
		public LabAssistantWindow(user users)
		{
			InitializeComponent();
			currentUser = users;
		}
		private void AdminWindow_Loaded(object sender, RoutedEventArgs e)
		{
			lbUserLastname.Content = currentUser.lastname;
			lbUserName.Content = currentUser.name;
		}
		private void nazad_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = new MainWindow();
			mainWindow.Show();
			Close();
		}
    }
}
