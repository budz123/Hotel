//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

//namespace TermPaper.MVVM.View
//{
//    /// <summary>
//    /// Логика взаимодействия для ReservationsAddView.xaml
//    /// </summary>
//    public partial class ReservationsAddView : UserControl
//    {
//        DataBase dataBase = new DataBase();
//        BaseField baseField = new BaseField();
//        public ReservationsAddView()
//        {
//            InitializeComponent();
//        }
//        public string status { get; set; }
//        public string TypePayment { get; set; }
//        public string SearchElementID(string SearchRow)
//        {
//            string SearchElementId = null;
//            for (int i = 0; i < SearchRow.Length; i++)
//            {
//                if (SearchRow[i] == ':')
//                {
//                    break;
//                }
//                else
//                {
//                    SearchElementId += SearchRow[i];
//                }
//            }
//            return SearchElementId;
//        }
//        private void TypePaymentText_SelectionChanged(object sender, SelectionChangedEventArgs e)
//        {

//        }
//        public void AddReservations()
//        {
//            baseField.RoomsId = Convert.ToInt32(SearchElementID(ComboBoxRoomIDText.Text));
//            baseField.ClientsID = Convert.ToInt32(SearchElementID(ComboBoxClientIDText.Text));
//            baseField.CheckInDate = Convert.ToDateTime(DatePickerCheckInDate.Text);
//            baseField.CheckOutDate = Convert.ToDateTime(DatePickerCheckOutDate.Text);
//            baseField.Status = ComboBoxReservationStatusText.Text;
//            baseField.TypePayment = ComboBoxTypePaymentText.Text;           
//            dataBase.openConnection();
//            string query = $"INSERT INTO[dbo].[Reservations] ([CheckInDate],[CheckOutDate],[RoomID],[ReservationStatus],[typePayment],[ClientID])VALUES('{baseField.CheckInDate.Date.Year}-{baseField.CheckInDate.Date.Month}-{baseField.CheckInDate.Date.Day}', '{baseField.CheckOutDate.Date.Year}-{baseField.CheckOutDate.Date.Month}-{baseField.CheckOutDate.Date.Day}', {baseField.RoomsId}, '{baseField.Status}', '{baseField.TypePayment}', {baseField.ClientsID})";
//            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
//            command.ExecuteNonQuery();
//            dataBase.closeConnection();
//        }


//        public void RoomsComboBoxRefresh()
//        {
//            dataBase.openConnection();
//            string queryString = "SELECT * From Rooms";
//            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
//            SqlDataReader sqlDataReader = command.ExecuteReader();
//            ComboBoxRoomIDText.Items.Clear();
//            while (sqlDataReader.Read())
//            {
//                int RoomsID = sqlDataReader.GetInt32(0);
//                string Number = sqlDataReader.GetString(1);
//                ComboBoxRoomIDText.Items.Add($"{RoomsID}: {Number}");
//            }
//            dataBase.closeConnection();
//        }
//        public void ClietnsComboBoxRefresh1()
//        {
//            dataBase.openConnection();
//            string queryString = "SELECT * From Clients";
//            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
//            SqlDataReader sqlDataReader = command.ExecuteReader();
//            ComboBoxClientIDText.Items.Clear();
//            while (sqlDataReader.Read())
//            {
//                int ClientsID = sqlDataReader.GetInt32(0);
//                string FirstName = sqlDataReader.GetString(1);
//                string LastName = sqlDataReader.GetString(2);
//                ComboBoxClientIDText.Items.Add($"{ClientsID}: {FirstName}: {LastName}");
//            }
//            dataBase.closeConnection();
//        }
//        public void Status()
//        {
//            dataBase.openConnection();
           
//            string query = $"UPDATE  [dbo].[Rooms] SET  [Status] = '{ComboBoxReservationStatusText.Text}' WHERE RoomsID = {baseField.RoomsId}";
//            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
//            command.ExecuteNonQuery();
//            dataBase.closeConnection();
//        }
//        private void ComboBoxRoomIDText_DropDownClosed(object sender, EventArgs e)
//        {
            
          
//        }

//        private void ___AddViewReserv__Loaded(object sender, RoutedEventArgs e)
//        {
//            ClietnsComboBoxRefresh1();
//            RoomsComboBoxRefresh();
//        }

//        private void Button_Click(object sender, RoutedEventArgs e)
//        {

//            AddReservations();
//            Status();
//        }

//        private void ComboBoxClientIDText_DropDownClosed(object sender, EventArgs e)
//        {
           
           
//        }

//        private void ComboBoxReservationStatusText_DropDownClosed(object sender, EventArgs e)
//        {
            
//        }

//        private void ComboBoxTypePaymentText_DropDownClosed(object sender, EventArgs e)
//        {
           
//        }
//    }
//}
