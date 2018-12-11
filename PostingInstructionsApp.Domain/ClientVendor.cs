using PostingInstructionsApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace PostingInstructionsApp.Domain
{
    public class ClientVendor
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int VendorId { get; set; }
        public string SourceName { get; set; }
        public string ClientCode { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreatedTime { get; set; }

        //private List<Client> FindClients()
        //{
        //    using (InfrastructureEntities context = new InfrastructureEntities())
        //    {
        //        return FindClients(context);
        //    }
        //}

        private List<Client> FindClients(List<Client> clientList)
        {
            using (InfrastructureEntities context = new InfrastructureEntities())
            {
                var result = context.Clients.OrderBy(x => x.Name).ToList();
                foreach (var obj in result)
                {
                    Client client = new Client();
                    client.Id = obj.Id;
                    client.Name = obj.Name;
                    client.CodeName = obj.Code;
                    clientList.Add(client);
                }                
            }

            return clientList;
        }        

        private List<Vendor> FindVendors(List<Vendor> vendorList)
        {
            using (InfrastructureEntities context = new InfrastructureEntities())
            {
                var result = context.Vendors.Select(x => x).OrderBy(x => x.VendorName).ToList();

                foreach(var obj in result)
                {
                    if(obj.VendorName != "Test") { 
                        Vendor vendor = new Vendor();
                        vendor.Id = obj.Id;
                        vendor.VendorName = obj.VendorName;
                        vendor.Enabled = obj.Enabled;
                        vendor.CreatedTime = obj.CreatedTime;
                        vendorList.Add(vendor);
                    }
                }
            }
            return vendorList;
        }

        private List<ClientVendor> FindClientVendor(List<ClientVendor> clientVendorsRel) {
            using (InfrastructureEntities context = new InfrastructureEntities())
            {
                var result = context.ClientVendorRels.Select(x => x).OrderBy(x => x.SourceName).ToList();

                foreach (var obj in result)
                {
                    ClientVendor clientVendor = new ClientVendor();
                    clientVendor.Id = obj.Id;
                    clientVendor.ClientId = obj.ClientId;
                    clientVendor.VendorId = obj.VendorId;
                    clientVendor.SourceName = obj.SourceName;
                    clientVendor.Enabled = obj.Enabled;
                    clientVendor.CreatedTime = obj.CreatedTime;
                    clientVendorsRel.Add(clientVendor);
                }
            }
            return clientVendorsRel;
        }

        private string getClientName(ClientVendor thisClientVendor, List<Client> clientList, string clientName) {
            for (var i = 0; i < clientList.Count; i++) {
                Client thisClient = clientList[i];
                if (thisClient.Id == thisClientVendor.ClientId) {
                    clientName = thisClient.Name;
                }
            }
            return clientName;
        }

        private List<object> GetClientVendorRel(List<Vendor> vendorList, List<Client> clientList, List<object> clientVendorList) {
            string vendorName, clientName = "";
            List <ClientVendor> clientVendorsRel = new List<ClientVendor>();

            FindClientVendor(clientVendorsRel);

            for (var r = 0; clientVendorsRel.Count > r; r++) {
                ClientVendor thisClientVendor = clientVendorsRel[r];

                if (thisClientVendor.VendorId != 0) {
                    for (var v = 0; vendorList.Count > v; v++) {
                        Vendor thisVendor = vendorList[v];
                        AuthKey authKey = new AuthKey();
                        if (thisClientVendor.VendorId == thisVendor.Id) {
                            string key = authKey.GetAuthKey(thisClientVendor.Id);
                            vendorName = thisVendor.VendorName;
                            clientName = getClientName(thisClientVendor, clientList, clientName);

                            var clientVendorInfo = new
                            {
                                vendorName,
                                clientName,
                                authKey = key
                            };
                            clientVendorList.Add(clientVendorInfo);
                        }
                    }
                }
            }
            return clientVendorList;
        }


        public List<object> getClientsAndVendors(List<Client> clientList, List<Vendor> vendorList, List<object> clientVendorList) {
            //using (InfrastructureEntities context = new InfrastructureEntities())
            //{
            //clientList = FindClients(context);
            //vendorList = FindVendors(vendorList);
            //}
            FindClients(clientList);
            FindVendors(vendorList);
            GetClientVendorRel(vendorList, clientList, clientVendorList);
            return clientVendorList;
        }


        public int GetClientVendorId(string vendorName, string clientName)
        {
            using (InfrastructureEntities context = new InfrastructureEntities())
            {
                var result = context.v_ClientVendors.Where(c => c.ClientName == clientName && c.VendorName == vendorName).ToList();
                foreach (var obj in result)
                {
                   Id = obj.ClientVenderId;
                }
            }
            return Id;
        }

        public void CreateClientVendorRel(Client client, Vendor vendor, AuthKey authKey)
        {
            using (InfrastructureEntities context = new InfrastructureEntities()) {
                var result = context.ClientVendorRels.Select(v => v).ToList();
                var clientVendor = new ClientVendorRel();
                clientVendor.ClientId = client.Id;
                clientVendor.VendorId = vendor.Id;
                clientVendor.SourceName = vendor.VendorName + "-" + client.CodeName;
                clientVendor.Enabled = true;
                clientVendor.CreatedTime = DateTime.Now;
                context.ClientVendorRels.Add(clientVendor);
                context.SaveChanges();
                authKey.UniqueIdentifier = authKey.CreateAuthKey(clientVendor);
            }
        }
    }
}