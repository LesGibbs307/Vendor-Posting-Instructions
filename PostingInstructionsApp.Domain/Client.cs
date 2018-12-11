using System.Collections.Generic;
using System.Linq;
using PostingInstructionsApp.Data;

namespace PostingInstructionsApp.Domain
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CodeName { get; set; }
        public Vendor[] Vendors { get; set; }

        public Client()
        {
            this.Id = Id;
            this.Name = Name;
            this.CodeName = CodeName;
            this.Vendors = Vendors;
        }

        public void FindClient(string clientName)
        {
            using (InfrastructureEntities context = new InfrastructureEntities())
            {
                var result = context.Clients.FirstOrDefault(x => x.Name == clientName);
                CodeName = result.Code;
                Id = result.Id;
                Name = result.Name;
            }
        }
    } 
}