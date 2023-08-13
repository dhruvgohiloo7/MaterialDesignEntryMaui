
using Microsoft.Maui.Graphics;

namespace MaterialDesignEntryMaui.CustomControls;

public partial class OutlinedEntry : EntryBase
{
	public OutlinedEntry()
	{
		InitializeComponent();
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
        LblPlaceholder.TranslateTo(0, -((BlEntry.Height + 20) / 2), 80, Easing.Linear);
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