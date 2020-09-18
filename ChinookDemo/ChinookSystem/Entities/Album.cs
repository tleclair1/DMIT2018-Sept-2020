using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace ChinookSystem.Entities
{
    [Table("Albums")]
    internal class Album
    {
        //private data member
        private string _Title;
        private string _ReleaseLabel;

        //properties

        [Key]
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Album title is required")]
        [StringLength(160, ErrorMessage = "Album title is limited to 120 characters.")]
        public string Title { get; set; }

        //[ForeignKey] DO NOT USE!!!
        public int ArtistId { get; set; }

        public int ReleaseYear { get; set; }

        [StringLength(50, ErrorMessage = "Release label is limited to 50 characters.")]
        public string ReleaseLabel
        {
            get { return _ReleaseLabel; }
            set { _ReleaseLabel = string.IsNullOrEmpty(value) ? null : value; }
        }

        //navigational properties
        //use to verlay a model of the database ERD relationships
        //you need to know the ERD relationship between Table A and Table B
        //we have a relationship between Artist and Album
        //that relationship is parent (Artist) to child (Album)
        //an Album has one parent
        //an Artist has zero, one or more children

        //the relationship in Album is child to parent (1:1)
        public virtual Artist Artist { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }

        //constructor 

        //behaviour
    }
}
