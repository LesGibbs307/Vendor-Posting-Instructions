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
    
    public partial class Employee
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string LDAP { get; set; }
        public string MemberOf { get; set; }
        public bool Enabled { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime UpdatedTime { get; set; }
        public int UpdatedBy { get; set; }
    }
}
