//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
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
//    /// Логика взаимодействия для ClientsAddView.xaml
//    /// </summary>
//    public partial class ClientsAddView : UserControl
//    {
//        BaseField baseField = new BaseField();
//        public ClientsAddView()
//        {
//            InitializeComponent();
//        }

//        private SqlConnection sqlConnection = null;
//        public int ID { get; set; }
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public DateTime DateOFBrith { get; set; }
//        public string Gender { get; set; }
//        public string PhoneNumber { get; set; }
//        public string Passport { get; set; }

//        private void Button_Click(object sender, RoutedEventArgs e)
//        {
//            AddClietnts_();
//        }
//        public void AddClietnts_()
//        {
//            FirstName = FirstNameText.Text;
//            LastName = LastNameText.Text;
//            DateOFBrith = Convert.ToDateTime(DatePickerDateOfBrith.Text);
//            Gender = baseField.Gender;
//            Passport = PassportText.Text;
//            PhoneNumber = PhoneNumberText.Text;
//            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);
//            sqlConnection.Open();
//            if (sqlConnection.State == ConnectionState.Open)
//                MessageBox.Show("подключение успешно");
//            string query = $"INSERT INTO [dbo].[Clients]([Name],[LastName],[DateOfBirth],[Gender],[PhoneNumber],[Passport])VALUES('{FirstName}','{LastName}','{DateOFBrith.Date.Year}-{DateOFBrith.Date.Month}-{DateOFBrith.Date.Day}','{Gender}','{PhoneNumber}','{Passport}')";
//            SqlCommand command = new SqlCommand(query, sqlConnection);
//            command.ExecuteNonQuery();
//        }

//        private void ComboBox_DropDownClosed(object sender, EventArgs e)
//        {
//           baseField.Gender = ComboBoxGender.Text;
//        }
//    }
//}
