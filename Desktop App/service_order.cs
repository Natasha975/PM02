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
    
    public partial class service_order
    {
        public int id { get; set; }
        public int id_service { get; set; }
        public int id_order { get; set; }
    
        public virtual order order { get; set; }
        public virtual performed_service performed_service { get; set; }
    }
}
