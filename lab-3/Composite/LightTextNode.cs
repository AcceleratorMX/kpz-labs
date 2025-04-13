namespace Composite;

public class LightTextNode(string text) : LightNode
{
    public override string OuterHtml => text;
    public override string InnerHtml => text;
}