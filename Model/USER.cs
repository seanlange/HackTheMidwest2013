//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KcCauldronCapo.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Votes = new HashSet<Vote>();
        }
    
        public int USER_ID { get; set; }
        public System.DateTime DATE_ADDED_DT_TM { get; set; }
        public string PHONE_NUMBER { get; set; }
        public string SECTION { get; set; }
    
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
