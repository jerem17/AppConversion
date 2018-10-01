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
            //ToolbarItems.Add(new ToolbarItem("Burger", "ic_menu_grey600_36dp.png", () =>
            //{

            //}));

            Dollar.Clicked += (s, e) => Convert_monnaie(Money, 1);
            Livre.Clicked += (s, e) => Convert_monnaie(Money, 2);
            reset.Clicked += (s, e) => Money.Text = "";

        }


        public void Convert_monnaie(Entry numbers, int choose_money)
        {
            double resultat = 0;
            double dollar = 1.16;
            double livre = 0.90;

            //    double number = Math.Round(GetValue);
            double.TryParse(numbers.Text, out var valeur); // Convertie une string en double
            if (valeur == 0)
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
    }
    public class HyperlinkLabel : Label
    {
        public HyperlinkLabel()
        {
        }
    }
}
