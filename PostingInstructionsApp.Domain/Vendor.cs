using PostingInstructionsApp.Data;
using System;
using System.Linq;

namespace PostingInstructionsApp.Domain
{
    public class Vendor
    {
        public int Id { get; set; }
        public string VendorName { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreatedTime { get; set; }
        public Client[] Clients { get; set; }

        public Vendor() {
            this.Id = Id;
            this.VendorName = VendorName;
            this.Enabled = Enabled;
            this.CreatedTime = CreatedTime;
            this.Clients = Clients;
        }

        private void AddVendor(string vendorName)
        {
            using (InfrastructureEntities context = new InfrastructureEntities())
            {
                var results = context.Vendors.Select(v => v).ToList();
                var vendor = new Data.Vendor();
                vendor.CreatedTime = DateTime.Now;
                vendor.Enabled = true;
                vendor.VendorName = vendorName;
                vendor.Id = results.Count;
                results.Add(vendor);
                context.Vendors.Add(vendor);
                context.SaveChanges();
            }
        }

        public void FindVendor(string vendorName)
        {
            using (InfrastructureEntities context = new InfrastructureEntities())
            {
                var result = context.Vendors.FirstOrDefault(x => x.VendorName == vendorName);

                if(result == null) {
                    AddVendor(vendorName);
                } else {
                    Id = result.Id;
                    VendorName = result.VendorName;
                }
            }
        }
    }
}