﻿#pragma checksum "..\..\..\..\..\Views\A_Pages\FinanceTabs\FinanceTab.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C7458B2775D295689DFA157FC6FDB63CE80DA8D28FF38388CA60FEE7ECA7A74A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using COOLMANAGER.Views.A_Pages.FInanceTabs;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace COOLMANAGER.Views.A_Pages.FInanceTabs {
    
    
    /// <summary>
    /// FinanceTab
    /// </summary>
    public partial class FinanceTab : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 42 "..\..\..\..\..\Views\A_Pages\FinanceTabs\FinanceTab.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addFin;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\..\Views\A_Pages\FinanceTabs\FinanceTab.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PurseSearchTB;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\..\Views\A_Pages\FinanceTabs\FinanceTab.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PurseDG;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/COOLMANAGER;component/views/a_pages/financetabs/financetab.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\A_Pages\FinanceTabs\FinanceTab.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.addFin = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\..\Views\A_Pages\FinanceTabs\FinanceTab.xaml"
            this.addFin.Click += new System.Windows.RoutedEventHandler(this.addFin_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PurseSearchTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 56 "..\..\..\..\..\Views\A_Pages\FinanceTabs\FinanceTab.xaml"
            this.PurseSearchTB.GotFocus += new System.Windows.RoutedEventHandler(this.PurseSearchTB_GotFocus);
            
            #line default
            #line hidden
            
            #line 57 "..\..\..\..\..\Views\A_Pages\FinanceTabs\FinanceTab.xaml"
            this.PurseSearchTB.LostFocus += new System.Windows.RoutedEventHandler(this.PurseSearchTB_LostFocus);
            
            #line default
            #line hidden
            
            #line 58 "..\..\..\..\..\Views\A_Pages\FinanceTabs\FinanceTab.xaml"
            this.PurseSearchTB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.PurseSearchTB_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PurseDG = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 4:
            
            #line 75 "..\..\..\..\..\Views\A_Pages\FinanceTabs\FinanceTab.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Edit_Click);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 86 "..\..\..\..\..\Views\A_Pages\FinanceTabs\FinanceTab.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
