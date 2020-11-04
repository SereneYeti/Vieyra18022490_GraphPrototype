public class Vertex
{
    public bool WasVisited
    {
        get { return wasVisisted; }
        set { wasVisisted = value; }
        
    }
    private bool wasVisisted;

    //Label = CharacterNickname + '_' + LineID
    public string Label
    {
        get { return label; }
        set { label = value; }
    }
    private string label;

    public Vertex(string lbl)
    {
        this.Label = lbl;
        WasVisited = false;
    }
}
