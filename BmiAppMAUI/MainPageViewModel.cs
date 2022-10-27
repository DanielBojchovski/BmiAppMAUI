using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BmiAppMAUI
{
    internal class MainPageViewModel : INotifyPropertyChanged
    {
        private double weight = 70;
        private double height = 150;

        public double Height
        {
            get => height;
            set
            {
                height = NextStep(value);
                UpdateBMI();
            }
        }
        public double Weight
        {
            get => weight;
            set
            {
                weight = NextStep(value);
                UpdateBMI();
            }
        }

        public double Bmi => Math.Round(Weight / ((Height / 100) * (Height / 100)), 2);

        public string Classification
        {
            get
            {
                if (Bmi < 18.5)
                {
                    return "You are under weight";
                }
                else if (Bmi < 25)
                {
                    return "You are normal weight";
                }
                else if (Bmi < 30)
                {
                    return "You are overweight";
                }
                else
                {
                    return "You are obese";
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        private double NextStep(double value) => Math.Round(value / 1) * 1;

        private void UpdateBMI()
        {
            RaisePropertyChanged(nameof(Bmi));
            RaisePropertyChanged(nameof(Classification));
        }
    }
}
