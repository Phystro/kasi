namespace Kasi.Web.Client.Pages
{
    public partial class Drivers// : ComponentBase
    {
        public IEnumerable<Driver> _drivers { get; set; } = new List<Driver>();

        [Inject]
        private IDriverService _driverService { get; set; }

        // public Drivers(IDriverService driverService)
        // {
        //     _driverService = driverService;
        // }

        protected async override Task OnInitializedAsync()
        {
            _drivers = await _driverService.QueryAsync();
            // IEnumerable<Driver> drivers = await _driverService.QueryAsync();

            // if(drivers != null && drivers.Any())
            // {
            //     _drivers = drivers;
            // }
        }

    }
}