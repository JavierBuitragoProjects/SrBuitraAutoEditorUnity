
public class SimplifiedCapcutFormatClass
{
    public SimplifiedMaterials materials { get; set; }
    public SimplifiedTrack[] tracks { get; set; }
}

public class SimplifiedMaterials
{
    
    public SimplifiedDrafts[] drafts { get; set; }
    public SimplifiedVideo[] videos { get; set; }
}

public class SimplifiedDrafts
{
    public CapcutFormatClass draft { get; set; }
    public string id { get; set; }

    public string type { get; set; }
}
public class SimplifiedVideo
{
   
    public string id { get; set; }
    public string material_id { get; set; }
    public string material_name { get; set; }
    public string material_url { get; set; }
    public string path { get; set; }
}

public class SimplifiedTime_Range
{
    public int duration { get; set; }
    public int start { get; set; }
}

public class SimplifiedTrack
{
    public string id { get; set; }
    public bool is_default_name { get; set; }
    public string name { get; set; }
    public SimplifiedSegment[] segments { get; set; }
    public string type { get; set; }
}

public class SimplifiedSegment
{
   
    public string[] extra_material_refs { get; set; }
    public string id { get; set; }
    public string material_id { get; set; }
    public SimplifiedSource_Timerange source_timerange { get; set; }
    public SimplifiedTarget_Timerange target_timerange { get; set; }
}


public class SimplifiedSource_Timerange
{
    public int duration { get; set; }
    public int start { get; set; }
}

public class SimplifiedTarget_Timerange
{
    public int duration { get; set; }
    public int start { get; set; }
}

