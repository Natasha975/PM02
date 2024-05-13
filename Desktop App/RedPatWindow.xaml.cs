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
using System.Xml.Linq;

namespace Desktop_App
{
	/// <summary>
	/// Логика взаимодействия для RedPatWindow.xaml
	/// </summary>
	public partial class RedPatWindow : Window
	{
		public RedPatWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			using (var db = new MedicalLaboratoryEntities3())
			{
				cbPat.ItemsSource = db.user.ToList();
				cbPat.DisplayMemberPath = "lastname";
			}
        }
		private void cbPat_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (cbPat.SelectedItem != null)
			{
				string lastna = cbPat.SelectedItem.ToString();

				using (var db = new MedicalLaboratoryEntities3())
				{
					var patient = db.user.FirstOrDefault(u => u.lastname == lastna);
					var day = db.add_inform.FirstOrDefault(i => i.user_id == patient.id)?.date_of_birth.Value;
					var phone = db.add_inform.FirstOrDefault(i => i.user_id == patient.id)?.phone;
					var email = db.add_inform.FirstOrDefault(i => i.user_id == patient.id)?.email;
					var polic = db.add_inform.FirstOrDefault(i => i.user_id == patient.id)?.ins_policy_number;

					lbFam.Content = patient.lastname;
					lbName.Content = patient.name;
					lbSurn.Content = patient.surname;
					lbbith.Content = day;
					tbPhone.Text = phone;
					tbEmail.Text = email;
					tbPolice.Text = polic;
				}
			}
		}
		private void btSave_Click(object sender, RoutedEventArgs e)
		{
			string surname = cbPat.SelectedItem.ToString();
			using (var db = new MedicalLaboratoryEntities3())
			{
				var patient = db.user.FirstOrDefault(u => u.lastname == surname);
				var phone = db.add_inform.FirstOrDefault(i => i.user_id == patient.id);
				phone.phone = tbPhone.Text;
				var email = db.add_inform.FirstOrDefault(i => i.user_id == patient.id);
				email.email = tbEmail.Text;
				var police = db.add_inform.FirstOrDefault(i => i.user_id == patient.id);
				police.ins_policy_number = tbPolice.Text;
				db.SaveChanges();
			}
		}
	}
}
