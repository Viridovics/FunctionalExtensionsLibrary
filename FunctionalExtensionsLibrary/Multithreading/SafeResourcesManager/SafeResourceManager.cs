using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalExtensionsLibrary.Multithreading.SafeResourcesManager
{
	public class SafeResourceManager
	{
		private static readonly SafeResourceManager _instance = new SafeResourceManager();
		private SafeResourcesPool resourcesPool = new SafeResourcesPool();
		private SafeResourceManager()
		{ }

		public SafeResource LockResource(string resourceName)
		{
			var resource = GetResource(resourceName);
			resource.Lock();
			return resource;
		}

		public SafeResource GetResource(string resourceName)
		{
			return resourcesPool.GetResource(resourceName);
		}

		public static SafeResourceManager Instance
		{
			get
			{
				return _instance;
			}
		}
	}
}
