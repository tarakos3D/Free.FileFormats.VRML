using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;
using Free.FileFormats.VRML.X3DVisitation;

namespace Free.FileFormats.VRML
{
	public class Scene : IX3DVisitable
    {
		public List<X3DChildNode> Nodes=new List<X3DChildNode>();

        public void Accept(IX3DVisitor visitor) => visitor.Visit(this);
    }
}
