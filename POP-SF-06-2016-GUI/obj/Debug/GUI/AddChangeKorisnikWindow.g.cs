﻿#pragma checksum "..\..\..\GUI\AddChangeKorisnikWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A291EBF0019EDC9DFA352DEF6EA5CE1A"
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
    /// AddChangeKorisnikWindow
    /// </summary>
    public partial class AddChangeKorisnikWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\GUI\AddChangeKorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbIme;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\GUI\AddChangeKorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPrezime;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\GUI\AddChangeKorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbKorIme;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\GUI\AddChangeKorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbLozinka;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\GUI\AddChangeKorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbTipKorisnika;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\GUI\AddChangeKorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSacuvaj;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\GUI\AddChangeKorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnZatvori;
        
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
            System.Uri resourceLocater = new System.Uri("/POP-SF-06-2016-GUI;component/gui/addchangekorisnikwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GUI\AddChangeKorisnikWindow.xaml"
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
            this.tbIme = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbPrezime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbKorIme = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbLozinka = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cmbTipKorisnika = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.btnSacuvaj = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\GUI\AddChangeKorisnikWindow.xaml"
            this.btnSacuvaj.Click += new System.Windows.RoutedEventHandler(this.btnSacuvaj_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnZatvori = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\GUI\AddChangeKorisnikWindow.xaml"
            this.btnZatvori.Click += new System.Windows.RoutedEventHandler(this.btnZatvori_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
