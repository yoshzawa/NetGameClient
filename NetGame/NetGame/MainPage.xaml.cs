using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.AppCenter.Analytics;

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

            ActivityIndicator loading = new ActivityIndicator { IsRunning = true, VerticalOptions = LayoutOptions.CenterAndExpand };
            workArea.Content = loading;
            HttpClient client = new HttpClient();
            var result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                //                Items = JsonConvert.DeserializeObject<List<TodoItem>>(content);
                Analytics.TrackEvent("get from Server", new Dictionary<string, string> {
                    { "server", url},
                    { "content", content}});
                Editor editor = new Editor { Text = content, VerticalOptions = LayoutOptions.CenterAndExpand };
                workArea.Content = editor;
            }
        }

        private void ButtonJisaku_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
