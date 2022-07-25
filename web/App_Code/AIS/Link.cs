using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIS
{
    [Serializable]
    public class Link
    {
        String url;
        String texte;
        String target;

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

        public string Texte
        {
            get
            {
                return texte;
            }

            set
            {
                texte = value;
            }
        }

        public string Target
        {
            get
            {
                return target;
            }

            set
            {
                target = value;
            }
        }
    }
}
