using SourceGenerator;
using System.ComponentModel;

namespace ConsoleApp
{
    internal partial class MyModelObject : INotifyPropertyChanged
    {
        [NotificationProperty]
        private int _intField1, _intField2, _intField3;

        [NotificationProperty]
        private long _longField;

        public event PropertyChangedEventHandler? PropertyChanged;
    }

    internal partial class InvalidMyModelObject
    {
        [NotificationProperty]
        private int _intField1, _intField2, _intField3;

        [NotificationProperty]
        private long _longField;

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
