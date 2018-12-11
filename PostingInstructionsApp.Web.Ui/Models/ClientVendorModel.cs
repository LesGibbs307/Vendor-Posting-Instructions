using PostingInstructionsApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostingInstructionsApp.Web.Ui.Models
{
    public class ClientVendorModel
    {
        public List<Client> clients { get; set; }
        public List<Vendor> vendors { get; set; }
        public List<object> clientVendors { get; set; }
        public string client { get; set; }
        public string vendor { get; set; }
        public string authKey { get; set; }
    }
}