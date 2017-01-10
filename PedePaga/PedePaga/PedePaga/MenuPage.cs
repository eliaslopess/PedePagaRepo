using PedePaga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PedePaga
{
   public class MenuPage : ContentPage
    {
        List<Menu> listaMenu;

        StackLayout stackPrinc;
        ListView lv;

        public MenuPage()
        {
            //titulo
            Title = "Menu";

            //Popular opções menu
            listaMenu = new List<Menu>();
            listaMenu.Add(new Menu { opcao = 0, descricao = "Home", targetType = typeof(MainPage) });
            listaMenu.Add(new Menu { opcao = 1, descricao = "Produtos", targetType = typeof(ProdPage) });
            listaMenu.Add(new Menu { opcao = 2, descricao = "Sair" });

            //pilha de componentes principal
            stackPrinc = new StackLayout
            {
                //Margin = new Tickness(0,10,0,0),
                Orientation = StackOrientation.Vertical
            };

            //listview com menu
            lv = new ListView
            {

                //Template menu
                ItemTemplate = new DataTemplate(() =>
                {
                    var txtCell = new TextCell();
                    txtCell.SetBinding(TextCell.TextProperty, "descricao");
                    return txtCell;
                }),
            };
            lv.ItemsSource = listaMenu;
            lv.ItemSelected += Lv_ItemSelected;

            stackPrinc.Children.Add(lv);

            Content = stackPrinc;
        }

        private async void Lv_ItemSelected (object sender, SelectedItemChangedEventArgs e)
        {
            //se n tem nada selecionado sai
            if (lv.SelectedItem == null)
            {
                return;
            }

            //pega item selecionado do menu q é do tipo menu
            var it = lv.SelectedItem as Menu;

            //se n tem nenhum tipo definido no menu
            if(it.targetType == null)
            {
                //exibe aviso de confirmação e saída do app
                var resp = await this.DisplayAlert("CONFIRMAR", "SAIR DO APP?", "SIM", "NÃO");

                if (resp)
                {
                    //...
                }
            }
            else
            {
                //pagina principal
                var mainPage = Application.Current.MainPage as MasterDetailPage;
                //instancia da page do menu
                var pg = (Page)Activator.CreateInstance(it.targetType);
                //seta page
                mainPage.Detail = new NavigationPage(pg);
           }
            lv.SelectedItem = null;
        }

    }
}
