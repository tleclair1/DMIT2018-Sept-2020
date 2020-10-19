using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.ViewModels
{
    public class PlaylistItem
    {
        public string Name { get; set; }

        public int SongCount { get; set; }

        public string UserName { get; set; }

        public IEnumerable<PlaylistSong> Songs { get; set; }
    }
}
