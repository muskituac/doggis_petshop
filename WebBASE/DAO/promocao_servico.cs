//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBASE.DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class promocao_servico
    {
        public int id { get; set; }
        public int id_promocao { get; set; }
        public int id_servico { get; set; }
    
        public virtual promocao promocao { get; set; }
        public virtual servico servico { get; set; }
    }
}
