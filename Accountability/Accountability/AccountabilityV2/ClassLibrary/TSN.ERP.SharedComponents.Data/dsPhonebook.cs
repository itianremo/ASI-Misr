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
    public class dsPhonebook : DataSet {
        
        private GEN_PhonebookDataTable tableGEN_Phonebook;
        
        public dsPhonebook() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected dsPhonebook(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["GEN_Phonebook"] != null)) {
                    this.Tables.Add(new GEN_PhonebookDataTable(ds.Tables["GEN_Phonebook"]));
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
        public GEN_PhonebookDataTable GEN_Phonebook {
            get {
                return this.tableGEN_Phonebook;
            }
        }
        
        public override DataSet Clone() {
            dsPhonebook cln = ((dsPhonebook)(base.Clone()));
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
            if ((ds.Tables["GEN_Phonebook"] != null)) {
                this.Tables.Add(new GEN_PhonebookDataTable(ds.Tables["GEN_Phonebook"]));
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
            this.tableGEN_Phonebook = ((GEN_PhonebookDataTable)(this.Tables["GEN_Phonebook"]));
            if ((this.tableGEN_Phonebook != null)) {
                this.tableGEN_Phonebook.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "dsPhonebook";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/dsPhonebook.xsd";
            this.Locale = new System.Globalization.CultureInfo("en-US");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableGEN_Phonebook = new GEN_PhonebookDataTable();
            this.Tables.Add(this.tableGEN_Phonebook);
        }
        
        private bool ShouldSerializeGEN_Phonebook() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void GEN_PhonebookRowChangeEventHandler(object sender, GEN_PhonebookRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class GEN_PhonebookDataTable : DataTable, System.Collections.IEnumerable {
            
            private DataColumn columnPhoneBookID;
            
            private DataColumn columnContactID;
            
            private DataColumn columnAreaCode;
            
            private DataColumn columnCountryCode;
            
            private DataColumn columnPhoneZone;
            
            private DataColumn columnPhoneNumber;
            
            private DataColumn columnPhoneType;
            
            private DataColumn columnPrimaryPhoneBook;
            
            internal GEN_PhonebookDataTable() : 
                    base("GEN_Phonebook") {
                this.InitClass();
            }
            
            internal GEN_PhonebookDataTable(DataTable table) : 
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
            
            internal DataColumn PhoneBookIDColumn {
                get {
                    return this.columnPhoneBookID;
                }
            }
            
            internal DataColumn ContactIDColumn {
                get {
                    return this.columnContactID;
                }
            }
            
            internal DataColumn AreaCodeColumn {
                get {
                    return this.columnAreaCode;
                }
            }
            
            internal DataColumn CountryCodeColumn {
                get {
                    return this.columnCountryCode;
                }
            }
            
            internal DataColumn PhoneZoneColumn {
                get {
                    return this.columnPhoneZone;
                }
            }
            
            internal DataColumn PhoneNumberColumn {
                get {
                    return this.columnPhoneNumber;
                }
            }
            
            internal DataColumn PhoneTypeColumn {
                get {
                    return this.columnPhoneType;
                }
            }
            
            internal DataColumn PrimaryPhoneBookColumn {
                get {
                    return this.columnPrimaryPhoneBook;
                }
            }
            
            public GEN_PhonebookRow this[int index] {
                get {
                    return ((GEN_PhonebookRow)(this.Rows[index]));
                }
            }
            
            public event GEN_PhonebookRowChangeEventHandler GEN_PhonebookRowChanged;
            
            public event GEN_PhonebookRowChangeEventHandler GEN_PhonebookRowChanging;
            
            public event GEN_PhonebookRowChangeEventHandler GEN_PhonebookRowDeleted;
            
            public event GEN_PhonebookRowChangeEventHandler GEN_PhonebookRowDeleting;
            
            public void AddGEN_PhonebookRow(GEN_PhonebookRow row) {
                this.Rows.Add(row);
            }
            
            public GEN_PhonebookRow AddGEN_PhonebookRow(int PhoneBookID, int ContactID, string AreaCode, string CountryCode, string PhoneZone, string PhoneNumber, string PhoneType, bool PrimaryPhoneBook) {
                GEN_PhonebookRow rowGEN_PhonebookRow = ((GEN_PhonebookRow)(this.NewRow()));
                rowGEN_PhonebookRow.ItemArray = new object[] {
                        PhoneBookID,
                        ContactID,
                        AreaCode,
                        CountryCode,
                        PhoneZone,
                        PhoneNumber,
                        PhoneType,
                        PrimaryPhoneBook};
                this.Rows.Add(rowGEN_PhonebookRow);
                return rowGEN_PhonebookRow;
            }
            
            public GEN_PhonebookRow FindByPhoneBookID(int PhoneBookID) {
                return ((GEN_PhonebookRow)(this.Rows.Find(new object[] {
                            PhoneBookID})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                GEN_PhonebookDataTable cln = ((GEN_PhonebookDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new GEN_PhonebookDataTable();
            }
            
            internal void InitVars() {
                this.columnPhoneBookID = this.Columns["PhoneBookID"];
                this.columnContactID = this.Columns["ContactID"];
                this.columnAreaCode = this.Columns["AreaCode"];
                this.columnCountryCode = this.Columns["CountryCode"];
                this.columnPhoneZone = this.Columns["PhoneZone"];
                this.columnPhoneNumber = this.Columns["PhoneNumber"];
                this.columnPhoneType = this.Columns["PhoneType"];
                this.columnPrimaryPhoneBook = this.Columns["PrimaryPhoneBook"];
            }
            
            private void InitClass() {
                this.columnPhoneBookID = new DataColumn("PhoneBookID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPhoneBookID);
                this.columnContactID = new DataColumn("ContactID", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnContactID);
                this.columnAreaCode = new DataColumn("AreaCode", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnAreaCode);
                this.columnCountryCode = new DataColumn("CountryCode", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnCountryCode);
                this.columnPhoneZone = new DataColumn("PhoneZone", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPhoneZone);
                this.columnPhoneNumber = new DataColumn("PhoneNumber", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPhoneNumber);
                this.columnPhoneType = new DataColumn("PhoneType", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPhoneType);
                this.columnPrimaryPhoneBook = new DataColumn("PrimaryPhoneBook", typeof(bool), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnPrimaryPhoneBook);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnPhoneBookID}, true));
                this.columnPhoneBookID.AllowDBNull = false;
                this.columnPhoneBookID.Unique = true;
                this.columnPhoneNumber.AllowDBNull = false;
                this.columnPhoneType.AllowDBNull = false;
            }
            
            public GEN_PhonebookRow NewGEN_PhonebookRow() {
                return ((GEN_PhonebookRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new GEN_PhonebookRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(GEN_PhonebookRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.GEN_PhonebookRowChanged != null)) {
                    this.GEN_PhonebookRowChanged(this, new GEN_PhonebookRowChangeEvent(((GEN_PhonebookRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.GEN_PhonebookRowChanging != null)) {
                    this.GEN_PhonebookRowChanging(this, new GEN_PhonebookRowChangeEvent(((GEN_PhonebookRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.GEN_PhonebookRowDeleted != null)) {
                    this.GEN_PhonebookRowDeleted(this, new GEN_PhonebookRowChangeEvent(((GEN_PhonebookRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.GEN_PhonebookRowDeleting != null)) {
                    this.GEN_PhonebookRowDeleting(this, new GEN_PhonebookRowChangeEvent(((GEN_PhonebookRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveGEN_PhonebookRow(GEN_PhonebookRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class GEN_PhonebookRow : DataRow {
            
            private GEN_PhonebookDataTable tableGEN_Phonebook;
            
            internal GEN_PhonebookRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableGEN_Phonebook = ((GEN_PhonebookDataTable)(this.Table));
            }
            
            public int PhoneBookID {
                get {
                    return ((int)(this[this.tableGEN_Phonebook.PhoneBookIDColumn]));
                }
                set {
                    this[this.tableGEN_Phonebook.PhoneBookIDColumn] = value;
                }
            }
            
            public int ContactID {
                get {
                    try {
                        return ((int)(this[this.tableGEN_Phonebook.ContactIDColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGEN_Phonebook.ContactIDColumn] = value;
                }
            }
            
            public string AreaCode {
                get {
                    try {
                        return ((string)(this[this.tableGEN_Phonebook.AreaCodeColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGEN_Phonebook.AreaCodeColumn] = value;
                }
            }
            
            public string CountryCode {
                get {
                    try {
                        return ((string)(this[this.tableGEN_Phonebook.CountryCodeColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGEN_Phonebook.CountryCodeColumn] = value;
                }
            }
            
            public string PhoneZone {
                get {
                    try {
                        return ((string)(this[this.tableGEN_Phonebook.PhoneZoneColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGEN_Phonebook.PhoneZoneColumn] = value;
                }
            }
            
            public string PhoneNumber {
                get {
                    return ((string)(this[this.tableGEN_Phonebook.PhoneNumberColumn]));
                }
                set {
                    this[this.tableGEN_Phonebook.PhoneNumberColumn] = value;
                }
            }
            
            public string PhoneType {
                get {
                    return ((string)(this[this.tableGEN_Phonebook.PhoneTypeColumn]));
                }
                set {
                    this[this.tableGEN_Phonebook.PhoneTypeColumn] = value;
                }
            }
            
            public bool PrimaryPhoneBook {
                get {
                    try {
                        return ((bool)(this[this.tableGEN_Phonebook.PrimaryPhoneBookColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableGEN_Phonebook.PrimaryPhoneBookColumn] = value;
                }
            }
            
            public bool IsContactIDNull() {
                return this.IsNull(this.tableGEN_Phonebook.ContactIDColumn);
            }
            
            public void SetContactIDNull() {
                this[this.tableGEN_Phonebook.ContactIDColumn] = System.Convert.DBNull;
            }
            
            public bool IsAreaCodeNull() {
                return this.IsNull(this.tableGEN_Phonebook.AreaCodeColumn);
            }
            
            public void SetAreaCodeNull() {
                this[this.tableGEN_Phonebook.AreaCodeColumn] = System.Convert.DBNull;
            }
            
            public bool IsCountryCodeNull() {
                return this.IsNull(this.tableGEN_Phonebook.CountryCodeColumn);
            }
            
            public void SetCountryCodeNull() {
                this[this.tableGEN_Phonebook.CountryCodeColumn] = System.Convert.DBNull;
            }
            
            public bool IsPhoneZoneNull() {
                return this.IsNull(this.tableGEN_Phonebook.PhoneZoneColumn);
            }
            
            public void SetPhoneZoneNull() {
                this[this.tableGEN_Phonebook.PhoneZoneColumn] = System.Convert.DBNull;
            }
            
            public bool IsPrimaryPhoneBookNull() {
                return this.IsNull(this.tableGEN_Phonebook.PrimaryPhoneBookColumn);
            }
            
            public void SetPrimaryPhoneBookNull() {
                this[this.tableGEN_Phonebook.PrimaryPhoneBookColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class GEN_PhonebookRowChangeEvent : EventArgs {
            
            private GEN_PhonebookRow eventRow;
            
            private DataRowAction eventAction;
            
            public GEN_PhonebookRowChangeEvent(GEN_PhonebookRow row, DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            public GEN_PhonebookRow Row {
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
