using System.Collections.Generic;
using Free.FileFormats.VRML.Fields;
using Free.FileFormats.VRML.Interfaces;
using Free.FileFormats.VRML.X3DVisitation;

namespace Free.FileFormats.VRML.Nodes
{
	public class dummyMatrixTransform : X3DNode, X3DGroupingNode, IDummyNode
	{
		// TODO
		// http://doc.instantreality.org/documentation/nodetype/MatrixTransform/

		public List<X3DChildNode> Children { get; set; }
		public SFVec3f BBoxCenter { get; set; }
		public SFVec3f BBoxSize { get; set; }

		public dummyMatrixTransform()
		{
			Children=new List<X3DChildNode>();
			BBoxCenter=new SFVec3f(0, 0, 0);
			BBoxSize=new SFVec3f(-1, -1, -1);
		}

		internal override X3DPrototypeInstance GetProto() { return new dummyMatrixTransformPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="children")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DChildNode child=node as X3DChildNode;
					if(child==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Children.Add(child);
				}
			}
			else if(id=="bboxCenter") BBoxCenter=parser.ParseSFVec3fValue();
			else if(id=="bboxSize") BBoxSize=parser.ParseSFVec3fValue();
			else return false;
			return true;
		}

        public void Accept(IX3DVisitor visitor) => visitor.Visit(this);
    }
}
