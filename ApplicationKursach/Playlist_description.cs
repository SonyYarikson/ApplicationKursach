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
    
    public partial class Playlist_description
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Playlist_description()
        {
            this.Playlists = new HashSet<Playlists>();
        }
    
        public int id_playlist { get; set; }
        public string Name { get; set; }
        public int Obedience { get; set; }
        public byte[] Cover { get; set; }
        public System.DateTime Creation_date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Playlists> Playlists { get; set; }
    }
}
