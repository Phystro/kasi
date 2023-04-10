namespace Kasi.Web.Client.Pages.Drivers
{
    public partial class Drivers
    {
        public IEnumerable<Driver> Items { get; set; } = new List<Driver>();

        [Inject]
        public required DriverService DriverService { get; set; }

        // public Drivers(IDriverService driverService)
        // {
        //     Console.WriteLine("On Constructor Started");
        //     _driverService = driverService;
        //     Console.WriteLine("On Constructor Ended");
        // }

        protected async override Task OnInitializedAsync()
        {
            Console.WriteLine("On Initialized  Started");
            Items = await DriverService.QueryAsync();
            Console.WriteLine("On Initialized Ended");
            // IEnumerable<Driver> drivers = await _driverService.QueryAsync();

            // if(drivers != null && drivers.Any())
            // {
            //     _drivers = drivers;
            // }
        }
    }
}
