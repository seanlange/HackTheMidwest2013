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
    
    public partial class Vote
    {
        public int VOTE_ID { get; set; }
        public int CHANT_ID { get; set; }
        public System.DateTime DATE_ADDED_DT_TM { get; set; }
        public Nullable<int> USER_ID { get; set; }
    
        public virtual Chant Chant { get; set; }
        public virtual User User { get; set; }
    }
}
