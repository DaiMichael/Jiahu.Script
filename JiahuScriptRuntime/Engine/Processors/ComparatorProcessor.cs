using System;

namespace JiahuScriptRuntime.Engine.Processors
{
    internal class ComparatorProcessor
    {
        public object Equal(object left, object right)
        {
            return left.Equals(right);
        }

        public object NotEqual(object left, object right)
        {
            return !Convert.ToBoolean(Equal(left, right));
        }

        public object GreaterThan(object value, object compareToValue)
        {
            if (!IsTheSameType(value, compareToValue))
            {
                return false;
            }

            if (value is int)
            {
                return (object)((int)value > (int)compareToValue);
            }

            if (value is decimal)
            {
                return (object)((decimal)value > (decimal)compareToValue);
            }

            if (value is DateTime)
            {
                return (object)((DateTime)value > (DateTime)compareToValue);
            }

            return false;
        }

        public object GreaterThanOrEqual(object value, object compareToValue)
        {
            if (!IsTheSameType(value, compareToValue))
            {
                return false;
            }

            return (object)(Convert.ToBoolean(GreaterThan(value, compareToValue)) || Convert.ToBoolean(Equal(value, compareToValue)));
        }

        public object LessThan(object value, object compareToValue)
        {
            if (!IsTheSameType(value, compareToValue))
            {
                return false;
            }

            if (value is int)
            {
                return (object)((int)value < (int)compareToValue);
            }

            if (value is decimal)
            {
                return (object)((decimal)value < (decimal)compareToValue);
            }

            if (value is DateTime)
            {
                return (object)((DateTime)value < (DateTime)compareToValue);
            }

            return false;
        }

        public object LessThanOrEqual(object value, object compareToValue)
        {
            if (!IsTheSameType(value, compareToValue))
            {
                return false;
            }

            return (object)(Convert.ToBoolean(LessThan(value, compareToValue)) || Convert.ToBoolean(Equal(value, compareToValue)));
        }

        public object And(object value, object compareToValue)
        {
            return (object)((bool)value && (bool)compareToValue);
        }

        public object Or(object value, object compareToValue)
        {
            return (object)((bool)value || (bool)compareToValue);
        }


        private bool IsTheSameType(object left, object right)
        {
            return left.GetType() == right.GetType();
        }
    }
}
