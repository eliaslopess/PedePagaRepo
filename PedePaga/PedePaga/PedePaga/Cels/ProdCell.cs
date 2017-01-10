using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PedePaga.Cels
{
    public class ProdCell : ViewCell
    {
        StackLayout stackPrinc;

        StackLayout stackColuna1;
        StackLayout stackColuna2;

        Label lblDescricao;
        Label lblValor;

        Image logoImage;

        const string caminhoFotos = "http://192.198.109.1:2000/api/VitrineProd/GetProdImag?id=";

        public ProdCell()
        {
            stackPrinc = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            //Coluna Imagem
            stackColuna1 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            //coluna texto
            stackColuna2 = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Orientation = StackOrientation.Vertical
            };
            stackPrinc.Children.Add(stackColuna2);


            //imagem
            logoImage = new Image
            {
                WidthRequest = 75,
                Aspect = Aspect.AspectFit
            };
            stackColuna1.Children.Add(logoImage);
            logoImage.SetBinding(Image.SourceProperty,
                new Binding("imgId", stringFormat: caminhoFotos + "{0}"));

            //descricao
            lblDescricao = new Label();
            lblDescricao.SetBinding(Label.TextColorProperty, "descricao");
            stackColuna2.Children.Add(lblDescricao);

            //valor
            lblValor = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            };
            lblValor.SetBinding(Label.TextColorProperty,
                new Binding("Valor", BindingMode.OneWay, null, null, "{0:c2}"));
            stackColuna2.Children.Add(lblValor);


            View = stackPrinc;

        }
    }
}
