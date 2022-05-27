using Visual_Lab_7.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ReactiveUI;

namespace Visual_Lab_7.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get => students;
            set
            {
                this.RaiseAndSetIfChanged(ref students, value);
            }
        }
        string path;
        public string Path
        {
            get => path;
            set
            {
                path = value;
                if (path != "")
                {
                    Stream openFileStream = File.OpenRead(path);
                    BinaryFormatter deserializer = new BinaryFormatter();
                    Students = (ObservableCollection<Student>)deserializer.Deserialize(openFileStream);
                    foreach (Student student in Students)
                    {
                        foreach (Cell cell in student.Cells)
                        {
                            cell.Mark = cell.Mark;
                        }
                        student.Average = student.Average;
                    }
                    openFileStream.Close();
                }
            }
        }
        string savepath;
        public string Savepath
        {
            get => savepath;
            set
            {
                savepath = value;
                if (savepath != "")
                {
                    Stream SaveFileStream = File.Create(savepath);
                    BinaryFormatter serializer = new BinaryFormatter();
                    serializer.Serialize(SaveFileStream, Students);
                    SaveFileStream.Close();
                }
            }
        }
        public MainWindowViewModel()
        {
            Students = new ObservableCollection<Student>();
        }
        public void Add()
        {
            Student s = new Student("");
            Students.Add(s);
        }
        public void Delete()
        {
            for (int i = 0; i < Students.Count;)
            {
                Student s = Students[i];
                if (s.IsChecked)
                {
                    Students.Remove(s);
                }
                else i++;
            }
        }
    }
}
