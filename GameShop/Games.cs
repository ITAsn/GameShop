//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameShop
{
    using System;
    using System.Collections.Generic;
    
    public partial class Games
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
        public int Developer { get; set; }
        public int Publisher { get; set; }
        public string CP1 { get; set; }
        public string OP1 { get; set; }
        public string GPD1 { get; set; }
        public string D1 { get; set; }
        public string CP2 { get; set; }
        public string OP2 { get; set; }
        public string GDP2 { get; set; }
        public string D2 { get; set; }
    
        public virtual Developers Developers { get; set; }
        public virtual Publishers Publishers { get; set; }
    }
}
