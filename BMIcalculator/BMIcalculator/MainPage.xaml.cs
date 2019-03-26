using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BMIcalculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Oblicz_Clicked(object sender, EventArgs e)
        {
            double x = 0;
            double y = 0;
            if(double.TryParse(Weight.Text, out x))
            {
                if(double.TryParse(Height.Text, out y))
                {
                    double bmi = double.Parse(Weight.Text) / (Math.Pow(double.Parse(Height.Text) / 100, 2));
                    Wynik.BindingContext = bmi;
                    if (bmi < 18.5)
                    {
                        CoOznacza.BindingContext = "Niedowaga";
                    }
                    else if (bmi >= 25)
                    {
                        CoOznacza.BindingContext = "Nadwaga";
                    }
                    else
                    {
                        CoOznacza.BindingContext = "Waga prawidłowa";
                    }
                }
                else
                {
                    await DisplayAlert("Uwaga", "Podany wzrost jest niepoprawny", "OK");
                }
            }
            else
            {
                await DisplayAlert("Uwaga", "Podana waga jest niepoprawna", "OK");
            }
        }
    }
}
