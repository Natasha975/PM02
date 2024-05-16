using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Chart
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			float scale = 10.0f;
			e.Graphics.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2);
			e.Graphics.ScaleTransform(1, -1);
			DrawLine(e.Graphics, new double[] { 2, 1 }, 10, scale);
			DrawLine(e.Graphics, new double[] { -2, 3 }, 6, scale);
			DrawLine(e.Graphics, new double[] { 2, 4 }, 8, scale);

			// Построение целевой функции
			DrawLine(e.Graphics, new double[] { 3, 4 }, 0, scale);

			// Поиск оптимального решения
			double[] optimalSolution = FindOptimalSolution();

			// Отображение оптимального решения
			DrawPoint(e.Graphics, optimalSolution, scale);

			e.Graphics.DrawLine(new Pen(Color.Black, 2f), 0, 0, 0, 200);
			e.Graphics.DrawLine(new Pen(Color.Black, 2f), 0, 0, 200, 0);
		}
		// Метод для построения линии
		private void DrawLine(Graphics g, double[] coefficients, double constant, float scale)
		{ 
			// Вычисление точек пересечения с осями
			double x1 = 0;
			double y1 = constant / coefficients[1];
			double x2 = constant / coefficients[0];
			double y2 = 0;
			// Масштабировать координаты
			x1 *= scale;
			y1 *= scale;
			x2 *= scale;
			y2 *= scale;

			// Рисование линии
			g.DrawLine(Pens.Red, (float)x1, (float)y1, (float)x2, (float)y2);
		}

		// Метод для поиска оптимального решения
		private double[] FindOptimalSolution()
		{
			double[] intersection1 = FindIntersection(new double[] { 2, 1 }, 10);
			double[] intersection2 = FindIntersection(new double[] { -2, 3 }, 6);
			double[] intersection3 = FindIntersection(new double[] { 2, 4 }, 8);

			double[] optimalSolution = FindIntersection(new double[] { 2, 3 }, 0, intersection1, intersection2, intersection3);

			return optimalSolution;
		}

		private double[] FindIntersection(double[] coefficients1, double constant1, params double[][] otherIntersections)
		{
			double[] intersection = new double[2];

			foreach (double[] otherIntersection in otherIntersections)
			{
				double x = (constant1 - otherIntersection[1]) / (coefficients1[1] - otherIntersection[1]);
				double y = coefficients1[0] * x + constant1;

				if (x >= 0 && y >= 0)
				{
					intersection[0] = x;
					intersection[1] = y;
					break;
				}
			}

			return intersection;
		}

		private void DrawPoint(Graphics g, double[] point, float scale)
		{
			float x = (float)(point[0] * scale);
			float y = (float)(point[1] * scale);

			g.FillEllipse(Brushes.Red, x - 2, y - 2, 4, 4);
		}
	}
}