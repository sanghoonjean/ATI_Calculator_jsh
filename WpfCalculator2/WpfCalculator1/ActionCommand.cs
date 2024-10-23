using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCalculator1.ViewModels;
using WpfCalculator1.Models;
using System.Windows;
using Wrapper;

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
            viewmodel.InputData += parameter;
            viewmodel.DisplayData += parameter;
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
                viewmodel.InputData = viewmodel.InputData.Substring(0, Len);
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
            viewmodel.InputData = viewmodel.DisplayData = string.Empty;
            viewmodel.OpereteAnd = null;
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
            double operand;

            if (double.TryParse(viewmodel.InputData, out operand))
            {
                viewmodel.Oper = operate;
                viewmodel.OpereteAnd = operand;
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
            double data = double.Parse(viewmodel.InputData);
            double result = 0;

            if (viewmodel.Oper == "+")
            {
                result = Myadd((int)viewmodel.OpereteAnd, (int)data);
            }
            else if (viewmodel.Oper == "-")
            {
                result = Mysubtract((int)viewmodel.OpereteAnd, (int)data);
            }
            else if(viewmodel.Oper == "*")
            {
                result = Mymultiply((int)viewmodel.OpereteAnd, (int)data);
            }
            else if(viewmodel.Oper == "/")
            {
                result = MyDivde((int)viewmodel.OpereteAnd, (int)data);
            }

            viewmodel.InputData = result.ToString();
            viewmodel.OpereteAnd = null;
            viewmodel.DisplayData = viewmodel.InputData;
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

    }
}
