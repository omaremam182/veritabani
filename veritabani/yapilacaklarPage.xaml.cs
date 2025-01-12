using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace veritabani;

public partial class yapilacaklarPage : ContentPage
{
    public ObservableCollection<TaskItem> Tasks { get; set; }

    public yapilacaklarPage()
    {
        InitializeComponent();
        Tasks = new ObservableCollection<TaskItem>();
        TasksListView.ItemsSource = Tasks;
    }

    private async void OnAddTaskClicked(object sender, EventArgs e)
    {
        var taskName = await DisplayPromptAsync("Yeni Görev", "Görev adýný girin:");
        if (!string.IsNullOrEmpty(taskName))
        {
            Tasks.Add(new TaskItem { TaskName = taskName, IsCompleted = false });
        }
    }

    private async void OnEditTaskClicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var task = button?.BindingContext as TaskItem;

        if (task != null)
        {
            var newTaskName = await DisplayPromptAsync("Görev Adýný Düzenle", "Yeni görev adýný girin:", initialValue: task.TaskName);
            if (!string.IsNullOrEmpty(newTaskName))
            {
                task.TaskName = newTaskName;

            }
        }
    }

    private void OnDeleteTaskClicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;
        var task = button?.BindingContext as TaskItem;

        if (task != null)
        {
            Tasks.Remove(task);
        }
    }

    private void OnTaskCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkBox && checkBox.BindingContext is TaskItem task)
        {
            task.IsCompleted = e.Value;
        }
    }
}

public class TaskItem
{
    public string TaskName { get; set; }
    public bool IsCompleted { get; set; }
}

