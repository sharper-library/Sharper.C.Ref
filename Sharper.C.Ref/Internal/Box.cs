using System;

namespace Sharper.C.Data.Internal
{
    internal sealed class Box<A>
    {
        private readonly object updateLock = new object();
        private A value;

        public Box(A a)
        {
            value = a;
        }

        public A View => value;

        public A Update(Func<A, A> f)
        {
            lock (updateLock)
            {
                value = f(value);
                return value;
            }
        }

        public Unit Change(A a)
        {
            lock (updateLock)
            {
                value = a;
            }
            return default(Unit);
        }
    }
}
