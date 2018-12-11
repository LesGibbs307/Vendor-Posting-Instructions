using PostingInstructionsApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostingInstructionsApp.Domain
{
    public class AuthKey
    {
        public string UniqueIdentifier { get; set; }

        public string GetAuthKey(int clientVendorId) {
            using (InfrastructureEntities context = new InfrastructureEntities()) {
                var result = context.AuthorizationWS.Where(x => x.ClientVendorId == clientVendorId).ToList();

                foreach (var obj in result)
                {
                    UniqueIdentifier = obj.AuthorizationGuid.ToString();
                }
            }
                return UniqueIdentifier;
        }

        public string CreateAuthKey(ClientVendorRel clientVendor) {
            AuthKey authKey = new AuthKey();
            using (InfrastructureEntities context = new InfrastructureEntities()) {
                var result = context.AuthorizationWS.Select(v => v).ToList();
                var newAuth = new AuthorizationW();
                newAuth.AuthorizationGuid = Guid.NewGuid();
                authKey.UniqueIdentifier = newAuth.AuthorizationGuid.ToString();
                newAuth.ClientVendorId = clientVendor.Id;
                newAuth.InternalURL = "http://api.dev.rmiatl.org/lead/v2/";
                newAuth.Enabled = true;
                newAuth.CreatedTime = DateTime.Now;
                context.AuthorizationWS.Add(newAuth);
                context.SaveChanges();
            }
            return authKey.UniqueIdentifier;
        }
    }
}