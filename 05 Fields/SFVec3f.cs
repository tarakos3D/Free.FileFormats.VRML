using System.Numerics;

namespace Free.FileFormats.VRML.Fields
{
	public class SFVec3f : X3DField
	{
		public double X=0, Y=0, Z=0;

		public SFVec3f() { }
		public SFVec3f(double x, double y, double z) { X=x; Y=y; Z=z; }

        public static implicit operator Vector3(SFVec3f sfVector)
        {
            return new Vector3((float)sfVector.X, (float)sfVector.Y, (float)sfVector.Z);
        }
    }
}
