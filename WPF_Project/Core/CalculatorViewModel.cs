using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Core
{
    public class CalculatorViewModel : WindowModel
    {
        #region Private fields

        private ICommand setExpression;
        private ICommand clearExpression;
        private ICommand deleteSymbol;
        private ICommand computeExpression;
        private ICommand applyNegativeSign;

        public const string mult = "*";
        public const string divide = "/";
        public const string plus = "+";
        public const string minus = "-";
        public const string leftBracket = "(";
        public const string rightBracket = ")";
        public const string dot = ".";
        public const string zeroDot = "0.";
        public const string minusString = "(-";
        private const string wrongFormat = "Wrong format";
        private const string equal = "=";

        #endregion

        #region Public fields
        public string ZeroDot { get { return zeroDot; } }
        public string Dot { get { return dot; } }
        public string LeftBracket { get { return leftBracket; } }
        public string RightBracket { get { return rightBracket; } }
        public string Mult { get { return mult; } }
        public string MinusString { get { return minusString; } }
        public string Plus { get { return plus; } }
        public string Minus { get { return minus; } }
        public string Divide { get { return divide; } }
        public string Equal { get { return equal; } }
        public string WrongFormat { get { return wrongFormat; } }

        /// <summary>
        /// The mathematical expression
        /// </summary>
        public string Expression
        { get; set; }

        /// <summary>
        /// The shown result
        /// </summary>
        public string Result
        { get; set; }


        /// <summary>
        /// The command to apply an expression
        /// </summary>
        public ICommand SetExpression
        {
            get
            {
                return setExpression ??
                  (setExpression = new RelayCommand(param =>
                  {
                      ApplyExpression(param.ToString());
                  }));

            }
        }

        /// <summary>
        /// The command to clear an expression
        /// </summary>
        public ICommand ClearExpression
        {
            get
            {
                return clearExpression ??
                  (clearExpression = new RelayCommand(param =>
                  {
                      Expression = Result = string.Empty;
                  }));

            }
        }

        /// <summary>
        /// The command to compute an expression
        /// </summary>
        public ICommand ComputeExpression
        {
            get
            {
                return computeExpression ??
                  (computeExpression = new RelayCommand(param =>
                  {
                      var value = GetCalculation();
                      Result = "=" + value;
                  }));

            }
        }

        /// <summary>
        /// The command to delete the last char symbol from expression
        /// </summary>
        public ICommand DeleteSymbol
        {
            get
            {
                return deleteSymbol ??
                  (deleteSymbol = new RelayCommand(param =>
                  {
                      if (Expression.Length > 0)
                      {
                          Expression = Expression.Substring(0, Expression.Length - 1);
                      }
                  }));

            }
        }

        /// <summary>
        /// The command to apply +/-
        /// </summary>
        public ICommand ApplyNegativeSign
        {
            get
            {
                return applyNegativeSign ??
                  (applyNegativeSign = new RelayCommand(param =>
                  {
                      ApplyPlusMinus();
                  }));

            }
        }


        #endregion

        /// <summary>
        /// Applies an expression for calculation 
        /// </summary>
        /// <param name="passValue">Value for expression concatination</param>
        public void ApplyExpression(string passValue)
        {
            if (passValue == dot)
            {
                if (!ApplyDot())
                {
                    return;
                }
            }

            if (passValue == divide || passValue == minus ||
                passValue == plus || passValue == mult)
            {
                if (string.IsNullOrEmpty(Expression))
                {
                    return;
                }
            }

            if (passValue == divide)
            {
                if (!ApplyDivision())
                {
                    return;
                }
            }

            if (passValue == mult)
            {
                if (!ApplyMultiplication())
                {
                    return;
                }
            }

            if (passValue == plus)
            {
                if (!ApplySum())
                {
                    return;
                }
            }

            if (passValue == minus)
            {
                if (!ApplySubtract())
                {
                    return;
                }
            }

            if (passValue == (leftBracket + rightBracket))
            {
                ApplyBrackets();
                return;
            }

            Expression += passValue;
        }

        public bool ApplyDot()
        {
            
            if (string.IsNullOrEmpty(Expression) || Expression.Contains(leftBracket))
            {
                int i = 0;
                //The last symbol is int
                if (int.TryParse(GetLastSymbol(), out i))
                {
                    return true;
                }
                else if (GetLastSymbol() == rightBracket)
                {
                    Expression += "*" + zeroDot;
                }
                else
                {
                    Expression += zeroDot;
                } 
            }

            if (GetLastSymbol() == plus || GetLastSymbol() == minus ||
                GetLastSymbol() == divide || GetLastSymbol() == mult)
            {
                Expression += zeroDot;
            }


            if (Expression.Contains(dot))
            {
                return false;
            }

            return true;
        }

        public bool ApplyDivision()
        {
            if (GetLastSymbol() == divide || GetLastSymbol() == leftBracket)
            {
                return false;
            }

            return true;
        }

        public bool ApplyMultiplication()
        {
            if (GetLastSymbol() == mult || GetLastSymbol() == leftBracket)
            {
                return false;
            }

            return true;
        }

        public bool ApplySum()
        {
            if (GetLastSymbol() == plus || GetLastSymbol() == minus)
            {
                return false;
            }

            return true;
        }

        public bool ApplySubtract()
        {
            if (GetLastSymbol() == minus || GetLastSymbol() == plus)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Applies brackets for the expression
        /// </summary>
        public void ApplyBrackets()
        {
            int i = 0;
            int leftBrackCount = !string.IsNullOrEmpty(Expression) ?
                Regex.Matches(Expression, "\\" + leftBracket).Count : 0;
            int rightBrackCount = !string.IsNullOrEmpty(Expression) ?
                Regex.Matches(Expression, "\\" + rightBracket).Count : 0;

            if (string.IsNullOrEmpty(Expression)  ||
                GetLastSymbol() == leftBracket)
            {
                Expression += leftBracket;
            }

            //The expression is int
            else if (int.TryParse(Expression, out i))
            {
                Expression += mult + leftBracket;
            }


            //The last symbol is int
            else if (int.TryParse(GetLastSymbol(), out i))
            {
                if(leftBrackCount > 0)
                {
                    Expression += rightBracket;
                }
                else
                {
                    Expression += mult + leftBracket;
                }
            }

            //The last symbol is )
            else if (GetLastSymbol() == rightBracket)
            {
                if (rightBrackCount < leftBrackCount)
                {
                    Expression += rightBracket;
                }
                else
                {
                    Expression += mult + leftBracket;
                }

            }


            //The last symbol is + or - or /
            else if (GetLastSymbol() == plus || 
                GetLastSymbol() == minus ||
                GetLastSymbol() == divide)
            {
                   Expression += leftBracket;
            }

            //The last symbol is .
            if ( GetLastSymbol() == dot)
            {
                Expression += mult + leftBracket;
            }

        }

        public void ApplyPlusMinus()
        {
            

            if (string.IsNullOrEmpty(Expression) ||
                GetLastSymbol() == plus ||
                GetLastSymbol() == minus ||
                GetLastSymbol() == divide ||
                GetLastSymbol() == mult)
            {
                Expression += minusString;
            }
            else
            {

                //Splits expression by chars
                var chars = Expression.ToCharArray();
                // Position of last number in the expression
                int position = 0;
                // Found last number in the expression
                string number = string.Empty;

                //The cycle to find last mumber in the expression
                for (int i = chars.Count()-1; i >= 0; i--)
                {
                    //If number was found, would break
                    if (chars[i] == plus[0] || chars[i] == minus[0] ||
                        chars[i] == mult[0] || chars[i] == divide[0] ||
                        chars[i] == leftBracket[0] || chars[i] == rightBracket[0])
                    {
                        position = i+1;
                        break;
                    }
                    else
                    {
                        number += chars[i];
                    }
                }


                //If the last number was negative, would remove minus sign
                if (position >0 &&
                    Expression.Substring(position - 1)[0] == minus[0] &&
                    Expression.Substring(position -2)[0] == leftBracket[0])
                {
                    position -= 2;
                    Expression = Expression.Remove(position) +  Reverse(number);
                }
                //If the last number was positive, would apply plus sign
                else
                {
                    Expression = Expression.Remove(position) + "(-" + Reverse(number);
                }

                
            }
        }

        /// <summary>
        /// Reverses a string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Applies calculation for the expression
        /// </summary>
        /// <returns>Calculated value as string</returns>
        public string GetCalculation()
        {
            try
            {
                return new DataTable().Compute(Expression, "").ToString();
            }
            catch
            {
                return wrongFormat;
            }

            
        }


        /// <summary>
        /// Returns last symbol from an expression
        /// </summary>
        /// <returns></returns>
        public string GetLastSymbol()
        {
            return Expression.Length > 0 ? Expression.Substring(Expression.Length - 1) : string.Empty;
        }
    }
}
