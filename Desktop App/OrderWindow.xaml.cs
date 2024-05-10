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
using System.Drawing.Imaging;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Reflection.Emit;


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
			using (var db = new MedicalLaboratoryEntities3())
			{
				int last = db.order.Max(u => u.id) + 1;
				tbCode.Text = last.ToString();

				cbOrder.ItemsSource = db.status_order.ToList();
				cbService.ItemsSource = db.status_service.ToList();
				cbUser.ItemsSource = db.user.ToList();
				cbBio.ItemsSource = db.biomaterial.ToList();

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
			try
			{
				if (tbCode.Text != "")
				{
					string qr = tbCode.Text;
					QRCodeEncoder encoder = new QRCodeEncoder();
					Bitmap qrcode = encoder.Encode(qr);
					MemoryStream ms = new MemoryStream();
					((System.Drawing.Bitmap)qrcode).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
					BitmapImage image = new BitmapImage();
					image.BeginInit();
					ms.Seek(0, SeekOrigin.Begin);
					image.StreamSource = ms;
					image.EndInit();
					im.Source = image;
				}
				else { MessageBox.Show("Ошибка"); }
				// Создать пустой MemoryStream
				//using (var memoryStream = new MemoryStream())
				//{
				// Сгенерировать штрих-код и сохранить его в MemoryStream
				//barcodeControl.
				//memoryStream.Write(barcod.GetImage(200, 200, false), 0, barcod.GetImage(200, 200, false).Length);
				// Создать BitmapImage из MemoryStream
				//var bitmapImage = new BitmapImage();
				//bitmapImage.BeginInit();
				//bitmapImage.StreamSource = memoryStream;
				//bitmapImage.EndInit();
				// Показать штрих-код на экране
				//im.Source = bitmapImage;
				//};
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			// Получение номера пробирки
			//int code;
			//int lastOrderNumber = int.Parse(tbCode.Text);
			//if (!int.TryParse(tbCode.Text, out code))
			//{
			//	MessageBox.Show("Введенный код не является числом", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
			//	return;
			//}
			//// Генерация уникального кода
			//string uniqueCode = GenerateUniqueCode();
			//// Формирование штрих-кода
			//string barcode = $"{code}{lastOrderNumber.ToString("yyyyMMdd")}{uniqueCode}";
			//// Сохранение штрих-кода в PDF
			////SaveBarcodeToPdf(barcode);
			//var imageType = "Png";
			//var imageFormat = (BarCodeImageFormat)Enum.Parse(typeof(BarCodeImageFormat), imageType.ToString());
			//// Отображение штрих-кода на экране
			//Barcode barcod = new Barcode();
			//barcod.Text = barcode;
			//barcod.BarcodeType = EncodeTypes.Code128;
			//barcod.ImageType = imageFormat;
			//try
			//{
			//	// Создать пустой MemoryStream
			//	//using (var memoryStream = new MemoryStream())
			//	//{
			//		// Сгенерировать штрих-код и сохранить его в MemoryStream
			//		//barcodeControl.
			//		//memoryStream.Write(barcod.GetImage(200, 200, false), 0, barcod.GetImage(200, 200, false).Length);
			//		// Создать BitmapImage из MemoryStream
			//		//var bitmapImage = new BitmapImage();
			//		//bitmapImage.BeginInit();
			//		//bitmapImage.StreamSource = memoryStream;
			//		//bitmapImage.EndInit();
			//		// Показать штрих-код на экране
			//		//im.Source = bitmapImage;
			//	//};
			//}
			//catch (Exception ex)
			//{
			//	MessageBox.Show(ex.Message);
			//}
		}
		private string GenerateUniqueCode()
		{
			Random random = new Random();
			const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
		}
		private void DisplayBarcode(string barcode)
		{
			// Генерация изображения штрих-кода
			//Bitmap bitmap = barcod.;

			// Отображение изображения в окне приложения
			//im.Source = Imaging.CreateBitmapSourceFromHBitmap(
			//	bitmap.GetHbitmap(),
			//	IntPtr.Zero,
			//	Int32Rect.Empty,
			//	BitmapSizeOptions.FromEmptyOptions());
		}
		//private string GenerateBarcode(Barcode barcod)
		//{
		//	Путь к изображению
		//	string imagePath = comboBarcodeType.Text + "." + barcode.ImageType;

		//	Инициализировать генератор штрих-кода
		//	BarcodeGenerator generator = new BarcodeGenerator(barcode.BarcodeType, barcode.Text);

		//	Сохранить изображение
		//	generator.Save(imagePath, barcode.ImageType);

		//	return imagePath;
		//}

		private void btorder_Click(object sender, RoutedEventArgs e)
		{
			using (var db = new MedicalLaboratoryEntities3())
			{
				try
				{
					var newOrder = new order();
					int idU = int.Parse(tbCode.Text);
					newOrder.id = idU;
					newOrder.creation_date = DateTime.Now;
					// Получение выбранного статуса заказа
					var selectedOrderStatus = (status_order)cbOrder.SelectedItem;
					newOrder.status_order = selectedOrderStatus.id;
					var selectedService = (status_service)cbService.SelectedItem;
					newOrder.status_servic = selectedService.id;
					var selectedUser = (user)cbUser.SelectedItem;
					newOrder.user_id = selectedUser.id;
					var selectedBiomaterial = (biomaterial)cbBio.SelectedItem;
					newOrder.biomaterial_id = selectedBiomaterial.id;
					try
					{
						db.order.Add(newOrder);
						db.SaveChanges();
						MessageBox.Show("Заказ оформлен!");
					}
					catch
					{
						MessageBox.Show("Заказ не может быть оформлен!");
					}
				}
				catch (Exception ex) { MessageBox.Show("Ошибка при добавлении посетителя: " + ex.Message); }
			}
		}
	}
}
