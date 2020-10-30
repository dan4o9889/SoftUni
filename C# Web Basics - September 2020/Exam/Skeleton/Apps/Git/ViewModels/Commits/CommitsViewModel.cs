using System;
using System.Collections.Generic;
using System.Text;

namespace Git.ViewModels.Commits
{
    public class CommitsViewModel
    {
        public string Repository { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public Action Delete { get; set; }
    }
}
