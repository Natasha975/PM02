//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Desktop_App
{
    using System;
    using System.Collections.Generic;
    
    public partial class add_inform
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public Nullable<System.DateTime> date_of_birth { get; set; }
        public int passport_series { get; set; }
        public int passport_number { get; set; }
        public string phone { get; set; }
        public byte[] photo { get; set; }
        public string email { get; set; }
        public string ins_policy_number { get; set; }
        public Nullable<int> ins_policy_type { get; set; }
        public Nullable<int> ins_company_id { get; set; }
    
        public virtual ins_company ins_company { get; set; }
        public virtual ins_policy_type ins_policy_type1 { get; set; }
        public virtual user user { get; set; }
    }
}
