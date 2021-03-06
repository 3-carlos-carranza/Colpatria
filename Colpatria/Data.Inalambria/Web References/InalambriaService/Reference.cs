﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace Data.Inalambria.InalambriaService
{


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ServiceSendSoap", Namespace="soa.inalambria.com")]
    public partial class ServiceSend : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SendOperationCompleted;
        
        private System.Threading.SendOrPostCallback SendWithHashOperationCompleted;
        
        private System.Threading.SendOrPostCallback SendWithUserOperationCompleted;
        
        private System.Threading.SendOrPostCallback CancelTicketOperationCompleted;
        
        private System.Threading.SendOrPostCallback CancelTicketWithHashOperationCompleted;
        
        private System.Threading.SendOrPostCallback CancelTicketWithUserOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ServiceSend() {
            this.Url = global::Data.Inalambria.Properties.Settings.Default.Data_Inalambria_InalambriaService_ServiceSend;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event SendCompletedEventHandler SendCompleted;
        
        /// <remarks/>
        public event SendWithHashCompletedEventHandler SendWithHashCompleted;
        
        /// <remarks/>
        public event SendWithUserCompletedEventHandler SendWithUserCompleted;
        
        /// <remarks/>
        public event CancelTicketCompletedEventHandler CancelTicketCompleted;
        
        /// <remarks/>
        public event CancelTicketWithHashCompletedEventHandler CancelTicketWithHashCompleted;
        
        /// <remarks/>
        public event CancelTicketWithUserCompletedEventHandler CancelTicketWithUserCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("soa.inalambria.com/Send", RequestNamespace="soa.inalambria.com", ResponseNamespace="soa.inalambria.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Transaction Send(string TicketTGS, string DeviceNumber, string Message, string DateMessage, string Provider) {
            var results = this.Invoke("Send", new object[] {
                        TicketTGS,
                        DeviceNumber,
                        Message,
                        DateMessage,
                        Provider});
            return ((Transaction)(results[0]));
        }
        
        /// <remarks/>
        public void SendAsync(string TicketTGS, string DeviceNumber, string Message, string DateMessage, string Provider) {
            this.SendAsync(TicketTGS, DeviceNumber, Message, DateMessage, Provider, null);
        }
        
        /// <remarks/>
        public void SendAsync(string TicketTGS, string DeviceNumber, string Message, string DateMessage, string Provider, object userState) {
            if ((this.SendOperationCompleted == null)) {
                this.SendOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendOperationCompleted);
            }
            this.InvokeAsync("Send", new object[] {
                        TicketTGS,
                        DeviceNumber,
                        Message,
                        DateMessage,
                        Provider}, this.SendOperationCompleted, userState);
        }
        
        private void OnSendOperationCompleted(object arg) {
            if ((this.SendCompleted != null)) {
                var invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendCompleted(this, new SendCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("soa.inalambria.com/SendWithHash", RequestNamespace="soa.inalambria.com", ResponseNamespace="soa.inalambria.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Transaction SendWithHash(string Hash, string User, string DeviceNumber, string Message, string DateMessage, string Provider) {
            var results = this.Invoke("SendWithHash", new object[] {
                        Hash,
                        User,
                        DeviceNumber,
                        Message,
                        DateMessage,
                        Provider});
            return ((Transaction)(results[0]));
        }
        
        /// <remarks/>
        public void SendWithHashAsync(string Hash, string User, string DeviceNumber, string Message, string DateMessage, string Provider) {
            this.SendWithHashAsync(Hash, User, DeviceNumber, Message, DateMessage, Provider, null);
        }
        
        /// <remarks/>
        public void SendWithHashAsync(string Hash, string User, string DeviceNumber, string Message, string DateMessage, string Provider, object userState) {
            if ((this.SendWithHashOperationCompleted == null)) {
                this.SendWithHashOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendWithHashOperationCompleted);
            }
            this.InvokeAsync("SendWithHash", new object[] {
                        Hash,
                        User,
                        DeviceNumber,
                        Message,
                        DateMessage,
                        Provider}, this.SendWithHashOperationCompleted, userState);
        }
        
        private void OnSendWithHashOperationCompleted(object arg) {
            if ((this.SendWithHashCompleted != null)) {
                var invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendWithHashCompleted(this, new SendWithHashCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("soa.inalambria.com/SendWithUser", RequestNamespace="soa.inalambria.com", ResponseNamespace="soa.inalambria.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Transaction SendWithUser(string User, string Password, string DeviceNumber, string Message, string DateMessage, string Provider) {
            var results = this.Invoke("SendWithUser", new object[] {
                        User,
                        Password,
                        DeviceNumber,
                        Message,
                        DateMessage,
                        Provider});
            return ((Transaction)(results[0]));
        }
        
        /// <remarks/>
        public void SendWithUserAsync(string User, string Password, string DeviceNumber, string Message, string DateMessage, string Provider) {
            this.SendWithUserAsync(User, Password, DeviceNumber, Message, DateMessage, Provider, null);
        }
        
        /// <remarks/>
        public void SendWithUserAsync(string User, string Password, string DeviceNumber, string Message, string DateMessage, string Provider, object userState) {
            if ((this.SendWithUserOperationCompleted == null)) {
                this.SendWithUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendWithUserOperationCompleted);
            }
            this.InvokeAsync("SendWithUser", new object[] {
                        User,
                        Password,
                        DeviceNumber,
                        Message,
                        DateMessage,
                        Provider}, this.SendWithUserOperationCompleted, userState);
        }
        
        private void OnSendWithUserOperationCompleted(object arg) {
            if ((this.SendWithUserCompleted != null)) {
                var invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendWithUserCompleted(this, new SendWithUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("soa.inalambria.com/CancelTicket", RequestNamespace="soa.inalambria.com", ResponseNamespace="soa.inalambria.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Transaction CancelTicket(string TicketTGS, string TicketSMS) {
            var results = this.Invoke("CancelTicket", new object[] {
                        TicketTGS,
                        TicketSMS});
            return ((Transaction)(results[0]));
        }
        
        /// <remarks/>
        public void CancelTicketAsync(string TicketTGS, string TicketSMS) {
            this.CancelTicketAsync(TicketTGS, TicketSMS, null);
        }
        
        /// <remarks/>
        public void CancelTicketAsync(string TicketTGS, string TicketSMS, object userState) {
            if ((this.CancelTicketOperationCompleted == null)) {
                this.CancelTicketOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCancelTicketOperationCompleted);
            }
            this.InvokeAsync("CancelTicket", new object[] {
                        TicketTGS,
                        TicketSMS}, this.CancelTicketOperationCompleted, userState);
        }
        
        private void OnCancelTicketOperationCompleted(object arg) {
            if ((this.CancelTicketCompleted != null)) {
                var invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CancelTicketCompleted(this, new CancelTicketCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("soa.inalambria.com/CancelTicketWithHash", RequestNamespace="soa.inalambria.com", ResponseNamespace="soa.inalambria.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Transaction CancelTicketWithHash(string Hash, string User, string TicketSMS) {
            var results = this.Invoke("CancelTicketWithHash", new object[] {
                        Hash,
                        User,
                        TicketSMS});
            return ((Transaction)(results[0]));
        }
        
        /// <remarks/>
        public void CancelTicketWithHashAsync(string Hash, string User, string TicketSMS) {
            this.CancelTicketWithHashAsync(Hash, User, TicketSMS, null);
        }
        
        /// <remarks/>
        public void CancelTicketWithHashAsync(string Hash, string User, string TicketSMS, object userState) {
            if ((this.CancelTicketWithHashOperationCompleted == null)) {
                this.CancelTicketWithHashOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCancelTicketWithHashOperationCompleted);
            }
            this.InvokeAsync("CancelTicketWithHash", new object[] {
                        Hash,
                        User,
                        TicketSMS}, this.CancelTicketWithHashOperationCompleted, userState);
        }
        
        private void OnCancelTicketWithHashOperationCompleted(object arg) {
            if ((this.CancelTicketWithHashCompleted != null)) {
                var invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CancelTicketWithHashCompleted(this, new CancelTicketWithHashCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("soa.inalambria.com/CancelTicketWithUser", RequestNamespace="soa.inalambria.com", ResponseNamespace="soa.inalambria.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Transaction CancelTicketWithUser(string User, string Password, string TicketSMS) {
            var results = this.Invoke("CancelTicketWithUser", new object[] {
                        User,
                        Password,
                        TicketSMS});
            return ((Transaction)(results[0]));
        }
        
        /// <remarks/>
        public void CancelTicketWithUserAsync(string User, string Password, string TicketSMS) {
            this.CancelTicketWithUserAsync(User, Password, TicketSMS, null);
        }
        
        /// <remarks/>
        public void CancelTicketWithUserAsync(string User, string Password, string TicketSMS, object userState) {
            if ((this.CancelTicketWithUserOperationCompleted == null)) {
                this.CancelTicketWithUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCancelTicketWithUserOperationCompleted);
            }
            this.InvokeAsync("CancelTicketWithUser", new object[] {
                        User,
                        Password,
                        TicketSMS}, this.CancelTicketWithUserOperationCompleted, userState);
        }
        
        private void OnCancelTicketWithUserOperationCompleted(object arg) {
            if ((this.CancelTicketWithUserCompleted != null)) {
                var invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CancelTicketWithUserCompleted(this, new CancelTicketWithUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            var wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="soa.inalambria.com")]
    public partial class Transaction {
        
        private bool statusField;
        
        private string ticketKdcField;
        
        private string ticketTransactionField;
        
        private string detailField;
        
        private System.DateTime dateArrivedField;
        
        private System.DateTime dateSendField;
        
        private ResponseValidation validationField;
        
        /// <remarks/>
        public bool Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        public string TicketKdc {
            get {
                return this.ticketKdcField;
            }
            set {
                this.ticketKdcField = value;
            }
        }
        
        /// <remarks/>
        public string TicketTransaction {
            get {
                return this.ticketTransactionField;
            }
            set {
                this.ticketTransactionField = value;
            }
        }
        
        /// <remarks/>
        public string Detail {
            get {
                return this.detailField;
            }
            set {
                this.detailField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime DateArrived {
            get {
                return this.dateArrivedField;
            }
            set {
                this.dateArrivedField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime DateSend {
            get {
                return this.dateSendField;
            }
            set {
                this.dateSendField = value;
            }
        }
        
        /// <remarks/>
        public ResponseValidation Validation {
            get {
                return this.validationField;
            }
            set {
                this.validationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="soa.inalambria.com")]
    public partial class ResponseValidation {
        
        private string errorMessageField;
        
        private string[] messageField;
        
        private ValidationPhoneResult[] mobileField;
        
        private int numErrorField;
        
        private int partField;
        
        private bool stateField;
        
        /// <remarks/>
        public string ErrorMessage {
            get {
                return this.errorMessageField;
            }
            set {
                this.errorMessageField = value;
            }
        }
        
        /// <remarks/>
        public string[] Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
        
        /// <remarks/>
        public ValidationPhoneResult[] Mobile {
            get {
                return this.mobileField;
            }
            set {
                this.mobileField = value;
            }
        }
        
        /// <remarks/>
        public int NumError {
            get {
                return this.numErrorField;
            }
            set {
                this.numErrorField = value;
            }
        }
        
        /// <remarks/>
        public int Part {
            get {
                return this.partField;
            }
            set {
                this.partField = value;
            }
        }
        
        /// <remarks/>
        public bool State {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="soa.inalambria.com")]
    public partial class ValidationPhoneResult {
        
        private int codeBillingField;
        
        private string codeMessageField;
        
        private string messageField;
        
        private string messageBillingField;
        
        private double operatorField;
        
        private int partField;
        
        private string phoneField;
        
        /// <remarks/>
        public int CodeBilling {
            get {
                return this.codeBillingField;
            }
            set {
                this.codeBillingField = value;
            }
        }
        
        /// <remarks/>
        public string CodeMessage {
            get {
                return this.codeMessageField;
            }
            set {
                this.codeMessageField = value;
            }
        }
        
        /// <remarks/>
        public string Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
        
        /// <remarks/>
        public string MessageBilling {
            get {
                return this.messageBillingField;
            }
            set {
                this.messageBillingField = value;
            }
        }
        
        /// <remarks/>
        public double Operator {
            get {
                return this.operatorField;
            }
            set {
                this.operatorField = value;
            }
        }
        
        /// <remarks/>
        public int Part {
            get {
                return this.partField;
            }
            set {
                this.partField = value;
            }
        }
        
        /// <remarks/>
        public string Phone {
            get {
                return this.phoneField;
            }
            set {
                this.phoneField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void SendCompletedEventHandler(object sender, SendCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Transaction Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Transaction)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void SendWithHashCompletedEventHandler(object sender, SendWithHashCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendWithHashCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendWithHashCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Transaction Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Transaction)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void SendWithUserCompletedEventHandler(object sender, SendWithUserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendWithUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendWithUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Transaction Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Transaction)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void CancelTicketCompletedEventHandler(object sender, CancelTicketCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CancelTicketCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CancelTicketCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Transaction Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Transaction)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void CancelTicketWithHashCompletedEventHandler(object sender, CancelTicketWithHashCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CancelTicketWithHashCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CancelTicketWithHashCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Transaction Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Transaction)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void CancelTicketWithUserCompletedEventHandler(object sender, CancelTicketWithUserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CancelTicketWithUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CancelTicketWithUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Transaction Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Transaction)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591