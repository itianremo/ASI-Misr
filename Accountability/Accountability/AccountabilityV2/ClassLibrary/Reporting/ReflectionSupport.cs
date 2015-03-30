using System;
using System.Reflection;
using TSN.ERP.Engine;
namespace TSN.ERP.Reporting
{
	/// <summary>
	/// Summary description for ReflectionSupport.
	/// </summary>
	public class ReflectionSupport:Engine.BussinesObject 
	{
		public ReflectionSupport()
		{

		}
		public  object ExecuteMethod(MethodCall Call)
		{
			Engine.BussinesObject BO =  ActiveSession.GetInstance(Call.TypeName,Call.AssemblyName);
			if (BO == null)
				return null;
			Type TargetType  = BO.GetType();
			MethodInfo[] ListMethodInfo = TargetType.GetMethods();
			foreach(MethodInfo TempMI in ListMethodInfo)
			{
				if (TempMI.Name == Call.MethodName)
				{
					if (TempMI.GetParameters().Length == Call.Parameters.Length)
					{
						try
						{
							return ExecuteMethod(BO,TempMI,Call.Parameters) ;
						}
						catch( Exception ee )
						{
							continue;
						}
					}
				}
			}
			return null;
		}
		public object ExecuteMethod(Engine.BussinesObject BO,  MethodInfo MInfo, object[] Parameters)
		{
			ParameterInfo[] parInf = MInfo.GetParameters();
			Object[] finalParams = new object[  Parameters.Length ];
			int n = 0;
			foreach( ParameterInfo parm in parInf  )
			{
				switch ( parm.ParameterType.ToString() )
				{
					case "System.Int32" :
						finalParams[ n ] = Convert.ToInt32( Parameters[ n ] );
						break;
					case "System.String" :
						finalParams[ n ] = Convert.ToString( Parameters[ n ] );
						break;
					case "System.DateTime" :
						finalParams[ n ] = Convert.ToDateTime( Parameters[ n ] );
						break;
					default :
						break;
				}
				n++;
				
			}
			return MInfo.Invoke(BO,finalParams);
		}
		public static bool CheckInheritance(Type ChildType, Type ParnetType) 
		{
			if (ChildType.ToString() == ParnetType.ToString())
				return true;
			if (ChildType.BaseType != null )
				return CheckInheritance(ChildType.BaseType,ParnetType);
			return false;
		}

		public static bool CheckMethodERPType(MethodInfo MInfo,ERPMethodType EMtype)
		{
			try
			{
				Object[] myAttributes = MInfo.GetCustomAttributes(typeof(AtrERPMethodType),false);
				foreach(object tempObj in myAttributes)
				{
					AtrERPMethodType CurrentEMType = (AtrERPMethodType)tempObj;
					if (CurrentEMType.CurrentERPMethodType == EMtype )
						return true;
				}
				return false;
			}
			catch{return false;}

		}
	
		public static string GetArgummentsString(MethodInfo MInfo)
		{
			try
			{
				Object[] myAttributes = MInfo.GetCustomAttributes(typeof(AtrERPMethodType),false);
				foreach(object tempObj in myAttributes)
				{
					AtrERPMethodType CurrentEMType = (AtrERPMethodType)tempObj;
					return CurrentEMType.MethodArguments.ToString(); 
				}
			}
			catch{return "";}
			return "";
		}
	}
}
