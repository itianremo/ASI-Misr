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
    public class dsCompanyElementLevels : DataSet {
        
        private GEN_CompanyElmentLevelsDataTable tableGEN_CompanyElmentLevels;
        
        public dsCompanyElementLevels() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected dsCompanyElementLevels(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["GEN_CompanyElmentLevels"] != null)) {
                    this.Tables.Add(new GEN_CompanyElmentLevelsDataTable(ds.Tables["GEN_CompanyElmentLevels"]));
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
        public GEN_CompanyElmentLevelsDataTable GEN_CompanyElmentLevels {
            get {
                return this.tableGEN_CompanyElmentLevels;
            }
        }
        
        public override DataSet Clone() {
            dsCompanyElementLevels cln = ((dsCompanyElementLevels)(base.Clone()));
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
            if ((ds.Tables["GEN_CompanyElmentLevels"] != null)) {
                this.Tables.Add(new GEN_CompanyElmentLevelsDataTable(ds.Tables["GEN_CompanyElmentLevels"]));
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
            this.tableGEN_CompanyElmentLevels = ((GEN_CompanyElmentLevelsDataTable)(this.Tables["GEN_CompanyElmentLevels"]));
            if ((this.tableGEN_CompanyElmentLevels != null)) {
                this.tableGEN_CompanyElmentLevels.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "dsCompanyElementLevels";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/dsCompanyElementLevels.xsd";
            this.Locale = new System.Globalization.CultureInfo("ar-EG");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableGEN_CompanyElmentLevels = new GEN_CompanyElmentLevelsDataTable();
            this.Tables.Add(this.tableGEN_CompanyElmentLevels);
        }
        
        private bool ShouldSerializeGEN_CompanyElmentLevels() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void GEN_CompanyElmentLevelsRowChangeEventHandler(object sender, GEN_CompanyElmentLevelsRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class GEN_CompanyElmentLevelsDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnCEL_ID;
            
            private DataColumn columnCELName;
            
            private DataColumn columnCELevelDesc;
            
            private DataColumn columnCELOrder;
            
            internal GEN_CompanyElmentLevelsDataTable() : 
                    base("GEN_CompanyElmentLevels") {
                this.InitClass();
            }
            
            internal GEN_CompanyElmentLevelsDataTable(DataTable table) : 
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
            
            internal DataColumn CEL_IDColumn {
                get {
                    return this.columnCEL_ID;
                }
            }
            
            internal DataColumn CELNameColumn {
                get {
                    return this.columnCELName;
                }
            }
            
            internal DataColumn CELevelDescColumn {
                get {
                    return this.columnCELevelDesc;
                }
            }
            
            internal DataColumn CELOrderColumn {
                get {
                    return this.columnCELOrder;
                }
            }
            
            public GEN_CompanyElmentLevelsRow this[int index] {
                get {
                    return ((GEN_CompanyElmentLevelsRow)(this.Rows[index]));
                }
            }
            
            public event GEN_CompanyElmentLevelsRowChangeEventHandler GEN_CompanyElmentLevelsRowChanged;
            
            public event GEN_CompanyElmentLevelsRowChangeEventHandler GEN_CompanyElmentLevelsRowChanging;
            
            public event GEN_CompanyElmentLevelsRowChangeEventHandler GEN_CompanyElmentLevelsRowDeleted;
            
            public event GEN_CompanyElmentLevelsRowChangeEventHandler GEN_CompanyElmentLevelsRowDeleting;
            
            public void AddGEN_CompanyElmentLevelsRow(GEN_CompanyElmentLevelsRow row) {
                this.Rows.Add(row);
            }
            
            public GEN_CompanyElmentLevelsRow AddGEN_CompanyElmentLevelsRow(int CEL_ID, string CELName, string CELevelDesc, int CELOrder) {
                GEN_CompanyElmentLevelsRow rowGEN_CompanyElmentLevelsRow = ((GEN_CompanyElmentLevelsRow)(this.NewRow()));
                rowGEN_CompanyElmentLevelsRow.ItemArray = new object[] {
                        CEL_ID,
                        CELName,
                        CELevelDesc,
                        CELOrder};
                this.Rows.Add(rowGEN_CompanyElmentLevelsRow);
                return rowGEN_CompanyElmentLevelsRow;
            }
            
            public GEN_CompanyElmentLevelsRow FindByCEL_ID(int CEL_ID) {
                return ((GEN_CompanyElmentLevelsRow)(this.Rows.Find(new object[] {
                            CEL_ID})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                GEN_CompanyElmentLevelsDataTable cln = ((GEN_CompanyElmentLevelsDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new GEN_CompanyElmentLevelsDataTable();
            }
            
            internal void InitVars() {
                this.columnCEL_ID = this.Columns["CEL_ID"];
                this.columnCELName = this.Columns["CELName"];
                this.columnCELevelDesc = this.Columns["CELevelDesc"];
                this.columnCELOrder = this.Columns["CELOrder"];
            }
            
            private void InitClass() {
                this.columnCEL_ID = new DataColumn("CEL_ID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnCEL_ID);
                this.columnCELName = new DataColumn("CELName", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnCELName);
                this.columnCELevelDesc = new DataColumn("CELevelDesc", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnCELevelDesc);
                this.columnCELOrder = new DataColumn("CELOrder", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnCELOrder);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnCEL_ID}, true));
                this.columnCEL_ID.AllowDBNull = false;
                this.columnCEL_ID.Unique = true;
                this.columnCELName.AllowDBNull = false;
                this.columnCELOrder.AllowDBNull = false;
            }
            
            public GEN_CompanyElmentLevelsRow NewGEN_CompanyElmentLevelsRow() {
                return ((GEN_CompanyElmentLevelsRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new GEN_CompanyElmentLevelsRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(GEN_CompanyElmentLevelsRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.GEN_CompanyElmentLevelsRowChanged != null)) {
                    this.GEN_CompanyElmentLevelsRowChanged(this, new GEN_CompanyElmentLevelsRowChangeEvent(((GEN_CompanyElmentLevelsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.GEN_CompanyElmentLevelsRowChanging != null)) {
                    this.GEN_CompanyElmentLevelsRowChanging(this, new GEN_CompanyElmentLevelsRowChangeEvent(((GEN_CompanyElmentLevelsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.GEN_CompanyElmentLevelsRowDeleted != null)) {
                    this.GEN_CompanyElmentLevelsRowDeleted(this, new GEN_CompanyElmentLevelsRowChangeEvent(((GEN_CompanyElmentLevelsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.GEN_CompanyElmentLevelsRowDeleting != null)) {
                    this.GEN_CompanyElmentLevelsRowDeleting(this, new GEN_CompanyElmentLevelsRowChangeEvent(((GEN_CompanyElmentLevelsRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveGEN_CompanyElmentLevelsRow(GEN_CompanyElmentLevelsRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class GEN_CompanyElmentLevelsRow : DataRow {
            
            private GEN_CompanyElmentLevelsDataTable tableGEN_CompanyElmentLevels;
            
            internal GEN_CompanyElmentLevelsRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableGEN_CompanyElmentLevels = ((GEN_CompanyElmentLevelsDataTable)(this.Table));
            }
            
            public int CEL_ID {
                get {
                    return ((int)(this[this.tableGEN_CompanyElmentLevels.CEL_IDColumn]));
                }
                set {
                    this[this.tableGEN_CompanyElmentLevels.CEL_IDColumn] = value;
                }
            }
            
            public string CELName {
                get {
                    return ((string)(this[this.tableGEN_CompanyElmentLevels.CELNameColumn]));
                }
                set {
                    this[this.tableGEN_CompanyElmentLevels.CELNameColumn] = value;
                }
            }
            
            public string CELevelDesc {
                get {
                    try {
                        return ((string)(this[this.tableGEN_CompanyElmentLevels.CELevelDescColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGEN_CompanyElmentLevels.CELevelDescColumn] = value;
                }
            }
            
            public int CELOrder {
                get {
                    return ((int)(this[this.tableGEN_CompanyElmentLevels.CELOrderColumn]));
                }
                set {
                    this[this.tableGEN_CompanyElmentLevels.CELOrderColumn] = value;
                }
            }
            
            public bool IsCELevelDescNull() {
                return this.IsNull(this.tableGEN_CompanyElmentLevels.CELevelDescColumn);
            }
            
            public void SetCELevelDescNull() {
                this[this.tableGEN_CompanyElmentLevels.CELevelDescColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class GEN_CompanyElmentLevelsRowChangeEvent : EventArgs {
            
            private GEN_CompanyElmentLevelsRow eventRow;
            
            private DataRowAction eventAction;
            
            public GEN_CompanyElmentLevelsRowChangeEvent(GEN_CompanyElmentLevelsRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public GEN_CompanyElmentLevelsRow Row {
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
