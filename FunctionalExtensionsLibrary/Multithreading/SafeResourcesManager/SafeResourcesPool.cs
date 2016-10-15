using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalExtensionsLibrary.Multithreading.SafeResourcesManager
{
	internal class SafeResourcesPool
	{
		private readonly ConcurrentDictionary<string, SafeResource> _resources = new ConcurrentDictionary<string, SafeResource>();
		private readonly ResourcesGraph _resourcesGraph = new ResourcesGraph();

		public SafeResource GetResource(string name)
		{
			return _resources.GetOrAdd(name, new SafeResource(name, _resourcesGraph));
		}
	}
}
