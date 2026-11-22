using MySqlConnector;
using System.Diagnostics;

namespace StudentSystem.Mobile;

public partial class MainPage : ContentPage
{
    public MainPage() => InitializeComponent();

    private async void OnTestClicked(object? sender, EventArgs e)
    {
        TestButton.IsEnabled = false;
        Spinner.IsRunning = true;
        ResultLabel.Text = "Connecting...";
        var sw = Stopwatch.StartNew();
        try
        {
            await using var conn = new MySqlConnection(Secrets.ConnectionString);
            await conn.OpenAsync();
            await using var cmd = new MySqlCommand("SELECT COUNT(*) FROM v_Student_Active", conn);
            var count = await cmd.ExecuteScalarAsync();
            ResultLabel.Text = $"OK: {count} active students ({sw.ElapsedMilliseconds} ms)";
        }
        catch (MySqlException ex)
        {
            ResultLabel.Text = $"MySQL error {ex.Number}: {ex.Message}";
        }
        catch (Exception ex)
        {
            ResultLabel.Text = $"{ex.GetType().Name}: {ex.Message}";
        }
        finally
        {
            Spinner.IsRunning = false;
            TestButton.IsEnabled = true;
        }
    }
}