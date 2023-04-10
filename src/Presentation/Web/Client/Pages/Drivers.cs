namespace Kasi.Web.Client.Pages
{
    public partial class Drivers// : ComponentBase
    {
        public IEnumerable<Driver> _drivers { get; set; } = new List<Driver>();

        [Inject]
        private IDriverService _driverService { get; set; }

        // public Drivers(IDriverService driverService)
        // {
        //     Console.WriteLine("On Constructor Started");
        //     _driverService = driverService;
        //     Console.WriteLine("On Constructor Ended");
        // }

        protected async override Task OnInitializedAsync()
        {
            Console.WriteLine("On Initialized  Started");
            // _drivers = await _driverService.QueryAsync();
            Console.WriteLine("On Initialized Ended");
            // IEnumerable<Driver> drivers = await _driverService.QueryAsync();

            // if(drivers != null && drivers.Any())
            // {
            //     _drivers = drivers;
            // }
        }

    }
}