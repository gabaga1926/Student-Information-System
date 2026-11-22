using StudentSystem.Mobile.Models;

namespace StudentSystem.Mobile.Views;

public partial class StudentDetailPage : ContentPage, IQueryAttributable
{
    public StudentDetailPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Student", out var value) && value is Student student)
        {
            BindingContext = student;
        }
    }
}
