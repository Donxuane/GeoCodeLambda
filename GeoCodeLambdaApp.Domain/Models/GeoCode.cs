using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoCodeLambdaApp.Domain.Models;


public class GeoCode
{
    public List<Result> Results { get; set; }
    public string Status { get; set; }
}

public class Result
{
    public List<AddressComponent> Address_Components { get; set; }
    public string Formatted_Address { get; set; }

    public Geometry Geometry { get; set; }
    public List<NavigationPoint> Navigation_Points { get; set; }
    public string Place_Id { get; set; }
    public List<string> Types { get; set; }
}

public class AddressComponent
{
    public string Long_Name { get; set; }
    public string Short_Name { get; set; }
    public List<string> Types { get; set; }
}

public class Geometry
{
    public Location Location { get; set; }

    public string Location_Type { get; set; }
    public Viewport Viewport { get; set; }
}

public class Location
{
    public double Lat { get; set; }
    public double Lng { get; set; }
}

public class Viewport
{
    public Location Northeast { get; set; }
    public Location Southwest { get; set; }
}

public class NavigationPoint
{
    public NavigationLocation Location { get; set; }
}

public class NavigationLocation
{
    public double Latitude { get; set; }

    public double Longitude { get; set; }
}



