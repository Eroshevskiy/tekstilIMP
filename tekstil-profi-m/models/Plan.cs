//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tekstil_profi_m.models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Plan
    {
        public int id { get; set; }
        public Nullable<int> id_merch { get; set; }
        public string name { get; set; }
        public string material { get; set; }
        public string razmer { get; set; }
        public string color { get; set; }
        public string photo { get; set; }
        public string filePath { get; set; }
        public Nullable<int> id_otvetst { get; set; }
        public string count { get; set; }
    
        public virtual Merch Merch { get; set; }
        public virtual Otvetstvenie Otvetstvenie { get; set; }
    }
}