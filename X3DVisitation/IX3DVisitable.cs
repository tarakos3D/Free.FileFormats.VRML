using System;
using System.Collections.Generic;
using System.Text;

namespace Free.FileFormats.VRML.X3DVisitation
{
    /// <summary>
    /// Add this interface to a class to make it visitable by an IX3DVisitor.
    /// </summary>
    public interface IX3DVisitable
    {
        void Accept(IX3DVisitor visitor);
    }
}
