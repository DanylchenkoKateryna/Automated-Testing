using CalcClassBr;

using ErrorLibrary;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AnalaizerClassLibrary
{
    public static class AnalaizerClass
    {
        private const char _symbolCloseBracket = ')';
        private const char _symbolOpenBracket = '(';
        private const char _symbolOperatorAdd = '+';
        private const char _symbolOperatorSub = '-';
        private const char _symbolOperatorDiv = '/';
        private const char _symbolOperatorMul = '*';
        private const char _symbolOperatorMod = '%';
        private const char _symbolUnaryPlus = 'p';
        private const char _symbolUnaryMinus = 'm';

        /// <summary>
        /// максимальна глибина вкладеності.
        /// </summary>
        private const int _mAXDEPTHBRACKET = 3;

        /// <summary>
        /// максимальна довжина виразу (символів).
        /// </summary>
        private const int _mAXLENGHTEXPRESSION = 65536;

        /// <summary>
        /// максимальна кількість операторів та чисел у виразі.
        /// </summary>
        private const int _mAXCOUNTOPERANDS = 30;

        private static readonly char[] _operators = new char[] // бінарні операції
            {
                _symbolOperatorAdd,
                _symbolOperatorSub,
                _symbolOperatorMul,
                _symbolOperatorDiv,
                _symbolOperatorMod
            };

        private static readonly char[] _unary_operators = new char[] // унарні операції
            {
                _symbolUnaryMinus,
                _symbolUnaryPlus
            };

        private static readonly char[] _brackets = new char[] // дужки для розділу виразів
            {
                _symbolOpenBracket,
                _symbolCloseBracket
            };

        /// <summary>
        /// позиція виразу, на якій знайдена синтаксична помилка
        /// (у випадку відловлення на рівні виконання - не визначається).
        /// </summary>
        private static int _erposition = 0;

        /// <summary>
        /// Вхідний вираз.
        /// </summary>
        public static string Expression = string.Empty;

        /// <summary>
        /// Показує, чи є необхідність у виведенні повідомлень про помилки.
        /// У разі консольного запуску програми це значення - false.
        /// </summary>
        public static bool ShowMessage = false;

        /// <summary>
        /// Перевірка коректності структури в дужках вхідного виразу.
        /// </summary>
        /// <returns> true - якщо все нормально, false - якщо  є помилка. </returns>
        /// метод біжить по вхідному виразу, символ за символом аналізуючи його, і рахуючи кількість дужок.
        /// У разі виникнення помилки повертає false, а в erposition записує позицію, на якій виникла помилка.
        public static bool CheckCurrency()
        {
            _erposition = 0;

            Stack<int> openBracket = new Stack<int>();

            for (int i = 0; i < Expression.Length; i++)
            {
                if (Expression[i] == _symbolOpenBracket)
                {
                    openBracket.Push(i);

                    if (openBracket.Count > _mAXDEPTHBRACKET)
                    {
                        _erposition = i;
                        if (ShowMessage)
                        {
                            MessageBox.Show(
                                $"expression: '{Expression}'\nerposition: {_erposition}\nError in expression: Maximum depth bracket {_mAXDEPTHBRACKET}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }

                        return false;
                    }
                }
                else
                {
                    if (Expression[i] == ')')
                    {
                        if (openBracket.Count == 0)
                        {
                            _erposition = i;
                            if (ShowMessage)
                            {
                                MessageBox.Show(
                                    $"expression: '{Expression}'\nerposition: {_erposition}\nError in expression: '{_symbolCloseBracket}' used without '{_symbolOpenBracket}'",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }

                            return false;
                        }
                        else
                        {
                            openBracket.Pop();
                        }
                    }
                }
            }

            if (openBracket.Count > 0)
            {
                _erposition = openBracket.Peek();
                if (ShowMessage)
                {
                    MessageBox.Show(
                        $"expression: '{Expression}'\nerposition: {_erposition}\nError in expression: '{_symbolOpenBracket}' used without '{_symbolCloseBracket}'",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                return false;
            }

            return true;
        }

        /// <summary>
        /// Форматує вхідний вираз, виставляючи між операторами пропуски і видаляючи зайві,
        /// а також знаходить нерозпізнані оператори, стежить за кінцем рядка
        /// а також знаходить помилки в кінці рядка.
        /// </summary>
        /// <returns> кінцевий рядок або повідомлення про помилку, що починаються з спец. символу &.</returns>
        public static string Format()
        {
            Expression = Expression.Replace(" ", string.Empty);    // видаляэмо всі пробіли у виразі

            if (Expression.Length > _mAXLENGHTEXPRESSION)
            {
                return "&" + ErrorsExpression.ERROR07;
            }

            if (Expression == string.Empty)
            {
                return string.Empty;
            }

            for (int i = 0; i < Expression.Length; i++)
            {
                char currentSymbol = Expression[i];

                // перевірка на невідомий символа оператора
                if (char.IsDigit(currentSymbol) ||
                    _operators.Contains(currentSymbol) ||
                    _brackets.Contains(currentSymbol) ||
                    _unary_operators.Contains(currentSymbol))
                {
                    continue;
                }

                return "&" + ErrorsExpression.GetFullStringError(ErrorsExpression.ERROR02, i);
            }

            char startSymbol = Expression[0];

            // перевірка на невірний початок виразу
            if (!char.IsDigit(startSymbol) &&
                startSymbol != _symbolOpenBracket &&
                startSymbol != _symbolUnaryMinus &&
                startSymbol != _symbolUnaryPlus)
            {
                return "&" + ErrorsExpression.ERROR03;
            }

            char endSymbol = Expression[Expression.Length - 1];

            // перевірка на закінчення всього виразу
            if (!char.IsDigit(endSymbol) &&
                endSymbol != _symbolCloseBracket)
            {
                return "&" + ErrorsExpression.ERROR05;
            }

            for (int i = 0; i < Expression.Length; i++)
            {
                char currentSymbol = Expression[i];

                // проверка следующего символе после цифры
                if (char.IsDigit(currentSymbol))
                {
                    if (i < Expression.Length - 1)
                    {
                        char nextSymbol = Expression[i + 1];
                        if (nextSymbol == _symbolOpenBracket || nextSymbol == _symbolUnaryMinus || nextSymbol == _symbolUnaryPlus)
                        {
                            return "&" + ErrorsExpression.GetFullStringError(ErrorsExpression.ERROR01, i + 1);
                        }
                    }
                }

                // перевірка на два оператори підряд
                if (_operators.Contains(currentSymbol))
                {
                    if (i < Expression.Length - 1)
                    {
                        char nextSymbol = Expression[i + 1];
                        if (_operators.Contains(nextSymbol))
                        {
                            return "&" + ErrorsExpression.GetFullStringError(ErrorsExpression.ERROR04, i + 1);
                        }

                        if (!char.IsDigit(nextSymbol) && nextSymbol != _symbolOpenBracket && nextSymbol != _symbolUnaryMinus && nextSymbol != _symbolUnaryPlus)
                        {
                            return "&" + ErrorsExpression.ERROR03;
                        }
                    }
                }

                // перевірка на сивол після відкриваючої дужки
                if (currentSymbol == _symbolOpenBracket)
                {
                    if (i < Expression.Length - 1)
                    {
                        char nextSymbol = Expression[i + 1];
                        if (nextSymbol == _symbolCloseBracket || _operators.Contains(nextSymbol))
                        {
                            return "&" + ErrorsExpression.ERROR03;
                        }
                    }
                }

                // перевірка на символ після закриваючої дужки
                if (currentSymbol == _symbolCloseBracket)
                {
                    if (i < Expression.Length - 1)
                    {
                        char nextSymbol = Expression[i + 1];
                        if (!_operators.Contains(nextSymbol) && nextSymbol != _symbolCloseBracket)
                        {
                            return "&" + ErrorsExpression.ERROR03;
                        }
                    }
                }

                // перевірка на сиволи після унарного оператора
                if (_unary_operators.Contains(currentSymbol))
                {
                    if (i < Expression.Length - 1)
                    {
                        char nextSymbol = Expression[i + 1];
                        if (nextSymbol == _symbolCloseBracket || _unary_operators.Contains(nextSymbol) || _operators.Contains(nextSymbol))
                        {
                            return "&" + ErrorsExpression.ERROR03;
                        }
                    }
                    else
                    {
                        return "&" + ErrorsExpression.ERROR05;
                    }
                }
            }

            return Expression;
        }

        private static bool IsOperator(string s)
        {
            if (s.Length == 1)
            {
                char c = s[0];
                if (_operators.Contains(c) || _brackets.Contains(c) || _unary_operators.Contains(c))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsDelimeter(char c)
        {
            return c == ' ' ? true : false;
        }

        private static byte GetPriority(string s)
        {
            switch (s)
            {
                case "(":
                case ")":
                    return 0;
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                case "%":
                    return 3;
                case "m":
                case "p":
                    return 4;
                default:
                    return 5;
            }
        }

        public static IEnumerable<string> Separate(string input)
        {
            int pos = 0;
            while (pos < input.Length)
            {
                string s = string.Empty + input[pos];
                if (!_operators.Union(_brackets).Union(_unary_operators).Contains(input[pos]))
                {
                    if (char.IsDigit(input[pos]))
                    {
                        for (int i = pos + 1;
                            i < input.Length && char.IsDigit(input[i]);
                            i++)
                        {
                            s += input[i];
                        }
                    }
                    else if (char.IsLetter(input[pos]))
                    {
                        for (int i = pos + 1; i < input.Length &&
                            (char.IsLetter(input[i]) || char.IsDigit(input[i])); i++)
                        {
                            s += input[i];
                        }
                    }
                }

                yield return s;
                pos += s.Length;
            }
        }

        /// <summary>
        /// Формує  масив, в якому розташовуються оператори і символи
        /// представлені в зворотному польському записі (без дужок)
        /// На  цьому ж етапі відшукується решта всіх помилок (див. код).
        /// По суті - це компіляція.
        /// </summary>
        /// <returns> массив зворотнього польського запису. </returns>
        public static ArrayList CreateStack()
        {
            ArrayList result = new ArrayList();
            Stack<string> stack = new Stack<string>();

            foreach (string c in Separate(Expression))
            {
                if (IsOperator(c))
                {
                    if (stack.Count > 0 && !c.Equals(_symbolOpenBracket.ToString()))
                    {
                        if (c.Equals(_symbolCloseBracket.ToString()))
                        {
                            string s = stack.Pop();
                            while (s != _symbolOpenBracket.ToString())
                            {
                                result.Add(s);
                                s = stack.Pop();
                            }
                        }
                        else
                            if (GetPriority(c) > GetPriority(stack.Peek()))
                        {
                            stack.Push(c);
                        }
                        else
                        {
                            while (stack.Count > 0 && GetPriority(c) <= GetPriority(stack.Peek()))
                            {
                                result.Add(stack.Pop());
                            }

                            stack.Push(c);
                        }
                    }
                    else
                    {
                        stack.Push(c);
                    }
                }
                else
                {
                    result.Add(c);
                }
            }

            if (stack.Count > 0)
            {
                foreach (string c in stack)
                {
                    result.Add(c);
                }
            }

            return result;
        }

        /// <summary>
        /// Обчислення зворотнього польського запису.
        /// </summary>
        /// <returns> результат обчислень, або повідомлення про помилку. </returns>
        public static string RunEstimate()
        {
            Stack<string> stack = new Stack<string>();
            Queue<string> queue = new Queue<string>();
            foreach (var item in CreateStack())
            {
                queue.Enqueue((string)item);
            }

            if (queue.Count == 1)
            {
                return queue.Dequeue();
            }
            else
            {
                if (queue.Count > _mAXCOUNTOPERANDS)
                {
                    return "&" + ErrorsExpression.ERROR08;
                }
            }

            string str = queue.Dequeue();

            while (queue.Count >= 0)
            {
                if (!IsOperator(str))
                {
                    stack.Push(str);
                    str = queue.Dequeue();
                }
                else
                {
                    long res = 0;
                    try
                    {
                        switch (str)
                        {
                            case "+":
                                {
                                    long b = Convert.ToInt64(stack.Pop());
                                    long a = Convert.ToInt64(stack.Pop());
                                    res = CalcClass.Add(a, b);
                                    break;
                                }

                            case "-":
                                {
                                    long b = Convert.ToInt64(stack.Pop());
                                    long a = Convert.ToInt64(stack.Pop());
                                    res = CalcClass.Sub(a, b);
                                    break;
                                }

                            case "*":
                                {
                                    long b = Convert.ToInt64(stack.Pop());
                                    long a = Convert.ToInt64(stack.Pop());
                                    res = CalcClass.Mult(a, b);
                                    break;
                                }

                            case "/":
                                {
                                    long b = Convert.ToInt64(stack.Pop());
                                    long a = Convert.ToInt64(stack.Pop());
                                    res = CalcClass.Div(a, b);
                                    break;
                                }

                            case "%":
                                {
                                    long b = Convert.ToInt64(stack.Pop());
                                    long a = Convert.ToInt64(stack.Pop());
                                    res = CalcClass.Mod(a, b);
                                    break;
                                }

                            case "m":
                                {
                                    long a = Convert.ToInt64(stack.Pop());
                                    res = CalcClass.IABS(a);
                                    break;
                                }

                            case "p":
                                {
                                    long a = Convert.ToInt64(stack.Pop());
                                    res = CalcClass.ABS(a);
                                    break;
                                }
                        }
                    }
                    catch
                    {
                        return "&" + CalcClass.LastError;
                    }

                    stack.Push(res.ToString());
                    if (queue.Count > 0)
                    {
                        str = queue.Dequeue();
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return stack.Pop();
        }

        private static string ReplaceSymbol(string input, char symbol, int position)
        {
            string res = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                if (i == position)
                {
                    res += symbol;
                }
                else
                {
                    res += input[i];
                }
            }

            return res;
        }

        public static string ReplaceUnaryPlusMinus(string input)
        {
            string res = input.Replace(" ", string.Empty);

            for (int i = 0; i < res.Length; i++)
            {
                char currentSymbol = res[i];
                if (currentSymbol == _symbolOperatorAdd)
                {
                    char previosSymbol = _symbolOperatorMul;

                    if (i > 0)
                    {
                        previosSymbol = res[i - 1];
                    }

                    if (i < res.Length - 1)
                    {
                        char nextSymbol = res[i + 1];
                        if ((nextSymbol == _symbolOpenBracket || char.IsDigit(nextSymbol)) && (_operators.Contains(previosSymbol) || previosSymbol == _symbolOpenBracket))
                        {
                            res = ReplaceSymbol(res, _symbolUnaryPlus, i);
                        }
                    }
                }

                if (currentSymbol == _symbolOperatorSub)
                {
                    char previosSymbol = _symbolOperatorMul;

                    if (i > 0)
                    {
                        previosSymbol = res[i - 1];
                    }

                    if (i < res.Length - 1)
                    {
                        char nextSymbol = res[i + 1];
                        if ((nextSymbol == _symbolOpenBracket || char.IsDigit(nextSymbol)) && (_operators.Contains(previosSymbol) || previosSymbol == _symbolOpenBracket))
                        {
                            res = ReplaceSymbol(res, _symbolUnaryMinus, i);
                        }
                    }
                }
            }

            return res;
        }

        public static string Estimate()
        {
            if (!CheckCurrency())
            {
                return "&" + ErrorsExpression.GetFullStringError(ErrorsExpression.ERROR01, _erposition);
            }

            Expression = ReplaceUnaryPlusMinus(Expression);

            string format = Format();

            if (format == string.Empty)
            {
                return string.Empty;
            }

            if (format.StartsWith("&"))
            {
                return format;
            }

            return RunEstimate();
        }
    }
}
