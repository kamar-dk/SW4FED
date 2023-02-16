using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lek_3._1_Excercise_1
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Agent> agents;

        public MainWindowViewModel()
        {
            agents = new ObservableCollection<Agent>();
            agents.Add(new Agent("001", "Nina", "Assassination", "Uppervolta"));
            agents.Add(new Agent("007", "James Bond", "Martinis", "North Korea"));
            CurrentAgent = agents[0]; 
        }

        Agent currentAgent = null;

        public Agent CurrentAgent
        {
            get { return currentAgent; }
            set
            {
                if (currentAgent != value)
                {
                    currentAgent = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<Agent> Agents
        {
            get
            {
                return agents;
            }
        }

        public void AddNewAgent()
        {
            agents.Add(new Agent());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
