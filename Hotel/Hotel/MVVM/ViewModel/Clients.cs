using Hotel.MVVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.MVVM.ViewModel
{
   public class ClientsvM : INotifyPropertyChanged
    {
        private List<Clients> ClientsAll = DataWork.GetAllClietns();
        public List<Clients> clientsAll
        {
            get
            {
                return ClientsAll;
            }
           private set
            {
                ClientsAll = value;
                OnPropretyChanged("Allows");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected bool Set<T>(ref T field, T value, string propretyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropretyChanged(propretyName);
            return true;
        }
        protected void OnPropretyChanged(string propretyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propretyName));
        }

    }
}
