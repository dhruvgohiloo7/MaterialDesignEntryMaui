
using Microsoft.Maui.Graphics;

namespace MaterialDesignEntryMaui.CustomControls;

public partial class OutlinedEntry : Grid
{
	public OutlinedEntry()
	{
		InitializeComponent();
	}

	public static readonly BindableProperty TextProperty = BindableProperty.Create(
		propertyName:nameof(Text),
		returnType: typeof(string),
		defaultValue: null,
		declaringType:typeof(OutlinedEntry),
		defaultBindingMode:BindingMode.TwoWay
		); 

	public string Text
	{
		get => (string)GetValue( TextProperty ); set => SetValue( TextProperty, value );
	}

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        propertyName: nameof(Placeholder),
        returnType: typeof(string),
        defaultValue: null,
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
        declaringType: typeof(OutlinedEntry),
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
        declaringType: typeof(OutlinedEntry),
        defaultBindingMode: BindingMode.TwoWay
        );

    public Color FocusedBorderColor
    {
        get => (Color)GetValue(FocusedBorderColorProperty); set => SetValue(FocusedBorderColorProperty, value);
    }

    public static readonly BindableProperty UnFocusedBorderColorProperty = BindableProperty.Create(
        propertyName: nameof(UnFocusedBorderColor),
        returnType: typeof(Color),
        defaultValue: Colors.LightSlateGrey,
        declaringType: typeof(OutlinedEntry),
        defaultBindingMode: BindingMode.TwoWay
        );

    public Color UnFocusedBorderColor
    {
        get => (Color)GetValue(UnFocusedBorderColorProperty); set => SetValue(UnFocusedBorderColorProperty, value);
    }

    public static readonly BindableProperty PlaceholderColorProperty = BindableProperty.Create(
        propertyName: nameof(PlaceholderColor),
        returnType: typeof(Color),
        defaultValue: Colors.LightSlateGrey,
        declaringType: typeof(OutlinedEntry),
        defaultBindingMode: BindingMode.TwoWay
        );

    public Color PlaceholderColor
    {
        get => (Color)GetValue(PlaceholderColorProperty); set => SetValue(PlaceholderColorProperty, value);
    }

    public static readonly BindableProperty PlaceholderBackgroundColorProperty = BindableProperty.Create(
        propertyName: nameof(PlaceholderBackgroundColor),
        returnType: typeof(Color),
        defaultValue: Colors.White,
        declaringType: typeof(OutlinedEntry),
        defaultBindingMode: BindingMode.TwoWay
        );

    public Color PlaceholderBackgroundColor
    {
        get => (Color)GetValue(PlaceholderBackgroundColorProperty); set => SetValue(PlaceholderBackgroundColorProperty, value);
    }

    public static new readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(
        propertyName: nameof(BackgroundColor),
        returnType: typeof(Color),
        defaultValue: Colors.Transparent,
        declaringType: typeof(OutlinedEntry),
        defaultBindingMode: BindingMode.TwoWay
        );

    public new Color BackgroundColor
    {
        get => (Color)GetValue(BackgroundColorProperty); set => SetValue(BackgroundColorProperty, value);
    }

    private void BlEntry_Focused(object sender, FocusEventArgs e)
    {
        LblPlaceholder.FontSize = 0.75 * FontSize;
        LblPlaceholder.TranslateTo(0, DeviceInfo.Platform == DevicePlatform.iOS ? -((BlEntry.Height + 20) / 2) : -(BlEntry.Height/2), 80, Easing.Linear);
        LblPlaceholder.TextColor = FocusedBorderColor;
        border.Stroke = FocusedBorderColor;
    }

    private void BlEntry_Unfocused(object sender, FocusEventArgs e)
    {
        var entry = sender as BorderlessEntry;
        if (string.IsNullOrWhiteSpace(entry.Text))
        {
            LblPlaceholder.FontSize = FontSize;
            LblPlaceholder.TranslateTo(0, 0, 80, Easing.Linear);
            entry.Text = string.Empty;
            LblPlaceholder.TextColor = PlaceholderColor;
        }
        else
        {
            //LblPlaceholder.FontSize = 0.75 * FontSize;
            LblPlaceholder.TextColor = UnFocusedBorderColor;
        }
        border.Stroke = UnFocusedBorderColor;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        BlEntry.Focus();
    }
}