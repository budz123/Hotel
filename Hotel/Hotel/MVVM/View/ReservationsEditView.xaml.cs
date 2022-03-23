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
//    /// Логика взаимодействия для ReservationsEditView.xaml
//    /// </summary>
//    public partial class ReservationsEditView : UserControl
//    {
//        DataBase dataBase = new DataBase();
//        BaseField baseField = new BaseField();
//        public ReservationsEditView()
//        {
//            InitializeComponent();
//        }
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
//        public void ReservationsComboBoxRefresh_2()
//        {
//            dataBase.openConnection();
//            string queryString = $"SELECT * From Reservations WHERE ReservationsID = {baseField.ReservationsId}";
//            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
//            SqlDataReader sqlDataReader = command.ExecuteReader();
//            while (sqlDataReader.Read())
//            {

//                DatePickerCheckInDate.Text = Convert.ToString(sqlDataReader.GetDateTime(1));
//                DatePickerCheckOutDate.Text = Convert.ToString(sqlDataReader.GetDateTime(2));
//                RoomIDText.Text = Convert.ToString(sqlDataReader.GetInt32(3));
//                ReservationStatusText.Text = sqlDataReader.GetString(4);
//                TypePaymentText.Text = sqlDataReader.GetString(5);
//                ClientIDText.Text = Convert.ToString(sqlDataReader.GetInt32(6));

//            }
//            dataBase.closeConnection();
//        }
//        public void ReservationsComboBoxRefresh()
//        {
//            dataBase.openConnection();
//            string queryString = "SELECT * From Reservations";
//            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
//            SqlDataReader sqlDataReader = command.ExecuteReader();
//            ComboBoxEdit.Items.Clear();
//            while (sqlDataReader.Read())
//            {
//                int ReservationsId = sqlDataReader.GetInt32(0);
//                string CheckInDate = Convert.ToString(sqlDataReader.GetDateTime(1));
//                string CheckOutDate = Convert.ToString(sqlDataReader.GetDateTime(2));
//                ComboBoxEdit.Items.Add($"{ReservationsId}: {CheckInDate}: {CheckOutDate}");
//            }
//            dataBase.closeConnection();
//        }
//        public void RoomIDComboBoxRefresh()
//        {
//            dataBase.openConnection();
//            string queryString = "SELECT * From Rooms";
//            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
//            SqlDataReader sqlDataReader = command.ExecuteReader();
//            RoomIDText.Items.Clear();
//            while (sqlDataReader.Read())
//            {
//                int RoomsId = sqlDataReader.GetInt32(0);
//                string Number = sqlDataReader.GetString(1);
//                int Floor = sqlDataReader.GetInt32(2);
//                string Type = sqlDataReader.GetString(3);
//                int Capacity = sqlDataReader.GetInt32(4);
//                string Price = sqlDataReader.GetString(5);
//                RoomIDText.Items.Add($"{RoomsId}: НОМЕР-{Number} ЭТАЖ-{Floor} ТИП-{Type} ЁМКОСТЬ-{Capacity} ЦЕНА-{Price}");
//            }
//            dataBase.closeConnection();
//        }
//        public void ClientIDComboBoxRefresh()
//        {
//            dataBase.openConnection();
//            string queryString = "SELECT * From Clients";
//            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
//            SqlDataReader sqlDataReader = command.ExecuteReader();
//            ClientIDText.Items.Clear();
//            while (sqlDataReader.Read())
//            {
//                int Id = sqlDataReader.GetInt32(0);
//                string lastName = sqlDataReader.GetString(1);
//                string firstName = sqlDataReader.GetString(2);
//                ClientIDText.Items.Add($"{Id}: ИМЯ-{firstName} ФАМИЛИЯ-{lastName}");
//            }
//            dataBase.closeConnection();
//        }

//        private void Button_Click(object sender, RoutedEventArgs e)
//        {
//            dataBase.openConnection();
//            baseField.CheckInDate = Convert.ToDateTime(DatePickerCheckInDate.Text);
//            baseField.CheckOutDate = Convert.ToDateTime(DatePickerCheckOutDate.Text);
//            string query = $"UPDATE [Reservations] SET [CheckInDate] = '{baseField.CheckInDate.Year}-{baseField.CheckInDate.Month}-{baseField.CheckInDate.Day}',[CheckOutDate] = '{baseField.CheckOutDate.Year}-{baseField.CheckOutDate.Month}-{baseField.CheckOutDate.Day}',[RoomID] = {baseField.RoomsId},[ReservationStatus] = '{baseField.ReseravtionStatus}',[typePayment] = '{baseField.TypePayment}',[ClientID] = {baseField.ClientsID} WHERE ReservationsID={baseField.ReservationsId}";
//            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
//            command.ExecuteNonQuery();
//            ReservationsComboBoxRefresh();
//            dataBase.closeConnection();

//            ReservationsComboBoxRefresh();
//            RoomIDComboBoxRefresh();
//            ClientIDComboBoxRefresh();
//        }

//        private void ComboBoxEdit_DropDownClosed(object sender, EventArgs e)
//        {
//            baseField.ReservationsId = Convert.ToInt32(SearchElementID(ComboBoxEdit.Text));
//            //GroupComboBoxRefresh_2();
//        }

//        private void Edit_Loaded(object sender, RoutedEventArgs e)
//        {
//            ReservationsComboBoxRefresh();
//            RoomIDComboBoxRefresh();
//            ClientIDComboBoxRefresh();
//        }

//        private void ReservationStatusText_SelectionChanged(object sender, SelectionChangedEventArgs e)
//        {

//        }

//        private void RoomIDText_DropDownClosed(object sender, EventArgs e)
//        {
//            baseField.RoomsId = Convert.ToInt32(SearchElementID(RoomIDText.Text));
//        }

//        private void ReservationStatusText_DropDownClosed(object sender, EventArgs e)
//        {
//            baseField.ReseravtionStatus = ReservationStatusText.Text;
//        }

//        private void TypePaymentText_DropDownClosed(object sender, EventArgs e)
//        {
//            baseField.TypePayment = SearchElementID(TypePaymentText.Text);
//        }

//        private void ClientIDText_DropDownClosed(object sender, EventArgs e)
//        {
//            baseField.ClientsID = Convert.ToInt32(SearchElementID(ClientIDText.Text));
//        }
//    }
//}
