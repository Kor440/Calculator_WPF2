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
	        ///������� ������������ Deystvie, ��� ����������� ������ �� ������� �������� ������������.
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
	        /// ��������� � �������������� ����������, 
	        /// ������� ����� �������������� ��� ����� ����� ��� ������� ������� (+/-)
	        /// </summary>

		    private static double peremennayaMinus = -1;

		    /// <summary>
		    /// �������� ����������, ��� ������ ������������:
		    /// resultatVichisleniy - ���������� ��� ��������
		    ///  �������������� ���������� � ��������� ������������
		    ///  resultatOutput - ����������, �������� ������� ����� ��������� � ������ �  ���������� �� ����.
		    ///  tekusheeDeystvieCalculatora - �������� ������ �� �������� ������������.
		    ///  pervoeChislo - ����������, � ������� ����� ������������ ����� �� ������
		    ///   �� ������� �� ���� �� ������� ������ � ���������.
		    ///  vtoroeChislo - ������ ����� �� ������.
		    ///  dobavlenierazryada ��� ���������� ����������  ������� ��� ���������� ������ �������� true;
		    ///  ChislosTochkoy ��� ���������� ����������� ������� (����� �����) ��� ���������� ������ �������� true
		    /// </summary>
	
		    private static double resultatVichisleniy;
		    private static string resultatOutput;
		    private static Deystvie tekusheeDeystvieCalculatora;
		    private static double pervoeChislo;
		    private static double vtoroeChislo;
		    private static bool dobavlenierazryada;
		    private static bool ChislosTochkoy;
 
		    /// <summary>
		    /// � ������������ ������ mehanizmcalkulyatora �������������� ���������� 
		    /// ChislosTochkoy � dobavlenierazryada - ��� ������� ������������ �� ������ 
		    /// ��� �� �����������, �� ���������� �����.
		    /// </summary>

		    //public static mehanizmcalkulyatora ()
		    //{
			   // ChislosTochkoy = false;
			   // dobavlenierazryada = false;
		    //}

			
		    /// <summary>
		    /// � ���� ������ ���������� resultatOutput ���������� - ��� ����� ����� �� �������� ����������������.
		    /// </summary>
		

		    public static string chislonaEkrane (string najatayaKlavisha)
		    {
                resultatOutput = resultatOutput + najatayaKlavisha;

                return (resultatOutput);
		    }

            /// <summary>
            /// �����, � ������� ������������ peremenDeystviya - ���� �������� ������������ Deystvie,
            ///� ����������� �� ������  ������� +, -, *,  ��� /
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
            /// ��� �������  ������ +/- ����� �� ������ - tekusheeChislo ���������� �� -1,
            ///  � ����� ��������� ����� ������������� ���������� resultatOutput.
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
		    /// ��� ������� ������ ( , ) ���������� resultatOutput ����������� ������� �����.
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
	    /// ��� ������� ������ ZnakRavno �������������� �������� 
	    /// ����������� pervoeChislo � vtoroeChislo, ��������� ������������� ���������� resultatVichisleniy 
	    /// �������  ����� ������������� � resultatOutput.
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
	    /// ��� ������� ������  � (�����) �������� ���������� ����������.
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
