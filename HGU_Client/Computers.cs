//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HGU_Client
{
    using System;
    using System.Collections.Generic;
    
    public partial class Computers
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int id_Specification { get; set; }
        public Nullable<int> Count { get; set; }
        public string Office { get; set; }
    
        public virtual Specification Specification { get; set; }
    }
}
