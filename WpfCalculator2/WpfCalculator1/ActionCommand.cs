using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCalculator1.ViewModels;
using WpfCalculator1.Models;
using System.Windows;
using Wrapper;
using Microsoft.VisualBasic;

namespace WpfCalculator1
{
    class DataInsert : CommandBase
    {
        private MainWindowViewModels viewmodel;

        public DataInsert(MainWindowViewModels viewmodel)
        {
            this.viewmodel = viewmodel;
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            //데이터 인풋

            if (viewmodel.InputData == "0")
            {
                viewmodel.InputData = viewmodel.DisplayData = string.Empty;
                viewmodel.InputData += parameter;
                viewmodel.DisplayData += parameter;
            }
            else
            {
                viewmodel.InputData += parameter;
                viewmodel.DisplayData += parameter;
            }

        }
    }
    class DataBack : CommandBase
    {
        private MainWindowViewModels viewmodel;

        public DataBack(MainWindowViewModels viewmodel)
        {
            this.viewmodel=viewmodel;
        }
        public override bool CanExecute(object parameter)
        {
            return viewmodel.DisplayData.Length > 0;
        }

        public override void Execute(object parameter)
        {
            int Len = viewmodel.InputData.Length - 1;
            if (0 < Len)
            {
                viewmodel.InputData = viewmodel.DisplayData = viewmodel.InputData.Substring(0, Len);
            }
            else
            {
                viewmodel.InputData = viewmodel.DisplayData = string.Empty;
            }
            //데이터 지우기
        }
    }
    class DataClear : CommandBase
    {
        private MainWindowViewModels viewmodel;

        public DataClear(MainWindowViewModels viewmodel)
        {
            this.viewmodel = viewmodel;
        }
        public override bool CanExecute(object parameter)
        {
            return viewmodel.DisplayData.Length > 0;
        }

        public override void Execute(object parameter)
        {
            viewmodel.InputData = viewmodel.DisplayData = "0";
            viewmodel.Firstdata = null;
            //데이터 클리어
        }
    }
    class DataOperator : CommandBase
    {
        private MainWindowViewModels viewmodel;

        public DataOperator(MainWindowViewModels viewmodel)
        {
            this.viewmodel = viewmodel;
        }
        public override bool CanExecute(object parameter)
        {
            return 0 < viewmodel.InputData.Length;
        }

        public override void Execute(object parameter)
        {
            string operate = parameter.ToString();
            double pfirstdata;

            if (double.TryParse(viewmodel.InputData, out pfirstdata))
            {
                viewmodel.Oper = operate;
                viewmodel.Firstdata = pfirstdata;
                viewmodel.InputData = "";
                viewmodel.DisplayData += operate;
            }
            else if(viewmodel.InputData == "" && operate == "-")
            {
                viewmodel.DisplayData += viewmodel.InputData = "-";
            }
            //데이터 연산자
        }
    }
    class DataCalculator : CommandBase
    {
        private MainWindowViewModels viewmodel;
        private MyArithmetic arithmetic = new MyArithmetic();
        public int Data
        {
            get; set;
        }

        public DataCalculator(int data)
        {
            this.Data = data;
        }

        public DataCalculator(MainWindowViewModels viewmodel)
        {
            this.viewmodel = viewmodel;
        }

        public override bool CanExecute(object parameter)
        {
            double result;
            return viewmodel.Oper != null && double.TryParse(viewmodel.InputData, out result);
        }

        public override void Execute(object parameter)
        {
            double currentdata = double.Parse(viewmodel.InputData);
            List<double> datalist = new List<double>();
            List<char> opreatelist = new List<char>();
            double result = 0;
            string _history = "";

            GetCalclurateList(datalist, opreatelist);

            for (int j = opreatelist.Count() - 1; j >= 0; j--)
            {
                if (opreatelist[j] == '/')
                {
                    datalist[j] = MyDivde((int)datalist[j], (int)datalist[j + 1]);
                    datalist[j + 1] = 0;
                    opreatelist[j] = '+';

                }
                else if (opreatelist[j] == '*')
                {
                    datalist[j] = Mymultiply((int)datalist[j], (int)datalist[j + 1]);
                    datalist[j + 1] = 0;
                    opreatelist[j] = '+';
                }
                result = datalist[j];
            }

            for (int j = 0; j < opreatelist.Count(); j++)
            {
                if (opreatelist[j] == '+')
                {
                    datalist[j + 1] = Myadd((int)datalist[j], (int)datalist[j + 1]);
                }
                else if (opreatelist[j] == '-')
                {
                    datalist[j + 1] = Mysubtract((int)datalist[j], (int)datalist[j + 1]);
                }
                result = datalist[j + 1];
            }

            _history = string.Format("{0}{1}{2}", viewmodel.DisplayData, "=", result.ToString());
            viewmodel.AddHistory(_history);
            viewmodel.InputData = viewmodel.DisplayData = result.ToString();
            viewmodel.Firstdata = null;
            //데이터 출력
        }

        private double Myadd(int _int1, int _int2)
        {
            int value = arithmetic.Add(Convert.ToInt32(_int1), Convert.ToInt32(_int2));
            return (double)value;
        }
        private double Mysubtract(int _int1, int _int2)
        {
            int value = arithmetic.Subtract(Convert.ToInt32(_int1), Convert.ToInt32(_int2));
            return (double)value;
        }
        private double Mymultiply(int _int1, int _int2)
        {
            float value = arithmetic.Multiply((float)Convert.ToDouble(_int1), (float)Convert.ToDouble(_int2));
            return (double)value;
        }
        private  double MyDivde(int _int1, int _int2)
        {
            float value = arithmetic.Divide((float)Convert.ToDouble(_int1), (float)Convert.ToDouble(_int2));
            return (double)value;
        }

        public void GetCalclurateList(List<double> dlist, List<char> olist)
        {
            string splitpoint = "";
            string palldata = viewmodel.DisplayData;

            for (int i = 0; i < palldata.Length; i++)
            {
                if (palldata[i] == '*' || palldata[i] == '-' || palldata[i] == '/' || palldata[i] == '+')
                {
                    olist.Add(palldata[i]);
                    dlist.Add(double.Parse(splitpoint));
                    splitpoint = "";
                }
                else
                {
                    splitpoint += palldata[i];
                }
            }

            dlist.Add(double.Parse(splitpoint));
        }
    }
}
