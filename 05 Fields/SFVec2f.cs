using System.Numerics;

namespace Free.FileFormats.VRML.Fields
{
	public class SFVec2f : X3DField
	{
		public double X=0, Y=0;

		public SFVec2f() { }
		public SFVec2f(double x, double y) { X=x; Y=y; }

        public static implicit operator Vector2(SFVec2f sfVector)
        {
            return new Vector2((float)sfVector.X, (float)sfVector.Y);
        }
    }
}
