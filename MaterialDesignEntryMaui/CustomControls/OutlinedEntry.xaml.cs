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

    private void BlEntry_Focused(object sender, FocusEventArgs e)
    {
        LblPlaceholder.FontSize = 0.75 * FontSize;
        LblPlaceholder.TranslateTo(0, -(BlEntry.Height/2), 80, Easing.Linear);
        LblPlaceholder.TextColor = Colors.Blue;
        border.Stroke = Colors.Blue;
    }

    private void BlEntry_Unfocused(object sender, FocusEventArgs e)
    {
        var entry = sender as BorderlessEntry;
        if (string.IsNullOrWhiteSpace(entry.Text))
        {
            LblPlaceholder.FontSize = FontSize;
            LblPlaceholder.TranslateTo(0, 0, 80, Easing.Linear);
            entry.Text = string.Empty;
        }
        else
            LblPlaceholder.FontSize = 0.75 * FontSize;

        LblPlaceholder.TextColor = Colors.LightGray;
        border.Stroke = Colors.LightGray;
    }
}