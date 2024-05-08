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
using System.Data.Entity;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.IO;
using Aspose.BarCode;
using Aspose.BarCode.BarCodeRecognition;
using Aspose.BarCode.Generation;
using System.Drawing;
using System.Windows.Interop;
using System.Windows.Controls.Primitives;
using System.Xml.Linq;


namespace Desktop_App
{
	/// <summary>
	/// Логика взаимодействия для OrderWindow.xaml
	/// </summary>
	public partial class OrderWindow : Window
	{
		private user currentUser;
		public OrderWindow(user users)
		{
			InitializeComponent();
			currentUser = users;	
			using (var db = new MedicalLaboratoryEntities2())
			{
				int last = db.order.Max(u => u.id) + 1;
				tbCode.Text = last.ToString();

				cbOrder.ItemsSource = db.order.ToList();
				cbService.ItemsSource = db.service.ToList();
				cbUser.ItemsSource = db.user.ToList();
				cbBio.ItemsSource = db.biomaterial;

				cbOrder.DisplayMemberPath = "name";
				cbService.DisplayMemberPath = "name";
				cbUser.DisplayMemberPath = "lastname";
				cbBio.DisplayMemberPath = "name";
			}
		}
		private void nazad_Click(object sender, RoutedEventArgs e)
		{
			LabAssistantWindow lab = new LabAssistantWindow(currentUser);
			lab.Show();
			Close();
		}

		private void CodeBtn_Click(object sender, RoutedEventArgs e)
		{
			// Получение номера пробирки
			int code;
			int lastOrderNumber = int.Parse(tbCode.Text);
			if (!int.TryParse(tbCode.Text, out code))
			{
				MessageBox.Show("Введенный код не является числом", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			// Генерация уникального кода
			string uniqueCode = GenerateUniqueCode();

			// Формирование штрих-кода
			string barcode = $"{code}{lastOrderNumber.ToString("yyyyMMdd")}{uniqueCode}";

			// Сохранение штрих-кода в PDF
			//SaveBarcodeToPdf(barcode);

			// Отображение штрих-кода на экране
			DisplayBarcode(barcode);
		}
		private string GenerateUniqueCode()
		{
			Random random = new Random();
			const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
		}
		private void DisplayBarcode(string barcode)
		{
			Barcode barcod = new Barcode();
			// Установка данных для штрих-кода
			barcod.Text = barcode;
			// Установка типа штрих-кода
			barcod.BarcodeType = EncodeTypes.Code128;

			// Генерация изображения штрих-кода
			//Bitmap bitmap = barcod.;

			// Отображение изображения в окне приложения
			//im.Source = Imaging.CreateBitmapSourceFromHBitmap(
			//	bitmap.GetHbitmap(),
			//	IntPtr.Zero,
			//	Int32Rect.Empty,
			//	BitmapSizeOptions.FromEmptyOptions());
		}

		private void btorder_Click(object sender, RoutedEventArgs e)
		{
			using (var db = new MedicalLaboratoryEntities2())
			{
				try
				{
					var newOrder = new order();
					int idU = int.Parse(tbCode.Text);

					newOrder.id = idU;
					newOrder.creation_date = dpDate.SelectedDate.Value;

					try
					{
						db.order.Add(newOrder);
						db.SaveChanges();
						MessageBox.Show("Заказ создан!");
					}
					catch
					{
						MessageBox.Show("Заказ не может быть создан!");
					}
				}
				catch (Exception ex) { MessageBox.Show("Ошибка при добавлении посетителя: " + ex.Message); }
			}
		}
	}
}
