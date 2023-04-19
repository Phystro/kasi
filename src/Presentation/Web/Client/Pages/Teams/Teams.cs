namespace Kasi.Web.Client.Pages.Teams
{
    public partial class Teams
    {
        [Inject]
        public required ITeamService TeamService { get; set; }
        [Inject]
        public required NavigationManager Navigation { get; set; }

        public IEnumerable<TeamResponse> Items { get; set; } = new List<TeamResponse>();
        public int TeamCount { get; set; } = 0;

        public bool isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            Items = await TeamService.QueryAsync();
            isLoading = false;
            TeamCount = Items.Count();
        }

        protected void HandleAddTeam()
        {
            Navigation.NavigateTo("/teams/edit");
        }
    }
}
