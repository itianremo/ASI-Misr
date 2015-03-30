namespace TSN.ERP.WebGUI.Go.flowcharts
{
   using System;
   using System.Drawing;
   using System.Text.RegularExpressions;

   /// <summary>
   /// Useful C# snippets from CambiaResearch.com
   /// </summary>
   public class ColorConv
   {

      public ColorConv()
      {
      }
	   static char[] hexDigits = {'0', '1', '2', '3', '4', '5', '6', '7',
									 '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
	   //-------------------------------------------------------------------------------
	   #region Hex to color converter
	   /// <summary>
      /// Convert a hex string to a .NET Color object.
      /// </summary>
      /// <param name="hexColor">a hex string: "FFFFFF", "#000000"</param>
      public static Color HexStringToColor(string hexColor)
      {
         string hc = ExtractHexDigits(hexColor);
		 
         if (hc.Length != 6)
         {
            // you can choose whether to throw an exception
            //throw new ArgumentException("hexColor is not exactly 6 digits.");
            return Color.Empty;
         }
         string r = hc.Substring(0, 2);
         string g = hc.Substring(2, 2);
         string b = hc.Substring(4, 2);
         Color color = Color.Empty;
         try
         {
            int ri 
               = Int32.Parse(r, System.Globalization.NumberStyles.HexNumber);
            int gi 
               = Int32.Parse(g, System.Globalization.NumberStyles.HexNumber);
            int bi 
               = Int32.Parse(b, System.Globalization.NumberStyles.HexNumber);
            color = Color.FromArgb(ri, gi, bi);
         }
         catch
         {
            // you can choose whether to throw an exception
            //throw new ArgumentException("Conversion failed.");
            return Color.Empty;
         }
         return color;
      }
	   #endregion
	   //-------------------------------------------------------------------------------		
	   #region ExtractHexDigits
		/// <summary>
		/// Extract only the hex digits from a string.
		/// </summary>
      public static string ExtractHexDigits(string input)
      {
         // remove any characters that are not digits (like #)
         Regex isHexDigit 
            = new Regex("[abcdefABCDEF\\d]+", RegexOptions.Compiled);
         string newnum = "";
         foreach (char c in input)
         {
            if (isHexDigit.IsMatch(c.ToString()))
               newnum += c.ToString();
         }
         return newnum;
      }
#endregion
	   //-------------------------------------------------------------------------------
	   #region Color to hex converter 
	   public static string ColorToHexString(Color color) 
	   {
		   byte[] bytes = new byte[3];
		   bytes[0] = color.R;
		   bytes[1] = color.G;
		   bytes[2] = color.B;
		   char[] chars = new char[bytes.Length * 2];
		   for (int i = 0; i < bytes.Length; i++) 
		   {
			   int b = bytes[i];
			   chars[i * 2] = hexDigits[b >> 4];
			   chars[i * 2 + 1] = hexDigits[b & 0xF];
		   }
		   return new string(chars);
	   }
	   #endregion
	   //-------------------------------------------------------------------------------
   }
}