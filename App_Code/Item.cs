using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Item
/// </summary>
public class Item
{
    public Item()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    
    public int id_image { get; set; }
    public string ImageUrl { get; set; }
    public string legend { get; set; }
    public string cover { get; set; }
    public int position { get; set; }
}