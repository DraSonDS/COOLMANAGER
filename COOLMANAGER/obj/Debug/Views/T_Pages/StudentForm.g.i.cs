﻿#pragma checksum "..\..\..\..\Views\T_Pages\StudentForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "11B87813C7A8EEF00523A6A27437D10817381ABAA9476E9AC2A7DFF685EDEA5B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using COOLMANAGER.Views;
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


namespace COOLMANAGER.Views {
    
    
    /// <summary>
    /// StudentForm
    /// </summary>
    public partial class StudentForm : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\..\Views\T_Pages\StudentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StudentAddB;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\Views\T_Pages\StudentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StudentSearchNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Views\T_Pages\StudentForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid StudentsDataGreed;
        
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
            System.Uri resourceLocater = new System.Uri("/COOLMANAGER;component/views/t_pages/studentform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\T_Pages\StudentForm.xaml"
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
            this.StudentAddB = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\Views\T_Pages\StudentForm.xaml"
            this.StudentAddB.Click += new System.Windows.RoutedEventHandler(this.StudentAddB_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.StudentSearchNameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 50 "..\..\..\..\Views\T_Pages\StudentForm.xaml"
            this.StudentSearchNameTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.StudentSearchNameTextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 51 "..\..\..\..\Views\T_Pages\StudentForm.xaml"
            this.StudentSearchNameTextBox.LostFocus += new System.Windows.RoutedEventHandler(this.StudentSearchNameTextBox_LostFocus);
            
            #line default
            #line hidden
            
            #line 55 "..\..\..\..\Views\T_Pages\StudentForm.xaml"
            this.StudentSearchNameTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.StudentSearchNameTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.StudentsDataGreed = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

