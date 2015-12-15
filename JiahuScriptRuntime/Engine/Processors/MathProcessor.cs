using System;

namespace JiahuScriptRuntime.Engine.Processors
{
    internal class MathProcessor
    {
        private const string LeftParameter = "left";
        private const string RightParameter = "right";
        private const string AddOperation = "Register";
        private const string MinusOperation = "Minus";
        private const string MultipleOperation = "Multiply";
        private const string DivideOperation = "Divide";

        public object Add(object left, object right)
        {
            IsValidNumber(left, LeftParameter, AddOperation);
            IsValidNumber(right, RightParameter, AddOperation);

            if (left is int)
            {
                return right is int ? (object)(((int)left) + ((int)right)) : (object)(((int)left) + ((decimal)right));
            }
            return right is decimal ? (object)(((decimal)left) + ((decimal)right)) : (object)(((decimal)left) + ((int)right));
        }

        public object Minus(object left, object right)
        {
            IsValidNumber(left, LeftParameter, MinusOperation);
            IsValidNumber(right, RightParameter, MinusOperation);

            if (left is int)
            {
                return right is int ? (object)(((int)left) - ((int)right)) : (object)(((int)left) - ((decimal)right));
            }
            return right is decimal ? (object)(((decimal)left) - ((decimal)right)) : (object)(((decimal)left) - ((int)right));
        }

        public object Multiply(object left, object right)
        {
            IsValidNumber(left, LeftParameter, MultipleOperation);
            IsValidNumber(right, RightParameter, MultipleOperation);

            if (left is int)
            {
                return right is int ? (object)(((int)left) * ((int)right)) : (object)(((int)left) * ((decimal)right));
            }
            return right is decimal ? (object)(((decimal)left) * ((decimal)right)) : (object)(((decimal)left) * ((int)right));
        }

        public object Divide(object left, object right)
        {
            IsValidNumber(left, LeftParameter, DivideOperation);
            IsValidNumber(right, RightParameter, DivideOperation);

            if (left is int)
            {
                if (right is int)
                {
                    int remainder;
                    int result = Math.DivRem((int) left, (int) right, out remainder);

                    if (remainder != 0)
                    {
                        return (object)(Convert.ToDecimal(left) / Convert.ToDecimal(right));
                    }
                    return (object) result;
                }
                return (object)(((int)left) / ((decimal)right));
            }
            return right is decimal ? (object)(((decimal)left) / ((decimal)right)) : (object)(((decimal)left) / ((int)right));
        }

        private void IsValidNumber(object number, string name, string operation)
        {
            if (number is int || number is decimal)
            {
                return;
            }
            throw new ArgumentException(string.Format("{0} parameter in operation {1} is not a valid type.", name, operation));
        }
    }
}
