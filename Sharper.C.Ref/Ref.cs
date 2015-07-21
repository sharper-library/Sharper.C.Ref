using System;

namespace Sharper.C
{
    public sealed class Ref<A>
    {
        private readonly object updateLock = new object();
        private A value;

        internal Ref(A a)
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

    public static class Ref
    {
        public static Ref<A> Mk<A>(A a) => new Ref<A>(a);
    }
}
