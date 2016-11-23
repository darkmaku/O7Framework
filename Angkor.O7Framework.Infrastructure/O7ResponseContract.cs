// Create by Felix A. Bueno

using System;

namespace Angkor.O7Framework.Infrastructure
{
    public class O7ResponseContract<T1> : O7Contract
    {
        public Tuple<T1> Response { get; private set; }
        public void SetResponse(T1 value)
        {
            Response = new Tuple<T1>(value);
        }
    }

    public class O7ResponseContract<T1, T2> : O7Contract
    {
        public Tuple<T1, T2> Response { get; set; }

        public void SetResponse(T1 value1, T2 value2)
        {
            Response = new Tuple<T1, T2>(value1, value2);
        }
    }

    public class O7ResponseContract<T1, T2, T3> : O7Contract
    {
        public Tuple<T1, T2, T3> Response { get; set; }

        public void SetResponse(T1 value1, T2 value2, T3 value3)
        {
            Response = new Tuple<T1, T2, T3>(value1, value2, value3);
        }
    }

    public class O7ResponseContract<T1, T2, T3, T4> : O7Contract
    {
        public Tuple<T1, T2, T3, T4> Response { get; set; }
        public void SetResponse(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            Response = new Tuple<T1, T2, T3, T4>(value1, value2, value3, value4);
        }
    }

    public class O7ResponseContract<T1, T2, T3, T4, T5> : O7Contract
    {
        public Tuple<T1, T2, T3, T4, T5> Response { get; set; }
        public void SetResponse(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            Response = new Tuple<T1, T2, T3, T4, T5>(value1, value2, value3, value4, value5);
        }
    }
}