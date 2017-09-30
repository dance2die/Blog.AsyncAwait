using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.AsyncAwait
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Task.Run(async () => await MainAsync().ConfigureAwait(false)).Wait();
		}

		private static async Task MainAsync()
		{
			SyncMethod();

			Console.WriteLine($"\n{new string('*', 80)}\n");

			await AsyncMethodAsync();
		}

		private static void SyncMethod()
		{
			Console.WriteLine("sync: first");

			Thread.Sleep(500);
			Console.WriteLine("sync: three");

			var result = SomeSyncTask(2);
			Console.WriteLine("SomeSyncTask value :{0}", result);
		}

		private static int SomeSyncTask(int arg)
		{
			for (int j = 0; j < 10; j++)
			{
				Console.WriteLine("\tDoing work inside 'SomeSYNCTask'...");
				Thread.Sleep(100);
			}

			return arg;

		}

		private static async Task AsyncMethodAsync()
		{
			Console.WriteLine("async: first");
			var task = SomeAsyncTask(2);

			Thread.Sleep(500);
			Console.WriteLine("async: three");

			var result = await task;
			Console.WriteLine("Task1 value :{0}", result);
		}

		private static async Task<int> SomeAsyncTask(int arg)
		{
			for (int j = 0; j < 10; j++)
			{
				Console.WriteLine("\tDoing work inside 'SomeAsyncTask'...");
				await Task.Delay(100);
			}

			return arg;
		}
	}
}