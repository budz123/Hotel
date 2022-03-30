using ManageStaffDBApp.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace ManageStaffDBApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView AllReservationsView;
        public static ListView AllRoomsView;
        public static ListView AllClientsView;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            AllReservationsView = ViewAllReservations;
            AllRoomsView = ViewAllRooms;
            AllClientsView = ViewAllClietns;
        }
    }
}
