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
//using System.Data;

//namespace TermPaper.MVVM.View
//{
//    /// <summary>
//    /// Логика взаимодействия для ClietnsEditView.xaml
//    /// </summary>
//    public partial class ClietnsEditView : UserControl
//    {
//        BaseField baseField = new BaseField();
//        DataBase dataBase = new DataBase();
//       private SqlConnection sqlConnection = null;
//        public ClietnsEditView()
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

       

//        private void Edit_Loaded(object sender, RoutedEventArgs e)
//        {
            
//            EditComboBoxRefresh();
           
//        }
//        public void EditComboBoxRefresh_2()
//        {
//            dataBase.openConnection();
//            string queryString = $"SELECT * From Clients WHERE ClientsID = {baseField.ClientsID}";
//            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
//            SqlDataReader sqlDataReader = command.ExecuteReader();
//            while (sqlDataReader.Read())
//            {

//                FirstNameTextEdit.Text = sqlDataReader.GetString(1);
//                LastNameTextEdit.Text = sqlDataReader.GetString(2);
//                DatePickerDateOfBrithEdit.Text = Convert.ToString(sqlDataReader.GetDateTime(3));
//                GenderTextEdit.Text = sqlDataReader.GetString(4);
//                PassportTextEdit.Text = sqlDataReader.GetString(5);
//                PhoneNumberTextEdit.Text = sqlDataReader.GetString(6);
 
//            }
//            dataBase.closeConnection();
//        }

//        private void ComboBoxEdit_DropDownClosed(object sender, EventArgs e)
//        {
            
//            baseField.ClientsID = Convert.ToInt32(SearchElementID(ComboBoxEdit.Text));
//            EditComboBoxRefresh_2();
           
//        }
//        public void EditComboBoxRefresh()
//        {
//            dataBase.openConnection();
//            string queryString = "SELECT * From Clients";
//            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
//            SqlDataReader sqlDataReader = command.ExecuteReader();
//            ComboBoxEdit.Items.Clear();
//            while (sqlDataReader.Read())
//            {
//                int ClientsId = sqlDataReader.GetInt32(0);
//                string FirstName = sqlDataReader.GetString(1);
//                string LastName = sqlDataReader.GetString(2);
//                ComboBoxEdit.Items.Add($"{ClientsId}: {FirstName}: {LastName}");
//            }
//            dataBase.closeConnection();
//        }

//        private void Button_Click(object sender, RoutedEventArgs e)
//        {
//            dataBase.openConnection();
//            baseField.DateOFBrith = Convert.ToDateTime(DatePickerDateOfBrithEdit.Text);
//            string query = $"UPDATE [dbo].[Clients] SET [Name] = '{FirstNameTextEdit.Text}', [LastName] = '{LastNameTextEdit.Text}', [DateOfBirth] = '{baseField.DateOFBrith.Date.Year}-{baseField.DateOFBrith.Date.Month}-{baseField.DateOFBrith.Date.Day}', [Gender] = '{GenderTextEdit.Text}', [PhoneNumber] = '{PhoneNumberTextEdit.Text}', [Passport] = '{PassportTextEdit.Text}' WHERE ClientsID = {baseField.ClientsID}";
//            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
//            command.ExecuteNonQuery();
//            EditComboBoxRefresh();
//            dataBase.closeConnection();
//        }

//        private void GenderTextEdit_DropDownClosed(object sender, EventArgs e)
//        {
//            baseField.Gender = ComboBoxEdit.Text;
//        }
//    }
//}
