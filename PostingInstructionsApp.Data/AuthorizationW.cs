//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PostingInstructionsApp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class AuthorizationW
    {
        public System.Guid AuthorizationGuid { get; set; }
        public int ClientVendorId { get; set; }
        public string InternalURL { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
    }
}
