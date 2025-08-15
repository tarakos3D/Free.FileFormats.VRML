using Free.FileFormats.VRML.X3DVisitation;

namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// This abstract node type indicates that the concrete nodes that are
	/// instantiated based on it may be used in children, addChildren, and
	/// removeChildren fields.
	/// </summary>
	public interface X3DChildNode : IX3DVisitable
    {
        // Parent relation no possible, because of USE
    }
}
