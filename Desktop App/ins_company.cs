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
    
    public partial class ins_company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ins_company()
        {
            this.add_inform = new HashSet<add_inform>();
        }
    
        public int id { get; set; }
        public string company_name { get; set; }
        public string address { get; set; }
        public string inn { get; set; }
        public string r_s { get; set; }
        public string bik { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<add_inform> add_inform { get; set; }
    }
}