using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PostingInstructionsApp.Domain;
using PostingInstructionsApp.Web.Ui.Models;

namespace PostingInstructionsApp.Web.Ui.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(ClientVendorModel model) {
            List<Client> clientList = new List<Client>();
            List<Vendor> vendorList = new List<Vendor>();
            List<object> clientVendorList = new List<object>();
            ClientVendor clientVendor = new ClientVendor();
            clientVendor.getClientsAndVendors(clientList, vendorList, clientVendorList);
            model.clients = clientList;
            model.vendors = vendorList;
            model.clientVendors = clientVendorList;
            ViewData["Clients"] = model.clients;
            ViewData["Vendors"] = model.vendors;
            ViewData["ClientVendor"] = model.clientVendors;
            return View();
        }

        [HttpGet]
        public ActionResult ThankYou(ClientVendorModel model)
        {
            return View();
        }
    }
}