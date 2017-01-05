// Create by Felix A. Bueno

namespace Angkor.O7Framework.Domain.Response
{
    public abstract class O7Response
    {
    }

    public abstract class O7Response<T1> : O7Response
    {
        protected O7Response(T1 value1)
        {
            Item1 = value1;
        }

        protected T1 Item1 { get; }
    }

    public abstract class O7Response<T1, T2> : O7Response<T1>
    {
        protected O7Response(T1 value1, T2 value2) : base(value1)
        {
            Item2 = value2;
        }

        protected T2 Item2 { get; }
    }

    public abstract class O7Response<T1, T2, T3> : O7Response<T1, T2>
    {
        protected O7Response(T1 value1, T2 value2, T3 value3) : base(value1, value2)
        {
            Item3 = value3;
        }

        protected T3 Item3 { get; }
    }

    public abstract class O7Response<T1, T2, T3, T4> : O7Response<T1, T2, T3>
    {
        protected O7Response(T1 value1, T2 value2, T3 value3, T4 value4) : base(value1, value2, value3)
        {
            Item4 = value4;
        }

        protected T4 Item4 { get; }
    }

    public abstract class O7Response<T1, T2, T3, T4, T5> : O7Response<T1, T2, T3, T4>
    {
        protected O7Response(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
            : base(value1, value2, value3, value4)
        {
            Item5 = value5;
        }

        protected T5 Item5 { get; }
    }

    public abstract class O7Response<T1, T2, T3, T4, T5, T6> : O7Response<T1, T2, T3, T4, T5>
    {
        protected O7Response(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
            : base(value1, value2, value3, value4, value5)
        {
            Item6 = value6;
        }

        protected T6 Item6 { get; }
    }

    public abstract class O7Response<T1, T2, T3, T4, T5, T6, T7> : O7Response<T1, T2, T3, T4, T5, T6>
    {
        protected O7Response(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7)
            : base(value1, value2, value3, value4, value5, value6)
        {
            Item7 = value7;
        }

        protected T7 Item7 { get; }
    }
}