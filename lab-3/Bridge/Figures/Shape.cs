using Bridge.Interfaces;

namespace Bridge.Figures;

public abstract class Shape(IRenderer renderer)
{
    public abstract void Draw();
}