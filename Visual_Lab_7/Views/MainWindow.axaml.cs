using Avalonia.Controls;
using Avalonia.Interactivity;
using Visual_Lab_7.ViewModels;
using Visual_Lab_7.Models;

namespace Visual_Lab_7.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.FindControl<MenuItem>("Save").Click += async delegate
            {
                var window = new SaveFileDialog()
                {
                    Title = "Save File"
                };
                window.Filters.Add(new FileDialogFilter() { Name = "Binary files (*.bin)", Extensions = { "bin" } });

                string? path = await window.ShowAsync((Window)this.VisualRoot);

                var context = this.DataContext as MainWindowViewModel;
                if (path == null) context.Savepath = "";
                else context.Savepath = path;
            };

            this.FindControl<MenuItem>("Load").Click += async delegate
            {

                var window = new OpenFileDialog()
                {
                    Title = "Open File"
                };
                window.Filters.Add(new FileDialogFilter() { Name = "Binary files (*.bin)", Extensions = { "bin" } });
                string[]? path = await window.ShowAsync((Window)this.VisualRoot);

                var context = this.DataContext as MainWindowViewModel;
                if (path == null) context.Path = "";
                else context.Path = string.Join("\\", path);
            };
            this.FindControl<MenuItem>("Exit").Click += delegate
            {
                this.Close();
            };
            this.FindControl<MenuItem>("About").Click += delegate
            {
                var window = new Info();
                window.ShowDialog((Window)this.VisualRoot);
            };
        }
        public void cAverage(object sender, RoutedEventArgs e)
        {
            var box = sender as TextBox;
            var student = box.DataContext as Student;
            student.CountAverage();
        }

    }

}
