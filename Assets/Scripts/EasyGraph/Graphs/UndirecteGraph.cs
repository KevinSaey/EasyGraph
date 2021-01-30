using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyGraph
{
    class UndirecteGraph<TVertex, TEdge> : IGraph<TVertex, TEdge>
        where TEdge : IEdge<TVertex>
        where TVertex : class
    {
        #region Private Fields
        private readonly bool _allowParallelEdges = false;
        private Dictionary<TVertex, List<TEdge>> _vertexEdgeDict { get; }
        #endregion

        #region Public Fields
        public bool AllowParallelEdges
        {
            get { return _allowParallelEdges; }
        }

        public Dictionary<TVertex, List<TEdge>> VertexEdgeDict
        {
            get
            {
                return _vertexEdgeDict;
            }
        }
        #endregion

        #region Constructors
        public UndirecteGraph()
        {
            _vertexEdgeDict = new Dictionary<TVertex, List<TEdge>>();
        }

        public UndirecteGraph(List<TEdge> edges)
        {
            _vertexEdgeDict = new Dictionary<TVertex, List<TEdge>>();

            foreach (var edge in edges)
            {
                AddEdge(edge);
            }
        }

        #endregion

        #region functions
        public bool AddEdge(TEdge newEdge)
        {
            if (_vertexEdgeDict.ContainsKey(newEdge.Source))
                //Check if the egde is parallell to an existing edge
                foreach (var targetVertex in _vertexEdgeDict[newEdge.Source].Select(v => v.Target))
                {
                    Console.WriteLine("Edge is parallel");
                    if (newEdge.Target == targetVertex) return false;
                }
            else
                //add edge to source vertex
                _vertexEdgeDict.Add(newEdge.Source, new List<TEdge>());

            if (!_vertexEdgeDict.ContainsKey(newEdge.Target))
                _vertexEdgeDict.Add(newEdge.Target, new List<TEdge>());

            //add edges to source and target vertices
            _vertexEdgeDict[newEdge.Source].Add(newEdge);
            _vertexEdgeDict[newEdge.Target].Add(newEdge);

            return true;
        }

        public List<TEdge> GetEdges()
        {
            List<TEdge> edges = new List<TEdge>();
            foreach (var edge in _vertexEdgeDict.Values.SelectMany(e=>e))
            {
                if (!edges.Contains(edge))
                {
                    edges.Add(edge);
                }
            }

            return edges;
        }

        public HashSet<TVertex> GetConnectedVertices(TVertex source)
        {
            if (!_vertexEdgeDict.ContainsKey(source)) return null;

            IEnumerable<TVertex> connectedVertices = _vertexEdgeDict[source].Select(e=>e.GetNeighbourVertices(source));
            return new HashSet<TVertex>(connectedVertices);
        }
        #endregion

    }
}
