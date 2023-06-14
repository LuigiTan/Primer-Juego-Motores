using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KGraph 
{
    private List<KVertex> vertex;
    private List<KEdge> edges;

    public KVertex[] Vertex => vertex.ToArray();
    public KEdge[] Edges => edges.ToArray();

    public KGraph(Vector2[] positions)
    {
        vertex = new List<KVertex>();
        for (int i = 0; i < positions.Length; i++)
        {
            KVertex vertex = new KVertex();
            vertex.position = positions[i];
            vertex.group = -1;
            this.vertex.Add(vertex);
        }

        edges = new List<KEdge>();
        for (int i = 0; i < vertex.Count; i++)
        {
            for (int j = i; j < vertex.Count; j++)
            {
                KEdge edge = new KEdge();
                edge.source = i;
                edge.destination = j;
                edge.weight = Vector2.Distance(vertex[i].position, vertex[j].position);
                edges.Add(edge);
            }
        }

        edges.Sort(delegate (KEdge x, KEdge y)
        {
            if (x.weight > y.weight) return 1;
            if (x.weight < y.weight) return -1;
            return 0;
        });
    }
    public KEdge[] Kruskal()
    {
        List<KEdge> path = new List<KEdge>();
        List<KGroup> groups = new List<KGroup>();

        for (int i = 0; i < edges.Count; i++)
        {
            KEdge edge = edges[i];
            KVertex src = vertex[edge.source];
            KVertex dst = vertex[edge.destination];

            if (src.group == -1 && dst.group == -1)
            {
                src.group = groups.Count;
                dst.group = groups.Count;
                vertex[edge.source] = src;
                vertex[edge.destination] = dst;

                KGroup group = new KGroup();
                group.vertex = new List<int>
            {
                edge.source,
                edge.destination
            };

                groups.Add(group);
                path.Add(edges[i]);
                continue;

            }
        }
        return path.ToArray();
    }
}
