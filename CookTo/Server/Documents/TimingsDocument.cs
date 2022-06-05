namespace CookTo.Server.Documents;

public class TimingsDocument
{
    [BsonElement("prep_time_from")]
    public int PrepTimeFrom { get; set; }

    [BsonElement("prep_time_to")]
    public int PrepTimeTo { get; set; }

    [BsonElement("cooking_time_from")]
    public int CookTimeFrom { get; set; }

    [BsonElement("cooking_time_to")]
    public int CookTimeTo { get; set; }
}
