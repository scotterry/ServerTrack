﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServerTrackClient.ServerTrackServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LoadTuple", Namespace="http://schemas.datacontract.org/2004/07/ServerTrack")]
    [System.SerializableAttribute()]
    public partial class LoadTuple : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double CPULoadField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double RAMLoadField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double CPULoad {
            get {
                return this.CPULoadField;
            }
            set {
                if ((this.CPULoadField.Equals(value) != true)) {
                    this.CPULoadField = value;
                    this.RaisePropertyChanged("CPULoad");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double RAMLoad {
            get {
                return this.RAMLoadField;
            }
            set {
                if ((this.RAMLoadField.Equals(value) != true)) {
                    this.RAMLoadField = value;
                    this.RaisePropertyChanged("RAMLoad");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServerTrackServiceReference.IServerTrackService")]
    public interface IServerTrackService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerTrackService/RecordServerLoad", ReplyAction="http://tempuri.org/IServerTrackService/RecordServerLoadResponse")]
        void RecordServerLoad(string serverName, double CPULoad, double RAMLoad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerTrackService/RecordServerLoad", ReplyAction="http://tempuri.org/IServerTrackService/RecordServerLoadResponse")]
        System.Threading.Tasks.Task RecordServerLoadAsync(string serverName, double CPULoad, double RAMLoad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerTrackService/DisplayServerLoad", ReplyAction="http://tempuri.org/IServerTrackService/DisplayServerLoadResponse")]
        System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<System.DateTime, ServerTrackClient.ServerTrackServiceReference.LoadTuple>> DisplayServerLoad(string serverName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerTrackService/DisplayServerLoad", ReplyAction="http://tempuri.org/IServerTrackService/DisplayServerLoadResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<System.DateTime, ServerTrackClient.ServerTrackServiceReference.LoadTuple>>> DisplayServerLoadAsync(string serverName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServerTrackServiceChannel : ServerTrackClient.ServerTrackServiceReference.IServerTrackService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServerTrackServiceClient : System.ServiceModel.ClientBase<ServerTrackClient.ServerTrackServiceReference.IServerTrackService>, ServerTrackClient.ServerTrackServiceReference.IServerTrackService {
        
        public ServerTrackServiceClient() {
        }
        
        public ServerTrackServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServerTrackServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServerTrackServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServerTrackServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void RecordServerLoad(string serverName, double CPULoad, double RAMLoad) {
            base.Channel.RecordServerLoad(serverName, CPULoad, RAMLoad);
        }
        
        public System.Threading.Tasks.Task RecordServerLoadAsync(string serverName, double CPULoad, double RAMLoad) {
            return base.Channel.RecordServerLoadAsync(serverName, CPULoad, RAMLoad);
        }
        
        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<System.DateTime, ServerTrackClient.ServerTrackServiceReference.LoadTuple>> DisplayServerLoad(string serverName) {
            return base.Channel.DisplayServerLoad(serverName);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<System.DateTime, ServerTrackClient.ServerTrackServiceReference.LoadTuple>>> DisplayServerLoadAsync(string serverName) {
            return base.Channel.DisplayServerLoadAsync(serverName);
        }
    }
}
