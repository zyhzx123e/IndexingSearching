using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class item
{
    //model item this include items and services

    /*
c# 3.0 - Store data into Objects based on the input C# - Stack Overflow. 
* . c# 3.0 - Store data into Objects based on the input C# - Stack Overflow. [ONLINE] Available at: http://stackoverflow.com/questions/4209964/store-data-into-objects-based-on-the-input-c-sharp. 
* [Accessed 08 September 2017].
*/
    public int id { get; set; }
    public string venue { get; set; }
    public string ITEM { get; set; }
    public string description { get; set; }
    public int location_id { get; set; }
    public string available { get; set; }
    public string date{ get; set; }
    public char status { get; set; }
    public char type { get; set; }
    public int added_by { get; set; }
    public string posted_by { get; set; }
    public double unit_price { get; set; }
    public string img { get; set; }
 

    public item() 
    {
 
    }
}