//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HoteL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public int Id { get; set; }
        public System.DateTime EntryDate { get; set; }
        public System.DateTime DepartureDate { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}
