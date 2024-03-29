﻿namespace BCCCompact.Models.Compacts.Squarillity
{
    public class SQR : Compact
    {
        public override void Process(Graph graph)
        {
            SquariPicker picker = new SquariPicker(graph.V);
            foreach (var vertex in graph.Vertices)
            {
                picker.SetLocation(vertex);
            }
        }
    }
}