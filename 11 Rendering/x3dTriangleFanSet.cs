using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;
using Free.FileFormats.VRML.X3DVisitation;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// A TriangleFanSet represents a 3D shape composed of triangles that form
	/// a fan shape around the first vertex declared in each fan.
	/// </summary>
	public class x3dTriangleFanSet : X3DNode, X3DComposedGeometryNode
	{
		public List<X3DVertexAttributeNode> Attrib { get; set; }
		public X3DColorNode Color { get; set; }
		public X3DCoordinateNode Coord { get; set; }
		public List<int> FanCount { get; set; }
		public IX3DFogCoordinateNode FogCoord { get; set; }
		public X3DNormalNode Normal { get; set; }
		public X3DTextureCoordinateNode TexCoord { get; set; }
		public bool CCW { get; set; }
		public bool ColorPerVertex { get; set; }
		public bool NormalPerVertex { get; set; }
		public bool Solid { get; set; }

		public x3dTriangleFanSet()
		{
			Attrib=new List<X3DVertexAttributeNode>();
			FanCount=new List<int>();
			CCW=true;
			ColorPerVertex=true;
			NormalPerVertex=true;
			Solid=true;
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dTriangleFanSetPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			int line=parser.Line;

			if(id=="attrib")
			{
				List<X3DNode> nodes=parser.ParseSFNodeOrMFNodeValue();
				foreach(X3DNode node in nodes)
				{
					X3DVertexAttributeNode attr=node as X3DVertexAttributeNode;
					if(attr==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
					else Attrib.Add(attr);
				}
			}
			else if(id=="color")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Color=node as X3DColorNode;
					if(Color==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="coord")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Coord=node as X3DCoordinateNode;
					if(Coord==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="fanCount") FanCount.AddRange(parser.ParseSFInt32OrMFInt32Value());
			else if(id=="fogCoord")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					FogCoord=node as IX3DFogCoordinateNode;
					if(FogCoord==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="normal")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					Normal=node as X3DNormalNode;
					if(Normal==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="texCoord")
			{
				X3DNode node=parser.ParseSFNodeValue();
				if(node!=null)
				{
					TexCoord=node as X3DTextureCoordinateNode;
					if(TexCoord==null) parser.ErrorParsingNode(VRMLReaderError.UnexpectedNodeType, this, id, node, line);
				}
			}
			else if(id=="ccw") CCW=parser.ParseBoolValue();
			else if(id=="colorPerVertex") ColorPerVertex=parser.ParseBoolValue();
			else if(id=="normalPerVertex") NormalPerVertex=parser.ParseBoolValue();
			else if(id=="solid") Solid=parser.ParseBoolValue();
			else return false;
			return true;
		}

        public void Accept(IX3DVisitor visitor) => visitor.Visit(this);
    }
}
