﻿#pragma checksum "..\..\..\..\AvisRecette.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D940143E71C807FEF581006A9091BF9CD33145E3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using SugarDay;
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


namespace SugarDay {
    
    
    /// <summary>
    /// AvisRecette
    /// </summary>
    public partial class AvisRecette : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\AvisRecette.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridTotal;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\AvisRecette.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lesAvisListBox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\AvisRecette.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TitrePage;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\AvisRecette.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Commenter_Btn;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\AvisRecette.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CommentText;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\AvisRecette.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Noter_Btn;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\AvisRecette.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NoterText;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\AvisRecette.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Titre6;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SugarDay;component/avisrecette.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\AvisRecette.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\..\AvisRecette.xaml"
            ((SugarDay.AvisRecette)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Fenetre_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GridTotal = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.lesAvisListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.TitrePage = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.Commenter_Btn = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\..\AvisRecette.xaml"
            this.Commenter_Btn.Click += new System.Windows.RoutedEventHandler(this.Commenter);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CommentText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Noter_Btn = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\..\AvisRecette.xaml"
            this.Noter_Btn.Click += new System.Windows.RoutedEventHandler(this.Noter);
            
            #line default
            #line hidden
            return;
            case 8:
            this.NoterText = ((System.Windows.Controls.TextBox)(target));
            
            #line 89 "..\..\..\..\AvisRecette.xaml"
            this.NoterText.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Champ_Noté_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Titre6 = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

