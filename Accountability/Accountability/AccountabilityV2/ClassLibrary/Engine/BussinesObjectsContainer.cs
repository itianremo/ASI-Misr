using System;
using System.Reflection;
using TSN.ERP;
namespace TSN.ERP.Engine
{
	/// <summary>
	/// Summary description for BussinesObjectsContainer.
	/// </summary>
	public class BussinesObjectsContainer
	{
		private Server ParentServer;
		
		public BussinesObjectsContainer():base(){}
		public BussinesObjectsContainer(Server TargetServer)
		{
			this.ParentServer = TargetServer;
		}
		
		# region Loading Bussines Objects
		public BussinesObject LoadStandardBussinessObject(string ClassName)
		{
			Object[] args = null;
			Type ObjectType  = Type.GetTypeFromProgID(ClassName);
			object TempObject = ObjectType.InvokeMember(null, 
				BindingFlags.DeclaredOnly | 
				BindingFlags.Public | BindingFlags.NonPublic | 
				BindingFlags.Instance | BindingFlags.CreateInstance, null, null, args);
			return  (BussinesObject) TempObject;
		}
		# endregion
		
	}
}

