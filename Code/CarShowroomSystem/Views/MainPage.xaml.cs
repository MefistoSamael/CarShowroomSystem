using CarShowroomSystem.Model;
using CarShowroomSystem.ViewModels;

namespace CarShowroomSystem.Views;

public partial class MainPage : ContentPage
{
    private readonly AppDbContext _dbContext;
    public MainPage(MainViewModel vm) 
	{

        BindingContext = vm;
        InitializeComponent();
        _dbContext = new AppDbContext();

        // Выполните операции с базой данных
        //var customers = _dbContext.Customers.ToList();

    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        // Закройте соединение с базой данных при необходимости
        _dbContext.Dispose();
    }
    private async void OnCounterClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}

