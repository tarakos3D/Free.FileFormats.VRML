using System;
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
            // Explanation:
            // https://www.euclideanspace.com/maths/geometry/rotations/conversions/angleToQuaternion/index.htm

            var axis = Vector3.Normalize(new Vector3((float)sfVector.X, (float)sfVector.Y, (float)sfVector.Z));
            var halfAngle = (float)sfVector.Angle * 0.5f;
            var sinHalf = (float)Math.Sin(halfAngle);
            var cosHalf = (float)Math.Cos(halfAngle);

            return new Quaternion(axis * sinHalf, cosHalf);
        }
    }
}
