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
    
    public partial class authorization
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string ip { get; set; }
        public Nullable<System.DateTime> last_date_of_entry { get; set; }
        public Nullable<System.TimeSpan> last_time_of_entry { get; set; }
    
        public virtual user user { get; set; }
    }
}
