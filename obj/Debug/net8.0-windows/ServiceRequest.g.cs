﻿#pragma checksum "..\..\..\ServiceRequest.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "626FE65EEC48FA8B50CA08885EBC1CC14537C1E9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MunicipalAppProgPoe {
    
    
    /// <summary>
    /// ServiceRequest
    /// </summary>
    public partial class ServiceRequest : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\ServiceRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvRequest;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\ServiceRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearchId;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\ServiceRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtId;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\ServiceRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescription;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\ServiceRequest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtStatus;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MunicipalAppProgPoe;component/servicerequest.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ServiceRequest.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lvRequest = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.txtSearchId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            
            #line 24 "..\..\..\ServiceRequest.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnSearch_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtStatus = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 50 "..\..\..\ServiceRequest.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnAddRequest_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 55 "..\..\..\ServiceRequest.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnViewAll_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
