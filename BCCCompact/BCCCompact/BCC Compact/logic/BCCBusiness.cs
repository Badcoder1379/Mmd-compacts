﻿using BCCCompact.Models;

namespace BCCCompact.BCC_Compact.logic
{
    public class BCCBusiness
    {
        private readonly BCCGraph graph;

        public BCCBusiness(BCCGraph graph)
        {
            this.graph = graph;
        }

        /// <summary>
        /// this method give the gragh and set the vertices locations
        /// </summary>
        /// <param name="graph"></param>
        public void Process()
        {
            var componentMaker = new ComponentMaker(graph);
            componentMaker.Process();
            var components = componentMaker.Components;

            foreach (var component in components)
            {
                new ClusterMaker(component).Process();
                new ClusterTreeMaker(component).Process();
                new SizeCalculater(component).Process();
                new AroundCirclePicker(component).PickClusters();
            }

            new ComponentSetter(components).SetComponents();

            foreach (var component in components)
            {
                new LocationCalculater(component).Calcute();
            }
        }
    }
}
