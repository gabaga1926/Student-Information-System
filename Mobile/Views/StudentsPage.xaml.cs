using System.Collections.ObjectModel;
using StudentSystem.Mobile.Data;
using StudentSystem.Mobile.Models;

namespace StudentSystem.Mobile.Views;

public partial class StudentsPage : ContentPage
{
    private readonly ObservableCollection<Student> _students = new();
    private CancellationTokenSource? _searchCts;
    private bool _hasLoaded;

    public StudentsPage()
    {
        InitializeComponent();
        StudentsCollectionView.ItemsSource = _students;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_hasLoaded)
        {
            return;
        }

        _hasLoaded = true;
        await LoadStudentsAsync(string.Empty, CancellationToken.None);
    }

    private async void OnSearchTextChanged(object? sender, TextChangedEventArgs e)
    {
        _searchCts?.Cancel();
        _searchCts?.Dispose();
        _searchCts = new CancellationTokenSource();
        var cancellationToken = _searchCts.Token;

        try
        {
            await Task.Delay(300, cancellationToken);
            await LoadStudentsAsync(e.NewTextValue ?? string.Empty, cancellationToken);
        }
        catch (OperationCanceledException)
        {
        }
    }

    private async void OnRefreshing(object? sender, EventArgs e)
    {
        _searchCts?.Cancel();
        await LoadStudentsAsync(StudentSearchBar.Text ?? string.Empty, CancellationToken.None);
    }

    private async void OnRetryClicked(object? sender, EventArgs e)
    {
        await LoadStudentsAsync(StudentSearchBar.Text ?? string.Empty, CancellationToken.None);
    }

    private async void OnStudentSelected(object? sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Student student)
        {
            return;
        }

        try
        {
            await Shell.Current.GoToAsync(nameof(StudentDetailPage), new Dictionary<string, object>
            {
                ["Student"] = student
            });
        }
        catch (Exception)
        {
            ErrorLabel.Text = "Unable to open the student details.";
            ErrorState.IsVisible = true;
        }
        finally
        {
            StudentsCollectionView.SelectedItem = null;
        }
    }

    private async Task LoadStudentsAsync(string term, CancellationToken cancellationToken)
    {
        LoadingIndicator.IsVisible = true;
        LoadingIndicator.IsRunning = true;
        ErrorState.IsVisible = false;
        EmptyLabel.IsVisible = false;

        try
        {
            var students = string.IsNullOrWhiteSpace(term)
                ? await StudentReadRepository.GetAllAsync(cancellationToken)
                : await StudentReadRepository.SearchAsync(term, cancellationToken);

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            _students.Clear();
            foreach (var student in students)
            {
                _students.Add(student);
            }

            EmptyLabel.IsVisible = _students.Count == 0;
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
        }
        catch (Exception)
        {
            ErrorLabel.Text = "Unable to load students. Check the connection and try again.";
            ErrorState.IsVisible = true;
        }
        finally
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                LoadingIndicator.IsRunning = false;
                LoadingIndicator.IsVisible = false;
                StudentsRefreshView.IsRefreshing = false;
            }
        }
    }
}
