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
    
    public partial class Playlists
    {
        public int id_PlaylistRecord { get; set; }
        public int id_playlist { get; set; }
        public int id_record { get; set; }
        public int id_user { get; set; }
    
        public virtual Albums Albums { get; set; }
        public virtual Playlist_description Playlist_description { get; set; }
        public virtual Users Users { get; set; }
    }
}