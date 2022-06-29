using System;
using System.Collections.Generic;
using System.Text;

namespace GagerApp.Model.DTO
{
     public class AdressDTO
    {
        
        public long IdAdress
        {
            get; set;
        }
       
        public string Burg
        {
            get; set;
        }
        
        public string Ulica
        {
            get; set;
        }
      
        public string NumberDom
        {
            get; set;
        }
       
        public int? NumberKvartira
        {
            get; set;
        }
        
     
    }
}
