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
    
    public partial class work_analyzer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public work_analyzer()
        {
            this.performed_service = new HashSet<performed_service>();
        }
    
        public int id { get; set; }
        public System.DateTime order_received_date { get; set; }
        public System.TimeSpan order_execution_time { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<performed_service> performed_service { get; set; }
    }
}
