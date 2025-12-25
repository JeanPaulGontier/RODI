using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.Xml.Serialization;
namespace AIS.RotaryInternational
{ 
    [XmlRoot(ElementName = "image")]
    public class Image
    {
        public Image()
        {
            this.Url = "";
            this.Title = "";
            this.Link = "";
        }

        [XmlElement(ElementName = "url")] public string Url { get; set; }

        [XmlElement(ElementName = "title")] public string Title { get; set; }

        [XmlElement(ElementName = "link")] public string Link { get; set; }
    }

    [XmlRoot(ElementName = "guid")]
    public class guid
    {
        public guid()
        {
            this.Text = "";
        }

        [XmlAttribute(AttributeName = "isPermaLink")]
        public bool IsPermalink { get; set; }

        [XmlText] public string Text { get; set; }
    }

    [XmlRoot(ElementName = "item")]
    public class Item
    {
        public Item()
        {
            this.Guid = new guid();
            this.Title = "";
            this.Link = "";
            this.PubDateString = "";
            this.Description = "";
            this.Photo="";
            this.Dt=DateTime.Now;
           // this.PubDate = DateTimeOffset.Parse(this.PubDateString);
            this.Media = new List<Content>();
            this.Category = new List<string>();
            this.Enclosure = new Enclosure();
        }


        [XmlElement(ElementName = "guid")] public guid Guid { get; set; }

        [XmlElement(ElementName = "title")] public string Title { get; set; }

        [XmlElement(ElementName = "photo")] public string Photo { get; set; }

        [XmlElement(ElementName = "dt")] public DateTime Dt { get; set; }


        [XmlElement(ElementName = "link")] public string Link { get; set; }

        [XmlIgnore] public DateTimeOffset PubDate;

        [XmlElement(ElementName = "pubDate"),
         EditorBrowsable(EditorBrowsableState.Never),
         Browsable(false)]
        public string PubDateString { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "content", Namespace = "http://search.yahoo.com/mrss/")]
        public List<Content> Media { get; set; }

        [XmlElement(ElementName = "category")] public List<string> Category { get; set; }

        [XmlElement(ElementName = "enclosure")]
        public Enclosure Enclosure { get; set; }
    }

    [XmlRoot(ElementName = "rating", Namespace = "http://search.yahoo.com/mrss/")]
    public class Rating
    {
        public Rating()
        {
            this.Text = "";
        }

        [XmlAttribute(AttributeName = "scheme")]
        public string Scheme { get; set; }

        [XmlText] public string Text { get; set; }
    }

    [XmlRoot(ElementName = "description", Namespace = "http://search.yahoo.com/mrss/")]
    public class Description
    {
        public Description()
        {
            this.Text = "";
            this.Type = "";
        }

        [XmlAttribute(AttributeName = "type")] public string Type { get; set; }

        [XmlText] public string Text { get; set; }
    }

    [XmlRoot(ElementName = "content", Namespace = "http://search.yahoo.com/mrss/")]
    public class Content
    {
        public Content()
        {
            this.Rating = new Rating();
            this.Url = "";
            this.Type = "";
            this.Medium = "";
            this.Text = "";
        }


        [XmlElement(ElementName = "rating", Namespace = "http://search.yahoo.com/mrss/")]
        public Rating Rating { get; set; }

        [XmlElement(ElementName = "description", Namespace = "http://search.yahoo.com/mrss/")]
        public Description Description { get; set; }

        [XmlAttribute(AttributeName = "url")] public string Url { get; set; }

        [XmlAttribute(AttributeName = "type")] public string Type { get; set; }

        [XmlAttribute(AttributeName = "fileSize")]
        public int FileSize { get; set; }

        [XmlAttribute(AttributeName = "medium")]
        public string Medium { get; set; }

        [XmlText] public string Text { get; set; }
    }

    [XmlRoot(ElementName = "enclosure")]
    public class Enclosure
    {
        public Enclosure()
        {
            this.Url = "";
            this.Type = "";
        }

        [XmlAttribute(AttributeName = "url")] public string Url { get; set; }

        [XmlAttribute(AttributeName = "length")]
        public int Length { get; set; }

        [XmlAttribute(AttributeName = "type")] public string Type { get; set; }
    }

    [XmlRoot(ElementName = "channel")]
    public class Channel
    {
        public Channel()
        {
            this.Title = "";
            this.Description = "";
            this.Link = "";
            this.Image = new Image();
            this.LastBuildDateString = "";
            //this.LastBuildDate = DateTimeOffset.Parse(this.LastBuildDateString);
            this.Icon = "";
            this.Generator = "";
            this.Items = new List<Item>();
        }


        [XmlElement(ElementName = "title")] public string Title { get; set; }

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "link")] public string Link { get; set; }

        [XmlElement(ElementName = "image")] public Image Image { get; set; }

        [XmlIgnore]
        public DateTimeOffset LastBuildDate;

        [XmlElement(ElementName = "lastBuildDate"),
         EditorBrowsable(EditorBrowsableState.Never),
         Browsable(false)]
        public string LastBuildDateString { get; set; }

        [XmlElement(ElementName = "icon", Namespace = "http://webfeeds.org/rss/1.0")]
        public string Icon { get; set; }

        [XmlElement(ElementName = "generator")]
        public string Generator { get; set; }

        [XmlElement(ElementName = "item")] public List<Item> Items { get; set; }
    }

    [XmlRoot(ElementName = "rss")]
    public class Rss
    {
        public Rss()
        {
            this.Channel = new Channel();
        }
        [XmlElement(ElementName = "channel")] public Channel Channel { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public double Version { get; set; }
    }
}