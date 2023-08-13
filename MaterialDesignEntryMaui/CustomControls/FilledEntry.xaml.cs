namespace MaterialDesignEntryMaui.CustomControls;

public partial class FilledEntry : EntryBase
{
	public FilledEntry()
	{
		InitializeComponent();
        border.Padding = new Thickness(10, BlEntry.FontSize * 0.75 + 10, 10, 5);
        LblPlaceholder.Margin = new Thickness(10, 0, 0, 0);
	}

    public static readonly BindableProperty FocusedBackgroundColorProperty = BindableProperty.Create(
        propertyName: nameof(FocusedBackgroundColor),
        returnType: typeof(Color),
        defaultValue: Colors.Black,
        declaringType: typeof(FilledEntry),
        defaultBindingMode: BindingMode.TwoWay
        );

    public Color FocusedBackgroundColor
    {
        get => (Color)GetValue(FocusedBackgroundColorProperty); set => SetValue(FocusedBackgroundColorProperty, value);
    }

    public static readonly BindableProperty UnFocusedBackgroundColorProperty = BindableProperty.Create(
        propertyName: nameof(UnFocusedBackgroundColor),
        returnType: typeof(Color),
        defaultValue: Color.FromArgb("#f7f7f7"),
        declaringType: typeof(FilledEntry),
        defaultBindingMode: BindingMode.TwoWay
        );

    public Color UnFocusedBackgroundColor
    {
        get => (Color)GetValue(UnFocusedBackgroundColorProperty); set => SetValue(UnFocusedBackgroundColorProperty, value);
    }

    private void BlEntry_Focused(object sender, FocusEventArgs e)
    {
        LblPlaceholder.FontSize = 0.75 * 20;
        LblPlaceholder.TranslateTo(0, -((BlEntry.Height + (BlEntry.FontSize - (BlEntry.FontSize * 0.75) - 5))/2), 80, Easing.Linear);
        LblPlaceholder.TextColor = boxViewBorder.Color = FocusedBorderColor;
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
            LblPlaceholder.TextColor = UnFocusedBorderColor;

        boxViewBorder.Color = UnFocusedBorderColor;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        BlEntry.Focus();
    }
}