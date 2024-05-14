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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Desktop_App
{
	/// <summary>
	/// Логика взаимодействия для AddPatientWindow.xaml
	/// </summary>
	public partial class AddPatientWindow : Window
	{
		public AddPatientWindow()
		{
			InitializeComponent();
			using (var db = new MedicalLaboratoryEntities())
			{
				cbType.ItemsSource = db.ins_policy_type.ToList();
				cbComp.ItemsSource = db.ins_company.ToList();

				cbType.DisplayMemberPath = "name";
				cbComp.DisplayMemberPath = "company_name";
			}
		}
		private void btAdd_Click(object sender, RoutedEventArgs e)
		{
			string login = RegisterVisitor(tbEmail.Text);
			using (var db = new MedicalLaboratoryEntities())
			{
				try
				{
					int maxIdUs = db.user.Max(u => u.id) + 1;
					int maxIdUsAdd = db.add_inform.Max(u => u.id) + 1;
					string log = $"{login}{maxIdUs}";
					string uniqueCode = GenerateUniqueCode();
					int ser = int.Parse(tbSer.Text);
					int numb = int.Parse(tbNum.Text);

					var newUs = new user
					{
						id =maxIdUs,
						lastname = tbLastname.Text,
						name = tbName.Text,
						surname = tbSurname.Text,
						role = 1,
						login = log,
						password = uniqueCode,
					};
					var newUsAdd = new add_inform
					{
						id =maxIdUsAdd,
						user_id = maxIdUs,
						date_of_birth = dpDay.SelectedDate.Value,
						passport_series = ser,
						passport_number = numb,
						phone = tbPhone.Text,
						email = tbEmail.Text,
					};
					newUsAdd.ins_policy_type = (cbType.SelectedItem as ins_policy_type).id;
					newUsAdd.ins_company_id = (cbComp.SelectedItem as ins_company).id;

					var usern1 = db.add_inform.FirstOrDefault(Users => Users.passport_series == ser && Users.passport_number == numb);
					if (usern1 == null)
					{
						db.user.Add(newUs);
						db.add_inform.Add(newUsAdd);
						db.SaveChanges();
						MessageBox.Show("Пациент зарегистрирован!");
					}
					else
					{
						MessageBox.Show("Такой пациент существует!");
					}
				}
				catch (Exception ex) { MessageBox.Show("Ошибка при добавлении пациента: " + ex.Message); }
			}
		}
		public string RegisterVisitor(string email)
		{
			if (string.IsNullOrWhiteSpace(email))
			{
				throw new ArgumentException("Требуется адрес электронной почты");
			}
			string login = GenerateUniqueLogin(email);
			return login;
		}
		private string GenerateUniqueLogin(string email)
		{
			string username = email.Substring(0, email.IndexOf('@'));
			string login = $"{username}";
			return login;
		}
		private string GenerateUniqueCode()
		{
			Random random = new Random();
			const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
		}
		private void tbSer_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0))
			{
				e.Handled = true;
			}
		}
	}
}