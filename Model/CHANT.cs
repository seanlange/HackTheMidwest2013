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
    
    public partial class CHANT
    {
        public CHANT()
        {
            this.CHANT_HISTORY = new HashSet<CHANT_HISTORY>();
            this.VOTES = new HashSet<VOTE>();
        }
    
        public int CHANT_ID { get; set; }
        public string CHANT_NAME { get; set; }
        public string LYRICS { get; set; }
        public string ERRATA { get; set; }
        public string LISTENLINK { get; set; }
        public string HISTORY { get; set; }
    
        public virtual ICollection<CHANT_HISTORY> CHANT_HISTORY { get; set; }
        public virtual ICollection<VOTE> VOTES { get; set; }
    }
}
