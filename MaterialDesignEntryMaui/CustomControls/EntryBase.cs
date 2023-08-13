using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignEntryMaui.CustomControls
{
    public class EntryBase : Grid
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
        propertyName: nameof(Text),
        returnType: typeof(string),
        defaultValue: null,
        declaringType: typeof(OutlinedEntry),
        defaultBindingMode: BindingMode.TwoWay
        );

        public string Text
        {
            get => (string)GetValue(TextProperty); set => SetValue(TextProperty, value);
        }

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            propertyName: nameof(Placeholder),
            returnType: typeof(string),
            defaultValue: "Enter text",
            declaringType: typeof(OutlinedEntry),
            defaultBindingMode: BindingMode.TwoWay
            );

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty); set => SetValue(PlaceholderProperty, value);
        }

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
        propertyName: nameof(FontSize),
        returnType: typeof(double),
        defaultValue: 15.0,
        declaringType: typeof(FilledEntry),
        defaultBindingMode: BindingMode.TwoWay
        );

        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty); set => SetValue(FontSizeProperty, value);
        }

        public static readonly BindableProperty FocusedBorderColorProperty = BindableProperty.Create(
            propertyName: nameof(FocusedBorderColor),
            returnType: typeof(Color),
            defaultValue: Colors.Black,
            declaringType: typeof(FilledEntry),
            defaultBindingMode: BindingMode.TwoWay
            );

        public Color FocusedBorderColor
        {
            get => (Color)GetValue(FocusedBorderColorProperty); set => SetValue(FocusedBorderColorProperty, value);
        }

        public static readonly BindableProperty UnFocusedBorderColorProperty = BindableProperty.Create(
        propertyName: nameof(UnFocusedBorderColor),
        returnType: typeof(Color),
        defaultValue: Colors.DarkGray,
        declaringType: typeof(FilledEntry),
        defaultBindingMode: BindingMode.TwoWay
        );

        public Color UnFocusedBorderColor
        {
            get => (Color)GetValue(UnFocusedBorderColorProperty); set => SetValue(UnFocusedBorderColorProperty, value);
        }

        public static readonly BindableProperty PlaceholderColorProperty = BindableProperty.Create(
        propertyName: nameof(PlaceholderColor),
        returnType: typeof(Color),
        defaultValue: Colors.DarkGray,
        declaringType: typeof(FilledEntry),
        defaultBindingMode: BindingMode.TwoWay
        );

        public Color PlaceholderColor
        {
            get => (Color)GetValue(PlaceholderColorProperty); set => SetValue(PlaceholderColorProperty, value);
        }
    }
}
