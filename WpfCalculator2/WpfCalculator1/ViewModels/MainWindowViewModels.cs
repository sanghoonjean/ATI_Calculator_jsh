using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfCalculator1.Models;

namespace WpfCalculator1.ViewModels
{
    public class MainWindowViewModels : BaseViewModel
    {
        private string inputData = "";
        private string displayData = "";
        private string AllData = "";
        public string Oper { get; set; }
        public double? firstdata { get; set; }

        public MainWindowViewModels()
        {
            this.DataInsert = new DataInsert(this);
            this.DataOperator = new DataOperator(this);
            this.DataBack = new DataBack(this);
            this.DataClear = new DataClear(this);
            this.DataCalculator = new DataCalculator(this);
            SaveMemoryCommand = new RelayCommand<string>(SaveMemory);
        }

        public ICommand DataOperator { protected get; set; }
        public ICommand DataInsert { protected get; set; }
        public ICommand DataBack { protected get; set; }
        public ICommand DataClear { protected get; set; }
        public ICommand DataCalculator { protected get; set; }
        public ICommand SaveMemoryCommand { protected get; set; }

        public string InputData
        {
            internal set
            {
                if (inputData != value)
                {
                    inputData = value;
                    OnPropertyChanged("InputData");
                }
            }
            get { 
                    return inputData; 
                }
        }

        public string DisplayData
        {
            internal set
            {
                if (displayData != value)
                {
                    displayData = value;
                    OnPropertyChanged("DisplayData");
                }
            }
            get
            {
                return displayData;
            }
        }

        public string Alldata { get; set; }

        private void SaveMemory(string paramerter)
        {
            MainModel me = new MainModel();
            ModelManager _modelManager = new ModelManager();
            me.Memory = DisplayData;

            _modelManager.SetMemory(me);
        }
    }
}
