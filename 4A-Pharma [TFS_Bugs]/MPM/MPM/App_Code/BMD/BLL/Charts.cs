using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Summary description for Charts
/// </summary>
public abstract class FusionChartBase
{
    public const string PercentSignCode = "%25";
    public const int undefinedIntegerValue = -9999;

    #region Private Variables

    private string _bgColor = "FFFFFF";
    private int _bgAlpha = 100;
    private string _caption = "Caption";
    private string _subCaption = "subCaption";
    private bool _showNames = true; // 0  or 1
    private bool _showValues = true; // 0 or 1
    private string _baseFont = "Arial";
    private int _baseFontSize = 10;
    private string _baseFontColor = "000000";
    private string _numberPrefix = string.Empty;
    private string _numberSuffix = string.Empty;
    private bool _formatNumber = true;
    private bool _formatNumberScale = false;
    private string _decimalSeparator = ".";
    private string _thousandSeparator = ",";
    private int _decimalPrecision = 2;
    private bool _showHovercap = true;
    private string _hoverCapBgColor = "FFFFFF";
    private string _hoverCapBorderColor = "000000";
    private string _hoverCapSepChar = " - ";

    #endregion

    #region Properties

    public string bgColor
    {
        get
        {
            return _bgColor;
        }
        set
        {
            _bgColor = value;
        }
    }

    public int bgAlpha
    {
        get
        {
            return _bgAlpha;
        }
        set
        {
            _bgAlpha = Convert.ToInt32(value);
        }
    }

    public string caption
    {
        get
        {
            return _caption;
        }
        set
        {
            _caption = value;
        }
    }

    public string subCaption
    {
        get
        {
            return _subCaption;
        }
        set
        {
            _subCaption = value;
        }
    }

    public bool showNames
    {
        get
        {
            return _showNames;
        }
        set
        {
            _showNames = value;
        }
    }

    public bool showValues
    {
        get
        {
            return _showValues;
        }
        set
        {
            _showValues = value;
        }
    }

    public string baseFont
    {
        get
        {
            return _baseFont;
        }
        set
        {
            _baseFont = value;
        }
    }

    public int baseFontSize
    {
        get
        {
            return _baseFontSize;
        }
        set
        {
            _baseFontSize = Convert.ToInt32(value);
        }
    }

    public string baseFontColor
    {
        get
        {
            return _baseFontColor;
        }
        set
        {
            _baseFontColor = value;
        }
    }

    public string numberPrefix
    {
        get
        {
            return _numberPrefix;
        }
        set
        {
            _numberPrefix = value;
        }
    }

    public string numberSuffix
    {
        get
        {
            return _numberSuffix;
        }
        set
        {
            _numberSuffix = value;
        }
    }

    public bool formatNumber
    {
        get
        {
            return _formatNumber;
        }
        set
        {
            _formatNumber = value;
        }
    }

    public bool formatNumberScale
    {
        get
        {
            return _formatNumberScale;
        }
        set
        {
            _formatNumberScale = value;
        }
    }

    public string decimalSeparator
    {
        get
        {
            return _decimalSeparator;
        }
        set
        {
            _decimalSeparator = value;
        }
    }

    public string thousandSeparator
    {
        get
        {
            return _thousandSeparator;
        }
        set
        {
            _thousandSeparator = value;
        }
    }

    public int decimalPrecision
    {
        get
        {
            return _decimalPrecision;
        }
        set
        {
            _decimalPrecision = Convert.ToInt32(value);
        }
    }

    public bool showHovercap
    {
        get
        {
            return _showHovercap;
        }
        set
        {
            _showHovercap = value;
        }
    }

    public string hoverCapBgColor
    {
        get
        {
            return _hoverCapBgColor;
        }
        set
        {
            _hoverCapBgColor = value;
        }
    }

    public string hoverCapBorderColor
    {
        get
        {
            return _hoverCapBorderColor;
        }
        set
        {
            _hoverCapBorderColor = value;
        }
    }

    public string hoverCapSepChar
    {
        get
        {
            return _hoverCapSepChar;
        }
        set
        {
            _hoverCapSepChar = value;
        }
    }

    #endregion

    #region Methods

    public string GetValue(bool value)
    {
        if (value)
        {
            return "'1'";
        }
        else
        {
            return "'0'";
        }
    }

    public string GetValue(string value)
    {
        return "'" + HttpUtility.HtmlEncode(value.Replace("&", "and")) + "'";
    }

    public string GetValue(int value)
    {
        return "'" + value.ToString() + "'";
    }

