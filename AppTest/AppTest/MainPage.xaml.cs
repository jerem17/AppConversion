using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }


        public void Convert_monnaie(int choose_money)
        {
            double resultat = 0;
            double dollar = 1.16;
            double livre = 0.90;

            //    double number = Math.Round(GetValue);
             // Convertie une string en double
            if (!double.TryParse(Money.Text, out var valeur))
            {
                result.Text = "Veuillez entrer un montant valide !";
                return;
            }

            if (choose_money == 1)
            {
                resultat = valeur * dollar;
                result.Text = $"{resultat} $";
            }
            else if (choose_money == 2)
            {
                resultat = valeur * livre;
                result.Text = $"{resultat} £";
            }
            
        }

        private async void About_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new About());
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            DisplayAlert("ToolbarItem", "Menu", "OOKKK");
        }

        private void Reset_OnClicked(object sender, EventArgs e)
        {
            Money.Text = "";
        }

        private void Dollar_OnClicked(object sender, EventArgs e)
        {
            Convert_monnaie(1);
        }

        private void Livre_OnClicked(object sender, EventArgs e)
        {
           Convert_monnaie(2);
        }
    }
}
