namespace PTA.Repository.Requests
{
    public class SearchUserRequest
    {
        public bool? IsEnabled { get; set; }
        public bool? IsExpired { get; set; }
    }
}
