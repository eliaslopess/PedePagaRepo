using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PedePaga
{
    public class HomePage : MasterDetailPage
    {
        public HomePage()
        {
            Title = "Home";


            Master = new MenuPage();
            Detail = new NavigationPage(new MainPage());

        }
    }
}
