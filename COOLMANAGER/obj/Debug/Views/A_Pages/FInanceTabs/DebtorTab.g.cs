#pragma checksum "..\..\..\..\..\Views\A_Pages\FinanceTabs\DebtorTab.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6B556C17B1B9BA77AE9A0C7BA6A65A55A50869D81B7A36CB721F7FC17356987B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using COOLMANAGER.Views.A_Pages.FinanceTabs;
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


namespace COOLMANAGER.Views.A_Pages.FinanceTabs {
    
    
    /// <summary>
    /// DebtorTab
    /// </summary>
    public partial class DebtorTab : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 55 "..\..\..\..\..\Views\A_Pages\FinanceTabs\DebtorTab.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DebtorTB;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\..\Views\A_Pages\FinanceTabs\DebtorTab.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DebtorDG;
        
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
            System.Uri resourceLocater = new System.Uri("/COOLMANAGER;component/views/a_pages/financetabs/debtortab.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\A_Pages\FinanceTabs\DebtorTab.xaml"
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
            this.DebtorTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 58 "..\..\..\..\..\Views\A_Pages\FinanceTabs\DebtorTab.xaml"
            this.DebtorTB.GotFocus += new System.Windows.RoutedEventHandler(this.DebtorTB_GotFocus);
            
            #line default
            #line hidden
            
            #line 59 "..\..\..\..\..\Views\A_Pages\FinanceTabs\DebtorTab.xaml"
            this.DebtorTB.LostFocus += new System.Windows.RoutedEventHandler(this.DebtorTB_LostFocus);
            
            #line default
            #line hidden
            
            #line 60 "..\..\..\..\..\Views\A_Pages\FinanceTabs\DebtorTab.xaml"
            this.DebtorTB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.DebtorTB_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DebtorDG = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