    //public virtual string CreateSetElement(DataTable dtChart, string chartId, bool multiSeries, string multiSeriesGroupField, string nameField, string valueField, string hoverTextField, string urlField, string urlPrefix, bool newWindow, int chartWidth, int chartHeight)
    //{
    //    return "";
    //}

    #endregion
}

public class FusionPieChart : FusionChartBase
{
    private int _pieRadius = 0; //FusionCharts automatically calculates the best fit pie radius for the chart.
    private int _pieSliceDepth = 20;
    private int _pieYScale = 60; // 30 - 100
    private int _pieBorderThickness = 1;
    private int _pieBorderAlpha = 100;
    private int _pieFillAlpha = 100;

    private bool _showPercentageValues = true; // 0 or 1
    private bool _showPercentageInLabel = false; // 0 or 1

    public const string Pie2D = "FCF_Pie2D.swf";
    public const string Pie3D = "FCF_Pie3D.swf";

    #region Properties

    public int pieSliceDepth
    {
        get
        {
            return _pieSliceDepth;
        }
        set
        {
            _pieSliceDepth = Convert.ToInt32(value);
        }
    }

    public int pieYScale
    {
        get
        {
            return _pieYScale;
        }
        set
        {
            int scale = Convert.ToInt32(value);
            if (scale < 30 || scale > 100)
            {
                throw new Exception("PieYScale must be 30 - 100.");
            }
            _pieYScale = scale;
        }
    }

    public int pieBorderThickness
    {
        get
        {
            return _pieBorderThickness;
        }
        set
        {
            _pieBorderThickness = Convert.ToInt32(value);
        }
    }

    public int pieBorderAlpha
    {
        get
        {
            return _pieBorderAlpha;
        }
        set
        {
            _pieBorderAlpha = Convert.ToInt32(value);
        }
    }

    public int pieFillAlpha
    {
        get
        {
            return _pieFillAlpha;
        }
        set
        {
            _pieFillAlpha = Convert.ToInt32(value);
        }
    }

    public bool showPercentageValues
    {
        get
        {
            return _showPercentageValues;
        }
        set
        {
            _showPercentageValues = value;
        }
    }

    public bool showPercentageInLabel
    {
        get
        {
            return _showPercentageInLabel;
        }
        set
        {
            _showPercentageInLabel = value;
        }
    }

    #endregion

    public string CreateSetElement(DataTable dtChart, string chartType, string chartId, string nameField, string valueField, string hoverTextField, string urlField, string urlPrefix, bool newWindow, int chartWidth, int chartHeight)
    {
        StringBuilder strXML = new StringBuilder();

        //Initialize <graph> element
        strXML.Append("<graph");
        //base class (common) properties            
        strXML.Append(" bgColor=" + GetValue(bgColor));
        strXML.Append(" bgAlpha=" + GetValue(bgAlpha));
        strXML.Append(" caption=" + GetValue(caption));
        strXML.Append(" subCaption=" + GetValue(subCaption));
        strXML.Append(" showNames=" + GetValue(showNames));
        strXML.Append(" showValues=" + GetValue(showValues));
        strXML.Append(" showPercentageValues=" + GetValue(showPercentageValues));
        strXML.Append(" showPercentageInLabel=" + GetValue(showPercentageInLabel));
        strXML.Append(" baseFont=" + GetValue(baseFont));
        strXML.Append(" baseFontSize=" + GetValue(baseFontSize));
        strXML.Append(" baseFontColor=" + GetValue(baseFontColor));
        strXML.Append(" numberPrefix=" + GetValue(numberPrefix));
        strXML.Append(" numberSuffix=" + GetValue(numberSuffix));
        strXML.Append(" formatNumber=" + GetValue(formatNumber));
        strXML.Append(" formatNumberScale=" + GetValue(formatNumberScale));
        strXML.Append(" decimalSeparator=" + GetValue(decimalSeparator));
        strXML.Append(" thousandSeparator=" + GetValue(thousandSeparator));
        strXML.Append(" decimalPrecision=" + GetValue(decimalPrecision));
        strXML.Append(" showHovercap=" + GetValue(showHovercap));
        strXML.Append(" hoverCapBgColor=" + GetValue(hoverCapBgColor));
        strXML.Append(" hoverCapBorderColor=" + GetValue(hoverCapBorderColor));
        strXML.Append(" hoverCapSepChar=" + GetValue(hoverCapSepChar));

        //pie class properties            
        strXML.Append(" pieSliceDepth=" + GetValue(pieSliceDepth));
        strXML.Append(" pieYScale=" + GetValue(pieYScale));
        strXML.Append(" pieBorderThickness=" + GetValue(pieBorderThickness));
        strXML.Append(" pieBorderAlpha=" + GetValue(pieBorderAlpha));
        strXML.Append(" pieFillAlpha=" + GetValue(pieFillAlpha));
        strXML.Append(">");
        //Add all data

        FusionChartUtility utility = new FusionChartUtility();

        foreach (DataRow drChart in dtChart.Rows)
        {
            string name = drChart[nameField].ToString();
            string value = drChart[valueField].ToString();
            string text = drChart[hoverTextField].ToString();
            string url = string.Empty;
            if (!string.IsNullOrEmpty(urlField))
            {
                url = drChart[urlField].ToString();
            }

            strXML.Append("<set name='");
            strXML.Append(name);
            strXML.Append("' value='");
            strXML.Append(value);
            strXML.Append("' ");
            strXML.Append("color='");
            strXML.Append(utility.getFCColor());
            strXML.Append("' ");


            if (text.Trim().Length > 0)
            {
                strXML.Append(" hoverText=" + GetValue(text));
            }

            if (url.Trim().Length > 0)
            {
                if (newWindow)
                {
                    strXML.Append(" link=" + GetValue("n-" + urlPrefix + url));
                }
                else
                {
                    strXML.Append(" link=" + GetValue(urlPrefix + url));
                }
                //strXML.Append("' link='default.aspx' />");
                //strXML.Append("' link='n-default.aspx' />"); //new window
            }
            strXML.Append(" />");
        }

        //Close <graph> element
        strXML.Append("</graph>");

        //Create the chart - Pie 3D Chart with data from strXML
        return InfoSoftGlobal.FusionCharts.RenderChartHTML("FusionCharts/" + chartType, "", strXML.ToString(), chartId, chartWidth.ToString(), chartHeight.ToString(), false);
    }
}

