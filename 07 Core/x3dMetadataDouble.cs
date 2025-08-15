using System.Collections.Generic;
using Free.FileFormats.VRML.Interfaces;
using Free.FileFormats.VRML.X3DVisitation;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// The metadata provided by this node is contained in the double-precision
	/// floating point numbers of the value field.
	/// 
	/// Implementation supports x3dMetadata*-nodes to be stored in children
	/// arrays, even if not standard.
	/// </summary>
	public class x3dMetadataDouble : X3DNode, X3DChildNode, X3DMetadataObject
	{
		public string Name { get; set; }
		public string Reference { get; set; }
		public List<double> Value { get; set; }

		public x3dMetadataDouble()
		{
			Name="";
			Reference="";
			Value=new List<double>();
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dMetadataDoublePROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="name") Name=parser.ParseStringValue();
			else if(id=="reference") Reference=parser.ParseStringValue();
			else if(id=="value") Value.AddRange(parser.ParseSFFloatOrMFFloatValue());
			else return false;
			return true;
		}

        public void Accept(IX3DVisitor visitor) => visitor.Visit(this);
    }
}
