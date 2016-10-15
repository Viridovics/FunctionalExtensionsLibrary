using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalExtensionsLibrary.Multithreading.SafeResourcesManager
{
	internal class ResourcesGraph
	{
		private object _syncRoot = new object();
		private Dictionary<int, Node> _threadNodes = new Dictionary<int, Node>();
		private List<Node> _resourceNodes = new List<Node>();

		public ResourcesGraph() { }

		public void AddRequestToResource(int threadId, SafeResource resource)
		{
			lock (_syncRoot)
			{
				var threadNode = GetThreadNode(threadId);
				var resourceNode = GetResourceNode(resource);
				threadNode.Links.AddLast(resourceNode);
				CheckCycle(resourceNode);
			}
		}

		public void ApplyRequestToResource(int threadId, SafeResource resource)
		{
			lock (_syncRoot)
			{
				var threadNode = GetThreadNode(threadId);
				var resourceNode = GetResourceNode(resource);
				if (!threadNode.Links.Remove(resourceNode))
				{
					throw new ApplicationException("Resource link not found");
				}
				resourceNode.Links.AddLast(threadNode);
				CheckCycle(threadNode);
			}
		}

		public void DeleteLinkWithResource(int threadId, SafeResource resource)
		{
			lock (_syncRoot)
			{
				var threadNode = GetThreadNode(threadId);
				var resourceNode = GetResourceNode(resource);
				threadNode.Links.Remove(resourceNode);
				resourceNode.Links.Remove(threadNode);
			}
		}

		private void CheckCycle(Node startNode)
		{
			var path = new LinkedList<Node>();
			path.AddFirst(startNode);
			foreach(var node in startNode.Links)
			{
				CheckCycle(startNode, node, path);
			}
		}

		private void CheckCycle(Node startNode, Node currentNode, LinkedList<Node> path)
		{
			if(startNode == currentNode)
			{
				throw new ApplicationException(
					string.Format("Resource cycle found: {0}", 
									string.Join(" -> ", path.Select(n => n.Resource != null?
											("Resource " + n.Resource.Name):("Thread "+n.ThreadId)))));
			}
			path.AddLast(currentNode);
			foreach(var node in currentNode.Links)
			{
				CheckCycle(startNode, node, path);
			}
			path.RemoveLast();
		}

		private Node GetThreadNode(int threadId)
		{
			Node threadNode;
			if (!_threadNodes.TryGetValue(threadId, out threadNode))
			{
				threadNode = new Node
				{
					ThreadId = threadId
				};
				_threadNodes.Add(threadId, threadNode);
			}
			return threadNode;
		}

		private Node GetResourceNode(SafeResource resource)
		{
			var resourceNode = _resourceNodes.FirstOrDefault(n => n.Resource == resource);
			if (resourceNode == null)
			{
				resourceNode = new Node
				{
					Resource = resource,
					ThreadId = -1
				};
				_resourceNodes.Add(resourceNode);
			}
			return resourceNode;
		}

		internal class Node
		{
			public Node()
			{
				Links = new LinkedList<Node>();
			}
			public int ThreadId { get; set; }
			public SafeResource Resource { get; set; }
			public LinkedList<Node> Links { get; private set; }
		}
	}
}
