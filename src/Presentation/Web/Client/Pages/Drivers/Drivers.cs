namespace Kasi.Web.Client.Pages.Drivers
{
    public partial class Drivers
    {
        [Inject]
        public required IDriverService DriverService { get; set; }
        [Inject]
        public required NavigationManager Navigation { get; set; }

        public IEnumerable<DriverResponse> Items { get; set; } = new List<DriverResponse>();
        public Team DriverTeam { get; set; } = new Team();
        public int DriversCount { get; set; } = 0;

        public bool isLoading = true;
        
        protected async override Task OnInitializedAsync()
        {
            Items = await DriverService.QueryAsync();
            isLoading = false;
            DriversCount = Items.Count();
        }

        protected void HandleAddDriver()
        {
            Navigation.NavigateTo("/drivers/edit");
        }
    }
}
