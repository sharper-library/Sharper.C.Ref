using System;
using Sharper.C.Data.Internal;

namespace Sharper.C.Data
{
    public struct Ref<A>
    {
        private readonly Box<A> box;

        internal Ref(A a)
        {
            box = new Box<A>(a);
        }

        public A View => box.View;

        public A Update(Func<A, A> f) => box.Update(f);

        public Unit Change(A a) => box.Change(a);
    }

    public static class Ref
    {
        public static Ref<A> Mk<A>(A a) => new Ref<A>(a);
    }
}