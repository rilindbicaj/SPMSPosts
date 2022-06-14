namespace Application.Requests
{
    public class PostsReadByUserRequest
    {
        public int? Faculty { get; set; }
        public int? Role { get; set; }
        public int? Generation { get; set; }
    }
}