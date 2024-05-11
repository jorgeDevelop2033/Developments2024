﻿namespace WebAPI.Test
{
	public class AsyncEnumerator<T> : IAsyncEnumerator<T>
	{
		private readonly IEnumerator<T> enumerator;	
		
		public T Current => enumerator.Current;

		public AsyncEnumerator(IEnumerator<T> enumerator) => this.enumerator = enumerator ?? throw new AggregateException();
		


		public async ValueTask DisposeAsync()
		{
			await Task.CompletedTask;
		}

		public async ValueTask<bool> MoveNextAsync()
		{
			return await Task.FromResult(enumerator.MoveNext());
		}
	}
}
