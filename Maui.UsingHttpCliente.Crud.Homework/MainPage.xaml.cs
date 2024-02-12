using System.Net.Http.Json;

namespace Maui.UsingHttpCliente.Crud.Homework
{
    public partial class MainPage : ContentPage
    {
        const string URI_SERVICE = "https://crudcrud.com/api/976d31edc43f4c39b3624414a0d90a09/users";
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, EventArgs e)
        {
            GetUsers();
        }

        private async void BtnSend_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();

            if (txtUserName.BindingContext is null)
            {
                SetUser user = new SetUser()
                {
                    UserName = txtUserName.Text,
                    Name = txtName.Text,
                };

                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, URI_SERVICE);
                message.Content = JsonContent.Create<SetUser>(user);
                HttpResponseMessage response = await client.SendAsync(message);
                await DisplayAlert("Alert", "Se creó nuevo usuario", "Ok");
            }
            else
            {
                GetUser getUser = txtUserName.BindingContext as GetUser;
                SetUser user = new SetUser();
                user.UserName = txtUserName.Text;
                user.Name = txtName.Text;
                string userUri = $"{URI_SERVICE}/{getUser._id}";
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Put, userUri);
                message.Content = JsonContent.Create<SetUser>(user);
                HttpResponseMessage response = await client.SendAsync(message);
                await DisplayAlert("Alert", $"Se actualizó usuario {getUser._id}", "Ok");
                txtUserName.BindingContext = null;
            }

            txtUserName.Text = String.Empty;
            txtName.Text = String.Empty;
            GetUsers();
        }

        async void GetUsers()
        {
            HttpClient client = new HttpClient();
            List<GetUser> users = await client.GetFromJsonAsync<List<GetUser>>(URI_SERVICE);
            lstUsers.ItemsSource = users;
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            GetUser user = (sender as Button).BindingContext as GetUser;
            HttpClient client = new HttpClient();
            string userUri = $"{URI_SERVICE}/{user._id}";
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Delete, userUri);
            HttpResponseMessage response = await client.SendAsync(message);
            await DisplayAlert("Alert", $"Se eliminó usuario {user._id}", "Ok");
            GetUsers();
        }

        private void Update_Clicked(object sender, EventArgs e)
        {
            GetUser user = (sender as Button).BindingContext as GetUser;
            txtUserName.Text = user.UserName;
            txtName.Text = user.Name;
            txtUserName.BindingContext = user;
        }
    }
    class SetUser
    {
        public string UserName { get; set; }
        public string Name { get; set; }
    }
    class GetUser
    {
        public string _id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
    }
}