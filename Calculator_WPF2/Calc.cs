using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calculator_WPF2
{
		public class Calc 
        {
	
        }

        public class mehanizmcalkulyatora
        {
	        /// <summary>
	        ///—оздаем перечисление Deystvie, дл€ определени€ одного из четырех действи€ калькул€тора.
	        /// </summary>
		    public enum Deystvie:int
		    {
			    NeopredelDeystvie = 0,
			    Slojenie = 1,
			    Vichitanie = 2,
			    Umnojenie = 3,
			    Delenie = 4,
                pow2 = 5,
                pow = 6,
                sqrt = 7,
                sqrt3 = 8,
                abs = 9,
                fact = 10
		    }

	        /// <summary>
	        /// ќбъ€вл€ем и инициализируем переменную, 
	        /// котора€ будет использоватьс€ дл€ смены знака при нажатии клавиши (+/-)
	        /// </summary>

		    private static double peremennayaMinus = -1;

		    /// <summary>
		    /// ќбъвл€ем переменные, дл€ работы калькул€тора:
		    /// resultatVichisleniy - переменна€ дл€ хранени€
		    ///  промежуточного результата в механизме калькул€тора
		    ///  resultatOutput - переменна€, значение которой будет сниматьс€ с экрана и  выводитьс€ на него.
		    ///  tekusheeDeystvieCalculatora - хранение одного из действи€ калькул€тора.
		    ///  pervoeChislo - переменна€, в которую будет записыватьс€ число на экране
		    ///   до нажати€ на одну из четырех кнопок с действием.
		    ///  vtoroeChislo - второе число на экране.
		    ///  dobavlenierazryada при добавлении следующего  разр€да эта переменна€ примет значение true;
		    ///  ChislosTochkoy при добавлении дес€тичного разр€да (знака точки) эта переменна€ примет значение true
		    /// </summary>
	
		    private static double resultatVichisleniy;
		    private static string resultatOutput;
		    private static Deystvie tekusheeDeystvieCalculatora;
		    private static double pervoeChislo;
		    private static double vtoroeChislo;
		    private static bool dobavlenierazryada;
		    private static bool ChislosTochkoy;
 
		    /// <summary>
		    /// ¬ конструкторе класса mehanizmcalkulyatora инициализируем переменные 
		    /// ChislosTochkoy и dobavlenierazryada - при запуске калькул€тора на экране 
		    /// нет ни разр€дности, ни дес€тичной части.
		    /// </summary>

		    //public static mehanizmcalkulyatora ()
		    //{
			   // ChislosTochkoy = false;
			   // dobavlenierazryada = false;
		    //}

			
		    /// <summary>
		    /// ¬ этом методе переменна€ resultatOutput измен€етс€ - при вводе числа ее значение перезаписываетс€.
		    /// </summary>
		

		    public static string chislonaEkrane (string najatayaKlavisha)
		    {
                resultatOutput = resultatOutput + najatayaKlavisha;

                return (resultatOutput);
		    }

            /// <summary>
            /// ћетод, в котором определ€етс€ peremenDeystviya - одно значение перечислени€ Deystvie,
            ///в зависимости от выбора  клавиши +, -, *,  или /
            /// </summary>

            public static void DeystvieCalculatora(Deystvie peremenDeystviya)
            {
                try
                {
                    if (resultatOutput != "" && !dobavlenierazryada)
                    {
                        pervoeChislo = System.Convert.ToDouble(resultatOutput);
                        tekusheeDeystvieCalculatora = peremenDeystviya;
                        resultatOutput = "";
                        ChislosTochkoy = false;
                    }
                }

                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.ToString());
                }
                finally
                {

                }
            }



            /// <summary>
            /// ѕри нажатии  кнопки +/- число на экране - tekusheeChislo умножаетс€ на -1,
            ///  а затем результат снова присваиваетс€ переменной resultatOutput.
            /// </summary>


                public static string ZnakChisla ()
		    {
			    double tekusheeChislo;

			    if (resultatOutput != "")
			    {
				    tekusheeChislo = System.Convert.ToDouble (resultatOutput);
				    resultatOutput = System.Convert.ToString(tekusheeChislo * peremennayaMinus);
			    }
		
			    return (resultatOutput);
		    }

		    /// <summary>
		    /// ѕри нажатии кнопки ( , ) переменна€ resultatOutput приобретает дробную часть.
		    /// </summary>
	

		    public static string ZnakTochki ()
		    {
			    if (!ChislosTochkoy && !dobavlenierazryada)
			    {
				    if (resultatOutput != "")
					    resultatOutput = resultatOutput + ",";
				    else
					    resultatOutput = "0,";

				    ChislosTochkoy = true;
			    }

			    return (resultatOutput);
		    }

	    /// <summary>
	    /// ѕри нажатии кнопки ZnakRavno обрабатываютс€ значени€ 
	    /// переменнных pervoeChislo и vtoroeChislo, результат присваиваетс€ переменной resultatVichisleniy 
	    /// котора€  затем преобразуетс€ в resultatOutput.
	    /// </summary>


		public static string ZnakRavno ()
		{
			bool proverkaOshibok = false;

			if (resultatOutput != "")
			{
				vtoroeChislo = System.Convert.ToDouble (resultatOutput);
				dobavlenierazryada = true;

				switch (tekusheeDeystvieCalculatora)
				{
					case Deystvie.NeopredelDeystvie:
						proverkaOshibok = false;
						break;

					case Deystvie.Slojenie:
						resultatVichisleniy = pervoeChislo + vtoroeChislo;
						proverkaOshibok = true;
						break;

					case Deystvie.Vichitanie:
						resultatVichisleniy = pervoeChislo - vtoroeChislo;
						proverkaOshibok = true;
						break;

					case Deystvie.Umnojenie:
						resultatVichisleniy = pervoeChislo * vtoroeChislo;
						proverkaOshibok = true;
						break;

					case Deystvie.Delenie:
						resultatVichisleniy = pervoeChislo / vtoroeChislo;
						proverkaOshibok = true;
						break;

                    case Deystvie.pow2:
                        resultatVichisleniy = Math.Pow(pervoeChislo,2);
                        proverkaOshibok = true;
                        break;

                    case Deystvie.pow:
                        resultatVichisleniy = Math.Pow(pervoeChislo, vtoroeChislo);
                        proverkaOshibok = true;
                        break;

                    case Deystvie.sqrt:
                        resultatVichisleniy = Math.Sqrt(pervoeChislo);
                        proverkaOshibok = true;
                        break;

                    case Deystvie.sqrt3:
                        resultatVichisleniy = Math.Pow(pervoeChislo, 1.0 / 3.0); 
                        proverkaOshibok = true;
                        break;

                    case Deystvie.abs:
                        resultatVichisleniy = Math.Abs(pervoeChislo);
                        proverkaOshibok = true;
                        break;

                    case Deystvie.fact:
                        int f = 1;
                        while (pervoeChislo > 1)
                        {
                            f *= (int)pervoeChislo--;
                        }
                        resultatVichisleniy = f;
                        proverkaOshibok = true;
                        break;

                    default:
						proverkaOshibok = false;
						break;
				}

				if (proverkaOshibok)
					resultatOutput = System.Convert.ToString (resultatVichisleniy);
			}
			
			return (resultatOutput);
		}

	    /// <summary>
	    /// ѕри нажатии кнопки  — (сброс) значени€ переменных обнул€ютс€.
	    /// </summary>

		public static void Sbros ()
		{
			resultatVichisleniy = 0;
			pervoeChislo = 0;
			vtoroeChislo = 0;
			resultatOutput = "";
            tekusheeDeystvieCalculatora = Deystvie.NeopredelDeystvie;
			ChislosTochkoy = false;
			dobavlenierazryada = false;			
		}
	}
}
