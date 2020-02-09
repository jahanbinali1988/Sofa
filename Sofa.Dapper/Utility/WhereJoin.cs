using System.ComponentModel;

namespace Sofa.Dapper.Utility
{
    public enum WhereJoin
    {
        [Description(" AND ")]
        And = 1,

        [Description(" OR ")]
        Or = 2,

        [Description(" AND NOT ")]
        AndNot = 3,

        [Description(" OR NOT ")]
        OrNot = 4,
    }
}
