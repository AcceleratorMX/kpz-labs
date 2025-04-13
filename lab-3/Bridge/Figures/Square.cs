﻿using Bridge.Interfaces;

namespace Bridge.Figures;

public class Square(IRenderer renderer) : Shape(renderer)
{
    private readonly IRenderer _renderer = renderer;
    
    public override void Draw() => _renderer.RenderShape(GetType().Name);
}