//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace backend.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supplier
    {
        public Supplier()
        {
            this.Items = new HashSet<Item>();
        }
    
        public int SuppId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
    
        public virtual ICollection<Item> Items { get; set; }
    }
}