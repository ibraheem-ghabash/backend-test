//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManteqQuiz.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patient
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> FileNo { get; set; }
        public string CitizenId { get; set; }
        public Nullable<System.DateTime> Birthdate { get; set; }
        public Nullable<bool> Gender { get; set; }
        public Nullable<bool> VIP { get; set; }
        public string Natinality { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ContactPerson { get; set; }
        public string ContactRelation { get; set; }
        public string ContactPhone { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<System.DateTime> FirstVisitDate { get; set; }
        public System.DateTime RecordCreationDate { get; set; }
    }
}
