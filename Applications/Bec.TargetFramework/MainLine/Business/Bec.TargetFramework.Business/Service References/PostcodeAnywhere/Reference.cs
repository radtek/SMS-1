﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bec.TargetFramework.Business.PostcodeAnywhere {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="PostcodeAnywhere_Interactive_RetrieveByParts_v1_00_ArrayOfResults", Namespace="http://services.postcodeanywhere.co.uk/", ItemName="PostcodeAnywhere_Interactive_RetrieveByParts_v1_00_Results")]
    [System.SerializableAttribute()]
    public class PostcodeAnywhere_Interactive_RetrieveByParts_v1_00_ArrayOfResults : System.Collections.Generic.List<Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00_Results> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PostcodeAnywhere_Interactive_RetrieveByParts_v1_00_Results", Namespace="http://services.postcodeanywhere.co.uk/")]
    [System.SerializableAttribute()]
    public partial class PostcodeAnywhere_Interactive_RetrieveByParts_v1_00_Results : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int UdprnField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CompanyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DepartmentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Line1Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Line2Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Line3Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Line4Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Line5Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PostTownField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CountyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PostcodeField;
        
        private int MailsortField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BarcodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DeliveryPointSuffixField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SubBuildingField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BuildingNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BuildingNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PrimaryStreetField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SecondaryStreetField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DoubleDependentLocalityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DependentLocalityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PoBoxField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PrimaryStreetNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PrimaryStreetTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SecondaryStreetNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SecondaryStreetTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CountryNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Udprn {
            get {
                return this.UdprnField;
            }
            set {
                if ((this.UdprnField.Equals(value) != true)) {
                    this.UdprnField = value;
                    this.RaisePropertyChanged("Udprn");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Company {
            get {
                return this.CompanyField;
            }
            set {
                if ((object.ReferenceEquals(this.CompanyField, value) != true)) {
                    this.CompanyField = value;
                    this.RaisePropertyChanged("Company");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Department {
            get {
                return this.DepartmentField;
            }
            set {
                if ((object.ReferenceEquals(this.DepartmentField, value) != true)) {
                    this.DepartmentField = value;
                    this.RaisePropertyChanged("Department");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string Line1 {
            get {
                return this.Line1Field;
            }
            set {
                if ((object.ReferenceEquals(this.Line1Field, value) != true)) {
                    this.Line1Field = value;
                    this.RaisePropertyChanged("Line1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string Line2 {
            get {
                return this.Line2Field;
            }
            set {
                if ((object.ReferenceEquals(this.Line2Field, value) != true)) {
                    this.Line2Field = value;
                    this.RaisePropertyChanged("Line2");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string Line3 {
            get {
                return this.Line3Field;
            }
            set {
                if ((object.ReferenceEquals(this.Line3Field, value) != true)) {
                    this.Line3Field = value;
                    this.RaisePropertyChanged("Line3");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string Line4 {
            get {
                return this.Line4Field;
            }
            set {
                if ((object.ReferenceEquals(this.Line4Field, value) != true)) {
                    this.Line4Field = value;
                    this.RaisePropertyChanged("Line4");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=7)]
        public string Line5 {
            get {
                return this.Line5Field;
            }
            set {
                if ((object.ReferenceEquals(this.Line5Field, value) != true)) {
                    this.Line5Field = value;
                    this.RaisePropertyChanged("Line5");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=8)]
        public string PostTown {
            get {
                return this.PostTownField;
            }
            set {
                if ((object.ReferenceEquals(this.PostTownField, value) != true)) {
                    this.PostTownField = value;
                    this.RaisePropertyChanged("PostTown");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=9)]
        public string County {
            get {
                return this.CountyField;
            }
            set {
                if ((object.ReferenceEquals(this.CountyField, value) != true)) {
                    this.CountyField = value;
                    this.RaisePropertyChanged("County");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=10)]
        public string Postcode {
            get {
                return this.PostcodeField;
            }
            set {
                if ((object.ReferenceEquals(this.PostcodeField, value) != true)) {
                    this.PostcodeField = value;
                    this.RaisePropertyChanged("Postcode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=11)]
        public int Mailsort {
            get {
                return this.MailsortField;
            }
            set {
                if ((this.MailsortField.Equals(value) != true)) {
                    this.MailsortField = value;
                    this.RaisePropertyChanged("Mailsort");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=12)]
        public string Barcode {
            get {
                return this.BarcodeField;
            }
            set {
                if ((object.ReferenceEquals(this.BarcodeField, value) != true)) {
                    this.BarcodeField = value;
                    this.RaisePropertyChanged("Barcode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=13)]
        public string Type {
            get {
                return this.TypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeField, value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=14)]
        public string DeliveryPointSuffix {
            get {
                return this.DeliveryPointSuffixField;
            }
            set {
                if ((object.ReferenceEquals(this.DeliveryPointSuffixField, value) != true)) {
                    this.DeliveryPointSuffixField = value;
                    this.RaisePropertyChanged("DeliveryPointSuffix");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=15)]
        public string SubBuilding {
            get {
                return this.SubBuildingField;
            }
            set {
                if ((object.ReferenceEquals(this.SubBuildingField, value) != true)) {
                    this.SubBuildingField = value;
                    this.RaisePropertyChanged("SubBuilding");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=16)]
        public string BuildingName {
            get {
                return this.BuildingNameField;
            }
            set {
                if ((object.ReferenceEquals(this.BuildingNameField, value) != true)) {
                    this.BuildingNameField = value;
                    this.RaisePropertyChanged("BuildingName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=17)]
        public string BuildingNumber {
            get {
                return this.BuildingNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.BuildingNumberField, value) != true)) {
                    this.BuildingNumberField = value;
                    this.RaisePropertyChanged("BuildingNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=18)]
        public string PrimaryStreet {
            get {
                return this.PrimaryStreetField;
            }
            set {
                if ((object.ReferenceEquals(this.PrimaryStreetField, value) != true)) {
                    this.PrimaryStreetField = value;
                    this.RaisePropertyChanged("PrimaryStreet");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=19)]
        public string SecondaryStreet {
            get {
                return this.SecondaryStreetField;
            }
            set {
                if ((object.ReferenceEquals(this.SecondaryStreetField, value) != true)) {
                    this.SecondaryStreetField = value;
                    this.RaisePropertyChanged("SecondaryStreet");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=20)]
        public string DoubleDependentLocality {
            get {
                return this.DoubleDependentLocalityField;
            }
            set {
                if ((object.ReferenceEquals(this.DoubleDependentLocalityField, value) != true)) {
                    this.DoubleDependentLocalityField = value;
                    this.RaisePropertyChanged("DoubleDependentLocality");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=21)]
        public string DependentLocality {
            get {
                return this.DependentLocalityField;
            }
            set {
                if ((object.ReferenceEquals(this.DependentLocalityField, value) != true)) {
                    this.DependentLocalityField = value;
                    this.RaisePropertyChanged("DependentLocality");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=22)]
        public string PoBox {
            get {
                return this.PoBoxField;
            }
            set {
                if ((object.ReferenceEquals(this.PoBoxField, value) != true)) {
                    this.PoBoxField = value;
                    this.RaisePropertyChanged("PoBox");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=23)]
        public string PrimaryStreetName {
            get {
                return this.PrimaryStreetNameField;
            }
            set {
                if ((object.ReferenceEquals(this.PrimaryStreetNameField, value) != true)) {
                    this.PrimaryStreetNameField = value;
                    this.RaisePropertyChanged("PrimaryStreetName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=24)]
        public string PrimaryStreetType {
            get {
                return this.PrimaryStreetTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.PrimaryStreetTypeField, value) != true)) {
                    this.PrimaryStreetTypeField = value;
                    this.RaisePropertyChanged("PrimaryStreetType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=25)]
        public string SecondaryStreetName {
            get {
                return this.SecondaryStreetNameField;
            }
            set {
                if ((object.ReferenceEquals(this.SecondaryStreetNameField, value) != true)) {
                    this.SecondaryStreetNameField = value;
                    this.RaisePropertyChanged("SecondaryStreetName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=26)]
        public string SecondaryStreetType {
            get {
                return this.SecondaryStreetTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.SecondaryStreetTypeField, value) != true)) {
                    this.SecondaryStreetTypeField = value;
                    this.RaisePropertyChanged("SecondaryStreetType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=27)]
        public string CountryName {
            get {
                return this.CountryNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CountryNameField, value) != true)) {
                    this.CountryNameField = value;
                    this.RaisePropertyChanged("CountryName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://services.postcodeanywhere.co.uk/", ConfigurationName="PostcodeAnywhere.PostcodeAnywhere_Soap")]
    public interface PostcodeAnywhere_Soap {
        
        // CODEGEN: Generating message contract since the wrapper name (PostcodeAnywhere_Interactive_RetrieveByParts_v1_00_Response) of message PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Response does not match the default value (PostcodeAnywhere_Interactive_RetrieveByParts_v1_00)
        [System.ServiceModel.OperationContractAttribute(Action="http://services.postcodeanywhere.co.uk/PostcodeAnywhere_Interactive_RetrieveByPar" +
            "ts_v1_00", ReplyAction="*")]
        Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Response PostcodeAnywhere_Interactive_RetrieveByParts_v1_00(Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Request request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.postcodeanywhere.co.uk/PostcodeAnywhere_Interactive_RetrieveByPar" +
            "ts_v1_00", ReplyAction="*")]
        System.Threading.Tasks.Task<Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Response> PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Async(Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Request request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PostcodeAnywhere_Interactive_RetrieveByParts_v1_00", WrapperNamespace="http://services.postcodeanywhere.co.uk/", IsWrapped=true)]
    public partial class PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Request {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.postcodeanywhere.co.uk/", Order=0)]
        public string Key;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.postcodeanywhere.co.uk/", Order=1)]
        public string Organisation;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.postcodeanywhere.co.uk/", Order=2)]
        public string Building;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.postcodeanywhere.co.uk/", Order=3)]
        public string Street;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.postcodeanywhere.co.uk/", Order=4)]
        public string Locality;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.postcodeanywhere.co.uk/", Order=5)]
        public string Postcode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.postcodeanywhere.co.uk/", Order=6)]
        public string UserName;
        
        public PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Request() {
        }
        
        public PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Request(string Key, string Organisation, string Building, string Street, string Locality, string Postcode, string UserName) {
            this.Key = Key;
            this.Organisation = Organisation;
            this.Building = Building;
            this.Street = Street;
            this.Locality = Locality;
            this.Postcode = Postcode;
            this.UserName = UserName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PostcodeAnywhere_Interactive_RetrieveByParts_v1_00_Response", WrapperNamespace="http://services.postcodeanywhere.co.uk/", IsWrapped=true)]
    public partial class PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Response {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://services.postcodeanywhere.co.uk/", Order=0)]
        public Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00_ArrayOfResults PostcodeAnywhere_Interactive_RetrieveByParts_v1_00_Result;
        
        public PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Response() {
        }
        
        public PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Response(Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00_ArrayOfResults PostcodeAnywhere_Interactive_RetrieveByParts_v1_00_Result) {
            this.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00_Result = PostcodeAnywhere_Interactive_RetrieveByParts_v1_00_Result;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface PostcodeAnywhere_SoapChannel : Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PostcodeAnywhere_SoapClient : System.ServiceModel.ClientBase<Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Soap>, Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Soap {
        
        public PostcodeAnywhere_SoapClient() {
        }
        
        public PostcodeAnywhere_SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PostcodeAnywhere_SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PostcodeAnywhere_SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PostcodeAnywhere_SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Response Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Soap.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00(Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Request request) {
            return base.Channel.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00(request);
        }
        
        public Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00_ArrayOfResults PostcodeAnywhere_Interactive_RetrieveByParts_v1_00(string Key, string Organisation, string Building, string Street, string Locality, string Postcode, string UserName) {
            Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Request inValue = new Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Request();
            inValue.Key = Key;
            inValue.Organisation = Organisation;
            inValue.Building = Building;
            inValue.Street = Street;
            inValue.Locality = Locality;
            inValue.Postcode = Postcode;
            inValue.UserName = UserName;
            Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Response retVal = ((Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Soap)(this)).PostcodeAnywhere_Interactive_RetrieveByParts_v1_00(inValue);
            return retVal.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00_Result;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Response> Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Soap.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Async(Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Request request) {
            return base.Channel.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Async(request);
        }
        
        public System.Threading.Tasks.Task<Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Response> PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Async(string Key, string Organisation, string Building, string Street, string Locality, string Postcode, string UserName) {
            Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Request inValue = new Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Request();
            inValue.Key = Key;
            inValue.Organisation = Organisation;
            inValue.Building = Building;
            inValue.Street = Street;
            inValue.Locality = Locality;
            inValue.Postcode = Postcode;
            inValue.UserName = UserName;
            return ((Bec.TargetFramework.Business.PostcodeAnywhere.PostcodeAnywhere_Soap)(this)).PostcodeAnywhere_Interactive_RetrieveByParts_v1_00Async(inValue);
        }
    }
}
