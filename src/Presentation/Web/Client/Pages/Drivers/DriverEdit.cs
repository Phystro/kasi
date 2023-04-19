namespace Kasi.Web.Client.Pages.Drivers
{
    public partial class DriverEdit
    {
        [Parameter]
        public string Id { get; set; } = string.Empty;
        [Inject]
        public required IDriverService DriverService { get; set; }
        [Inject]
        public required ITeamService TeamService { get; set; }
        [Inject]
        public required NavigationManager Navigation { get; set; }

        protected DriverResponse DriverDetails { get; set; } = new DriverResponse();
        protected DriverRequest Request { get; set; } = new DriverRequest();
        protected IEnumerable<TeamResponse> TeamList { get; set; } = new List<TeamResponse>();
        protected string Message { get; set; } = string.Empty;
        
        protected override async Task OnInitializedAsync()
        {
            TeamList = await TeamService.QueryAsync();

            if(string.IsNullOrEmpty(Id))
            {
                // Add New Driver
            }
            else
            {
                // update driver
                DriverResponse? response = await DriverService.ReadAsync(Id);

                if(response != null)
                {
                    DriverDetails = response;
                }
            }
        }

        protected void HandleFailedRequest()
        {
            Message = "Something Went Wrong! Form Not Submitted!";
        }

        protected void GoToDrivers()
        {
            Navigation.NavigateTo("/drivers");
        }

        protected async Task DeleteDriver()
        {
            if(!string.IsNullOrEmpty(Id))
            {
                bool response = await DriverService.DeleteAsync(Id);

                if(response)
                    Navigation.NavigateTo("/drivers");
                else
                    Message = "Something Went Wrong! Driver Not Deleted!";
            }
        }

        protected async void HandleValidRequest()
        {            
            if(string.IsNullOrEmpty(Id))
            {
                // add driver
                // DriverRequest request = new DriverRequest()
                // {
                // Request.FirstName = DriverDetails.FirstName,
                // Request.LastName = DriverDetails.LastName,
                // Request.Country = DriverDetails.Country,
                // Request.RacingNumber = DriverDetails.RacingNumber,
                // Request.TeamId = .TeamId
                // };
                DriverResponse response = await DriverService.CreateAsync(Request);

                if(response != null)
                    Navigation.NavigateTo("/drivers");
                else
                    Message = "Something Went Wrong! Driver Not Added!";
            }
            else
            {
                // Update Driver
                // DriverRequest request = new DriverRequest()
                // {
                //     FirstName = DriverDetails.FirstName,
                //     LastName = DriverDetails.LastName,
                //     Country = DriverDetails.Country,
                //     RacingNumber = DriverDetails.RacingNumber,
                //     TeamId = DriverDetails.TeamId
                // };
                bool response = await DriverService.UpdateAsync(Id, Request);

                if(response)
                    Navigation.NavigateTo("/drivers");
                else
                    Message = "Something Went Wrong! Driver Not Updated!";
            }
        }
    }
}
