using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detalhe : ContentPage
    {
        private Noticia _noticia = new Noticia();

        public Detalhe(Noticia noticia)
        {
            InitializeComponent();
            _noticia = noticia;

            BindingContext = noticia;
        }

        private void BtnSite_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(_noticia.Url));
        }
    }
}