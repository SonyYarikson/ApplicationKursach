//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApplicationKursach
{
    using System;
    using System.Collections.Generic;
    
    public partial class Performers_and_Albums
    {
        public int id_record_performer { get; set; }
        public int id_record { get; set; }
        public int id_performer { get; set; }
    
        public virtual Albums Albums { get; set; }
        public virtual Performers Performers { get; set; }
    }
}
