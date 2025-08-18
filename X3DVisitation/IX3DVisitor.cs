using Free.FileFormats.VRML.Nodes;

namespace Free.FileFormats.VRML.X3DVisitation;

public interface IX3DVisitor
{
    void Visit(Scene scene);
    void Visit(x3dGroup group);
    void Visit(x3dCollision collision);
    void Visit(x3dTransform transform);
    void Visit(x3dShape shape);
    void Visit(x3dBox box);
    void Visit(x3dCone cone);
    void Visit(x3dCylinder cylinder);
    void Visit(x3dElevationGrid elevationGrid);
    void Visit(x3dExtrusion extrusion);
    void Visit(x3dIndexedFaceSet indexedFaceSet);
    //void Visit(x3dViewpoint viewpoint);
    void Visit(IX3DVisitable node);
}
