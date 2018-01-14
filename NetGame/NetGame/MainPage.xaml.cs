using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NetGame
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            buttonJisaku.Clicked += ButtonJisaku_Clicked;
            buttonOtehon.Clicked += ButtonOtehon_Clicked;
		}

        private async void ButtonOtehon_Clicked(object sender, EventArgs e)
        {
            String url = "https://h29netgame.azurewebsites.net/Login?id=5";
            HttpClient client = new HttpClient();
            var result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
//                Items = JsonConvert.DeserializeObject<List<TodoItem>>(content);
            }


        }

        private void ButtonJisaku_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
