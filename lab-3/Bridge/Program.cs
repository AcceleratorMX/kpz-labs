using Bridge.Figures;
using Bridge.Interfaces;
using Bridge.Renderers;

IRenderer vectorRenderer = new VectorRenderer();
IRenderer rasterRenderer = new RasterRenderer();

Shape circleVector = new Circle(vectorRenderer);
Shape circleRaster = new Circle(rasterRenderer);
Shape squareVector = new Square(vectorRenderer);
Shape squareRaster = new Square(rasterRenderer);
Shape triangleVector = new Triangle(vectorRenderer);
Shape triangleRaster = new Triangle(rasterRenderer);

Console.WriteLine("Vector rendering:");
circleVector.Draw();
squareVector.Draw();
triangleVector.Draw();

Console.WriteLine("\nRaster rendering:");
circleRaster.Draw();
squareRaster.Draw();
triangleRaster.Draw();