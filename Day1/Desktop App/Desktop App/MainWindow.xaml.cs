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
		}

		private void btvxod_Click(object sender, RoutedEventArgs e)
		{
			string log = tbLogin.Text;
			string pass = passBox.Password;
			try
			{
				using (var db = new MedicalLaboratoryEntities1())
				{
					var usern = db.user.FirstOrDefault(us => us.login  == log && us.password == pass);
					var rol = db.role;
					if (usern == null)
					{
						MessageBox.Show("Неверно введен логин или пароль!");
					}
					else
					{
						var roles = db.role.FirstOrDefault(r => r.id == usern.id);
						if (roles.name != null)
						{
							if (roles.name == "Админ")
							{
								AdminWindow adminWindow = new AdminWindow();
								adminWindow.Show();
								this.Hide();
							}
							else if (roles.name == "Бухгалтер")
							{
								AccountantWindow accountantWindow = new AccountantWindow();
								accountantWindow.Show();
								this.Hide();
							}
							else if (roles.name == "Лаборант")
							{
								LabAssistantWindow labAssistantWindow = new LabAssistantWindow();
								labAssistantWindow.Show();
								this.Hide();
							}
							else if (roles.name == "Пациент")
							{
								MessageBox.Show("Вы пациент!");
							}
						}
					}
				}
			}
			catch { MessageBox.Show("Не удалось подключиться в БД"); }
		}
	}
}
