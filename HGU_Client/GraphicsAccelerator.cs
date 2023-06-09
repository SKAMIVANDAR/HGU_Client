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
    
    public partial class GraphicsAccelerator
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GraphicsAccelerator()
        {
            this.Specification = new HashSet<Specification>();
        }
    
        public int ID { get; set; }
        public string Model { get; set; }
        public int id_GraphicManufacturer { get; set; }
        public int id_TypeOfGraphicsAccelerator { get; set; }
        public int id_TypeVideoMemory { get; set; }
        public double VideoMemorySize { get; set; }
        public Nullable<int> Count { get; set; }
    
        public virtual GraphicManufacturer GraphicManufacturer { get; set; }
        public virtual TypeOfGraphicsAccelerator TypeOfGraphicsAccelerator { get; set; }
        public virtual TypeVideoMemory TypeVideoMemory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Specification> Specification { get; set; }
    }
}
