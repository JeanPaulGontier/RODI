using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


[Serializable]
public class FilesManagerCore
{
    public int id { get; set; }
    public string name { get; set; }
    public string ext { get; set; }
    public string mime { get; set; }
    public long size { get; set; }
    public string path { get; set; }
    public string urlLink { get; set; }
    public byte[] content { get; set; }
    public int sequence { get; set; }
    public string title { get; set; }
    public string alt { get; set; }
}