public class FusionLineChart : FusionChartBase
{
    public const string Line2D = "FCF_Line.swf";
    public const string Area2D = "FCF_Area2D.swf";
    public const string MultiSeriesLine2D = "FCF_MSLine.swf";
    public const string MultiSeriesArea2D = "FCF_MSArea2D.swf";
    public const string Bar2D = "FCF_Bar2D.swf";
    public const string Bar2DColour = "E6EFF7";

    private string _canvasBgColor = "FFFFFF";
    private int _canvasBgAlpha = 100;
    private string _canvasBorderColor = "000000";
    private int _canvasBorderThickness = 1;

    private string _xAxisName = "xAxisName";
    private string _yAxisName = "yAxisName";
    private int _yAxisMinValue = undefinedIntegerValue;
    private int _yAxisMaxValue = undefinedIntegerValue;

    private string _lineColor = "000000";
    private int _lineThickness = 1;
    private int _lineAlpha = 100;

    private bool _showShadow = true;
    private string _shadowColor = "000000";
    private int _shadowThickness = 3;
    private int _shadowAlpha = 10;
    private int _shadowXShift = 0;
    private int _shadowYShift = 4;

    private bool _showAnchors = true; // If the anchors are not shown, then the hover caption and link functions won't work.
    private int _anchorSides = 3; // number > 3;
    private int _anchorRadius = 5;
    private string _anchorBorderColor = "";
    private int _anchorBorderThickness = 1;
    private string _anchorBgColor = "";
    private int _anchorBgAlpha = 100;
    private int _anchorAlpha = 100;

    private int _divLineDecimalPrecision = 2;
    private int _limitsDecimalPrecision = 2;

    private int _numdivlines = 5;
    private string _divlinecolor = "";
    private int _divLineThickness = 1;
    private int _divLineAlpha = 100;
    private bool _showDivLineValue = true;
    private bool _showAlternateHGridColor = false;
    private string _alternateHGridColor = "";
    private int _alternateHGridAlpha = 100;

    private int _numVDivLines = 5;
    private string _VDivlinecolor = "";
    private int _VDivLineThickness = 1;
    private int _VDivLineAlpha = 100;
    private bool _showAlternateVGridColor = false;
    private string _alternateVGridColor = "";
    private int _alternateVGridAlpha = 100;

    private bool _showLimits = true;

    #region Properties

    public string canvasBgColor
    {
        get
        {
            return _canvasBgColor;
        }
        set
        {
            _canvasBgColor = value;
        }
    }

