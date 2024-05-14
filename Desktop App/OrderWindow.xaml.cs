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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using static System.Net.Mime.MediaTypeNames;


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
			using (var db = new MedicalLaboratoryEntities())
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
			AS();
		}
		private void AS()
		{
			// Формирование кода
			try
			{
				int code = int.Parse(tbCode.Text);
				DateTime lastOrderNumber = DateTime.Now;
				if (!int.TryParse(tbCode.Text, out code))
				{
					MessageBox.Show("Введенный код не является числом", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}
				string uniqueCode = GenerateUniqueCode();
				string barcode = $"{code}{lastOrderNumber.ToString("yyyyMMdd")}{uniqueCode}";
				QRCodeEncoder encoder = new QRCodeEncoder();
				Bitmap qrcode = encoder.Encode(barcode);
				MemoryStream ms = new MemoryStream();
				((System.Drawing.Bitmap)qrcode).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
				BitmapImage image = new BitmapImage();
				image.BeginInit();
				ms.Seek(0, SeekOrigin.Begin);
				image.StreamSource = ms;
				image.EndInit();
				im.Source = image;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		private string GenerateUniqueCode()
		{
			Random random = new Random();
			const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			return new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
		}
		private void btorder_Click(object sender, RoutedEventArgs e)
		{
			using (var db = new MedicalLaboratoryEntities())
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
		private void tbCode_KeyDown(object sender, KeyEventArgs e)
		{
			AS();
		}
		private void SaveBtn_Click(object sender, RoutedEventArgs e)
		{
			PngBitmapEncoder encoder = new PngBitmapEncoder();
			encoder.Frames.Add(BitmapFrame.Create((BitmapSource)im.Source));
			using (MemoryStream ms = new MemoryStream())
			{
				encoder.Save(ms);
				byte[] imageBytes = ms.ToArray();
				iTextSharp.text.Document doc = new iTextSharp.text.Document();
				string uniqueCode = GenerateUniqueCode();
				PdfWriter.GetInstance(doc, new FileStream($"pdfDoc{uniqueCode}.pdf", FileMode.Create));
				doc.Open();
				iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(imageBytes);
				doc.Add(pdfImage);
				doc.Close();
			}
			MessageBox.Show("PDF-документ сохранен");		
		}
		private void btAdd_Click(object sender, RoutedEventArgs e)
		{
			AddPatientWindow window = new AddPatientWindow();
			window.ShowDialog();
		}
	}
}