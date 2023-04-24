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

        protected DriverResponse Response { get; set; } = new DriverResponse();
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
                    Response = response;
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
                Request.FirstName = Response.FirstName;
                Request.LastName = Response.LastName;
                Request.Country = Response.Country;
                Request.RacingNumber = Response.RacingNumber;
                Request.TeamId = Response.TeamId;

                DriverResponse response = await DriverService.CreateAsync(Request);

                if(response != null)
                    Navigation.NavigateTo("/drivers");
                else
                    Message = "Something Went Wrong! Driver Not Added!";
            }
            else
            {
                Request.FirstName = Response.FirstName;
                Request.LastName = Response.LastName;
                Request.Country = Response.Country;
                Request.RacingNumber = Response.RacingNumber;
                Request.TeamId = Response.TeamId;

                bool response = await DriverService.UpdateAsync(Id, Request);

                if(response)
                    Navigation.NavigateTo("/drivers");
                else
                    Message = "Something Went Wrong! Driver Not Updated!";
            }
        }
    }
}
