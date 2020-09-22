namespace ChinookSystem.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    internal partial class Playlist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Playlist()
        {
            PlaylistTracks = new HashSet<PlaylistTrack>();
        }

        public int PlaylistId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(120, ErrorMessage = "Name is limited to 120 characters")]
        public string Name { get; set; }

        [StringLength(120, ErrorMessage = "Username is limited to 120 characters")]
        public string UserName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
}
