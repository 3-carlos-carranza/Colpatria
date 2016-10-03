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

namespace Data.Inalambria.InalambriaAuthService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ServiceKDCSoap", Namespace="soa.inalambria.com")]
    public partial class ServiceKDC : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ASGeneratePasswordOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetCryptoOperationCompleted;
        
        private System.Threading.SendOrPostCallback SetCryptoOperationCompleted;
        
        private System.Threading.SendOrPostCallback ASGenerateTicketOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ServiceKDC() {
            this.Url = global::Data.Inalambria.Properties.Settings.Default.Data_Inalambria_InalambriaAuthService_ServiceKDC;
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
        public event ASGeneratePasswordCompletedEventHandler ASGeneratePasswordCompleted;
        
        /// <remarks/>
        public event GetCryptoCompletedEventHandler GetCryptoCompleted;
        
        /// <remarks/>
        public event SetCryptoCompletedEventHandler SetCryptoCompleted;
        
        /// <remarks/>
        public event ASGenerateTicketCompletedEventHandler ASGenerateTicketCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("soa.inalambria.com/ASGeneratePassword", RequestNamespace="soa.inalambria.com", ResponseNamespace="soa.inalambria.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ASResponse ASGeneratePassword(string m_sUser, string m_sFlag) {
            object[] results = this.Invoke("ASGeneratePassword", new object[] {
                        m_sUser,
                        m_sFlag});
            return ((ASResponse)(results[0]));
        }
        
        /// <remarks/>
        public void ASGeneratePasswordAsync(string m_sUser, string m_sFlag) {
            this.ASGeneratePasswordAsync(m_sUser, m_sFlag, null);
        }
        
        /// <remarks/>
        public void ASGeneratePasswordAsync(string m_sUser, string m_sFlag, object userState) {
            if ((this.ASGeneratePasswordOperationCompleted == null)) {
                this.ASGeneratePasswordOperationCompleted = new System.Threading.SendOrPostCallback(this.OnASGeneratePasswordOperationCompleted);
            }
            this.InvokeAsync("ASGeneratePassword", new object[] {
                        m_sUser,
                        m_sFlag}, this.ASGeneratePasswordOperationCompleted, userState);
        }
        
        private void OnASGeneratePasswordOperationCompleted(object arg) {
            if ((this.ASGeneratePasswordCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ASGeneratePasswordCompleted(this, new ASGeneratePasswordCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("soa.inalambria.com/GetCrypto", RequestNamespace="soa.inalambria.com", ResponseNamespace="soa.inalambria.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetCrypto(string Value, string Password) {
            object[] results = this.Invoke("GetCrypto", new object[] {
                        Value,
                        Password});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetCryptoAsync(string Value, string Password) {
            this.GetCryptoAsync(Value, Password, null);
        }
        
        /// <remarks/>
        public void GetCryptoAsync(string Value, string Password, object userState) {
            if ((this.GetCryptoOperationCompleted == null)) {
                this.GetCryptoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCryptoOperationCompleted);
            }
            this.InvokeAsync("GetCrypto", new object[] {
                        Value,
                        Password}, this.GetCryptoOperationCompleted, userState);
        }
        
        private void OnGetCryptoOperationCompleted(object arg) {
            if ((this.GetCryptoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCryptoCompleted(this, new GetCryptoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("soa.inalambria.com/SetCrypto", RequestNamespace="soa.inalambria.com", ResponseNamespace="soa.inalambria.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SetCrypto(string Value, string Password) {
            object[] results = this.Invoke("SetCrypto", new object[] {
                        Value,
                        Password});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SetCryptoAsync(string Value, string Password) {
            this.SetCryptoAsync(Value, Password, null);
        }
        
        /// <remarks/>
        public void SetCryptoAsync(string Value, string Password, object userState) {
            if ((this.SetCryptoOperationCompleted == null)) {
                this.SetCryptoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSetCryptoOperationCompleted);
            }
            this.InvokeAsync("SetCrypto", new object[] {
                        Value,
                        Password}, this.SetCryptoOperationCompleted, userState);
        }
        
        private void OnSetCryptoOperationCompleted(object arg) {
            if ((this.SetCryptoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SetCryptoCompleted(this, new SetCryptoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("soa.inalambria.com/ASGenerateTicket", RequestNamespace="soa.inalambria.com", ResponseNamespace="soa.inalambria.com", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ASGenerateTicket(string TicketTGS) {
            object[] results = this.Invoke("ASGenerateTicket", new object[] {
                        TicketTGS});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ASGenerateTicketAsync(string TicketTGS) {
            this.ASGenerateTicketAsync(TicketTGS, null);
        }
        
        /// <remarks/>
        public void ASGenerateTicketAsync(string TicketTGS, object userState) {
            if ((this.ASGenerateTicketOperationCompleted == null)) {
                this.ASGenerateTicketOperationCompleted = new System.Threading.SendOrPostCallback(this.OnASGenerateTicketOperationCompleted);
            }
            this.InvokeAsync("ASGenerateTicket", new object[] {
                        TicketTGS}, this.ASGenerateTicketOperationCompleted, userState);
        }
        
        private void OnASGenerateTicketOperationCompleted(object arg) {
            if ((this.ASGenerateTicketCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ASGenerateTicketCompleted(this, new ASGenerateTicketCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
            System.Uri wsUri = new System.Uri(url);
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
    public partial class ASResponse {
        
        private string ticketField;
        
        private string passwordField;
        
        private string flagField;
        
        private bool stateField;
        
        /// <remarks/>
        public string Ticket {
            get {
                return this.ticketField;
            }
            set {
                this.ticketField = value;
            }
        }
        
        /// <remarks/>
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
            }
        }
        
        /// <remarks/>
        public string Flag {
            get {
                return this.flagField;
            }
            set {
                this.flagField = value;
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void ASGeneratePasswordCompletedEventHandler(object sender, ASGeneratePasswordCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ASGeneratePasswordCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ASGeneratePasswordCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ASResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ASResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void GetCryptoCompletedEventHandler(object sender, GetCryptoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCryptoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCryptoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void SetCryptoCompletedEventHandler(object sender, SetCryptoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SetCryptoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SetCryptoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void ASGenerateTicketCompletedEventHandler(object sender, ASGenerateTicketCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ASGenerateTicketCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ASGenerateTicketCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591