    public int canvasBgAlpha
    {
        get
        {
            return _canvasBgAlpha;
        }
        set
        {
            _canvasBgAlpha = Convert.ToInt32(value);
        }
    }

    public string canvasBorderColor
    {
        get
        {
            return _canvasBorderColor;
        }
        set
        {
            _canvasBorderColor = value;
        }
    }

    public int canvasBorderThickness
    {
        get
        {
            return _canvasBorderThickness;
        }
        set
        {
            _canvasBorderThickness = Convert.ToInt32(value);
        }
    }

    public string xAxisName
    {
        get
        {
            return _xAxisName;
        }
        set
        {
            _xAxisName = value;
        }
    }

    public string yAxisName
    {
        get
        {
            return _yAxisName;
        }
        set
        {
            _yAxisName = value;
        }
    }

    public int yAxisMinValue
    {
        get
        {
            return _yAxisMinValue;
        }
        set
        {
            _yAxisMinValue = Convert.ToInt32(value);
        }
    }

    public int yAxisMaxValue
    {
        get
        {
            return _yAxisMaxValue;
        }
        set
        {
            _yAxisMaxValue = Convert.ToInt32(value);
        }
    }

    public string lineColor
    {
        get
        {
            return _lineColor;
        }
        set
        {
            _lineColor = value;
        }
    }

    public int lineThickness
    {
        get
        {
            return _lineThickness;
        }
        set
        {
            _lineThickness = Convert.ToInt32(value);
        }
    }

    public int lineAlpha
    {
        get
        {
            return _lineAlpha;
        }
        set
        {
            _lineAlpha = Convert.ToInt32(value);
        }
    }

    public bool showShadow
    {
        get
        {
            return _showShadow;
        }
        set
        {
            _showShadow = value;
        }
    }

    public string shadowColor
    {
        get
        {
            return _shadowColor;
        }
        set
        {
            _shadowColor = value;
        }
    }

    public int shadowThickness
    {
        get
        {
            return _shadowThickness;
        }
        set
        {
            _shadowThickness = Convert.ToInt32(value);
        }
    }

    public int shadowAlpha
    {
        get
        {
            return _shadowAlpha;
        }
        set
        {
            _shadowAlpha = Convert.ToInt32(value);
        }
    }

    public int shadowXShift
    {
        get
        {
            return _shadowXShift;
        }
        set
        {
            _shadowXShift = Convert.ToInt32(value);
        }
    }

    public int shadowYShift
    {
        get
        {
            return _shadowYShift;
        }
        set
        {
            _shadowYShift = Convert.ToInt32(value);
        }
    }

    public bool showAnchors
    {// If the anchors are not shown, then the hover caption and link functions won't work.
        get
        {
            return _showAnchors;
        }
        set
        {
            _showAnchors = value;
        }
    }

    public int anchorSides
    {// number > 3;
        get
        {
            return _anchorSides;
        }
        set
        {
            _anchorSides = Convert.ToInt32(value);
        }
    }

    public int anchorRadius
    {
        get
        {
            return _anchorRadius;
        }
        set
        {
            _anchorRadius = Convert.ToInt32(value);
        }
    }

    public string anchorBorderColor
    {
        get
        {
            return _anchorBorderColor;
        }
        set
        {
            _anchorBorderColor = value;
        }
    }

    public int anchorBorderThickness
    {
        get
        {
            return _anchorBorderThickness;
        }
        set
        {
            _anchorBorderThickness = Convert.ToInt32(value);
        }
    }

    public string anchorBgColor
    {
        get
        {
            return _anchorBgColor;
        }
        set
        {
            _anchorBgColor = value;
        }
    }

    public int anchorBgAlpha
    {
        get
        {
            return _anchorBgAlpha;
        }
        set
        {
            _anchorBgAlpha = Convert.ToInt32(value);
        }
    }

    public int anchorAlpha
    {
        get
        {
            return _anchorAlpha;
        }
        set
        {
            _anchorAlpha = Convert.ToInt32(value);
        }
    }

    public int divLineDecimalPrecision
    {
        get
        {
            return _divLineDecimalPrecision;
        }
        set
        {
            _divLineDecimalPrecision = Convert.ToInt32(value);
        }
    }

    public int limitsDecimalPrecision
    {
        get
        {
            return _limitsDecimalPrecision;
        }
        set
        {
            _limitsDecimalPrecision = Convert.ToInt32(value);
        }
    }

    public int numDivLines
    {
        get
        {
            return _numdivlines;
        }
        set
        {
            _numdivlines = Convert.ToInt32(value);
        }
    }

