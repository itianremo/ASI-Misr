﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace TSN.ERP.SharedComponents.Data {
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class dsState : DataSet {
        
        private GEN_StateDataTable tableGEN_State;
        
        public dsState() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected dsState(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["GEN_State"] != null)) {
                    this.Tables.Add(new GEN_StateDataTable(ds.Tables["GEN_State"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.InitClass();
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public GEN_StateDataTable GEN_State {
            get {
                return this.tableGEN_State;
            }
        }
        
        public override DataSet Clone() {
            dsState cln = ((dsState)(base.Clone()));
            cln.InitVars();
            return cln;
        }
        
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        protected override void ReadXmlSerializable(XmlReader reader) {
            this.Reset();
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            if ((ds.Tables["GEN_State"] != null)) {
                this.Tables.Add(new GEN_StateDataTable(ds.Tables["GEN_State"]));
            }
            this.DataSetName = ds.DataSetName;
            this.Prefix = ds.Prefix;
            this.Namespace = ds.Namespace;
            this.Locale = ds.Locale;
            this.CaseSensitive = ds.CaseSensitive;
            this.EnforceConstraints = ds.EnforceConstraints;
            this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
            this.InitVars();
        }
        
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new XmlTextReader(stream), null);
        }
        
        internal void InitVars() {
            this.tableGEN_State = ((GEN_StateDataTable)(this.Tables["GEN_State"]));
            if ((this.tableGEN_State != null)) {
                this.tableGEN_State.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "dsState";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/dsState.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableGEN_State = new GEN_StateDataTable();
            this.Tables.Add(this.tableGEN_State);
        }
        
        private bool ShouldSerializeGEN_State() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void GEN_StateRowChangeEventHandler(object sender, GEN_StateRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class GEN_StateDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnStateCode;
            
            private DataColumn columnCountryID;
            
            private DataColumn columnStateName;
            
            internal GEN_StateDataTable() : 
                    base("GEN_State") {
                this.InitClass();
            }
            
            internal GEN_StateDataTable(DataTable table) : 
                    base(table.TableName) {
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }
            
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            internal DataColumn StateCodeColumn {
                get {
                    return this.columnStateCode;
                }
            }
            
            internal DataColumn CountryIDColumn {
                get {
                    return this.columnCountryID;
                }
            }
            
            internal DataColumn StateNameColumn {
                get {
                    return this.columnStateName;
                }
            }
            
            public GEN_StateRow this[int index] {
                get {
                    return ((GEN_StateRow)(this.Rows[index]));
                }
            }
            
            public event GEN_StateRowChangeEventHandler GEN_StateRowChanged;
            
            public event GEN_StateRowChangeEventHandler GEN_StateRowChanging;
            
            public event GEN_StateRowChangeEventHandler GEN_StateRowDeleted;
            
            public event GEN_StateRowChangeEventHandler GEN_StateRowDeleting;
            
            public void AddGEN_StateRow(GEN_StateRow row) {
                this.Rows.Add(row);
            }
            
            public GEN_StateRow AddGEN_StateRow(string StateCode, short CountryID, string StateName) {
                GEN_StateRow rowGEN_StateRow = ((GEN_StateRow)(this.NewRow()));
                rowGEN_StateRow.ItemArray = new object[] {
                        StateCode,
                        CountryID,
                        StateName};
                this.Rows.Add(rowGEN_StateRow);
                return rowGEN_StateRow;
            }
            
            public GEN_StateRow FindByStateCode(string StateCode) {
                return ((GEN_StateRow)(this.Rows.Find(new object[] {
                            StateCode})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                GEN_StateDataTable cln = ((GEN_StateDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new GEN_StateDataTable();
            }
            
            internal void InitVars() {
                this.columnStateCode = this.Columns["StateCode"];
                this.columnCountryID = this.Columns["CountryID"];
                this.columnStateName = this.Columns["StateName"];
            }
            
            private void InitClass() {
                this.columnStateCode = new DataColumn("StateCode", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnStateCode);
                this.columnCountryID = new DataColumn("CountryID", typeof(short), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnCountryID);
                this.columnStateName = new DataColumn("StateName", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnStateName);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnStateCode}, true));
                this.columnStateCode.AllowDBNull = false;
                this.columnStateCode.Unique = true;
            }
            
            public GEN_StateRow NewGEN_StateRow() {
                return ((GEN_StateRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new GEN_StateRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(GEN_StateRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.GEN_StateRowChanged != null)) {
                    this.GEN_StateRowChanged(this, new GEN_StateRowChangeEvent(((GEN_StateRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.GEN_StateRowChanging != null)) {
                    this.GEN_StateRowChanging(this, new GEN_StateRowChangeEvent(((GEN_StateRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.GEN_StateRowDeleted != null)) {
                    this.GEN_StateRowDeleted(this, new GEN_StateRowChangeEvent(((GEN_StateRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.GEN_StateRowDeleting != null)) {
                    this.GEN_StateRowDeleting(this, new GEN_StateRowChangeEvent(((GEN_StateRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveGEN_StateRow(GEN_StateRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class GEN_StateRow : DataRow {
            
            private GEN_StateDataTable tableGEN_State;
            
            internal GEN_StateRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableGEN_State = ((GEN_StateDataTable)(this.Table));
            }
            
            public string StateCode {
                get {
                    return ((string)(this[this.tableGEN_State.StateCodeColumn]));
                }
                set {
                    this[this.tableGEN_State.StateCodeColumn] = value;
                }
            }
            
            public short CountryID {
                get {
                    try {
                        return ((short)(this[this.tableGEN_State.CountryIDColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGEN_State.CountryIDColumn] = value;
                }
            }
            
            public string StateName {
                get {
                    try {
                        return ((string)(this[this.tableGEN_State.StateNameColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGEN_State.StateNameColumn] = value;
                }
            }
            
            public bool IsCountryIDNull() {
                return this.IsNull(this.tableGEN_State.CountryIDColumn);
            }
            
            public void SetCountryIDNull() {
                this[this.tableGEN_State.CountryIDColumn] = System.Convert.DBNull;
            }
            
            public bool IsStateNameNull() {
                return this.IsNull(this.tableGEN_State.StateNameColumn);
            }
            
            public void SetStateNameNull() {
                this[this.tableGEN_State.StateNameColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class GEN_StateRowChangeEvent : EventArgs {
            
            private GEN_StateRow eventRow;
            
            private DataRowAction eventAction;
            
            public GEN_StateRowChangeEvent(GEN_StateRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public GEN_StateRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            public DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}
