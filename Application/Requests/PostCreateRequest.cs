using System;

namespace Application.Requests
{
    public class PostCreateRequest
    {
        public string Title { get; set; }

        public string Contents { get; set; }

        public int Audience { get; set; }
    }
}