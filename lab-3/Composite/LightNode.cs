namespace Composite;

public abstract class LightNode
{
    public abstract string OuterHtml { get; }
    public abstract string InnerHtml { get; }
    
    public string Render()
    {
        OnBeforeRender();
        var result = OuterHtml;
        OnAfterRender();
        return result;
    }
    
    protected virtual void OnCreated() { }
    protected virtual void OnBeforeRender() { }
    protected virtual void OnAfterRender() { }
    protected virtual void OnRemoved() { }
    
    public void Remove()
    {
        OnRemoved();
    }
    
    public virtual List<LightNode> GetChildren() => [];
}