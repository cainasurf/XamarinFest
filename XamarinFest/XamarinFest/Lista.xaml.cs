using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//importados:
using System.Net.Http;
using Newtonsoft.Json;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lista : ContentPage
    {
        public Lista()
        {
            InitializeComponent();
            List<Noticia> listaNoticias = new List<Noticia>();
            
            //teste
            Noticia noticia = new Noticia() { Titulo = "Noticia 1", DataPublicacao = DateTime.Now, Conteudo = "Conteúdo referente à notícia 1!", Url = "https://www.google.com.br/" };
            listaNoticias.Add(noticia);
            ListNoticias.ItemsSource = listaNoticias;
            /// 

            //CarregarNoticias();
        }

        /**
         * async para deixar a interface livre enquanto a requisicao é feita 
         **/
        public async void CarregarNoticias()
        {
            using (var cliente = new HttpClient())
            {
                //primeiro é feita a requisicao do conteudo json pela url
                var json = await cliente.GetStringAsync("http://xamarinssa.azurewebsites.net/tables/noticias/?ZUMO-API-VERSION=2.0.0");
                //depois converte para o tipo: lista de noticias
                var noticias = JsonConvert.DeserializeObject<List<Noticia>>(json);

                ListNoticias.ItemsSource = noticias;
            }

        }

        private void ListNoticias_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //Atribui a selacao à variavel
            var noticiaSelecionada = (Noticia)e.SelectedItem;
            //Adiciona nova tela detalhe à navegacao
            Navigation.PushAsync(new Detalhe(noticiaSelecionada));
        }
    }
}