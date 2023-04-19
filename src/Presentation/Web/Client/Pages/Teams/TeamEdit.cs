namespace Kasi.Web.Client.Pages.Teams
{
    public partial class TeamEdit
    {
        [Parameter]
        public string Id { get; set; } = string.Empty;
        [Inject]
        public required ITeamService TeamService { get; set; }
        [Inject]
        public required NavigationManager Navigation { get; set; }

        protected TeamResponse TeamDetails { get; set; } = new TeamResponse();
        protected string Message { get; set; } = string.Empty;
        
        protected override async Task OnInitializedAsync()
        {
            if(string.IsNullOrEmpty(Id))
            {
                // Add New Team
            }
            else
            {
                // update Team
                TeamResponse? response = await TeamService.ReadAsync(Id);

                if(response != null)
                {
                    TeamDetails = response;
                }
            }
        }

        protected void HandleFailedRequest()
        {
            Message = "Something Went Wrong! Form Not Submitted!";
        }

        protected void GoToTeams()
        {
            Navigation.NavigateTo("/teams");
        }

        protected async Task DeleteTeam()
        {
            if(!string.IsNullOrEmpty(Id))
            {
                bool response = await TeamService.DeleteAsync(Id);

                if(response)
                    Navigation.NavigateTo("/teams");
                else
                    Message = "Something Went Wrong! Driver Not Deleted!";
            }
        }

        protected async void HandleValidRequest()
        {
            if(string.IsNullOrEmpty(Id))
            {
                // add driver
                TeamRequest request = new TeamRequest()
                {
                	Name = TeamDetails.Name,
                	Alias = TeamDetails.Alias,
                	Country = TeamDetails.Country
                };
                TeamResponse response = await TeamService.CreateAsync(request);

                if(response != null)
                    Navigation.NavigateTo("/teams");
                else
                    Message = "Something Went Wrong! Driver Not Added!";
            }
            else
            {
                // Update Driver
                TeamRequest request = new TeamRequest()
                {
                	Name = TeamDetails.Name,
                	Alias = TeamDetails.Alias,
                	Country = TeamDetails.Country
                };
                bool response = await TeamService.UpdateAsync(Id, request);

                if(response)
                    Navigation.NavigateTo("/teams");
                else
                    Message = "Something Went Wrong! Driver Not Updated!";
            }
        }
    }
}