using System;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace TetraPak.AspNet
{
    /// <summary>
    ///   Abstracts a HTTP expression 
    /// </summary>
    public abstract class ScriptExpression : StringValueBase
    {
        public abstract bool IsMatch(
            HttpRequest request,
            StringComparison comparison = StringComparison.InvariantCulture);

        internal static Outcome<ScriptExpression> Parse(string stringValue)
        {
            if (string.IsNullOrWhiteSpace(stringValue))
                return Outcome<ScriptExpression>.Fail(new Exception("HTTP criteria expression was unassigned"));

            if (containsLogicalOperators(stringValue))
            {
                var logicalExprOutcome = parseLogicExpression(stringValue);
                return logicalExprOutcome
                    ? Outcome<ScriptExpression>.Success(logicalExprOutcome.Value!)
                    : Outcome<ScriptExpression>.Fail(logicalExprOutcome.Exception);
            }
            
            var expression = new ScriptComparisonExpression(stringValue);
            return !expression.IsError 
                ? Outcome<ScriptExpression>.Success(expression) 
                : Outcome<ScriptExpression>.Fail(
                    new FormatException($"Invalid HTTP criteria expression: {stringValue}"));
        }

        internal abstract ScriptExpression Invert();

        static Outcome<ScriptLogicExpression> parseLogicExpression(string stringValue)
        {
            // yyy != xxx && !  (xxx == yyy && (xxx != yyy || xxx == yyy)) && yyy != xxx
            var ca = stringValue.Trim().ToCharArray();
            var idx = 0;
            ScriptLogicOperator logOp;
            var groupOutcome = tryEatGroupExpression(ca, ref idx, out var op, stringValue);
            ScriptLogicExpression logicExpr;
            if (groupOutcome)
            {
                logicExpr = groupOutcome.Value!;
            }
            else
            {
                var pos = idx;
                eatToTokens(ca, ref idx, out var sLeft, out op, ScriptOperators.AndOp, ScriptOperators.OrOp);
                if (op is null)
                    return Outcome<ScriptLogicExpression>.Fail(
                        new FormatException($"Invalid HTTP criteria (at pos. {pos}): \"{stringValue}\""));

                var left = new ScriptComparisonExpression(sLeft);
                if (left.IsError)
                    return Outcome<ScriptLogicExpression>.Fail(
                        new FormatException($"Invalid HTTP criteria (at pos. {pos}): \"{stringValue}\""));

                idx += 2;
                logOp = op == ScriptOperators.AndOp ? ScriptLogicOperator.And : ScriptLogicOperator.Or;
                skipWhite(ca, ref idx);
                groupOutcome = tryEatGroupExpression(ca, ref idx, out op, stringValue);
                ScriptExpression right;
                if (groupOutcome)
                {
                    right = groupOutcome.Value!;
                    logicExpr = new ScriptLogicExpression($"{left} {logOp.ToStringToken()} {right}")
                        .WithOperation(left, logOp, right);
                }
                else
                {
                    eatToTokens(ca, ref idx, out var sRight, out op, ScriptOperators.AndOp, ScriptOperators.OrOp);
                    if (sRight.Length == 0)
                        return Outcome<ScriptLogicExpression>.Fail(
                            new FormatException(
                                $"Invalid HTTP criteria (at pos. {pos}): \"{stringValue}\". Expected right operand"));

                    right = new ScriptComparisonExpression(sRight);
                    if (right.IsError)
                        return Outcome<ScriptLogicExpression>.Fail(
                            new FormatException($"Invalid HTTP criteria (at pos. {pos}): \"{stringValue}\""));

                    logicExpr = new ScriptLogicExpression($"{left} {logOp.ToStringToken()} {right}")
                        .WithOperation(left, logOp, right);
                }
            }

            while (idx < ca.Length && op is {})
            {
                idx += 2;
                var pos = idx;
                logOp = op == ScriptOperators.AndOp ? ScriptLogicOperator.And : ScriptLogicOperator.Or;
                groupOutcome = tryEatGroupExpression(ca, ref idx, out op, stringValue);
                ScriptExpression right;
                if (groupOutcome)
                {
                    right = groupOutcome.Value!;
                }
                else
                {
                    eatToTokens(ca, ref idx, out var sRight, out op, ScriptOperators.AndOp, ScriptOperators.OrOp);
                    if (sRight.Length == 0)
                        return Outcome<ScriptLogicExpression>.Fail(
                            new FormatException(
                                $"Invalid HTTP criteria (at pos. {pos}): \"{stringValue}\". Expected right operand"));

                    right = new ScriptComparisonExpression(sRight);
                    if (right.IsError)
                        return Outcome<ScriptLogicExpression>.Fail(
                            new FormatException($"Invalid HTTP criteria (at pos. {pos}): \"{stringValue}\""));
                }

                logicExpr = logicExpr.Expand(logOp, right);
            }
            return Outcome<ScriptLogicExpression>.Success(logicExpr);
        }

        static Outcome<ScriptLogicExpression> tryEatGroupExpression(char[] ca, ref int idx, out string? opToken, string stringValue)
        {
            var c = ca[idx];
            opToken = null;
            var isInverted = c == ScriptOperators.NotOp;
            string groupedExpression;
            Outcome<ScriptLogicExpression> groupOutcome;
            if (isInverted)
            {
                ++idx;
                if (!trySkipWhiteToExpected(ca, ref idx, ScriptOperators.GroupPrefix))
                    return Outcome<ScriptLogicExpression>.Fail(
                        new FormatException($"Invalid HTTP criteria (at pos. {idx}): \"{stringValue}\". Expected group expression at"));

                ++idx;
                if (!tryEatGroup(ca, ref idx, out groupedExpression))
                    return Outcome<ScriptLogicExpression>.Fail(
                        new FormatException($"Invalid HTTP criteria (at pos. {idx}): \"{stringValue}\". Expected closing group suffix at {idx}"));

                groupOutcome = parseLogicExpression(groupedExpression);
                if (!groupOutcome)
                    return groupOutcome;

                var expression = groupOutcome.Value!;
                var invertedExpression = (ScriptLogicExpression) expression.Invert();
                eatToTokens(ca, ref idx, out _, out opToken, ScriptOperators.AndOp, ScriptOperators.OrOp);
                if (expression.IsComplete)
                    return Outcome<ScriptLogicExpression>.Success(invertedExpression);
            }

            if (c != ScriptOperators.GroupPrefix)
                return Outcome<ScriptLogicExpression>.Fail(new Exception("Not a grouped expression"));
            
            ++idx;
            if (!tryEatGroup(ca, ref idx, out groupedExpression))
                return Outcome<ScriptLogicExpression>.Fail(
                    new FormatException($"Expected group balanced suffix at {idx}"));
            
            groupOutcome = parseLogicExpression(groupedExpression);
            eatToTokens(ca, ref idx, out _, out opToken, ScriptOperators.AndOp, ScriptOperators.OrOp);
            return !groupOutcome 
                ? groupOutcome 
                : Outcome<ScriptLogicExpression>.Fail(new Exception("Not a grouped expression"));
        }

        static bool isToken(string token, char[] ca, int idx)
        {
            if (ca[idx] != token[0] || idx+token.Length > ca.Length)
                return false;

            var caToken = token.ToCharArray();
            for (var i = 1; i < caToken.Length; i++)
            {
                if (ca[idx + i] != caToken[i])
                    return false;
            }

            return true;
        }

        static bool trySkipWhiteToExpected(char[] ca, ref int index, char expected)
        {
            var i = index;
            var c = ca[i];
            for (; i < ca.Length && char.IsWhiteSpace(c); i++)
            {
                c = ca[i];
            }
            index = i;
            return c == expected;
        }

        static void skipWhite(char[] ca, ref int index)
        {
            var i = index;
            var c = ca[i];
            for (; i < ca.Length && char.IsWhiteSpace(c); i++)
            {
                c = ca[i];
            }
            index = i-1;
            
        }

        static void eatToTokens(char[] ca, ref int index, out string text, out string? token, params string[] tokens)
        {
            var i = index;
            var sb = new StringBuilder();
            for (; i < ca.Length; i++)
            {
                var c = ca[i];
                for (var x = 0; x < tokens.Length; x++)
                {
                    token = tokens[x];
                    if (!isToken(token, ca, i)) 
                        continue;
                    
                    index = i;
                    text = sb.ToString().Trim();
                    return;
                }

                sb.Append(c);
            }

            token = null;
            index = i;
            text = sb.ToString().Trim();
        }

        static bool tryEatGroup(char[] ca, ref int index, out string groupedExpression)
        {
            var i = index;
            var count = 1;
            var sb = new StringBuilder();
            for (; i < ca.Length; i++)
            {
                var c = ca[i];
                switch (c)
                {
                    case ScriptOperators.GroupSuffix:
                    {
                        count--;
                        if (count > 0)
                        {
                            sb.Append(c);
                            continue;
                        }

                        groupedExpression = sb.ToString();
                        index = i;
                        return true;
                    }
                    case ScriptOperators.GroupPrefix:
                        count++;
                        break;
                }

                sb.Append(c);
            }

            groupedExpression = sb.ToString();
            return false;
        }

        static bool containsLogicalOperators(string stringValue)
        {
            return stringValue.Contains(ScriptOperators.AndOp) || stringValue.Contains(ScriptOperators.OrOp);
        }

        protected ScriptExpression(string? stringValue) : base(stringValue)
        {
        }
    }
}