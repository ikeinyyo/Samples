using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace Maktub82.Samples.UserInfo.UW
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await GetUsersInformation();
        }

        public async Task GetUsersInformation()
        {
            // Get Users
            IReadOnlyList<User> users = await User.FindAllAsync();
            User current = users.Where(p => p.AuthenticationStatus == UserAuthenticationStatus.LocallyAuthenticated &&
                                        p.Type == UserType.LocalUser).FirstOrDefault();

            // Get Data from User
            await GetUserData(current);
            await GetAccountPicture(current);
        }

        private async Task GetUserData(User user)
        {
            Dictionary<string, string> dataUser = new Dictionary<string, string>();

            var firstName = await GetPropertyAsync(user, KnownUserProperties.FirstName);
            var lastName = await GetPropertyAsync(user, KnownUserProperties.LastName);
            var displayName = await GetPropertyAsync(user, KnownUserProperties.DisplayName);
            dataUser.Add("First Name", firstName);
            dataUser.Add("Last Name", lastName);
            dataUser.Add("Account Name", await GetPropertyAsync(user, KnownUserProperties.AccountName));
            dataUser.Add("Display Name", displayName);
            dataUser.Add("Domain Name", await GetPropertyAsync(user, KnownUserProperties.DomainName));
            dataUser.Add("Guest Host", await GetPropertyAsync(user, KnownUserProperties.GuestHost));
            dataUser.Add("Principal Name", await GetPropertyAsync(user, KnownUserProperties.PrincipalName));
            dataUser.Add("Provider Name", await GetPropertyAsync(user, KnownUserProperties.ProviderName));
            dataUser.Add("Session Initiation Protocol Uri", await GetPropertyAsync(user, KnownUserProperties.SessionInitiationProtocolUri));

            DisplayName.Text = string.IsNullOrEmpty(displayName) ? $"{firstName} {lastName}" : displayName;
            UserData.ItemsSource = dataUser;
        }

        private async Task GetAccountPicture(User user)
        {
            IRandomAccessStreamReference streamReference = await user.GetPictureAsync(UserPictureSize.Size1080x1080);
            if (streamReference != null)
            {
                IRandomAccessStream stream = await streamReference.OpenReadAsync();
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.SetSource(stream);
                AccountPicture.ImageSource = bitmapImage;
            }

        }

        private async Task<string> GetPropertyAsync(User user, string propertyKey)
        {
            var property = await user.GetPropertyAsync(propertyKey);
            return property?.ToString();
        }
    }
}
