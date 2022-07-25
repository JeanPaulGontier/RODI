using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIS
{
    [Serializable]
    public class AIS_File
    {
        private String url;
        private String name;

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
    }
}
