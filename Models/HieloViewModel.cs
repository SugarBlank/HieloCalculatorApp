using System;
using HieloCalculator.Models;
using ReactiveUI;
using System.Reactive;
using DecimalMath;


namespace HieloCalculator.ViewModel
{
    class HieloViewModel : ViewModelBase
    {
        
        private decimal _FirstNumber, _SecondNumber;
        private SimpleOperations _SimpleOperations = SimpleOperations.Add;
        private HarderOperations _HarderOperations = HarderOperations.Execute;
        public decimal ShownValue
        {
            get => _SecondNumber;
            set => this.RaiseAndSetIfChanged(ref _SecondNumber, value);
        }
        public ReactiveCommand<decimal, Unit> AddNumberCommand { get; }

        public ReactiveCommand<Unit, Unit> RemoveLastNumberCommand { get; }
        
        public ReactiveCommand<SimpleOperations, Unit> ExecuteOperationCommand { get; }

        public ReactiveCommand<HarderOperations, Unit> ExecuteHarderOperationCommand { get; }
        public HieloViewModel()
        {
            AddNumberCommand = ReactiveCommand.Create<decimal>(AddNumber);
            RemoveLastNumberCommand = ReactiveCommand.Create(RemoveLastNumber);
            ExecuteOperationCommand = ReactiveCommand.Create<SimpleOperations>(ExecuteOperation);
            ExecuteHarderOperationCommand = ReactiveCommand.Create<HarderOperations>(HarderOperationsExecute);
        }
        private void AddNumber(decimal value)
        {
            ShownValue = ShownValue * 10 + value;
        }
        public void ClearScreen()
        {
            ShownValue = 0;
            
            _FirstNumber = 0;
        }
        public void RemoveLastNumber()
        {
            ShownValue = (int)ShownValue / 10;
        }
        public void Exit()
        {
            Environment.Exit(0);
        }
        private void HarderOperationsExecute(HarderOperations HardOperation)
        {   
            
            _HarderOperations = HardOperation;

            switch(_HarderOperations)
            {   
                
                case HarderOperations.ReferenceAngleSolution:
                {
                    if(ShownValue > 90) 
                    {
                        ShownValue = 90 - ShownValue%90;
                    }
                    else if(ShownValue < -90) {
                        ShownValue = 90 + ShownValue%90;    
                    }
                    else {
                        ShownValue = ShownValue;       
                    }
                    break;
                }

                case HarderOperations.SquareRoot:
                {
                    ShownValue = Math.Round(DecimalEx.Sqrt(ShownValue), 5);
                    break;
                }

                case HarderOperations.Square:
                {
                    ShownValue = Math.Round(ShownValue * ShownValue);
                    break;
                }
                
                case HarderOperations.FindingLog:
                {
                    ShownValue = Math.Round(DecimalEx.Log10(ShownValue), 5);
                    break;
                }

                case HarderOperations.FindingTan:
                {
                    ShownValue = Math.Round(DecimalEx.Tan(ShownValue), 5);
                    break;
                }

                case HarderOperations.FindingSin:
                {
                    ShownValue = Math.Round(DecimalEx.Sin(ShownValue), 5);
                    break;
                }
                // This converts centimeters into inches.
                case HarderOperations.FindingCos:
                {
                    ShownValue = Math.Round(DecimalEx.Cos(ShownValue), 5);
                    break;
                }

                case HarderOperations.CentimetersToInches:
                {
                    ShownValue = Math.Round(ShownValue / 2.54m, 5);
                    
                    break;
                }

                case HarderOperations.InchesToCentimeters:
                {
                    ShownValue = Math.Round(ShownValue * 2.54m, 5);
                    break;
                }

                case HarderOperations.KgToLb:
                {
                    ShownValue = Math.Round(ShownValue * 2.20462262185m, 5);
                    break;
                }

                case HarderOperations.LbToKg:
                {  
                    ShownValue = Math.Round(ShownValue / 2.20462262185m, 5);
                    break;
                }

                case HarderOperations.ConvertDegreesToRadians:
                {
                    ShownValue = Math.Round(((decimal)(Math.PI) / 180) * ShownValue, 4);
                    break;
                }

                case HarderOperations.ConvertRadiansToDegrees:
                {
                    ShownValue = Math.Round(180 / (ShownValue * (decimal)(Math.PI)), 4);
                    break;
                }

                case HarderOperations.ConvertCelsiusToFahrenheit:
                {
                    ShownValue = Math.Round((ShownValue * 1.8m) + 32, 2);
                    break;
                }

                case HarderOperations.ConvertFahrenheitToCelsius:
                {
                    ShownValue = Math.Round((ShownValue - 32)/1.8m, 2);
                    break;
                }

                case HarderOperations.ConvertToNegative:
                {
                    ShownValue *= -1m;
                    break;
                }
                
            }
        }
        private void ExecuteOperation(SimpleOperations operation)
        {
            switch (_SimpleOperations)
            {
                case SimpleOperations.Add:
                {
                    _FirstNumber += _SecondNumber;
                    ShownValue = 0;
                    break;
                }

                case SimpleOperations.Subtract:
                {
                    _FirstNumber -= _SecondNumber;
                    ShownValue = 0;
                    break;
                }

                case SimpleOperations.Multiply:
                {
                    _FirstNumber = Math.Round(_FirstNumber * _SecondNumber, 5);
                    ShownValue = 0;
                    break;
                }

                case SimpleOperations.Divide:
                {
                    _FirstNumber = Math.Round(_FirstNumber / _SecondNumber, 5);
                    break;
                }
                
                case SimpleOperations.PythagoreanTheory:
                {
                    _FirstNumber = _FirstNumber * _FirstNumber;
                    _SecondNumber = _SecondNumber * _SecondNumber;
                    _FirstNumber = Math.Round(DecimalEx.Sqrt(_FirstNumber + _SecondNumber), 5);
                    break;
                }
                case SimpleOperations.Modulo:
                {
                    _FirstNumber = _FirstNumber % _SecondNumber;
                    break;
                }
            }

            if (operation == SimpleOperations.Answer)
            {
                ShownValue = _FirstNumber;
                _SimpleOperations = SimpleOperations.Add;
                _FirstNumber = 0;
            }
            else
            {
                _SimpleOperations = operation;
            }
            
    }
    
    }
}