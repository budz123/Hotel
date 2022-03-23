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
//    / <summary>
//    / Логика взаимодействия для RoomsEditView.xaml
//    / </summary>
//    public partial class RoomsEditView : UserControl
//    {
//        public RoomsEditView()
//        {
//            InitializeComponent();
//        }
//        BaseField baseField = new BaseField();
//        DataBase dataBase = new DataBase();


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
//        public void RoomsComboBoxRefresh_2()
//        {
//            dataBase.openConnection();
//            string queryString = $"SELECT * From Rooms WHERE RoomsID = {baseField.RoomsId}";
//            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
//            SqlDataReader sqlDataReader = command.ExecuteReader();
//            while (sqlDataReader.Read())
//            {

//                NumberText.Text = sqlDataReader.GetString(1);
//                ComboBoxFloorText.Text = Convert.ToString(sqlDataReader.GetInt32(2));
//                ComboBoxTypeText.Text = sqlDataReader.GetString(3);
//                ComboBoxCapfcityText.Text = Convert.ToString(sqlDataReader.GetInt32(4));
//                ComboBoxStatusText.Text = sqlDataReader.GetString(5);
//                PriceText.Text = sqlDataReader.GetString(6);

//            }
//            dataBase.closeConnection();
//        }

//        private void ComboBox_DropDownClosed(object sender, EventArgs e)
//        {
//            baseField.RoomsId = Convert.ToInt32(SearchElementID(ComboBoxEdit.Text));
//            RoomsComboBoxRefresh_2();
//        }

//        private void Button_Click(object sender, RoutedEventArgs e)
//        {
//            dataBase.openConnection();
//            string query = $"UPDATE  [dbo].[Rooms] SET [Number] = '{NumberText.Text}', [Floor] = '{ComboBoxFloorText.Text}', [Type] = '{ComboBoxTypeText.Text}', [Capfcity] = '{ComboBoxCapfcityText.Text}', [Status] = '{ComboBoxStatusText.Text}', [Price] = '{PriceText.Text}' WHERE RoomsID = {baseField.RoomsId}";
//            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
//            command.ExecuteNonQuery();
//            RoomsComboBoxRefresh();
//            dataBase.closeConnection();
//        }
//        public void RoomsComboBoxRefresh()
//        {
//            dataBase.openConnection();
//            string queryString = "SELECT * From Rooms";
//            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
//            SqlDataReader sqlDataReader = command.ExecuteReader();
//            ComboBoxEdit.Items.Clear();
//            while (sqlDataReader.Read())
//            {
//                int RoomsID = sqlDataReader.GetInt32(0);
//                string Number = sqlDataReader.GetString(1);
//                ComboBoxEdit.Items.Add($"{RoomsID}: {Number}");
//            }
//            dataBase.closeConnection();
//        }

//        private void ComboBoxEdit_SelectionChanged(object sender, SelectionChangedEventArgs e)
//        {

//        }

//        private void UserControl_Loaded(object sender, RoutedEventArgs e)
//        {

//            RoomsComboBoxRefresh();
//        }
//    }
//}
