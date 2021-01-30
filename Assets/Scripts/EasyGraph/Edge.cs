using System;
using System.Collections.Generic;


namespace EasyGraph
{
    class Edge<TVertex> : IEdge<TVertex>
         where TVertex : class

    {
        #region Private fields
        private readonly TVertex _source;
        private readonly TVertex _target;
        private double _weight;

        #endregion

        #region Public field
        /// <summary>
        /// Gets the source vertex
        /// </summary>
        public TVertex Source => _source;
        /// <summary>
        /// Gets the target vertex
        /// </summary>
        public TVertex Target => _target;

        public double Weight => _weight;

        #endregion

        #region Constructor
        public Edge(TVertex source, TVertex target)
        {
            _source = source;
            _target = target;
            _weight = 1;
        }

        public Edge(TVertex source, TVertex target,double weight)
        {
            _source = source;
            _target = target;
            _weight = weight;
        }

        public Edge(TVertex source, TVertex target, float weight)
        {
            _source = source;
            _target = target;
            _weight = weight;
        }

        #endregion

        #region Public Function
        public TVertex GetOtherVertex(TVertex testVertex)
        {
            if (testVertex != Source && testVertex != Target) return null;
            return testVertex == Source ? Target : Source;
        }

        public void SetWeight(double weight)
        {
            _weight = weight;
        }
        #endregion
    }
}
