using MaterialDesignEntryMaui.CustomControls;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Platform;

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
			}
		});


#if DEBUG
            builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
