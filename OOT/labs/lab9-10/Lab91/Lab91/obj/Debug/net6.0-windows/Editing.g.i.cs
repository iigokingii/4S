// Updated by XamlIntelliSenseFileGenerator 14.04.2023 17:42:01
#pragma checksum "..\..\..\Editing.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3F76DBE17BEDFC2935A49721DB7360E0E5B9F6AA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Lab91;
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


namespace Lab91
{


    /// <summary>
    /// Editing
    /// </summary>
    public partial class Editing : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 19 "..\..\..\Editing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Libraries;

#line default
#line hidden


#line 25 "..\..\..\Editing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Books;

#line default
#line hidden


#line 43 "..\..\..\Editing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ID;

#line default
#line hidden


#line 52 "..\..\..\Editing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BookName;

#line default
#line hidden


#line 54 "..\..\..\Editing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BookAuthor;

#line default
#line hidden


#line 57 "..\..\..\Editing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button insertDate;

#line default
#line hidden


#line 58 "..\..\..\Editing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateDate;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Lab91;component/editing.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Editing.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:

#line 8 "..\..\..\Editing.xaml"
                    ((Lab91.Editing)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);

#line default
#line hidden
                    return;
                case 2:
                    this.Libraries = ((System.Windows.Controls.DataGrid)(target));
                    return;
                case 3:
                    this.Books = ((System.Windows.Controls.DataGrid)(target));
                    return;
                case 4:
                    this.ID = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 5:
                    this.LibAddr = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 6:
                    this.BookName = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 7:
                    this.BookAuthor = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 8:
                    this.insertDate = ((System.Windows.Controls.Button)(target));

#line 57 "..\..\..\Editing.xaml"
                    this.insertDate.Click += new System.Windows.RoutedEventHandler(this.insertDate_Click);

#line default
#line hidden
                    return;
                case 9:
                    this.UpdateDate = ((System.Windows.Controls.Button)(target));

#line 58 "..\..\..\Editing.xaml"
                    this.UpdateDate.Click += new System.Windows.RoutedEventHandler(this.UpdateDate_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TextBlock LibAddr;
    }
}

