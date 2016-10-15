using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FunctionalExtensionsLibrary.Multithreading.SafeResourcesManager;
using System.Threading;

namespace Tests.Multithreading
{
	/// <summary>
	/// Summary description for SafeResourcesManagerTests
	/// </summary>
	[TestClass]
	public class SafeResourcesManagerTests
	{
		public SafeResourcesManagerTests()
		{
		}

		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		[TestMethod]
		public void SimpleDeadlockResultSimpleDeadlock()
		{
			SimpleDeadlockResult = false;
			var th1 = new Thread(Thread1Lock);
			var th2 = new Thread(Thread2Lock);
			th1.Start();
			th2.Start();

			th1.Join(500);
			th2.Join(500);

			Assert.IsTrue(!th1.IsAlive && !th2.IsAlive && SimpleDeadlockResult, 
								"Threads alive or result is incorrect");
		}

		private void Thread1Lock()
		{
			using(SafeResourceManager.Instance.LockResource("res1"))
			{
				Thread.Sleep(200);
				try
				{
					using (SafeResourceManager.Instance.LockResource("res2"))
					{
						Thread.Sleep(100);
					}
				}
				catch(Exception e)
				{
					SimpleDeadlockResult = true;
				}
			}
		}

		private void Thread2Lock()
		{
			using (SafeResourceManager.Instance.LockResource("res2"))
			{
				Thread.Sleep(200);
				try
				{
					using (SafeResourceManager.Instance.LockResource("res1"))
					{
						Thread.Sleep(100);
					}
				}
				catch (Exception e)
				{
					SimpleDeadlockResult = true;
				}
			}
		}

		private bool SimpleDeadlockResult = false;
	}
}
