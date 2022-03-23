//using System;
//using System.Collections.Generic;
//using System.Configuration;
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
//    /// Логика взаимодействия для RoomsDeleteView.xaml
//    /// </summary>
//    public partial class RoomsDeleteView : UserControl
//    {
//        DataBase dataBase = new DataBase();
//        public RoomsDeleteView()
//        {
//            InitializeComponent();
//        }

//        BaseField baseField = new BaseField();
//        private SqlConnection sqlConnection = null;


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

      
//        public void RoomsComboBoxRefresh()
//        {
//            dataBase.openConnection();
//            string queryString = "SELECT * From Rooms";
//            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
//            SqlDataReader sqlDataReader = command.ExecuteReader();
//            ComboBoxDelete.Items.Clear();
//            while (sqlDataReader.Read())
//            {
//                int RoomsId = sqlDataReader.GetInt32(0);
//                string Number = sqlDataReader.GetString(1);
              
//                ComboBoxDelete.Items.Add($"{RoomsId}: {Number}");
//            }
//            dataBase.closeConnection();
//        }

       

       

//        private void ComboBoxDelete_DropDownClosed(object sender, EventArgs e)
//        {
//            baseField.RoomsId = Convert.ToInt32(SearchElementID(ComboBoxDelete.Text));
//        }

//        private void Button_Click(object sender, RoutedEventArgs e)
//        {
//            dataBase.openConnection();
//            string query = $"Delete From [dbo].[Rooms] WHERE RoomsID= {baseField.RoomsId}";
//            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
//            command.ExecuteNonQuery();
//            RoomsComboBoxRefresh();
//            dataBase.closeConnection();
//        }

//        private void delete_Loaded(object sender, RoutedEventArgs e)
//        {
           
//            RoomsComboBoxRefresh();
//        }

//        private void ComboBoxDelete_SelectionChanged(object sender, SelectionChangedEventArgs e)
//        {

//        }
//    }
//}

