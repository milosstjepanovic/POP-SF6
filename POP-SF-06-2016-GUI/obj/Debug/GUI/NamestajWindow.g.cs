﻿#pragma checksum "..\..\..\GUI\NamestajWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "01C133556147A3548FCC60B6EB4DFEC2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using POP_SF_06_2016_GUI.GUI;
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


namespace POP_SF_06_2016_GUI.GUI {
    
    
    /// <summary>
    /// NamestajWindow
    /// </summary>
    public partial class NamestajWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\GUI\NamestajWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgNamestaj;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\GUI\NamestajWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDodajNamestaj;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\GUI\NamestajWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIzmeniNamestaj;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\GUI\NamestajWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnObrisiNamestaj;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\GUI\NamestajWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIzlaz;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\GUI\NamestajWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPretrazi;
        
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
            System.Uri resourceLocater = new System.Uri("/POP-SF-06-2016-GUI;component/gui/namestajwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GUI\NamestajWindow.xaml"
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
            this.dgNamestaj = ((System.Windows.Controls.DataGrid)(target));
            
            #line 11 "..\..\..\GUI\NamestajWindow.xaml"
            this.dgNamestaj.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.dgNamestaj_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnDodajNamestaj = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\GUI\NamestajWindow.xaml"
            this.btnDodajNamestaj.Click += new System.Windows.RoutedEventHandler(this.btnDodajNamestaj_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnIzmeniNamestaj = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\GUI\NamestajWindow.xaml"
            this.btnIzmeniNamestaj.Click += new System.Windows.RoutedEventHandler(this.btnIzmeniNamestaj_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnObrisiNamestaj = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\GUI\NamestajWindow.xaml"
            this.btnObrisiNamestaj.Click += new System.Windows.RoutedEventHandler(this.btnObrisiNamestaj_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnIzlaz = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\GUI\NamestajWindow.xaml"
            this.btnIzlaz.Click += new System.Windows.RoutedEventHandler(this.btnIzlaz_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.tbPretrazi = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

