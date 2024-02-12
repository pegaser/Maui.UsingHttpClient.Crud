using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Maui.UsingHttpClient.Crud;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}
    readonly HttpClient client = new HttpClient();
    private async void OnCounterClicked(object sender, EventArgs e)
	{
        ///POST///
        //Unicorn unicorn = new Unicorn();
        //unicorn.name = "Cosita";
        //unicorn.age = 2;
        //unicorn.colour = "Morado";

        //HttpClient client = new HttpClient();
        //HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, "https://crudcrud.com/api/2f8f433a624b4ebd8015878831ee503e/unicorns");
        //message.Content = JsonContent.Create<Unicorn>(unicorn);
        //HttpResponseMessage response = await client.SendAsync(message);

        ///GET///
        //HttpClient client = new HttpClient();
        //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //string text = await client.GetStringAsync("https://crudcrud.com/api/2f8f433a624b4ebd8015878831ee503e/unicorns/64b98458c632b703e830dc86");
        //lblResponse.Text = text;

        ///PUT///
        //Unicorn unicorn = new Unicorn();
        //unicorn.name = "Cosita 2";
        //unicorn.age = 2;
        //unicorn.colour = "Morado";
        //HttpClient client = new HttpClient();
        //HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Put, "https://crudcrud.com/api/2f8f433a624b4ebd8015878831ee503e/unicorns/64b98458c632b703e830dc86");
        //message.Content = JsonContent.Create<Unicorn>(unicorn);
        //HttpResponseMessage response = await client.SendAsync(message);

        ///DELETE///
        try
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Delete, "https://crudcrud.com/api/2f8f433a624b4ebd8015878831ee503e/unicorns/64b97d39c632b703e830dc77");
            HttpResponseMessage response = await client.SendAsync(message);
            response.EnsureSuccessStatusCode();
            await DisplayAlert("Alert", "Terminé exitosamente", "Ok");
        }
        catch (HttpRequestException ex)
        {
            await DisplayAlert("Alert",ex.StatusCode.ToString(),"Ok"); 
        }
    }
}
class Unicorn
{
    public string name { get; set; }
    public int age { get; set; }
    public string colour { get; set; }
}

