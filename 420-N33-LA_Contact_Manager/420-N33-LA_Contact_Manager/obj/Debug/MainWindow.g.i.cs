// Updated by XamlIntelliSenseFileGenerator 12/10/2020 4:26:59 PM
#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0C3ACFFBCFFAD252F703E8778BAC3FA65CEBCA2C777C202D07719C3656BED404"
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
using _420_N33_LA_Contact_Manager;


namespace _420_N33_LA_Contact_Manager
{


    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 38 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listContacts;

#line default
#line hidden


#line 42 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button add;

#line default
#line hidden


#line 43 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button edit;

#line default
#line hidden


#line 44 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button delete;

#line default
#line hidden


#line 46 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button import;

#line default
#line hidden


#line 47 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button export;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/420-N33-LA_Contact_Manager;component/mainwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\MainWindow.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.listContacts = ((System.Windows.Controls.ListBox)(target));
                    return;
                case 2:
                    this.add = ((System.Windows.Controls.Button)(target));

#line 42 "..\..\MainWindow.xaml"
                    this.add.Click += new System.Windows.RoutedEventHandler(this.add_Click);

#line default
#line hidden
                    return;
                case 3:
                    this.edit = ((System.Windows.Controls.Button)(target));

#line 43 "..\..\MainWindow.xaml"
                    this.edit.Click += new System.Windows.RoutedEventHandler(this.edit_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.delete = ((System.Windows.Controls.Button)(target));

#line 44 "..\..\MainWindow.xaml"
                    this.delete.Click += new System.Windows.RoutedEventHandler(this.delete_Click);

#line default
#line hidden
                    return;
                case 5:
                    this.import = ((System.Windows.Controls.Button)(target));

#line 46 "..\..\MainWindow.xaml"
                    this.import.Click += new System.Windows.RoutedEventHandler(this.import_Click);

#line default
#line hidden
                    return;
                case 6:
                    this.export = ((System.Windows.Controls.Button)(target));

#line 47 "..\..\MainWindow.xaml"
                    this.export.Click += new System.Windows.RoutedEventHandler(this.export_Click);

#line default
#line hidden
                    return;
                case 7:
                    this.edit_Copy1 = ((System.Windows.Controls.Button)(target));

#line 50 "..\..\MainWindow.xaml"
                    this.edit_Copy1.Click += new System.Windows.RoutedEventHandler(this.testaddrecord);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }
    }
}

