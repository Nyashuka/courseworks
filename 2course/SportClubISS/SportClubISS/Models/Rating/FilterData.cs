using System;

namespace SportClubISS.Models.Rating;

public delegate void FilterAction();

public class FilterData
{
    public string FilterName { get; }
    public FilterAction FilterAction { get; }
    
 
    public FilterData(string filterName, FilterAction filterAction)
    {
        FilterName = filterName;
        FilterAction = filterAction;
    }
}