// Create by Felix A. Bueno
namespace Angkor.O7Framework.Domain.Response
{
    public static class O7SuccessResponse
    {
        public static O7SuccessResponse<T1> MakeResponse<T1>(T1 value1)
            => new O7SuccessResponse<T1>(value1);

        public static O7SuccessResponse<T1, T2> MakeResponse<T1, T2>(T1 value1, T2 value2)
            => new O7SuccessResponse<T1, T2>(value1, value2);


        public static O7SuccessResponse<T1, T2, T3> MakeResponse<T1, T2, T3>(T1 value1, T2 value2, T3 value3)
            => new O7SuccessResponse<T1, T2, T3>(value1, value2, value3);


        public static O7SuccessResponse<T1, T2, T3, T4> MakeResponse<T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3,
                T4 value4)
            => new O7SuccessResponse<T1, T2, T3, T4>(value1, value2, value3, value4);


        public static O7SuccessResponse<T1, T2, T3, T4, T5> MakeResponse<T1, T2, T3, T4, T5>(T1 value1, T2 value2,
                T3 value3, T4 value4, T5 value5)
            => new O7SuccessResponse<T1, T2, T3, T4, T5>(value1, value2, value3, value4, value5);

        public static O7SuccessResponse<T1, T2, T3, T4, T5, T6> MakeResponse<T1, T2, T3, T4, T5, T6>(T1 value1,
                T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
            => new O7SuccessResponse<T1, T2, T3, T4, T5, T6>(value1, value2, value3, value4, value5, value6);

        public static O7SuccessResponse<T1, T2, T3, T4, T5, T6, T7> MakeResponse<T1, T2, T3, T4, T5, T6, T7>(T1 value1,
                T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7)
            => new O7SuccessResponse<T1, T2, T3, T4, T5, T6, T7>(value1, value2, value3, value4, value5, value6, value7);
    }

    public class O7SuccessResponse<T1> : O7Response<T1>
    {
        public O7SuccessResponse(T1 value1) : base(value1)
        {
        }

        public T1 Value1 => Item1;
    }

    public class O7SuccessResponse<T1, T2> : O7Response<T1, T2>
    {
        public O7SuccessResponse(T1 value1, T2 value2) : base(value1, value2)
        {
        }

        public T1 Value1 => Item1;
        public T2 Value2 => Item2;
    }

    public class O7SuccessResponse<T1, T2, T3> : O7Response<T1, T2, T3>
    {
        public O7SuccessResponse(T1 value1, T2 value2, T3 value3) : base(value1, value2, value3)
        {
        }

        public T1 Value1 => Item1;
        public T2 Value2 => Item2;
        public T3 Value3 => Item3;
    }

    public class O7SuccessResponse<T1, T2, T3, T4> : O7Response<T1, T2, T3, T4>
    {
        public O7SuccessResponse(T1 value1, T2 value2, T3 value3, T4 value4) : base(value1, value2, value3, value4)
        {
        }

        public T1 Value1 => Item1;
        public T2 Value2 => Item2;
        public T3 Value3 => Item3;
        public T4 Value4 => Item4;
    }

    public class O7SuccessResponse<T1, T2, T3, T4, T5> : O7Response<T1, T2, T3, T4, T5>
    {
        public O7SuccessResponse(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
            : base(value1, value2, value3, value4, value5)
        {
        }

        public T1 Value1 => Item1;
        public T2 Value2 => Item2;
        public T3 Value3 => Item3;
        public T4 Value4 => Item4;
        public T5 Value5 => Item5;
    }

    public class O7SuccessResponse<T1, T2, T3, T4, T5, T6> : O7Response<T1, T2, T3, T4, T5, T6>
    {
        public O7SuccessResponse(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
            : base(value1, value2, value3, value4, value5, value6)
        {
        }

        public T1 Value1 => Item1;
        public T2 Value2 => Item2;
        public T3 Value3 => Item3;
        public T4 Value4 => Item4;
        public T5 Value5 => Item5;
        public T6 Value6 => Item6;
    }

    public class O7SuccessResponse<T1, T2, T3, T4, T5, T6, T7> : O7Response<T1, T2, T3, T4, T5, T6, T7>
    {
        public O7SuccessResponse(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7)
            : base(value1, value2, value3, value4, value5, value6, value7)
        {
        }

        public T1 Value1 => Item1;
        public T2 Value2 => Item2;
        public T3 Value3 => Item3;
        public T4 Value4 => Item4;
        public T5 Value5 => Item5;
        public T6 Value6 => Item6;
        public T7 Value7 => Item7;
    }
}