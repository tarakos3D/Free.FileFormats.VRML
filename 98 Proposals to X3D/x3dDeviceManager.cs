using Free.FileFormats.VRML.Interfaces;
using Free.FileFormats.VRML.X3DVisitation;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dDeviceManager : X3DNode, X3DChildNode
	{
		public x3dDeviceManager()
		{
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dDeviceManagerPROTO(); }

        public void Accept(IX3DVisitor visitor) => visitor.Visit(this);
    }
}
