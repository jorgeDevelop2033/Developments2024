using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Test
{


	public class AsyncEnumarable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
	{

		public AsyncEnumarable(IEnumerable<T> enumerable) : base(enumerable) { }
		public AsyncEnumarable(Expression expression) : base(expression) { }
		public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
		{
			return new AsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
		}

		IQueryProvider IQueryable.Provider {
			get { return new AsyncQueryProvider<T>(this); }
		}


	}
}
