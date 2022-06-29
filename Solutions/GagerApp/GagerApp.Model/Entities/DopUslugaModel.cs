using System;
using System.Collections.Generic;
using System.Text;

namespace GagerApp.Model.Entities
{
    public class DopUslugaModel
    {
        public int ID { get; set; }
        public string Name => DopUslugaName.ToString() + ", (шт.)";
        public string DopUslugaName { get; set; }
        public string Count => DopUslugaQuantity.ToString() + " шт.";
        public int DopUslugaQuantity { get; set; }
        public string Cost => DopUslugaCost.ToString() + " руб.";
        public int DopUslugaCost { get; set; }
    }
}
