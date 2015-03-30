using System;
using TSN.ERP;
using TSN.ERP.Engine;
namespace TSN.ERP.Engine.Collections
{
	/// <summary>
	/// Summary description for SessionCollection.
	/// </summary>
	/// 
	[Serializable]
	public class BussinesComponentsCollection:System.Collections.CollectionBase 
	{
		BussinesObject _ParentObject;
		public BussinesComponentsCollection(BussinesObject ParentObject)
		{
			this._ParentObject = ParentObject;
		}
		public BussinesComponent this[ int index ]  
		{
			get  
			{
				return( (BussinesComponent) List[index] );
			}
			set  
			{
				List[index] = value;
			}
		}

		public int Add( BussinesComponent value )  
		{
			return( List.Add( value ) );
		}

		public int IndexOf( BussinesComponent value )  
		{
			return( List.IndexOf( value ) );
		}

		internal void Insert( int index, BussinesComponent value )  
		{
			List.Insert( index, value );
		}

		internal void Remove( BussinesComponent value )  
		{
			List.Remove( value );
		}

		public bool Contains( BussinesComponent value )  
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
        ////////////////////public void Dispose()
        ////////////////////{
        ////////////////////    int TempCount = this.Count;
        ////////////////////    for (int i = 0;i<TempCount;i++)
        ////////////////////        this[0].Dispose();
        ////////////////////}
	}
}
