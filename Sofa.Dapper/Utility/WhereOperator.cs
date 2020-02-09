using System.ComponentModel;

namespace Sofa.Dapper.Utility
{
    public enum WhereOperator
    {
        [Description(" = ")]
        Equal = 1,

        [Description(" <> ")]
        NotEqual = 2,

        [Description(" > ")]
        GreaterThan = 3,

        [Description(" >= ")]
        GreaterThanOrEqual = 4,

        [Description(" < ")]
        LessThan = 5,

        [Description(" <= ")]
        LessThanOrEqual = 6,

        [Description(" IN ")]
        In = 7,
    }
}