    public string divLineColor
    {
        get
        {
            return _divlinecolor;
        }
        set
        {
            _divlinecolor = value;
        }
    }

    public int divLineThickness
    {
        get
        {
            return _divLineThickness;
        }
        set
        {
            _divLineThickness = Convert.ToInt32(value);
        }
    }

    public int divLineAlpha
    {
        get
        {
            return _divLineAlpha;
        }
        set
        {
            _divLineAlpha = Convert.ToInt32(value);
        }
    }

    public bool showDivLineValue
    {
        get
        {
            return _showDivLineValue;
        }
        set
        {
            _showDivLineValue = Convert.ToBoolean(value);
        }
    }


    public bool showAlternateHGridColor
    {
        get
        {
            return _showAlternateHGridColor;
        }
        set
        {
            _showAlternateHGridColor = Convert.ToBoolean(value);
        }
    }

    public string alternateHGridColor
    {
        get
        {
            return _alternateHGridColor;
        }
        set
        {
            _alternateHGridColor = value;
        }
    }

    public int alternateHGridAlpha
    {
        get
        {
            return _alternateHGridAlpha;
        }
        set
        {
            _alternateHGridAlpha = Convert.ToInt32(value);
        }
    }

    public int numVDivLines
    {
        get
        {
            return _numVDivLines;
        }
        set
        {
            _numVDivLines = Convert.ToInt32(value);
        }
    }

    public string VDivLineColor
    {
        get
        {
            return _VDivlinecolor;
        }
        set
        {
            _VDivlinecolor = value;
        }
    }

    public int VDivLineThickness
    {
        get
        {
            return _VDivLineThickness;
        }
        set
        {
            _VDivLineThickness = Convert.ToInt32(value);
        }
    }

    public int VDivLineAlpha
    {
        get
        {
            return _VDivLineAlpha;
        }
        set
        {
            _VDivLineAlpha = Convert.ToInt32(value);
        }
    }

    public bool showAlternateVGridColor
    {
        get
        {
            return _showAlternateVGridColor;
        }
        set
        {
            _showAlternateVGridColor = value;
        }
    }

    public string alternateVGridColor
    {
        get
        {
            return _alternateVGridColor;
        }
        set
        {
            _alternateVGridColor = value;
        }
    }

    public int alternateVGridAlpha
    {
        get
        {
            return _alternateVGridAlpha;
        }
        set
        {
            _alternateVGridAlpha = Convert.ToInt32(value);
        }
    }

    public bool showLimits
    {
        get
        {
            return _showLimits;
        }
        set
        {
            _showLimits = value;
        }
    }

    #endregion


    public string CreateSetElememtForTrendChart(DataTable dtChart, string chartId, string nameField, string valueField, int chartWidth, int chartHeight, int yAxisMinValue, int yAxisMaxValue, string backColor)
    {
        StringBuilder strXML = new StringBuilder();
        strXML.Append("<graph decimalPrecision='0' showNames='0' showValues='0' showLimits='0' canvasBorderThickness='0' showAnchors='0' showDivLineValue='0' divLineAlpha='0' showShadow='0' chartTopMargin='1' chartBottomMargin='2' areaBgColor='DFEFF7' showAreaBorder='1' areaBorderColor='00769C' areaBorderThickness='1' showhovercap='0' yAxisMinValue='");
        strXML.Append(yAxisMinValue);
        strXML.Append("' yAxisMaxValue='");
        strXML.Append(yAxisMaxValue);
        strXML.Append("' canvasBgColor='");
        strXML.Append(backColor);
        strXML.Append("' canvasBorderColor='");
        strXML.Append(backColor);
        strXML.Append("' bgColor='");
        strXML.Append(backColor);
        strXML.Append("'>");
        foreach (DataRow drChart in dtChart.Rows)
        {
            string name = drChart[nameField].ToString();
            string value = drChart[valueField].ToString();

            strXML.Append("<set name='");
            strXML.Append(name);
            strXML.Append("' value='");
            strXML.Append(value);
            strXML.Append("' ");
            strXML.Append(" />");
        }
        strXML.Append("</graph>");

        //Create the chart - Pie 3D Chart with data from strXML
        return InfoSoftGlobal.FusionCharts.RenderChartHTML("FusionCharts/" + FusionLineChart.Area2D, "", strXML.ToString(), chartId, chartWidth.ToString(), chartHeight.ToString(), false);
    }


