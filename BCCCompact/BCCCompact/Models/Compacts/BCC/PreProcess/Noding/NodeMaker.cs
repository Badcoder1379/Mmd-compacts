﻿using System.Collections.Generic;
using System.Linq;

namespace BCCCompact.Models
{
    class NodeMaker
    {
        Component component { get; set; }
        HashSet<Node> nodes { get; set; }
        Node largestNode { get; set; }
        Dictionary<Vertex, int> VertexNodeId;


        private void SetComponent(Component component)
        {
            this.component = component;
            nodes = new HashSet<Node>();
            VertexNodeId = new Dictionary<Vertex, int>();
        }

        public Node GetLargestNode()
        {
            return largestNode;
        }

        public void Process(Component component)
        {
            SetComponent(component);
            NodeLabelTagging();
            ConstructNodes();
            component.LasrgestNode = largestNode;
        }

        private void ConstructNodes()
        {
            largestNode = new Node();
            var nodeId_node = new Dictionary<int, Node>();
            foreach (var vertex in component.Vertices)
            {
                int nodeId = VertexNodeId[vertex];
                if (!nodeId_node.ContainsKey(nodeId))
                {
                    nodeId_node[nodeId] = new Node();
                    nodes.Add(nodeId_node[nodeId]);
                }
                var node = nodeId_node[nodeId];
                node.Vertices.Add(vertex);
                vertex.SetNode(node);
                if (node.Vertices.Count > largestNode.Vertices.Count)
                {
                    largestNode = node;
                }
            }
        }

        private void NodeLabelTagging()
        {
            var mmd = new BccAlgrtm();
            var ARandomVertex = component.Vertices.ToList().First();
            VertexNodeId = mmd.NodingComponentFromThisVertex(component, ARandomVertex);
            ConstructNodes();
            var ARandomVertexFromLargestNode = largestNode.Vertices.ToList().First();
            VertexNodeId = mmd.NodingComponentFromThisVertex(component, ARandomVertexFromLargestNode);
        }
    }
}