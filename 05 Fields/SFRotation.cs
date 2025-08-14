using System.Numerics;

namespace Free.FileFormats.VRML.Fields
{
    public class SFRotation : X3DField
	{
		public double X=0, Y=0, Z=1, Angle=0;

		public SFRotation() { }
		public SFRotation(double x, double y, double z, double angle) { X=x; Y=y; Z=z; Angle=angle; }

        public static implicit operator Quaternion(SFRotation sfVector)
        {
            return Quaternion.CreateFromAxisAngle(new Vector3((float)sfVector.X, (float)sfVector.Y, (float)sfVector.Z), (float)sfVector.Angle);
        }
    }
}
