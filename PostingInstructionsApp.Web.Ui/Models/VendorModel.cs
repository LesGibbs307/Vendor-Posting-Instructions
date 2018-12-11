using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostingInstructionsApp.Web.Ui.Models
{
    public class VendorModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string ClientName { get; set; }
    }
}