using System;
using System.Collections.Generic;
using System.Text;

namespace GagerApp.Model.DTO
{
    public class FullRoomDTO
    {
        public int IdRoom
        {
            get; set;
        }

        public string NameRoom
        {
            get; set;
        }

        public VidConstructDTO VidConstruct
        {
            get;
            set;
        }

        public List<DopUslugaDTO> DopUsluga
        {
            get; set;
        }

        public byte[] Blueprint
        {
            get;
            set;
        }
    }
}
