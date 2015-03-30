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
    public class dsCompaniesProfiles : DataSet {
        
        private GEN_CompanyProfileDataTable tableGEN_CompanyProfile;
        
        public dsCompaniesProfiles() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected dsCompaniesProfiles(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["GEN_CompanyProfile"] != null)) {
                    this.Tables.Add(new GEN_CompanyProfileDataTable(ds.Tables["GEN_CompanyProfile"]));
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
        public GEN_CompanyProfileDataTable GEN_CompanyProfile {
            get {
                return this.tableGEN_CompanyProfile;
            }
        }
        
        public override DataSet Clone() {
            dsCompaniesProfiles cln = ((dsCompaniesProfiles)(base.Clone()));
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
            if ((ds.Tables["GEN_CompanyProfile"] != null)) {
                this.Tables.Add(new GEN_CompanyProfileDataTable(ds.Tables["GEN_CompanyProfile"]));
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
            this.tableGEN_CompanyProfile = ((GEN_CompanyProfileDataTable)(this.Tables["GEN_CompanyProfile"]));
            if ((this.tableGEN_CompanyProfile != null)) {
                this.tableGEN_CompanyProfile.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "dsCompaniesProfiles";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/dsCompaniesProfiles.xsd";
            this.Locale = new System.Globalization.CultureInfo("ar-EG");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableGEN_CompanyProfile = new GEN_CompanyProfileDataTable();
            this.Tables.Add(this.tableGEN_CompanyProfile);
        }
        
        private bool ShouldSerializeGEN_CompanyProfile() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void GEN_CompanyProfileRowChangeEventHandler(object sender, GEN_CompanyProfileRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class GEN_CompanyProfileDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnCompID;
            
            private DataColumn columnCompanyName;
            
            internal GEN_CompanyProfileDataTable() : 
                    base("GEN_CompanyProfile") {
                this.InitClass();
            }
            
            internal GEN_CompanyProfileDataTable(DataTable table) : 
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
            
            internal DataColumn CompIDColumn {
                get {
                    return this.columnCompID;
                }
            }
            
            internal DataColumn CompanyNameColumn {
                get {
                    return this.columnCompanyName;
                }
            }
            
            public GEN_CompanyProfileRow this[int index] {
                get {
                    return ((GEN_CompanyProfileRow)(this.Rows[index]));
                }
            }
            
            public event GEN_CompanyProfileRowChangeEventHandler GEN_CompanyProfileRowChanged;
            
            public event GEN_CompanyProfileRowChangeEventHandler GEN_CompanyProfileRowChanging;
            
            public event GEN_CompanyProfileRowChangeEventHandler GEN_CompanyProfileRowDeleted;
            
            public event GEN_CompanyProfileRowChangeEventHandler GEN_CompanyProfileRowDeleting;
            
            public void AddGEN_CompanyProfileRow(GEN_CompanyProfileRow row) {
                this.Rows.Add(row);
            }
            
            public GEN_CompanyProfileRow AddGEN_CompanyProfileRow(int CompID, string CompanyName) {
                GEN_CompanyProfileRow rowGEN_CompanyProfileRow = ((GEN_CompanyProfileRow)(this.NewRow()));
                rowGEN_CompanyProfileRow.ItemArray = new object[] {
                        CompID,
                        CompanyName};
                this.Rows.Add(rowGEN_CompanyProfileRow);
                return rowGEN_CompanyProfileRow;
            }
            
            public GEN_CompanyProfileRow FindByCompID(int CompID) {
                return ((GEN_CompanyProfileRow)(this.Rows.Find(new object[] {
                            CompID})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                GEN_CompanyProfileDataTable cln = ((GEN_CompanyProfileDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new GEN_CompanyProfileDataTable();
            }
            
            internal void InitVars() {
                this.columnCompID = this.Columns["CompID"];
                this.columnCompanyName = this.Columns["CompanyName"];
            }
            
            private void InitClass() {
                this.columnCompID = new DataColumn("CompID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnCompID);
                this.columnCompanyName = new DataColumn("CompanyName", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnCompanyName);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnCompID}, true));
                this.columnCompID.AllowDBNull = false;
                this.columnCompID.Unique = true;
                this.columnCompanyName.AllowDBNull = false;
            }
            
            public GEN_CompanyProfileRow NewGEN_CompanyProfileRow() {
                return ((GEN_CompanyProfileRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new GEN_CompanyProfileRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(GEN_CompanyProfileRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.GEN_CompanyProfileRowChanged != null)) {
                    this.GEN_CompanyProfileRowChanged(this, new GEN_CompanyProfileRowChangeEvent(((GEN_CompanyProfileRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.GEN_CompanyProfileRowChanging != null)) {
                    this.GEN_CompanyProfileRowChanging(this, new GEN_CompanyProfileRowChangeEvent(((GEN_CompanyProfileRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.GEN_CompanyProfileRowDeleted != null)) {
                    this.GEN_CompanyProfileRowDeleted(this, new GEN_CompanyProfileRowChangeEvent(((GEN_CompanyProfileRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.GEN_CompanyProfileRowDeleting != null)) {
                    this.GEN_CompanyProfileRowDeleting(this, new GEN_CompanyProfileRowChangeEvent(((GEN_CompanyProfileRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveGEN_CompanyProfileRow(GEN_CompanyProfileRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class GEN_CompanyProfileRow : DataRow {
            
            private GEN_CompanyProfileDataTable tableGEN_CompanyProfile;
            
            internal GEN_CompanyProfileRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableGEN_CompanyProfile = ((GEN_CompanyProfileDataTable)(this.Table));
            }
            
            public int CompID {
                get {
                    return ((int)(this[this.tableGEN_CompanyProfile.CompIDColumn]));
                }
                set {
                    this[this.tableGEN_CompanyProfile.CompIDColumn] = value;
                }
            }
            
            public string CompanyName {
                get {
                    return ((string)(this[this.tableGEN_CompanyProfile.CompanyNameColumn]));
                }
                set {
                    this[this.tableGEN_CompanyProfile.CompanyNameColumn] = value;
                }
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class GEN_CompanyProfileRowChangeEvent : EventArgs {
            
            private GEN_CompanyProfileRow eventRow;
            
            private DataRowAction eventAction;
            
            public GEN_CompanyProfileRowChangeEvent(GEN_CompanyProfileRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public GEN_CompanyProfileRow Row {
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
