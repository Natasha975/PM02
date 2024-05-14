using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text;


namespace Desktop_App
{
	/// <summary>
	/// Логика взаимодействия для AccountantWindow.xaml
	/// </summary>
	public partial class AccountantWindow : Window
	{
		private user currentUser;
		public AccountantWindow(user users)
		{
			InitializeComponent();
			currentUser = users;
		}
		private void nazad_Click(object sender, RoutedEventArgs e)
		{
			MainWindow mainWindow = new MainWindow();
			mainWindow.Show();
			Hide();
		}
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			lbUserLastname.Content = currentUser.lastname;
			lbUserName.Content = currentUser.name;
			LoadDates();
		}
		private void LoadDates()
		{
			try
			{
				using (var db = new MedicalLaboratoryEntities3())
				{
					var query = from pay in db.payment_servic
								join or in db.order on pay.order_id equals or.id
								join us in db.user on or.user_id equals us.id
								join ad in db.add_inform on us.id equals ad.user_id
								join ins in db.ins_company on ad.ins_company_id equals ins.id
								select new
								{
									СтрКомпания = ins.company_name,
									Дата = or.creation_date,
									Фамилия = us.lastname,
									Имя = us.name,
									Отчество = us.surname,
									Номер = ad.ins_policy_number,
									Цена = pay.price,
								};
					dgChet.ItemsSource = query.ToList();
				}
			}
			catch (Exception ex) { MessageBox.Show("Ошибка" + ex.Message); }
		}
		private void LoadDate()
		{
			try
			{
				DateTime startDate = dpStart.SelectedDate ?? DateTime.MinValue;
				DateTime endDate = dpEnd.SelectedDate ?? DateTime.MaxValue;
				using (var db = new MedicalLaboratoryEntities3())
				{
					var query = from pay in db.payment_servic
								join or in db.order on pay.order_id equals or.id
								join us in db.user on or.user_id equals us.id
								join ad in db.add_inform on us.id equals ad.user_id
								join ins in db.ins_company on ad.ins_company_id equals ins.id
								where or.creation_date >= startDate && or.creation_date <= endDate
								select new
								{
									СтрКомпания = ins.company_name,
									Дата = or.creation_date,
									Фамилия = us.lastname,
									Имя = us.name,
									Отчество = us.surname,
									Номер = ad.ins_policy_number,
									Цена = pay.price,
								};
					dgChet.ItemsSource = query.ToList();
				}
			}
			catch (Exception ex) { MessageBox.Show("Ошибка" + ex.Message); } 
		}
		private void btPdfSave_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				iTextSharp.text.Document doc = new iTextSharp.text.Document();
				PdfWriter.GetInstance(doc, new FileStream("pdfTables.pdf", FileMode.Create));
				doc.Open();
				BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\Arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
				iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
				PdfPTable table = new PdfPTable(dgChet.Columns.Count);
				foreach (DataGridColumn column in dgChet.Columns)
				{
					PdfPCell cell = new PdfPCell(new Phrase(column.Header.ToString(), font));
					cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
					table.AddCell(cell);
				}
				//foreach (DataRow row in (dgChet.ItemsSource as DataView).ToTable().Rows);
				//{
				//	foreach (DataGridColumn column in dgChet.Columns)
				//	{
				//		table.AddCell(new Phrase(row[column.DisplayIndex].ToString(), font));
				//	}
				//}
				doc.Add(table);
				doc.Close();
				MessageBox.Show("Pdf-документ сохранен");
			} catch (Exception ex) { MessageBox.Show("Ошибка" + ex.Message); }			
		}
		private void btCsvSave_Click(object sender, RoutedEventArgs e)
		{
			
		}
		private void dpStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
		{
			LoadDate();
		}
		private void btOp_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}