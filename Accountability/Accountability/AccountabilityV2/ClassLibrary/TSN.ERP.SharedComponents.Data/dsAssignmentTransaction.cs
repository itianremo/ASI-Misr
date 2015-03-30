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
    public class dsAssignmentTransaction : DataSet {
        
        private GEN_AssgimentTransactionsDataTable tableGEN_AssgimentTransactions;
        
        public dsAssignmentTransaction() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected dsAssignmentTransaction(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["GEN_AssgimentTransactions"] != null)) {
                    this.Tables.Add(new GEN_AssgimentTransactionsDataTable(ds.Tables["GEN_AssgimentTransactions"]));
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
        public GEN_AssgimentTransactionsDataTable GEN_AssgimentTransactions {
            get {
                return this.tableGEN_AssgimentTransactions;
            }
        }
        
        public override DataSet Clone() {
            dsAssignmentTransaction cln = ((dsAssignmentTransaction)(base.Clone()));
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
            if ((ds.Tables["GEN_AssgimentTransactions"] != null)) {
                this.Tables.Add(new GEN_AssgimentTransactionsDataTable(ds.Tables["GEN_AssgimentTransactions"]));
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
            this.tableGEN_AssgimentTransactions = ((GEN_AssgimentTransactionsDataTable)(this.Tables["GEN_AssgimentTransactions"]));
            if ((this.tableGEN_AssgimentTransactions != null)) {
                this.tableGEN_AssgimentTransactions.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "dsAssignmentTransaction";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/dsAssignmentTransaction.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableGEN_AssgimentTransactions = new GEN_AssgimentTransactionsDataTable();
            this.Tables.Add(this.tableGEN_AssgimentTransactions);
        }
        
        private bool ShouldSerializeGEN_AssgimentTransactions() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void GEN_AssgimentTransactionsRowChangeEventHandler(object sender, GEN_AssgimentTransactionsRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class GEN_AssgimentTransactionsDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnTransID;
            
            private DataColumn columnAssignmentD;
            
            private DataColumn columnAssTransType;
            
            private DataColumn columnOldStatus;
            
            private DataColumn columnOLdEvalution;
            
            private DataColumn columnNewStatus;
            
            private DataColumn columnNewEvalutation;
            
            internal GEN_AssgimentTransactionsDataTable() : 
                    base("GEN_AssgimentTransactions") {
                this.InitClass();
            }
            
            internal GEN_AssgimentTransactionsDataTable(DataTable table) : 
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
            
            internal DataColumn TransIDColumn {
                get {
                    return this.columnTransID;
                }
            }
            
            internal DataColumn AssignmentDColumn {
                get {
                    return this.columnAssignmentD;
                }
            }
            
            internal DataColumn AssTransTypeColumn {
                get {
                    return this.columnAssTransType;
                }
            }
            
            internal DataColumn OldStatusColumn {
                get {
                    return this.columnOldStatus;
                }
            }
            
            internal DataColumn OLdEvalutionColumn {
                get {
                    return this.columnOLdEvalution;
                }
            }
            
            internal DataColumn NewStatusColumn {
                get {
                    return this.columnNewStatus;
                }
            }
            
            internal DataColumn NewEvalutationColumn {
                get {
                    return this.columnNewEvalutation;
                }
            }
            
            public GEN_AssgimentTransactionsRow this[int index] {
                get {
                    return ((GEN_AssgimentTransactionsRow)(this.Rows[index]));
                }
            }
            
            public event GEN_AssgimentTransactionsRowChangeEventHandler GEN_AssgimentTransactionsRowChanged;
            
            public event GEN_AssgimentTransactionsRowChangeEventHandler GEN_AssgimentTransactionsRowChanging;
            
            public event GEN_AssgimentTransactionsRowChangeEventHandler GEN_AssgimentTransactionsRowDeleted;
            
            public event GEN_AssgimentTransactionsRowChangeEventHandler GEN_AssgimentTransactionsRowDeleting;
            
            public void AddGEN_AssgimentTransactionsRow(GEN_AssgimentTransactionsRow row) {
                this.Rows.Add(row);
            }
            
            public GEN_AssgimentTransactionsRow AddGEN_AssgimentTransactionsRow(int TransID, int AssignmentD, short AssTransType, short OldStatus, short OLdEvalution, short NewStatus, short NewEvalutation) {
                GEN_AssgimentTransactionsRow rowGEN_AssgimentTransactionsRow = ((GEN_AssgimentTransactionsRow)(this.NewRow()));
                rowGEN_AssgimentTransactionsRow.ItemArray = new object[] {
                        TransID,
                        AssignmentD,
                        AssTransType,
                        OldStatus,
                        OLdEvalution,
                        NewStatus,
                        NewEvalutation};
                this.Rows.Add(rowGEN_AssgimentTransactionsRow);
                return rowGEN_AssgimentTransactionsRow;
            }
            
            public GEN_AssgimentTransactionsRow FindByTransID(int TransID) {
                return ((GEN_AssgimentTransactionsRow)(this.Rows.Find(new object[] {
                            TransID})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                GEN_AssgimentTransactionsDataTable cln = ((GEN_AssgimentTransactionsDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new GEN_AssgimentTransactionsDataTable();
            }
            
            internal void InitVars() {
                this.columnTransID = this.Columns["TransID"];
                this.columnAssignmentD = this.Columns["AssignmentD"];
                this.columnAssTransType = this.Columns["AssTransType"];
                this.columnOldStatus = this.Columns["OldStatus"];
                this.columnOLdEvalution = this.Columns["OLdEvalution"];
                this.columnNewStatus = this.Columns["NewStatus"];
                this.columnNewEvalutation = this.Columns["NewEvalutation"];
            }
            
            private void InitClass() {
                this.columnTransID = new DataColumn("TransID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnTransID);
                this.columnAssignmentD = new DataColumn("AssignmentD", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnAssignmentD);
                this.columnAssTransType = new DataColumn("AssTransType", typeof(short), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnAssTransType);
                this.columnOldStatus = new DataColumn("OldStatus", typeof(short), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnOldStatus);
                this.columnOLdEvalution = new DataColumn("OLdEvalution", typeof(short), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnOLdEvalution);
                this.columnNewStatus = new DataColumn("NewStatus", typeof(short), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnNewStatus);
                this.columnNewEvalutation = new DataColumn("NewEvalutation", typeof(short), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnNewEvalutation);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnTransID}, true));
                this.columnTransID.AllowDBNull = false;
                this.columnTransID.Unique = true;
                this.columnAssTransType.AllowDBNull = false;
                this.columnNewStatus.AllowDBNull = false;
                this.columnNewEvalutation.AllowDBNull = false;
            }
            
            public GEN_AssgimentTransactionsRow NewGEN_AssgimentTransactionsRow() {
                return ((GEN_AssgimentTransactionsRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new GEN_AssgimentTransactionsRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(GEN_AssgimentTransactionsRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.GEN_AssgimentTransactionsRowChanged != null)) {
                    this.GEN_AssgimentTransactionsRowChanged(this, new GEN_AssgimentTransactionsRowChangeEvent(((GEN_AssgimentTransactionsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.GEN_AssgimentTransactionsRowChanging != null)) {
                    this.GEN_AssgimentTransactionsRowChanging(this, new GEN_AssgimentTransactionsRowChangeEvent(((GEN_AssgimentTransactionsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.GEN_AssgimentTransactionsRowDeleted != null)) {
                    this.GEN_AssgimentTransactionsRowDeleted(this, new GEN_AssgimentTransactionsRowChangeEvent(((GEN_AssgimentTransactionsRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.GEN_AssgimentTransactionsRowDeleting != null)) {
                    this.GEN_AssgimentTransactionsRowDeleting(this, new GEN_AssgimentTransactionsRowChangeEvent(((GEN_AssgimentTransactionsRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveGEN_AssgimentTransactionsRow(GEN_AssgimentTransactionsRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class GEN_AssgimentTransactionsRow : DataRow {
            
            private GEN_AssgimentTransactionsDataTable tableGEN_AssgimentTransactions;
            
            internal GEN_AssgimentTransactionsRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableGEN_AssgimentTransactions = ((GEN_AssgimentTransactionsDataTable)(this.Table));
            }
            
            public int TransID {
                get {
                    return ((int)(this[this.tableGEN_AssgimentTransactions.TransIDColumn]));
                }
                set {
                    this[this.tableGEN_AssgimentTransactions.TransIDColumn] = value;
                }
            }
            
            public int AssignmentD {
                get {
                    try {
                        return ((int)(this[this.tableGEN_AssgimentTransactions.AssignmentDColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGEN_AssgimentTransactions.AssignmentDColumn] = value;
                }
            }
            
            public short AssTransType {
                get {
                    return ((short)(this[this.tableGEN_AssgimentTransactions.AssTransTypeColumn]));
                }
                set {
                    this[this.tableGEN_AssgimentTransactions.AssTransTypeColumn] = value;
                }
            }
            
            public short OldStatus {
                get {
                    try {
                        return ((short)(this[this.tableGEN_AssgimentTransactions.OldStatusColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGEN_AssgimentTransactions.OldStatusColumn] = value;
                }
            }
            
            public short OLdEvalution {
                get {
                    try {
                        return ((short)(this[this.tableGEN_AssgimentTransactions.OLdEvalutionColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGEN_AssgimentTransactions.OLdEvalutionColumn] = value;
                }
            }
            
            public short NewStatus {
                get {
                    return ((short)(this[this.tableGEN_AssgimentTransactions.NewStatusColumn]));
                }
                set {
                    this[this.tableGEN_AssgimentTransactions.NewStatusColumn] = value;
                }
            }
            
            public short NewEvalutation {
                get {
                    return ((short)(this[this.tableGEN_AssgimentTransactions.NewEvalutationColumn]));
                }
                set {
                    this[this.tableGEN_AssgimentTransactions.NewEvalutationColumn] = value;
                }
            }
            
            public bool IsAssignmentDNull() {
                return this.IsNull(this.tableGEN_AssgimentTransactions.AssignmentDColumn);
            }
            
            public void SetAssignmentDNull() {
                this[this.tableGEN_AssgimentTransactions.AssignmentDColumn] = System.Convert.DBNull;
            }
            
            public bool IsOldStatusNull() {
                return this.IsNull(this.tableGEN_AssgimentTransactions.OldStatusColumn);
            }
            
            public void SetOldStatusNull() {
                this[this.tableGEN_AssgimentTransactions.OldStatusColumn] = System.Convert.DBNull;
            }
            
            public bool IsOLdEvalutionNull() {
                return this.IsNull(this.tableGEN_AssgimentTransactions.OLdEvalutionColumn);
            }
            
            public void SetOLdEvalutionNull() {
                this[this.tableGEN_AssgimentTransactions.OLdEvalutionColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class GEN_AssgimentTransactionsRowChangeEvent : EventArgs {
            
            private GEN_AssgimentTransactionsRow eventRow;
            
            private DataRowAction eventAction;
            
            public GEN_AssgimentTransactionsRowChangeEvent(GEN_AssgimentTransactionsRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public GEN_AssgimentTransactionsRow Row {
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
