using System;
using System.Collections.ObjectModel;
using Avalonia.Media;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Visual_Lab_7.Models
{
	[Serializable()]
	public class Student : INotifyPropertyChanged
	{
		public string Name { get; set; }
		public ObservableCollection<Cell> Cells { get; set; }
		public bool IsChecked { get; set; }
		string average;
		[field: NonSerialized()]
		public event PropertyChangedEventHandler? PropertyChanged;
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		public string Average
		{
			get => average;
			set
			{
				average = value;
				double val = Convert.ToDouble(value);
				if (val < 1) Background = Brushes.IndianRed;
				else if (val < 1.5) Background = Brushes.LightYellow;
				else Background = Brushes.LightGreen;
				NotifyPropertyChanged();
			}
		}
		[field: NonSerialized()]
		IBrush background;
		[field: NonSerialized()]
		public IBrush Background
		{
			get => background;
			set
			{
				background = value;
				NotifyPropertyChanged();
			}
		}
		public Student(string name)
		{
			Name = name;
			Cells = new ObservableCollection<Cell>();
			for (int i = 0; i < 5; i++)
			{
				Cells.Add(new Cell("0"));
			}
		}
		public void CountAverage()
		{
			double sum = 0, count = 0;
			for (int i = 0; i < 5; i++)
			{
				if (Cells[i].Mark != "#ERROR") sum += Convert.ToDouble(Cells[i].Mark);
				count++;
			}
			Average = Convert.ToString(sum / count);
		}
	}
}
