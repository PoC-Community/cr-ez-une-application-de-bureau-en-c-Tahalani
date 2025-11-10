using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;
using TodoListApp.Models;

namespace TodoListApp;

public partial class MainWindow : Window
{
    private ObservableCollection<TaskItem> _tasks = new();
    private int _nextId = 1;

    public MainWindow()
    {
        InitializeComponent();
        TaskList.ItemsSource = _tasks;

        AddButton.Click += OnAddClick;
        DeleteButton.Click += OnDeleteClick;
    }

    private void OnAddClick(object? sender, RoutedEventArgs e)
    {
        var taskText = TaskInput.Text?.Trim();
        if (!string.IsNullOrWhiteSpace(taskText))
        {
            _tasks.Add(new TaskItem
            {
                Id = _nextId++,
                Title = taskText,
                IsCompleted = false
            });
            TaskInput.Text = string.Empty;
        }
    }

    private void OnDeleteClick(object? sender, RoutedEventArgs e)
    {
        if (TaskList.SelectedItem is TaskItem selected)
        {
            _tasks.Remove(selected);
        }
    }
}
