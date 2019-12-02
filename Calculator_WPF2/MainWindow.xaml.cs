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

namespace Calculator_WPF2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected const string odin = "1";
        protected const string dva = "2";
        protected const string tri = "3";
        protected const string chetire = "4";
        protected const string pyat = "5";
        protected const string shest = "6";
        protected const string sem = "7";
        protected const string vosem = "8";
        protected const string devyat = "9";
        protected const string nul = "0";


        public MainWindow()
        {
            InitializeComponent();
        }


        private void normalCalcBut_Click(object sender, RoutedEventArgs e)
        {
            Grid1.ColumnDefinitions[6].Width = new GridLength(0);
            Grid1.ColumnDefinitions[7].Width = new GridLength(0);
            calcWindow.Width = 390;
        }

        private void engeneeringCalcBut_Click(object sender, RoutedEventArgs e)
        {
            Grid1.ColumnDefinitions[6].Width = new GridLength(70);
            Grid1.ColumnDefinitions[7].Width = new GridLength(70);
            calcWindow.Width = 530;
        }

        /// <summary>
        /// Обработчики для кнопок  обращаются к методу chislonaEkrane класса mehanizmcalkulyatora
        /// и передают ему одну из постоянных (odin, dva, tri  и т.д.). Результат, возвращаемый методом,
        /// присваивается  свойству Text текстового поля txtOutput.
        /// </summary>

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            textBoxMain.Text = mehanizmcalkulyatora.chislonaEkrane(odin);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            textBoxMain.Text = mehanizmcalkulyatora.chislonaEkrane(dva);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            textBoxMain.Text = mehanizmcalkulyatora.chislonaEkrane(tri);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            textBoxMain.Text = mehanizmcalkulyatora.chislonaEkrane(chetire);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            textBoxMain.Text = mehanizmcalkulyatora.chislonaEkrane(pyat);
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            textBoxMain.Text = mehanizmcalkulyatora.chislonaEkrane(shest);
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            textBoxMain.Text = mehanizmcalkulyatora.chislonaEkrane(sem);
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            textBoxMain.Text = mehanizmcalkulyatora.chislonaEkrane(vosem);
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            textBoxMain.Text = mehanizmcalkulyatora.chislonaEkrane(devyat);
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            textBoxMain.Text = mehanizmcalkulyatora.chislonaEkrane(nul);
        }

        private void btnChangeSign_Click(object sender, RoutedEventArgs e)
        {
            textBoxMain.Text = mehanizmcalkulyatora.ZnakChisla();
        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            textBoxMain.Text = mehanizmcalkulyatora.ZnakTochki();
        }

        /// <summary>
        /// Обработчики кнопок действия калькулятора передают 
        /// методу DeystvieCalculatora класса mehanizmcalkulyatora переменную перечисления Deystvie.
        /// </summary>

        private void btnDelenie_Click(object sender, RoutedEventArgs e)
        {
            mehanizmcalkulyatora.DeystvieCalculatora(mehanizmcalkulyatora.Deystvie.Delenie);
            textBoxSec.Text = textBoxMain.Text + " " + "/";
            textBoxMain.Text = "0";
        }

        private void btnUmnojenie_Click(object sender, RoutedEventArgs e)
        {
            mehanizmcalkulyatora.DeystvieCalculatora(mehanizmcalkulyatora.Deystvie.Umnojenie);
            textBoxSec.Text = textBoxMain.Text + " " + "*";
            textBoxMain.Text = "0";
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            mehanizmcalkulyatora.DeystvieCalculatora(mehanizmcalkulyatora.Deystvie.Vichitanie);
            textBoxSec.Text = textBoxMain.Text + " " + "-";
            textBoxMain.Text = "0";
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            mehanizmcalkulyatora.DeystvieCalculatora(mehanizmcalkulyatora.Deystvie.Slojenie);
            textBoxSec.Text = textBoxMain.Text + " " + "+";
            textBoxMain.Text = "0";
        }

        private void btnRavno_Click(object sender, RoutedEventArgs e)
        {
            textBoxMain.Text = mehanizmcalkulyatora.ZnakRavno();
            mehanizmcalkulyatora.Sbros();
            textBoxSec.Text = "";
        }

        private void btnSbros_Click(object sender, RoutedEventArgs e)
        {
            mehanizmcalkulyatora.Sbros();
            textBoxMain.Text = "0";
            textBoxSec.Text = "";
        }

        private void pow2But_Click(object sender, RoutedEventArgs e)
        {
            mehanizmcalkulyatora.DeystvieCalculatora(mehanizmcalkulyatora.Deystvie.pow2);
            textBoxSec.Text = "sqr( " + textBoxMain.Text + " )";
            textBoxMain.Text = mehanizmcalkulyatora.chislonaEkrane(odin);
            textBoxMain.Text = mehanizmcalkulyatora.ZnakRavno();
            mehanizmcalkulyatora.Sbros();
            //lastNumberTextBox.Text = "";
            //txtOutput.Text = "0";
        }

        private void powBut_Click(object sender, RoutedEventArgs e)
        {
            mehanizmcalkulyatora.DeystvieCalculatora(mehanizmcalkulyatora.Deystvie.pow);
            textBoxSec.Text = textBoxMain.Text + " ^ ";
            textBoxMain.Text = "0";
        }


        private void sqrtBut_Click(object sender, RoutedEventArgs e)
        {
            mehanizmcalkulyatora.DeystvieCalculatora(mehanizmcalkulyatora.Deystvie.sqrt);
            textBoxSec.Text = "sqrt( " + textBoxMain.Text + " )";
            textBoxMain.Text = mehanizmcalkulyatora.chislonaEkrane(odin);
            textBoxMain.Text = mehanizmcalkulyatora.ZnakRavno();
            mehanizmcalkulyatora.Sbros();
            //lastNumberTextBox.Text = "";
        }

        private void sqrt3But_Click(object sender, RoutedEventArgs e)
        {
            mehanizmcalkulyatora.DeystvieCalculatora(mehanizmcalkulyatora.Deystvie.sqrt3);
            textBoxSec.Text = "cuberroot( " + textBoxMain.Text + " )";
            textBoxMain.Text = mehanizmcalkulyatora.chislonaEkrane(odin);
            textBoxMain.Text = mehanizmcalkulyatora.ZnakRavno();
            mehanizmcalkulyatora.Sbros();
            //lastNumberTextBox.Text = "";
        }

        private void absBut_Click(object sender, RoutedEventArgs e)
        {
            mehanizmcalkulyatora.DeystvieCalculatora(mehanizmcalkulyatora.Deystvie.abs);
            textBoxSec.Text = "abs( " + textBoxMain.Text + " )";
            textBoxMain.Text = mehanizmcalkulyatora.chislonaEkrane(odin);
            textBoxMain.Text = mehanizmcalkulyatora.ZnakRavno();
            mehanizmcalkulyatora.Sbros();
            //lastNumberTextBox.Text = "";
        }

        private void factBut_Click(object sender, RoutedEventArgs e)
        {
            mehanizmcalkulyatora.DeystvieCalculatora(mehanizmcalkulyatora.Deystvie.fact);
            textBoxSec.Text = "fact( " + textBoxMain.Text + " )";
            textBoxMain.Text = mehanizmcalkulyatora.chislonaEkrane(odin);
            textBoxMain.Text = mehanizmcalkulyatora.ZnakRavno();
            mehanizmcalkulyatora.Sbros();
        }

        private void x2_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            textBoxMain.Text = Program.Equation();
            this.Show();
        }

        
    }
}
