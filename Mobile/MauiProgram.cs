using Microsoft.Extensions.Logging;

namespace StudentSystem.Mobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("Consolas-Regular.ttf", "ConsolasRegular");
				fonts.AddFont("Consolas-Bold.ttf", "ConsolasBold");
			});

#if ANDROID
		Microsoft.Maui.Handlers.SearchBarHandler.Mapper.AppendToMapping("WhiteSearchIcon", (handler, view) =>
		{
			var iconId = handler.PlatformView.Resources?.GetIdentifier("search_mag_icon", "id", "android") ?? 0;
			var icon = iconId == 0 ? null : handler.PlatformView.FindViewById<Android.Widget.ImageView>(iconId);
			icon?.SetColorFilter(Android.Graphics.Color.White, Android.Graphics.PorterDuff.Mode.SrcIn);
		});
#endif

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
