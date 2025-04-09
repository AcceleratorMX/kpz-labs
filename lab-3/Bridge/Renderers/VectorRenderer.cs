using Bridge.Interfaces;

namespace Bridge.Renderers;

public class VectorRenderer : IRenderer
{
    public void RenderShape(string shapeName) => Console.WriteLine($"Drawing {shapeName} as vector");
}