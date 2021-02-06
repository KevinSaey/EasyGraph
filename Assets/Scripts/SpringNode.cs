using System.Collections;
using System.Collections.Generic;
using EasyGraph;
using UnityEngine;

public class SpringNode : MonoBehaviour
{
    public GameObject GONode => this.gameObject;
    public float Radius
    {
        get
        {
            return GONode.transform.localScale.x;
        }
        set
        {
            GONode.transform.localScale = Vector3.one * value;
        }
    }

    public Vector3 Position
    {
        get
        {
            return GONode.transform.position;
        }
    }

    private Vector3 _velocity;


    public void CalculateVelocity(UndirecteGraph<SpringNode, Edge<SpringNode>> graph, float speed)
    {
        List<Edge<SpringNode>> connectedEdges = graph.GetConnectedEdges(this);
        Vector3 velocity = Vector3.zero;
        
        foreach (var edge in connectedEdges)
        {
            SpringNode connectedVertex = edge.GetOtherVertex(this);
            float weight = (float)edge.Weight;
            Vector3 direction = connectedVertex.Position - this.Position;
            velocity += direction * (direction.magnitude - weight);
        }
        _velocity = velocity * speed;
    }

    public void MoveSpringNode()
    {
        GONode.transform.Translate(_velocity*Time.deltaTime,Space.World);
    }
}
