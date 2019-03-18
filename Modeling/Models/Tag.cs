using System.Collections.Generic;

namespace Modeling.Models
{
    public class Tag
    {
        public string TagId { get; set; }

        public List<PostTag> Posts { get; set; }
    }
}
