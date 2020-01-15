using System;
using System.Collections.Generic;
using System.Text;

namespace Sabio.Models.Requests.Forums
{
    public class PostUpdateRequest : PostAddRequest
    {
        public int Id { get; set; }
    }
}
