using Calculator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }


        private bool canContinue = false;
        public bool CanContinue
        {
            get => canContinue;
            set
            {
                canContinue = value;
                OnPropertyChanged();
            }
        }

        private double firstNumber;
        public double FirstNumber
        {
            get => firstNumber;
            set
            {
                firstNumber = value;
                OnPropertyChanged();
            }
        }

        private double secondNumber;
        public double SecondNumber
        {
            get => secondNumber;
            set
            {
                secondNumber = value;
                OnPropertyChanged();
            }
        }

        private double memory = 0;
        public double Memory
        {
            get => memory;
            set
            {
                memory = value;
                OnPropertyChanged();
            }
        }

        private string operation = "";
        public string Operation
        {
            get => operation;
            set
            {
                operation = value;
                OnPropertyChanged();
            }
        }

        private string display = "0";
        public string Display
        {
            get => display;
            set
            {
                display = value;
                OnPropertyChanged();
            }
        }

        public ICommand SqrtCommand { get; }
        public ICommand InvertCommand { get; }
        public ICommand AddOneCommand { get; }
        public ICommand AddTwoCommand { get; }
        public ICommand AddThreeCommand { get; }
        public ICommand AddFourCommand { get; }
        public ICommand AddFiveCommand { get; }
        public ICommand AddSixCommand { get; }
        public ICommand AddSevenCommand { get; }
        public ICommand AddEightCommand { get; }
        public ICommand AddNineCommand { get; }
        public ICommand AddZeroCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand ClearEntryCommand { get; }
        public ICommand AddPointCommand { get; }
        public ICommand BackspaceCommand { get; }
        public ICommand ResultCommand { get; }
        public ICommand SubtractionCommand { get; }
        public ICommand AdditionCommand { get; }
        public ICommand MultiplicationCommand { get; }
        public ICommand DivisionCommand { get; }
        public ICommand MemoryAdditionCommand { get; }
        public ICommand MemorySubtractionCommand { get; }
        public ICommand MemoryReturnCommand { get; }
        public ICommand MemoryClearCommand { get; }

        //очистка памяти калькулятора
        private void OnMemoryClearCommandExecute(object p)
        {
            Memory = 0;
        }
        private bool CanMemoryClearCommandExecuted(object p) => true;

        //вывод значения из памяти калькулятора на экран
        private void OnMemoryReturnCommandExecute(object p)
        {
            Display = Memory.ToString();
        }
        private bool CanMemoryReturnCommandExecuted(object p) => true;

        //вычитание значения из памяти калькулятора 
        private void OnMemorySubtractionCommandExecute(object p)
        {
            Memory = Memory - Convert.ToDouble(Display);
        }
        private bool CanMemorySubtractionCommandExecuted(object p)
        {
            return double.TryParse(Display, out double a);
        }

        //добавление значения в память калькулятора
        private void OnMemoryAdditionCommandExecute(object p)
        {
            Memory = Memory + Convert.ToDouble(Display);
        }
        private bool CanMemoryAdditionCommandExecuted(object p)
        {
            return double.TryParse(Display, out double a);
        }

        //выбор операции деления
        private void OnDivisionCommandExecute(object p)
        {
            FirstNumber = Convert.ToDouble(Display);
            SecondNumber = 0;
            Operation = "/";
            CanContinue = false;
        }
        private bool CanDivisionCommandExecuted(object p)
        {
            return double.TryParse(Display, out double a);
        }

        //выбор операции умножения
        private void OnMultiplicationCommandExecute(object p)
        {
            FirstNumber = Convert.ToDouble(Display);
            SecondNumber = 0;
            Operation = "*";
            CanContinue = false;

        }
        private bool CanMultiplicationCommandExecuted(object p)
        {
            return double.TryParse(Display, out double a);
        }

        //выбор операции сложения
        private void OnAdditionCommandExecute(object p)
        {
            FirstNumber = Convert.ToDouble(Display);
            SecondNumber = 0;
            Operation = "+";
            CanContinue = false;

        }
        private bool CanAdditionCommandExecuted(object p)
        {
            return double.TryParse(Display, out double a);
        }

        //выбор операции вычитания
        private void OnSubtractionCommandExecute(object p)
        {
            FirstNumber = Convert.ToDouble(Display);
            SecondNumber = 0;
            Operation = "-";
            CanContinue = false;

        }
        private bool CanSubtractionCommandExecuted(object p)
        {
            return double.TryParse(Display, out double a);
        }

        //вывод результата вычисления на экран согласно выбранной ранее операции
        private void OnResultCommandExecute(object p)
        {
            if (SecondNumber == 0)
            {
                SecondNumber = Convert.ToDouble(Display);
            }
            Display = Convert.ToString(Calculation.Result(FirstNumber, SecondNumber, Operation));
            FirstNumber = Convert.ToDouble(Display);
            CanContinue = false;
        }
        private bool CanResultCommandExecuted(object p)
        {
            return double.TryParse(Display, out double a);
        }

        //удаление правого символа на экране калькулятора
        private void OnBackspaceCommandExecute(object p)
        {
            if (Display.Length > 1)
            {
                Display = Display.Remove(Display.Length - 1, 1);
                if (Display == "0")
                    CanContinue = false;
                if (Display == "-")
                    Display = "0";
            }
            else
            {
                Display = "0";
                CanContinue = false;
            }
        }
        private bool CanBackspaceCommandExecuted(object p) => true;

        //начало ввода дробной части числа
        private void OnAddPointCommandExecute(object p)
        {
            if (CanContinue == false)
            {
                Display = "0,";
            }
            if (Display.Contains(",") == false)
            {
                Display = Display + ",";
            }
            CanContinue = true;
        }
        private bool CanAddPointCommandExecuted(object p) => true;

        //очистка экрана и отмена операций
        private void OnClearCommandExecute(object p)
        {
            FirstNumber = 0;
            SecondNumber = 0;
            Display = "0";
            Operation = "";
            CanContinue = false;
        }
        private bool CanClearCommandExecuted(object p) => true;

        //удаление второго числа без отмены выбранной операции
        private void OnClearEntryCommandExecute(object p)
        {
            SecondNumber = 0;
            Display = "0";
            CanContinue = false;
        }
        private bool CanClearEntryCommandExecuted(object p) => true;

        //вывод квадратного корня
        private void OnSqrtCommandExecute(object p)
        {
            if (Convert.ToDouble(Display)>=0)
            {
                Display = Convert.ToString(Math.Sqrt(Convert.ToDouble(Display)));
            }
            else
            {
                Display = "0";
            }
            CanContinue = false;
        }
        private bool CanSqrtCommandExecuted(object p)
        {
            return double.TryParse(Display, out double a);
        }


        //изменение знака числа на экране
        private void OnInvertCommandExecute(object p)
        {
            Display = Convert.ToString(Convert.ToDouble(Display) * (-1));
            if (Convert.ToDouble(Display) * (-1) == 0)
                CanContinue = false;
        }
        private bool CanInvertCommandExecuted(object p)
        {
            return double.TryParse(Display, out double a);
        }

        //ввод цифр от 0 до 9
        #region Ввод цифр
        private void OnAddOneCommandExecute(object p)
        {
            if (CanContinue == false)
            {
                Display = "1";
            }
            else
            {
                Display = Display + "1";
            }
            CanContinue = true;
        }
        private bool CanAddOneCommandExecuted(object p) => true;

        private void OnAddTwoCommandExecute(object p)
        {
            if (CanContinue == false)
            {
                Display = "2";
            }
            else
            {
                Display = Display + "2";
            }
            CanContinue = true;
        }
        private bool CanAddTwoCommandExecuted(object p) => true;

        private void OnAddThreeCommandExecute(object p)
        {
            if (CanContinue == false)
            {
                Display = "3";
            }
            else
            {
                Display = Display + "3";
            }
            CanContinue = true;
        }
        private bool CanAddThreeCommandExecuted(object p) => true;

        private void OnAddFourCommandExecute(object p)
        {
            if (CanContinue == false)
            {
                Display = "4";
            }
            else
            {
                Display = Display + "4";
            }
            CanContinue = true;
        }
        private bool CanAddFourCommandExecuted(object p) => true;

        private void OnAddFiveCommandExecute(object p)
        {
            if (CanContinue == false)
            {
                Display = "5";
            }
            else
            {
                Display = Display + "5";
            }
            CanContinue = true;
        }
        private bool CanAddFiveCommandExecuted(object p) => true;

        private void OnAddSixCommandExecute(object p)
        {
            if (CanContinue == false)
            {
                Display = "6";
            }
            else
            {
                Display = Display + "6";
            }
            CanContinue = true;
        }
        private bool CanAddSixCommandExecuted(object p) => true;

        private void OnAddSevenCommandExecute(object p)
        {
            if (CanContinue == false)
            {
                Display = "7";
            }
            else
            {
                Display = Display + "7";
            }
            CanContinue = true;
        }
        private bool CanAddSevenCommandExecuted(object p) => true;

        private void OnAddEightCommandExecute(object p)
        {
            if (CanContinue == false)
            {
                Display = "8";
            }
            else
            {
                Display = Display + "8";
            }
            CanContinue = true;
        }
        private bool CanAddEightCommandExecuted(object p) => true;

        private void OnAddNineCommandExecute(object p)
        {
            if (CanContinue == false)
            {
                Display = "9";
            }
            else
            {
                Display = Display + "9";
            }
            CanContinue = true;
        }
        private bool CanAddNineCommandExecuted(object p) => true;

        private void OnAddZeroCommandExecute(object p)
        {
            if (CanContinue == false)
            {
                Display = "0";
            }
            else
            {
                Display = Display + "0";
            }
            if (Display == "0")
            {
                CanContinue = false;
            }
            else
            {
                CanContinue = true;
            }
        }
        private bool CanAddZeroCommandExecuted(object p) => true;
        #endregion

        public MainWindowViewModel()
        {
            SqrtCommand = new RelayCommand(OnSqrtCommandExecute, CanSqrtCommandExecuted);
            InvertCommand = new RelayCommand(OnInvertCommandExecute, CanInvertCommandExecuted);
            AddOneCommand = new RelayCommand(OnAddOneCommandExecute, CanAddOneCommandExecuted);
            AddTwoCommand = new RelayCommand(OnAddTwoCommandExecute, CanAddTwoCommandExecuted);
            AddThreeCommand = new RelayCommand(OnAddThreeCommandExecute, CanAddThreeCommandExecuted);
            AddFourCommand = new RelayCommand(OnAddFourCommandExecute, CanAddFourCommandExecuted);
            AddFiveCommand = new RelayCommand(OnAddFiveCommandExecute, CanAddFiveCommandExecuted);
            AddSixCommand = new RelayCommand(OnAddSixCommandExecute, CanAddSixCommandExecuted);
            AddSevenCommand = new RelayCommand(OnAddSevenCommandExecute, CanAddSevenCommandExecuted);
            AddEightCommand = new RelayCommand(OnAddEightCommandExecute, CanAddEightCommandExecuted);
            AddNineCommand = new RelayCommand(OnAddNineCommandExecute, CanAddNineCommandExecuted);
            AddZeroCommand = new RelayCommand(OnAddZeroCommandExecute, CanAddZeroCommandExecuted);
            ClearCommand = new RelayCommand(OnClearCommandExecute, CanClearCommandExecuted);
            ClearEntryCommand = new RelayCommand(OnClearEntryCommandExecute, CanClearEntryCommandExecuted);
            AddPointCommand = new RelayCommand(OnAddPointCommandExecute, CanAddPointCommandExecuted);
            BackspaceCommand = new RelayCommand(OnBackspaceCommandExecute, CanBackspaceCommandExecuted);
            ResultCommand = new RelayCommand(OnResultCommandExecute, CanResultCommandExecuted);
            SubtractionCommand = new RelayCommand(OnSubtractionCommandExecute, CanSubtractionCommandExecuted);
            AdditionCommand = new RelayCommand(OnAdditionCommandExecute, CanAdditionCommandExecuted);
            MultiplicationCommand = new RelayCommand(OnMultiplicationCommandExecute, CanMultiplicationCommandExecuted);
            DivisionCommand = new RelayCommand(OnDivisionCommandExecute, CanDivisionCommandExecuted);
            MemoryAdditionCommand = new RelayCommand(OnMemoryAdditionCommandExecute, CanMemoryAdditionCommandExecuted);
            MemorySubtractionCommand = new RelayCommand(OnMemorySubtractionCommandExecute, CanMemorySubtractionCommandExecuted);
            MemoryReturnCommand = new RelayCommand(OnMemoryReturnCommandExecute, CanMemoryReturnCommandExecuted);
            MemoryClearCommand = new RelayCommand(OnMemoryClearCommandExecute, CanMemoryClearCommandExecuted);
        }

    }
}
