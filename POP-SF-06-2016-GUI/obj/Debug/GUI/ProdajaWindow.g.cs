﻿#pragma checksum "..\..\..\GUI\ProdajaWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "428980F5D25F5B35A2ED6BE7A275BB1F"
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
    /// ProdajaWindow
    /// </summary>
    public partial class ProdajaWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\GUI\ProdajaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgProdajaNamestaja;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\GUI\ProdajaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDodajProdaju;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\GUI\ProdajaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnObrisiProdaju;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\GUI\ProdajaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIzlaz;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\GUI\ProdajaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPretrazi;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\GUI\ProdajaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbSortiranje;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\GUI\ProdajaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbPretraga;
        
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
            System.Uri resourceLocater = new System.Uri("/POP-SF-06-2016-GUI;component/gui/prodajawindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GUI\ProdajaWindow.xaml"
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
            this.dgProdajaNamestaja = ((System.Windows.Controls.DataGrid)(target));
            
            #line 35 "..\..\..\GUI\ProdajaWindow.xaml"
            this.dgProdajaNamestaja.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.dgProdaja_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnDodajProdaju = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\GUI\ProdajaWindow.xaml"
            this.btnDodajProdaju.Click += new System.Windows.RoutedEventHandler(this.btnDodajProdaju_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnObrisiProdaju = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\GUI\ProdajaWindow.xaml"
            this.btnObrisiProdaju.Click += new System.Windows.RoutedEventHandler(this.btnObrisiProdaju_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnIzlaz = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\GUI\ProdajaWindow.xaml"
            this.btnIzlaz.Click += new System.Windows.RoutedEventHandler(this.btnIzlaz_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbPretrazi = ((System.Windows.Controls.TextBox)(target));
            
            #line 45 "..\..\..\GUI\ProdajaWindow.xaml"
            this.tbPretrazi.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbPretrazi_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cmbSortiranje = ((System.Windows.Controls.ComboBox)(target));
            
            #line 48 "..\..\..\GUI\ProdajaWindow.xaml"
            this.cmbSortiranje.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbSortiranje_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cmbPretraga = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

