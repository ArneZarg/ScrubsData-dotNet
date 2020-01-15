using System;
using System.Collections.Generic;
using System.Text;

namespace Sabio.Models.Requests.Forums
{
    public class ReplyUpdateRequest : ReplyAddRequest
    {
        public int Id { get; set; }
    }
}
