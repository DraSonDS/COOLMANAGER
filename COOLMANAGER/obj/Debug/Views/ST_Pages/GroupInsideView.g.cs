#pragma checksum "..\..\..\..\Views\ST_Pages\GroupInsideView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2C14302E150A4A287D94A3E5E91CEDB6105B6A2E1FEE981144520ED08E8963AD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using COOLMANAGER.Views.ST_Pages;
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


namespace COOLMANAGER.Views.ST_Pages {
    
    
    /// <summary>
    /// GroupInsideView
    /// </summary>
    public partial class GroupInsideView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\Views\ST_Pages\GroupInsideView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid myGrid;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Views\ST_Pages\GroupInsideView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackButton;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Views\ST_Pages\GroupInsideView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock GroupNameTextBlock;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Views\ST_Pages\GroupInsideView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl MyTabControl;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\..\Views\ST_Pages\GroupInsideView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem HomeworkList;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\..\Views\ST_Pages\GroupInsideView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel MyStackPanel;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\..\Views\ST_Pages\GroupInsideView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem DoneHomework;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\..\Views\ST_Pages\GroupInsideView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel DoneHomeworkStuckPanel;
        
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
            System.Uri resourceLocater = new System.Uri("/COOLMANAGER;component/views/st_pages/groupinsideview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\ST_Pages\GroupInsideView.xaml"
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
            
            #line 10 "..\..\..\..\Views\ST_Pages\GroupInsideView.xaml"
            ((COOLMANAGER.Views.ST_Pages.GroupInsideView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.myGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.BackButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\Views\ST_Pages\GroupInsideView.xaml"
            this.BackButton.Click += new System.Windows.RoutedEventHandler(this.BackButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.GroupNameTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.MyTabControl = ((System.Windows.Controls.TabControl)(target));
            return;
            case 6:
            this.HomeworkList = ((System.Windows.Controls.TabItem)(target));
            return;
            case 7:
            this.MyStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.DoneHomework = ((System.Windows.Controls.TabItem)(target));
            return;
            case 9:
            this.DoneHomeworkStuckPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

