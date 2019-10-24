﻿using System.Collections.Generic;

namespace BCCCompact.Models
{
    public class BCCGraph
    {
        public int VerticesCount;
        public List<BCCVertex> Vertices = new List<BCCVertex>();

        private void AddEdge(int v, int w)
        {
            Vertices[v].AddAdjacent(Vertices[w]);
        }

        public BCCGraph(int v, List<BCCEdge> edges)
        {
            VerticesCount = v;
            for (int i = 0; i < VerticesCount; i++)
            {
                Vertices.Add(new BCCVertex(i));
            }
            foreach (var edge in edges)
            {
                this.AddEdge(edge.Source, edge.Target);
                this.AddEdge(edge.Target, edge.Source);
            }
        }

        public BCCVertex GetVertexById(int ID)
        {
            return Vertices[ID];
        }
    }
}
