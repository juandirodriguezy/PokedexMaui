using PokedexMaui.Models;
using PokedexMaui.Services;

namespace PokedexMaui;

public partial class VehiclesPage : ContentPage
{
    private readonly VehicleApiService _vehicleService;
    private List<VehicleMake> _allMakes = new();

    public VehiclesPage(VehicleApiService vehicleService)
    {
        InitializeComponent();
        _vehicleService = vehicleService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        SetLoading(true);

        try
        {
            _allMakes = await _vehicleService.GetAllMakesAsync();
            VehiclesCollection.ItemsSource = _allMakes;
            MessageLabel.IsVisible = false;
        }
        catch (HttpRequestException)
        {
            ShowMessage("No fue posible conectarse con el servicio.");
        }
        catch (Exception)
        {
            ShowMessage("Ocurrió un error inesperado al cargar la lista.");
        }
        finally
        {
            SetLoading(false);
        }
    }

    private void OnFilterChanged(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(e.NewTextValue))
        {
            VehiclesCollection.ItemsSource = _allMakes;
        }
        else
        {
            VehiclesCollection.ItemsSource = _allMakes
                .Where(m => m.MakeName.Contains(e.NewTextValue, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }

    private void SetLoading(bool isLoading)
    {
        LoadingIndicator.IsVisible = isLoading;
        LoadingIndicator.IsRunning = isLoading;
        VehiclesCollection.IsVisible = !isLoading;
    }

    private void ShowMessage(string message)
    {
        MessageLabel.Text = message;
        MessageLabel.IsVisible = true;
        VehiclesCollection.IsVisible = false;
    }
}
