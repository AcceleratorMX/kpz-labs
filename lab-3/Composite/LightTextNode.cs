namespace Composite;

public class LightTextNode : LightNode
{
    private string _text;
    
    public override string OuterHtml => _text;
    public override string InnerHtml => _text;
    
    public LightTextNode(string text)
    {
        _text = text;
        OnCreated();
    }
    
    protected override void OnCreated()
    {
        Console.WriteLine($"TextNode created with text: {_text}");
    }
    
    protected override void OnBeforeRender()
    {
        Console.WriteLine($"TextNode preparing to render: {_text}");
    }
    
    protected override void OnAfterRender()
    {
        Console.WriteLine($"TextNode render completed: {_text}");
    }
    
    protected override void OnRemoved()
    {
        Console.WriteLine($"TextNode removed: {_text}");
    }

    public override List<LightNode> GetChildren() => [];
}