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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Desktop_App
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Loaded += Window_Loaded;
		}
		private int loginA = 0;
		private const int maxLoginA = 1;
		private bool captchaEnabled = false;
		
		private void btvxod_Click(object sender, RoutedEventArgs e)
		{
			string log = tbLogin.Text;
			string pass = passBox.Password;
			try
			{
				using (var db = new MedicalLaboratoryEntities3())
				{
					var usern = db.user.FirstOrDefault(us => us.login  == log && us.password == pass);
					var rol = db.role;
					if (usern == null)
					{
						if (loginA >= maxLoginA)
						{
							captchaEnabled = true;
							CapTB1.Text = captcha();
							CapTB.Visibility = Visibility.Visible;
						}
						MessageBox.Show("Неверно введен логин или пароль!");
						loginA++;
					}
					else
					{
						if (usern.role == 1)
						{
							MessageBox.Show("Вы пациент!");
						}
						else if (usern.role == 2)
						{
							user currentUser = GetUserFromDatabase(log, pass);
							AdminWindow adminForm = new AdminWindow(currentUser);
							adminForm.Show();
							Close();
						}
						else if (usern.role == 3)
						{
							user currentUser = GetUserFromDatabase(log, pass);
							AccountantWindow accountantWindow = new AccountantWindow(currentUser);
							accountantWindow.Show();
							this.Hide();
						}
						else if (usern.role == 4)
						{
							user currentUser = GetUserFromDatabase(log, pass);
							LabAssistantWindow labAssistantWindow = new LabAssistantWindow(currentUser);
							labAssistantWindow.Show();
							this.Hide();
						}
						else if (usern.role == 5)
						{
							user currentUser = GetUserFromDatabase(log, pass);
							LabAssisResearcherWindow labAssisResearcher = new LabAssisResearcherWindow(currentUser);
							labAssisResearcher.Show();
							this.Hide();
						}
						else { MessageBox.Show("Ошибка"); }
					}
				}
			}
			catch { MessageBox.Show("Не удалось подключиться в БД"); }
		}
		private user GetUserFromDatabase(string login, string password)
		{
			using (var db = new MedicalLaboratoryEntities3())
			{
				var usern = db.user.FirstOrDefault(u => u.login == login && u.password == password);
				return usern;
			}
		}
		public string captcha()
		{
			Random rnd = new Random();
			char[] z = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'v', 'L', 'M', 'v', 'N', 'v', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'v', 'W', 'X', 'Y', 'Z', 'v', };

			string captcha = "";

			for (int i = 0; i != 8; i++)
			{
				int j = rnd.Next(0, 62);
				captcha += z[j];
			}
			return captcha;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			CapTB.Visibility = Visibility.Collapsed;
		}
	}
}