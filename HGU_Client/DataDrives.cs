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
    
    public partial class DataDrives
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DataDrives()
        {
            this.Specification = new HashSet<Specification>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public int id_TypeDataDrives { get; set; }
        public double VDataDrives { get; set; }
        public Nullable<int> Count { get; set; }
    
        public virtual TypeDataDrives TypeDataDrives { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Specification> Specification { get; set; }
    }
}
