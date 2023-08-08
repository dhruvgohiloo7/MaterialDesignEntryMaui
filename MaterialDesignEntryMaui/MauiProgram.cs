using MaterialDesignEntryMaui.CustomControls;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Platform;
using System.Runtime.CompilerServices;

namespace MaterialDesignEntryMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("BorderlessEntry", (handler, view) =>
		{
			if (view is BorderlessEntry)
			{
#if ANDROID
				handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#endif
#if IOS
				handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None; 
#endif
#if WINDOWS
				//Note : logic is added to App.xaml in Windows
				//< Thickness x: Key = "TextControlBorderThemeThickness" > 0 </ Thickness >
				//< Thickness x: Key = "TextControlBorderThemeThicknessFocused" > 0 </ Thickness >
				//< SolidColorBrush x: Key = "TextControlBackground" Color = "Transparent" />
				//< SolidColorBrush x: Key = "TextControlBackgroundFocused" Color = "Transparent" />

				handler.PlatformView.Padding = new Microsoft.UI.Xaml.Thickness(0);
#endif
			}
		});


#if DEBUG
            builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
