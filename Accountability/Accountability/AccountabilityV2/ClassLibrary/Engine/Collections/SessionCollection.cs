using System;
using TSN.ERP;
namespace TSN.ERP.Engine.Collections
{
	/// <summary>
	/// Summary description for SessionCollection.
	/// </summary>
	public class SessionCollection:System.Collections.CollectionBase 
	{
		public SessionCollection()
		{

		}
		public Session this[ int index ]  
		{
			get  
			{
				return( (Session) List[index] );
			}
			set  
			{
				List[index] = value;
			}
		}

		public int Add( Session value )  
		{
			return( List.Add( value ) );
		}

		public int IndexOf( Session value )  
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, Session value )  
		{
			List.Insert( index, value );
		}

		public void Remove( Session value )  
		{
			List.Remove( value );
		}

		public bool Contains( Session value )  
		{
			// If value is not of type Int16, this will return false.
			return( List.Contains( value ) );
		}

		protected override void OnInsert( int index, object value )  
		{
			// Insert additional code to be run only when inserting values.
		}

		protected override void OnRemove( int index, object value )  
		{
			// Insert additional code to be run only when removing values.
		}

		protected override void OnSet( int index, object oldValue, object newValue )  
		{
			// Insert additional code to be run only when setting values.
		}

		protected override void OnValidate( Object value )  
		{
//			if ( value.GetType() != Type.GetType("System.Int16") )
//				//throw new ArgumentException( "value must be of type Int16.", "value" );
		}
		public Session find(string TokenString) 
		{
			int i , count;
			Session TempSession = null;
			count = this.Count ;
			for(i=0;i< count; i++)
			{
				if (this[i].Token == TokenString )
				{
					if (this[i]!=null)
						TempSession = this[i];
				}
			}
			return TempSession;
		}
	}
}
