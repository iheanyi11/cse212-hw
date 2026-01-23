public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public Feature[] features { get; set; }
}

public class Feature
{
    public Properties properties { get; set; }
}

public class Properties
{
    public double mag { get; set; }
    public string place { get; set; }
}