    public string CreateSetElement(DataTable dtChart, string chartType, string chartId, bool multiSeries, string multiSeriesGroupField, string nameField, string valueField, string hoverTextField, string urlField, string urlPrefix, bool newWindow, int chartWidth, int chartHeight)
    {
        StringBuilder strXML = new StringBuilder();

        //Initialize <graph> element
        strXML.Append("<graph");
        //base class (common) properties            
        strXML.Append(" bgColor=" + GetValue(bgColor));
        strXML.Append(" bgAlpha=" + GetValue(bgAlpha));
        strXML.Append(" caption=" + GetValue(caption));
        strXML.Append(" subCaption=" + GetValue(subCaption));
        strXML.Append(" showNames=" + GetValue(showNames));
        strXML.Append(" showValues=" + GetValue(showValues));
        strXML.Append(" baseFont=" + GetValue(baseFont));
        strXML.Append(" baseFontSize=" + GetValue(baseFontSize));
        strXML.Append(" baseFontColor=" + GetValue(baseFontColor));
        strXML.Append(" numberPrefix=" + GetValue(numberPrefix));
        strXML.Append(" numberSuffix=" + GetValue(numberSuffix));
        strXML.Append(" formatNumber=" + GetValue(formatNumber));
        strXML.Append(" formatNumberScale=" + GetValue(formatNumberScale));
        strXML.Append(" decimalSeparator=" + GetValue(decimalSeparator));
        strXML.Append(" thousandSeparator=" + GetValue(thousandSeparator));
        strXML.Append(" decimalPrecision=" + GetValue(decimalPrecision));
        strXML.Append(" showHovercap=" + GetValue(showHovercap));
        strXML.Append(" hoverCapBgColor=" + GetValue(hoverCapBgColor));
        strXML.Append(" hoverCapBorderColor=" + GetValue(hoverCapBorderColor));
        strXML.Append(" hoverCapSepChar=" + GetValue(hoverCapSepChar));
        strXML.Append(" showLimits=" + GetValue(showLimits));

        //line class properties

        strXML.Append(" canvasBgColor=" + GetValue(canvasBgColor));
        strXML.Append(" canvasBgAlpha=" + GetValue(canvasBgAlpha));
        strXML.Append(" canvasBorderColor=" + GetValue(canvasBorderColor));
        strXML.Append(" canvasBorderThickness=" + GetValue(canvasBorderThickness));

        strXML.Append(" xAxisName=" + GetValue(xAxisName));
        strXML.Append(" yAxisName=" + GetValue(yAxisName));
        if (yAxisMinValue != undefinedIntegerValue)
        {
            strXML.Append(" yAxisMinValue=" + GetValue(yAxisMinValue));
        }
        if (yAxisMaxValue != undefinedIntegerValue)
        {
            strXML.Append(" yAxisMaxValue=" + GetValue(yAxisMaxValue));
        }

        //strXML.Append(" lineColor=" + GetValue(lineColor)); // should be controlled in set tag.
        strXML.Append(" lineThickness=" + GetValue(lineThickness));
        strXML.Append(" lineAlpha=" + GetValue(lineAlpha));

        if (showShadow)
        {
            strXML.Append(" showShadow=" + GetValue(showShadow));
            strXML.Append(" shadowColor=" + GetValue(shadowColor));
            strXML.Append(" shadowThickness=" + GetValue(shadowThickness));
            strXML.Append(" shadowAlpha=" + GetValue(shadowAlpha));
            strXML.Append(" shadowXShift=" + GetValue(shadowXShift));
            strXML.Append(" shadowYShift=" + GetValue(shadowYShift));
        }

        if (showAnchors)
        {
            strXML.Append(" showAnchors=" + GetValue(showAnchors));
            strXML.Append(" anchorSides=" + GetValue(anchorSides));
            strXML.Append(" anchorRadius=" + GetValue(anchorRadius));
            strXML.Append(" anchorBorderColor=" + GetValue(anchorBorderColor));
            strXML.Append(" anchorBorderThickness=" + GetValue(anchorBorderThickness));
            strXML.Append(" anchorBgColor=" + GetValue(anchorBgColor));
            strXML.Append(" anchorBgAlpha=" + GetValue(anchorBgAlpha));
            strXML.Append(" anchorAlpha=" + GetValue(anchorAlpha));
        }
        strXML.Append(" divLineDecimalPrecision=" + GetValue(divLineDecimalPrecision));
        strXML.Append(" limitsDecimalPrecision=" + GetValue(limitsDecimalPrecision));

        //strXML.Append(" numdivlines=" + GetValue(numDivLines));
        strXML.Append(" divlinecolor=" + GetValue(divLineColor));
        strXML.Append(" divLineThickness=" + GetValue(divLineThickness));
        strXML.Append(" divLineAlpha=" + GetValue(divLineAlpha));
        strXML.Append(" showDivLineValue=" + GetValue(showDivLineValue));
        if (showAlternateHGridColor)
        {
            strXML.Append(" showAlternateHGridColor=" + GetValue(showAlternateHGridColor));
            strXML.Append(" alternateHGridColor=" + GetValue(alternateHGridColor));
            strXML.Append(" alternateHGridAlpha=" + GetValue(alternateHGridAlpha));
        }

        //strXML.Append(" numVDivLines=" + GetValue(numVDivLines));
        strXML.Append(" VDivlinecolor=" + GetValue(VDivLineColor));
        strXML.Append(" VDivLineThickness=" + GetValue(VDivLineThickness));
        strXML.Append(" VDivLineAlpha=" + GetValue(VDivLineAlpha));

        if (showAlternateVGridColor)
        {
            strXML.Append(" showAlternateVGridColor=" + GetValue(showAlternateVGridColor));
            strXML.Append(" alternateVGridColor=" + GetValue(alternateVGridColor));
            strXML.Append(" alternateVGridAlpha=" + GetValue(alternateVGridAlpha));
        }
        strXML.Append(">");
        //Add all data

        FusionChartUtility utility = new FusionChartUtility();

        if (multiSeries)
        {
            DataSetHelper dsHelper = new DataSetHelper();

            List<string> listUnique = new List<string>();
            listUnique.Add(nameField);
            DataTable dtUnique = dsHelper.RemoveDuplicates(dtChart, listUnique);

            StringBuilder categories = new StringBuilder();
            StringBuilder datasets = new StringBuilder();

            categories.Append("<categories>");
            foreach (DataRow drUnique in dtUnique.Rows)
            {
                string currentName = drUnique[nameField].ToString();
                categories.Append("<category name=");
                categories.Append(GetValue(currentName));
                categories.Append(" />");
            }
            categories.Append("</categories>");


            listUnique = new List<string>();
            listUnique.Add(multiSeriesGroupField);
            dtUnique = dsHelper.RemoveDuplicates(dtChart, listUnique);
            //DataRow[] drs = dtChart.Select(nameField + "=" + GetValue(currentName));
            foreach (DataRow drUnique in dtUnique.Rows)
            {
                string currentGroup = drUnique[multiSeriesGroupField].ToString();
                DataRow[] drs = dtChart.Select(multiSeriesGroupField + "=" + GetValue(currentGroup));

                if (drs.Length > 0)
                {
                    datasets.Append("<dataset seriesname=");
                    datasets.Append(GetValue(drUnique[nameField].ToString()));
                    datasets.Append(" color=");
                    datasets.Append(GetValue(utility.getFCColor()));
                    datasets.Append(" >");

                    foreach (DataRow drData in drs)
                    {
                        datasets.Append("<set value=");
                        datasets.Append(GetValue(drData[valueField].ToString()));
                        datasets.Append(" />");
                    }
                    datasets.Append("</dataset>");
                }
            }

            strXML.Append(categories.ToString());
            strXML.Append(datasets.ToString());
        }
        else
        {
            foreach (DataRow drChart in dtChart.Rows)
            {
                string name = drChart[nameField].ToString();
                string value = drChart[valueField].ToString();
                string text = string.Empty;
                if (!string.IsNullOrEmpty(hoverTextField))
                {
                    text = drChart[hoverTextField].ToString();
                }
                string url = string.Empty;
                if (!string.IsNullOrEmpty(urlField))
                {
                    url = drChart[urlField].ToString();
                }

                strXML.Append("<set name='");
                strXML.Append(name);
                strXML.Append("' value='");
                strXML.Append(value);
                strXML.Append("' ");
                strXML.Append("color='");
                //if (chartType == FusionLineChart.Bar2D)
                //{
                //    strXML.Append(FusionLineChart.Bar2DColour);
                //}
                //else
                //{
                strXML.Append(utility.getFCColor());
                //}
                strXML.Append("' ");

                if (text.Trim().Length > 0)
                {
                    strXML.Append(" hoverText=" + GetValue(text));
                }

                if (url.Trim().Length > 0)
                {
                    if (newWindow)
                    {
                        strXML.Append(" link=" + GetValue("n-" + urlPrefix + url));
                    }
                    else
                    {
                        strXML.Append(" link=" + GetValue(urlPrefix + url));
                    }
                    //strXML.Append("' link='default.aspx' />");
                    //strXML.Append("' link='n-default.aspx' />"); //new window
                }
                strXML.Append(" />");
            }
        }// end multi series
        //Close <graph> element
        strXML.Append("</graph>");

        //Create the chart - Pie 3D Chart with data from strXML
        return InfoSoftGlobal.FusionCharts.RenderChartHTML("FusionCharts/" + chartType, "", strXML.ToString(), chartId, chartWidth.ToString(), chartHeight.ToString(), false);
    }
}

