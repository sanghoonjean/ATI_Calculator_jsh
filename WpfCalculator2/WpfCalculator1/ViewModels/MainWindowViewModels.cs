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

        public string Oper { get; set; }
        public double? Firstdata { get; set; }

        private string inputData = "";
        private string displayData = "";
        private string AllData = "";
        private string memorydata = "";
        private ObservableCollection<MainModel> _mainModels;
        private MainModel _selectedmemory;


        public ICommand DataOperator { protected get; set; }
        public ICommand DataInsert { protected get; set; }
        public ICommand DataBack { protected get; set; }
        public ICommand DataClear { protected get; set; }
        public ICommand DataCalculator { protected get; set; }
        public ICommand SaveMemoryCommand { protected get; set; }


        public MainWindowViewModels()
        {
            _mainModels = new ObservableCollection<MainModel>();

            this.DataInsert = new DataInsert(this);
            this.DataOperator = new DataOperator(this);
            this.DataBack = new DataBack(this);
            this.DataClear = new DataClear(this);
            this.DataCalculator = new DataCalculator(this);
            SaveMemoryCommand = new RelayCommand<string>(SaveMemory);
        }
        public string InputData
        {
            internal set
            {
                if (inputData != value)
                {
                    inputData = value;
                    OnPropertyChanged(nameof(InputData));
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
                    OnPropertyChanged(nameof(DisplayData));
                }
            }
            get
            {
                return displayData;
            }
        }

        public ObservableCollection<MainModel> Memory
        {
            get { return _mainModels; }
            set
            {
                _mainModels = value;
                OnPropertyChanged(nameof(Memory));
            }
        }

        public MainModel SelectedMemory
        {
            get { if (_selectedmemory != null)
                {
                    InputData = DisplayData = _selectedmemory.Memory;
                }
                return _selectedmemory; }
            set
            {
                _selectedmemory = value;
                OnPropertyChanged(nameof(SelectedMemory));
            }
        }

        private void SaveMemory(string paramerter)
        {
            if (InputData != "")
            {
                _mainModels.Add(new MainModel { Memory = InputData });
            }
        }

        public void AddHistory(string paramerter)
        {
            if (InputData != "")
            {
                _mainModels.Add(new MainModel { History = paramerter });
            }
        }
    }
}
