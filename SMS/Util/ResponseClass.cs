
public class ResponseClass
{
    public bool isSuccessful { get; set; }
    public Featured[] featured { get; set; }
    public Store[] stores { get; set; }
    public Newly_Added[] newly_added { get; set; }
    public Popular[] popular { get; set; }
    public Slider_Images[] slider_images { get; set; }
    public Bottom_Ads[] bottom_ads { get; set; }
    public Top_Ads[] top_ads { get; set; }
    public School[] schools { get; set; }
    public string latest_version { get; set; }
}

public class Featured
{
    public int id { get; set; }
    public string name { get; set; }
    public string amount { get; set; }
    public string image { get; set; }
    public int?[] images { get; set; }
    public string location { get; set; }
    public string description { get; set; }
    public string owner_name { get; set; }
    public string owner_image { get; set; }
    public string owner_contact { get; set; }
    public string owner_id { get; set; }
    public string open_time { get; set; }
    public string close_time { get; set; }
    public bool is_store { get; set; }
    public int views { get; set; }
}

public class Store
{
    public int id { get; set; }
    public string name { get; set; }
    public string image { get; set; }
    public int open_time { get; set; }
    public int close_time { get; set; }
    public string location { get; set; }
}

public class Newly_Added
{
    public int id { get; set; }
    public string name { get; set; }
    public string amount { get; set; }
    public string image { get; set; }
    public int?[] images { get; set; }
    public string location { get; set; }
    public string description { get; set; }
    public string owner_name { get; set; }
    public string owner_image { get; set; }
    public string owner_contact { get; set; }
    public string owner_id { get; set; }
    public string open_time { get; set; }
    public string close_time { get; set; }
    public bool is_store { get; set; }
    public int views { get; set; }
}

public class Popular
{
    public int id { get; set; }
    public string name { get; set; }
    public string amount { get; set; }
    public string image { get; set; }
    public int?[] images { get; set; }
    public string location { get; set; }
    public string description { get; set; }
    public string owner_name { get; set; }
    public string owner_image { get; set; }
    public string owner_contact { get; set; }
    public string owner_id { get; set; }
    public string open_time { get; set; }
    public string close_time { get; set; }
    public bool is_store { get; set; }
    public int views { get; set; }
}

public class Slider_Images
{
    public int id { get; set; }
    public string image { get; set; }
    public string product_id { get; set; }
    public string store_id { get; set; }
}

public class Bottom_Ads
{
    public int id { get; set; }
    public string image { get; set; }
    public string product_id { get; set; }
    public string store_id { get; set; }
}

public class Top_Ads
{
    public int id { get; set; }
    public string image { get; set; }
    public string product_id { get; set; }
    public string store_id { get; set; }
}

public class School
{
    public int id { get; set; }
    public string name { get; set; }
}
