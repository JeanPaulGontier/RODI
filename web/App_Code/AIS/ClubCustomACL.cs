using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de ClubCustomACL
/// </summary>
public class ClubCustomACL
{
    
    public List<KeyValuePair<string,int>> Administrators { get; set; } 
    
    public ClubCustomACL()
    {
        Administrators = new List<KeyValuePair<string,int>>();
    }

}