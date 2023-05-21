﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using CarShowroomSystem.Model;
using CarShowroomSystem.ViewModels;
using CarShowroomSystem.Views;
using CarShowroomSystem.Views.Car;
using CarShowroomSystem.ViewModels.Car;

namespace CarShowroomSystem;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder
      .UseMauiApp<App>()
      .UseMauiCommunityToolkit()
      .ConfigureFonts(fonts =>
      {
          fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
          fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
      }).UseMauiMaps();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        //view models
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<CreateAccountViewModel>();
        builder.Services.AddTransient<AddCarViewModel>();

        //pages
        builder.Services.AddTransient<CreateAccountPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<AddCarPage>();

        //model
        builder.Services.AddSingleton<IModel, Model.Model>();

        return builder.Build();
	}
}
