﻿#pragma checksum "..\..\AccountantWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "850627B54383BAE058D15D68155CCEC2B01F9098C5DF528A460914D9A4E8B8E6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Desktop_App;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Desktop_App {
    
    
    /// <summary>
    /// AccountantWindow
    /// </summary>
    public partial class AccountantWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\AccountantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nazad;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\AccountantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbUserLastname;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\AccountantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbUserName;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\AccountantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgChet;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\AccountantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpStart;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\AccountantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpEnd;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\AccountantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btPdfSave;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\AccountantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCsvSave;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\AccountantWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btOp;
        
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
            System.Uri resourceLocater = new System.Uri("/Desktop App;component/accountantwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AccountantWindow.xaml"
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
            
            #line 8 "..\..\AccountantWindow.xaml"
            ((Desktop_App.AccountantWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.nazad = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\AccountantWindow.xaml"
            this.nazad.Click += new System.Windows.RoutedEventHandler(this.nazad_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lbUserLastname = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lbUserName = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.dgChet = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.dpStart = ((System.Windows.Controls.DatePicker)(target));
            
            #line 15 "..\..\AccountantWindow.xaml"
            this.dpStart.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.dpStart_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dpEnd = ((System.Windows.Controls.DatePicker)(target));
            
            #line 16 "..\..\AccountantWindow.xaml"
            this.dpEnd.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.dpStart_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btPdfSave = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\AccountantWindow.xaml"
            this.btPdfSave.Click += new System.Windows.RoutedEventHandler(this.btPdfSave_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btCsvSave = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\AccountantWindow.xaml"
            this.btCsvSave.Click += new System.Windows.RoutedEventHandler(this.btCsvSave_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btOp = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\AccountantWindow.xaml"
            this.btOp.Click += new System.Windows.RoutedEventHandler(this.btOp_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

