namespace TetraPak.AspNet
{
    static class ScriptOperators
    {
        internal const char NotOp = '!';
        internal const string AndOp = "&&";
        internal const string OrOp = "||";
        internal const char GroupPrefix = '(';
        internal const char GroupSuffix = ')';
        internal const string IsEqual = "==";
        internal const string IsNotEqual = "!=";
        internal const string Contains = "~~";
        internal const string NotContains = "!~";

        public static string ToStringToken(this ScriptLogicOperator op) => op == ScriptLogicOperator.And ? AndOp : OrOp;

        public static ScriptLogicOperator Invert(this ScriptLogicOperator op) => op == ScriptLogicOperator.And ? ScriptLogicOperator.Or : ScriptLogicOperator.And;
        
        public static ScriptComparisonOperator Invert(this ScriptComparisonOperator op) => op == ScriptComparisonOperator.IsEqual 
            ? ScriptComparisonOperator.NotEqual 
            : ScriptComparisonOperator.IsEqual;

        public static string ToStringToken(this ScriptComparisonOperator op) => op == ScriptComparisonOperator.IsEqual ? IsEqual : IsNotEqual;

    }
}