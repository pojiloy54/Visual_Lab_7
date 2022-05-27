using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Visual_Lab_7.Views
{
    public partial class Info : Window
    {
        public Info()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
