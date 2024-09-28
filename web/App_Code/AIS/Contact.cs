using System;

/// <summary>
/// Description résumée de Contact
/// </summary>
public class Contact
{
    public int nim {  get; set; }
    public string name { get; set; }


    public class List
    {
        public int? id { get; set; }
        public int cric {  get; set; }
        public Guid? guid { get; set; }
        public string title { get; set; }
        public string contacts {  get; set; }
        public DateTime dt_update { get; set; }
    }
}