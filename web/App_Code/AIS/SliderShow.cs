using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de SliderShow
/// </summary>
public class SliderShow : ICloneable
{
    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public string IdClub { get; set; }
    public string guid { get; set; }
    public string title { get; set; }
    public string urlText { get; set; }
    public string filenameImage { get; set; }
    public int orderDisplay { get; set; }
    public bool visible { get; set; }
    public bool used { get; set; }

   
}

