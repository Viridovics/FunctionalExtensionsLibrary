using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FunctionalExtensionsLibrary.Multithreading.SafeResourcesManager
{
	public class SafeResource : IDisposable
	{
		private object _syncResourceRoot = new object();

		internal SafeResource(string name, ResourcesGraph resourcesGraph)
		{
			Name = name;
			_resourcesGraph = resourcesGraph;
		}

		public void Lock()
		{
			_resourcesGraph.AddRequestToResource(Thread.CurrentThread.ManagedThreadId, this);
			Monitor.Enter(_syncResourceRoot);
			_resourcesGraph.ApplyRequestToResource(Thread.CurrentThread.ManagedThreadId, this);
		}

		public void Unlock()
		{
			_resourcesGraph.DeleteLinkWithResource(Thread.CurrentThread.ManagedThreadId, this);
			Monitor.Exit(_syncResourceRoot);
		}

		public void Dispose()
		{
			Unlock();
		}

		public string Name { get; private set; }
		private ResourcesGraph _resourcesGraph { get; set; }
	}
}