public class FusionChartUtility
{
    //private string[] arr_FCColors;
    private int FC_ColorCounter;
    private List<string> listColors = new List<string>();

    public FusionChartUtility()
    {
        /*    
         * This page contains an array of colors to be used as default set of colors for FusionCharts
         * arr_FCColors is the array that would contain the hex code of colors 
         * ALL COLORS HEX CODES TO BE USED WITHOUT #
         * 
         * We also initiate a counter variable to help us cyclically rotate through
         * the array of colors.
         */

        FC_ColorCounter = 0;
        //arr_FCColors = new string[27];

        listColors.Add("E48700");
        listColors.Add("A5BC4E");
        listColors.Add("C7C79E");
        listColors.Add("1895D7");
        listColors.Add("EF5E27");
        listColors.Add("6691AF");
        listColors.Add("86CFE4");

        listColors.Add("1941A5"); //Dark Blue
        listColors.Add("AFD8F8");
        listColors.Add("F6BD0F");
        listColors.Add("8BBA00");
        listColors.Add("A66EDD");
        listColors.Add("F984A1");
        listColors.Add("CCCC00"); //Chrome Yellow+Green
        listColors.Add("999999"); //Grey
        listColors.Add("0099CC"); //Blue Shade
        listColors.Add("FF0000"); //Bright Red 
        listColors.Add("006F00"); //Dark Green
        listColors.Add("0099FF"); //Blue (Light)
        listColors.Add("FF66CC"); //Dark Pink
        listColors.Add("669966"); //Dirty green
        listColors.Add("7C7CB4"); //Violet shade of blue
        listColors.Add("FF9933"); //Orange
        listColors.Add("9900FF"); //Violet
        listColors.Add("99FFCC"); //Blue+Green Light
        listColors.Add("CCCCFF"); //Light violet
        listColors.Add("669900"); //Shade of green

        /*
    arr_FCColors[0] = "E48700";
    arr_FCColors[1] = "A5BC4E";
    arr_FCColors[2] = "1895D7";
    arr_FCColors[3] = "C7C79E";
    arr_FCColors[4] = "6691AF";
    arr_FCColors[5] = "EF5E27";
    arr_FCColors[6] = "86CFE4";

    arr_FCColors[7] = "1941A5"; //Dark Blue
    arr_FCColors[8] = "AFD8F8";
    arr_FCColors[9] = "F6BD0F";
    arr_FCColors[10] = "8BBA00";
    arr_FCColors[11] = "A66EDD";
    arr_FCColors[12] = "F984A1";
    arr_FCColors[13] = "CCCC00"; //Chrome Yellow+Green
    arr_FCColors[14] = "999999"; //Grey
    arr_FCColors[15] = "0099CC"; //Blue Shade
    arr_FCColors[16] = "FF0000"; //Bright Red 
    arr_FCColors[17] = "006F00"; //Dark Green
    arr_FCColors[18] = "0099FF"; //Blue (Light)
    arr_FCColors[19] = "FF66CC"; //Dark Pink
    arr_FCColors[20] = "669966"; //Dirty green
    arr_FCColors[21] = "7C7CB4"; //Violet shade of blue
    arr_FCColors[22] = "FF9933"; //Orange
    arr_FCColors[23] = "9900FF"; //Violet
    arr_FCColors[24] = "99FFCC"; //Blue+Green Light
    arr_FCColors[25] = "CCCCFF"; //Light violet
    arr_FCColors[26] = "669900"; //Shade of green
         */
    }
    //getFCColor method helps return a color from arr_FCColors array. It uses
    //cyclic iteration to return a color from a given index. The index value is
    //maintained in FC_ColorCounter

    public string getFCColor()
    {

        //Update index
        FC_ColorCounter++;
        //Return color
        //return arr_FCColors[FC_ColorCounter % arr_FCColors.Length];
        return (listColors.ToArray())[FC_ColorCounter % listColors.Count];
    }
}