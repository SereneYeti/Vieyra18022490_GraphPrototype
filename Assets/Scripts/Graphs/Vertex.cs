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

    public int NumResponses
    {
        get { return numResponses; }
        set { numResponses = value; }
    }
    private int numResponses;

    public int[] PossibleResponses
    {
        get { return possibleResponses; }
        set { possibleResponses = value; }
    }
    private int[] possibleResponses;

    public int LineID
    {
        get { return lineID; }
        set { lineID = value; }
    }
    private int lineID;

    public dialogueData DialogueData = new dialogueData();

    public Vertex(string lbl, int nResponses, dialogueData dialogue_Data)
    {
        this.Label = lbl;
        DialogueData = dialogue_Data;
        LineID = dialogue_Data.lineID;
        possibleResponses = dialogue_Data.possibleResponses;
        WasVisited = false;
        NumResponses = nResponses;
    }

    public Vertex()
    {
        this.Label = "";
        DialogueData = null;
        WasVisited = false;
        NumResponses = 0;
    }
}
