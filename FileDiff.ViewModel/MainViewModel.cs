using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FileDiff.Model;

namespace FileDiff.ViewModel
{

    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            _diffList = new List<DiffLine>();
        }
        private List<DiffLine> _diffList;

        public List<DiffLine> DiffList
        {
            get => _diffList;
            set
            {
                _diffList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DiffList"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

    }


}
