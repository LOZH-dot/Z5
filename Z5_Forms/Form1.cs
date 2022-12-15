using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Z5_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ResultButton_Click(object sender, EventArgs e)
        {
            double a, b, h;

            try
            {
                a = double.Parse(ATextBox.Text);

                b = double.Parse(BTextBox.Text);

                if (a > b) throw new Exception("Начальное значение интервала не может быть больше конечного!");

                h = double.Parse(HTextBox.Text);

                if (h == .0) throw new Exception("Введите шаг отличный от нуля!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат введенных данных");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            string result = "Результат:\n";

            for (double i = a; i < b; i += h)
            {
                result += ($"x: {i} ");
                try
                {
                    result += ($"y: {f(i)}\n");
                }
                catch
                {
                    result += ($"y: не определена в точке x\n");
                }
            }

            ResultTextBox.Text = result;
        }

        static double f(double x)
        {
            double y = Math.Sqrt((x * x * x) - 1) / Math.Sqrt((x * x) - 1);

            if (double.IsNaN(y)
                || double.IsInfinity(y)
                ) throw new NotFiniteNumberException();

            return y;

        }
    }
}
