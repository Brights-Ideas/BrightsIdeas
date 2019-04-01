using System.Collections.Generic;
using System.Security.Policy;

namespace BrightsIdeas.Web.Models
{
    //public class Properties
    //{
    //    public Property[] property { get; set; }
    //}

    public class Properties
    {
        public string PropertyId { get; set; }
        public string Department { get; set; }
        public string Price { get; set; }
        public string BranchID { get; set; }
        public string clientName { get; set; }
        public string branchName { get; set; }
        public string DisplayAddress { get; set; }
        public string MainSummary { get; set; }
        public List<string> Images { get; set; }
    }


    public class images
    {
        public image image { get; set; }
    }

    public class image
    {
        public string modified { get; set; }
        public string text { get; set; }
    }
}