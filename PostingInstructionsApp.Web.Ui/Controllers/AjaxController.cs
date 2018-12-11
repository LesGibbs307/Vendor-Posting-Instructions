using System.Web.Mvc;
using PostingInstructionsApp.Domain;
using PostingInstructionsApp.Web.Ui.Models;

namespace PostingInstructionsApp.Web.Ui.Controllers
{
    public class AjaxController : Controller
    {
        [HttpPost]
        public ActionResult PostData(ClientVendorModel model)
        {
            string clientName = model.client;
            string vendorName = model.vendor;
            AuthKey authKey = new AuthKey();
            //WordDoc wordDoc = new WordDoc();
            //wordDoc.CreateSampleDocument();

            if (vendorName != null) {
                Client client = new Client();
                Vendor vendor = new Vendor();

                ClientVendor clientVendor = new ClientVendor();
                client.FindClient(clientName);
                vendor.FindVendor(vendorName);
                clientVendor.CreateClientVendorRel(client, vendor, authKey);
                model.vendor = vendorName;
                model.client = clientName;
                model.authKey = authKey.UniqueIdentifier;
                Session["Client"] = clientName;
                Session["Vendor"] = vendorName;
                Session["AuthKey"] = authKey.UniqueIdentifier;

                return new JsonResult()
                {
                    Data = new { Success = true }
                };

            }

            return View();
        }
    }
}