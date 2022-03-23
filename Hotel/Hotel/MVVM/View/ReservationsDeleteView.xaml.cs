//using System;
//using System.Collections.Generic;
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
//using System.Data.SqlClient;
//using System.Configuration;

//namespace TermPaper.MVVM.View
//{
//    /// <summary>
//    /// Логика взаимодействия для ReservationsDeleteView.xaml
//    /// </summary>
//    public partial class ReservationsDeleteView : UserControl
//    {
//        DataBase dataBase = new DataBase();
//        BaseField baseField = new BaseField();
//        public ReservationsDeleteView()
//        {
//            InitializeComponent();
//        }

//        public void ComboBoxDeleteRefresh()
//        {
//            dataBase.openConnection();
//            string queryString = "SELECT * From Reservations";
//            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
//            SqlDataReader sqlDataReader = command.ExecuteReader();
//            ComboBoxDelete.Items.Clear();
//            while (sqlDataReader.Read())
//            {
//                int ReservationId = sqlDataReader.GetInt32(0);
//                DateTime InDate = sqlDataReader.GetDateTime(1);
//                DateTime OutDate = sqlDataReader.GetDateTime(2);
//                int RoomId = sqlDataReader.GetInt32(3);
//                int ClientId = sqlDataReader.GetInt32(6);
//                ComboBoxDelete.Items.Add($"{ReservationId}: НОМЕР - {RoomId} КЛИЕНТ - {ClientId} ({InDate}-{OutDate})");
//            }
//            dataBase.closeConnection();
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
//        private void ComboBoxDelete_DropDownClosed(object sender, EventArgs e)
//        {
//            baseField.ReservationsId = Convert.ToInt32(SearchElementID(ComboBoxDelete.Text));
//        }

//        private void ReservationsDeleteView1_Loaded(object sender, RoutedEventArgs e)
//        {
//            ComboBoxDeleteRefresh();
//        }

//        private void Button_Click(object sender, RoutedEventArgs e)
//        {
//            dataBase.openConnection();
//            string query = $"Delete From [dbo].[Reservations] WHERE ReservationsID = {baseField.ReservationsId}";
//            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
//            command.ExecuteNonQuery();
//            ComboBoxDeleteRefresh();
//            dataBase.closeConnection();
//        }

//        private void ComboBoxDelete_SelectionChanged(object sender, SelectionChangedEventArgs e)
//        {

//        }
//    }
//}
