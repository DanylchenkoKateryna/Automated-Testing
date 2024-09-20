using ErrorLibrary;

using System;

namespace CalcClassBr
{
    public class CalcClass
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Add1(int a, int b)
        {
            return a + b;
        }

        public int Add2(int a, int b)
        {
            return a + b;
        }

        public int Sub(int a, int b)
        {
            return a - b;
        }

        public int Mult(int a, int b)
        {
            return a * b;
        }

        public int Div(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }

            return a / b;
        }

        public static int Add(long a, long b)
        {
            _lastError = string.Empty;
            long res;
            if ((a <= int.MaxValue && a >= int.MinValue) && (b <= int.MaxValue && b >= int.MinValue))
            {
                res = a + b;
            }
            else
            {
                _lastError = ErrorsExpression.ERROR06;
                throw new ArgumentOutOfRangeException(_lastError);
            }

            if (res <= int.MaxValue && res >= int.MinValue)
            {
                return (int)res;
            }
            else
            {
                _lastError = ErrorsExpression.ERROR06;
                throw new ArgumentOutOfRangeException(_lastError);
            }
        }

        /// <summary>
        /// функція віднімання чисел а і b.
        /// </summary>
        /// <param name="a">зменшуване.</param>
        /// <param name="b">від’ємне.</param>
        /// <returns>різниця.</returns>
        public static int Sub(long a, long b)
        {
            _lastError = string.Empty;
            long res;
            if ((a <= int.MaxValue && a >= int.MinValue) && (b <= int.MaxValue && b >= int.MinValue))
            {
                res = a - b;
            }
            else
            {
                _lastError = ErrorsExpression.ERROR06;
                throw new ArgumentOutOfRangeException(_lastError);
            }

            if (res <= int.MaxValue && res >= int.MinValue)
            {
                return (int)res;
            }
            else
            {
                _lastError = ErrorsExpression.ERROR06;
                throw new ArgumentOutOfRangeException(_lastError);
            }
        }

        public static int Mult(long a, long b)
        {
            _lastError = string.Empty;
            long res;
            if ((a <= int.MaxValue && a >= int.MinValue) && (b <= int.MaxValue && b >= int.MinValue))
            {
                res = a * b;
            }
            else
            {
                _lastError = ErrorsExpression.ERROR06;
                throw new ArgumentOutOfRangeException(_lastError);
            }

            if (res <= int.MaxValue && res >= int.MinValue)
            {
                return (int)res;
            }
            else
            {
                _lastError = ErrorsExpression.ERROR06;
                throw new ArgumentOutOfRangeException(_lastError);
            }
        }

        /// <summary>
        /// функція знаходження частки.
        /// </summary>
        /// <param name="a">ділене.</param>
        /// <param name="b">дільник.</param>
        /// <returns>частка.</returns>
        public static int Div(long a, long b)
        {
            _lastError = string.Empty;
            long res;
            if ((a <= int.MaxValue && a >= int.MinValue) && (b <= int.MaxValue && b >= int.MinValue))
            {
                if (b != 0)
                {
                    res = a / b;
                }
                else
                {
                    _lastError = ErrorsExpression.ERROR09;
                    throw new DivideByZeroException(_lastError);
                }
            }
            else
            {
                _lastError = ErrorsExpression.ERROR06;
                throw new ArgumentOutOfRangeException(_lastError);
            }

            if (res <= int.MaxValue && res >= int.MinValue)
            {
                return (int)res;
            }
            else
            {
                _lastError = ErrorsExpression.ERROR06;
                throw new ArgumentOutOfRangeException(_lastError);
            }
        }

        /// <summary>
        /// функція ділення по модулю.
        /// </summary>
        /// <param name="a">ділене.</param>
        /// <param name="b">дільник.</param>
        /// <returns>остача.</returns>
        public static int Mod(long a, long b)
        {
            _lastError = string.Empty;
            long res;
            if ((a <= int.MaxValue && a >= int.MinValue) && (b <= int.MaxValue && b >= int.MinValue))
            {
                if (b != 0)
                {
                    res = a % b;
                }
                else
                {
                    _lastError = ErrorsExpression.ERROR09;
                    throw new DivideByZeroException(_lastError);
                }
            }
            else
            {
                _lastError = ErrorsExpression.ERROR06;
                throw new ArgumentOutOfRangeException(_lastError);
            }

            if (res <= int.MaxValue && res >= int.MinValue)
            {
                return (int)res;
            }
            else
            {
                _lastError = ErrorsExpression.ERROR06;
                throw new ArgumentOutOfRangeException(_lastError);
            }
        }

        public static int ABS(long a)
        {
            _lastError = string.Empty;
            long res;
            if (a <= int.MaxValue && a >= int.MinValue)
            {
                res = a;
                return (int)res;
            }
            else
            {
                _lastError = ErrorsExpression.ERROR06;
                throw new ArgumentOutOfRangeException(_lastError);
            }
        }

        public static int IABS(long a)
        {
            _lastError = string.Empty;
            long res;
            if (a <= int.MaxValue && a >= int.MinValue)
            {
                res = a * -1;
                return (int)res;
            }
            else
            {
                _lastError = ErrorsExpression.ERROR06;
                throw new ArgumentOutOfRangeException(_lastError);
            }
        }

        /// <summary>
        /// Останнє повідомлення про помилку.
        /// Поле і властивість для нього.
        /// </summary>
        private static string _lastError = string.Empty;

        public static string LastError => _lastError;
    }
}
