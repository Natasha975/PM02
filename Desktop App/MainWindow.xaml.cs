using System;
using System.Linq;
using System.Windows;

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
			DateTime loginDate = DateTime.Now;
			try
			{
				using (var db = new MedicalLaboratoryEntities3())
				{
					var usern = db.user.FirstOrDefault(us => us.login  == log && us.password == pass);
					var rol = db.role;
					if (usern == null)
					{
						if (loginA > maxLoginA)
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
							var authorization = new authorization();
							int last = db.authorization.Max(u => u.id) + 1;
							authorization.id = last;
							authorization.user_id = usern.id;
							authorization.last_date_of_entry = loginDate;
							db.authorization.Add(authorization);
							db.SaveChanges();
						}
						else if (usern.role == 2)
						{
							user currentUser = GetUserFromDatabase(log, pass);
							AdminWindow adminForm = new AdminWindow(currentUser);
							adminForm.Show();
							Close();
							var authorization = new authorization();
							int last = db.authorization.Max(u => u.id) + 1;
							authorization.id = last;
							authorization.user_id = usern.id;
							authorization.last_date_of_entry = loginDate;
							db.authorization.Add(authorization);
							db.SaveChanges();
						}
						else if (usern.role == 3)
						{
							user currentUser = GetUserFromDatabase(log, pass);
							AccountantWindow accountantWindow = new AccountantWindow(currentUser);
							accountantWindow.Show();
							this.Hide();
							var authorization = new authorization();
							int last = db.authorization.Max(u => u.id) + 1;
							authorization.id = last;
							authorization.user_id = usern.id;
							authorization.last_date_of_entry = loginDate;
							db.authorization.Add(authorization);
							db.SaveChanges();
						}
						else if (usern.role == 4)
						{
							user currentUser = GetUserFromDatabase(log, pass);
							LabAssistantWindow labAssistantWindow = new LabAssistantWindow(currentUser);
							labAssistantWindow.Show();
							this.Hide();
							var authorization = new authorization();
							int last = db.authorization.Max(u => u.id) + 1;
							authorization.id = last;
							authorization.user_id = usern.id;
							authorization.last_date_of_entry = loginDate;
							db.authorization.Add(authorization);
							db.SaveChanges();
						}
						else if (usern.role == 5)
						{
							user currentUser = GetUserFromDatabase(log, pass);
							LabAssisResearcherWindow labAssisResearcher = new LabAssisResearcherWindow(currentUser);
							labAssisResearcher.Show();
							this.Hide();
							var authorization = new authorization();
							int last = db.authorization.Max(u => u.id) + 1;
							authorization.id = last;
							authorization.user_id = usern.id;
							authorization.last_date_of_entry = loginDate;
							db.authorization.Add(authorization);
							db.SaveChanges();
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
			for (int i = 0; i != 4; i++)
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
		private void cbSee_Checked(object sender, RoutedEventArgs e)
		{
			string a = passBox.Password;
			tb.Text = a;
			passBox.Visibility = Visibility.Hidden;
			tb.Visibility = Visibility.Visible;
		}
		private void cbSee_Unchecked(object sender, RoutedEventArgs e)
		{
			string a = tb.Text;
			passBox.Password = a;
			tb.Visibility = Visibility.Hidden;
			passBox.Visibility = Visibility.Visible;
		}
	}
}