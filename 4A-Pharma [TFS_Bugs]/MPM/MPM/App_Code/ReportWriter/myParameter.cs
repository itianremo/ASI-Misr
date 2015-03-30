using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for myParameter
/// </summary>

#region My Parameter Class
public class myParameter
{
    public string ColumnName, ColumnAlias, ColumnType, ConditionOperator, ConditionOperatorSymbol, ConditionValue1, ConditionValue2, SQL, Level, Index, ID, Linking, ListItems, AppliedOperations, ConditionIndex;
    public myParameter(string columnName, string columnAlias, string columnType, string conditionOperator, string conditionoperatorsymbol, string conditionValue1, string conditionValue2, string sql, string level, string index, string id, string linking, string listitems, string appliedoperations, string conditionindex)
    {
        this.ColumnName = columnName;
        this.ColumnAlias = columnAlias;
        this.ColumnType = columnType;
        this.ConditionOperator = conditionOperator;
        this.ConditionValue1 = conditionValue1;
        this.ConditionValue2 = conditionValue2;
        this.SQL = sql;
        this.Level = level;
        this.Linking = linking;
        this.Index = index;
        this.ID = id;
        this.ListItems = listitems;
        this.AppliedOperations = appliedoperations; ;
        this.ConditionOperatorSymbol = conditionoperatorsymbol;
        this.ConditionIndex = conditionindex;
    }
    public myParameter()
    {
    }
}
#endregion

