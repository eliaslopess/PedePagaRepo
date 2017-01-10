using PedePaga.Cels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using PedePaga.Models;

namespace PedePaga
{
    public class ProdPage : ContentPage
    {
        StackLayout stackPrinc;

        SearchBar sb;

        ListView lv;

        public ProdPage()
        {
            //título
            Title = "Produtos";

            //pilha Principal
            stackPrinc = new StackLayout
            {
                Orientation = StackOrientation.Vertical
            };

            //Componente de Pesquisa
            sb = new SearchBar
            {
                Placeholder = "Pesquisar Produto..."
            };
            stackPrinc.Children.Add(sb);
            //Comando de Pesquisa
            sb.SearchCommand = new Command(() =>
            {
                Pesquisar();
            });

            //Lista Produtos
            var itemTemplate  = new DataTemplate(typeof(ProdCell));
            lv = new ListView
            {
                HasUnevenRows = true,
                ItemTemplate = itemTemplate
            };
            stackPrinc.Children.Add(lv);

            Content = stackPrinc;
        }

        private async void Pesquisar()
        {
            lv.ItemsSource = null;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.109.1:5000/");

                var resp = await client.GetAsync($"api/VitrineProd/GetProd?valor={sb.Text}");

                if (resp.IsSuccessStatusCode)
                {
                    var contentJson = await resp.Content.ReadAsStringAsync();

                    var l = JsonConvert.DeserializeObject<List<Produto>>(contentJson);

                    if (l.Any())
                    {
                        lv.ItemsSource = l;
                    }
                }
            }
        }

    }
}
