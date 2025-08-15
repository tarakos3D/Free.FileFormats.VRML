using Free.FileFormats.VRML.Interfaces;
using Free.FileFormats.VRML.X3DVisitation;

namespace Free.FileFormats.VRML.Nodes
{
	public class x3dMidiSensor : X3DNode, X3DMidiDeviceSensorNode
	{
		public bool Enabled { get; set; }
		public string Name { get; set; }

		public x3dMidiSensor()
		{
			Enabled=true;
			Name="";
		}

		internal override X3DPrototypeInstance GetProto() { return new x3dMidiSensorPROTO(); }

		internal override bool ParseNodeBodyElement(string id, VRMLParser parser)
		{
			if(id=="enabled") Enabled=parser.ParseBoolValue();
			else if(id=="name") Name=parser.ParseStringValue();
			else return false;
			return true;
		}

        public void Accept(IX3DVisitor visitor) => visitor.Visit(this);
    }
}
