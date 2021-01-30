using System;
using System.Collections;
using System.Collections.Generic;

namespace EasyGraph
{
    public interface IEdge<TVertex>
        where TVertex :class
    {
        TVertex Source { get; }
        TVertex Target { get; }

        public TVertex GetOtherVertex(TVertex testVertex);
    }
}
