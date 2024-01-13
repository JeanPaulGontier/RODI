using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Block
/// </summary>
/// 
namespace AIS
{
    public class Block : Yemon.dnn.BlocksContent.Block
    {
        public class NewsClub
        {
            public string Title { get; set; }
            public int NBToShow { get; set; }
            public string DateBehavior { get; set; }
            public bool ShowImage { get; set; }
            public bool ShowTitle { get; set; }
            public bool ShowDate { get; set; }
        } 

    }
}