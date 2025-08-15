using Free.FileFormats.VRML.Interfaces;
using Free.FileFormats.VRML.X3DVisitation;

namespace Free.FileFormats.VRML.Nodes
{
	/// <summary>
	/// BooleanTrigger is a trigger node that generates Boolean
	/// events upon receiving time events.
	/// </summary>
	public class x3dBooleanTrigger : X3DNode, X3DTriggerNode
	{
		public x3dBooleanTrigger()
		{
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dBooleanTriggerPROTO(); }

        public void Accept(IX3DVisitor visitor) => visitor.Visit(this);
    }
}
