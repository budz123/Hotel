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
//    /// Логика взаимодействия для RoomsAddView.xaml
//    /// </summary>
//    public partial class RoomsAddView : UserControl
//    {
//        BaseField baseField = new BaseField();
//        private SqlConnection sqlConnection = null;
//        public RoomsAddView()
//        {
//            InitializeComponent();
//        }

//        private void TypeText_SelectionChanged(object sender, SelectionChangedEventArgs e)
//        {

//        }
//        private void AddRooms()
//        {
//            baseField.Number = NumberText.Text;
//            baseField.Floor = Convert.ToInt32(ComboBoxFloorText.Text);
//            baseField.Type = ComboBoxTypeText.Text;
//            baseField.Capcfcity = Convert.ToInt32(ComboBoxCapfcityText.Text);
//            baseField.Status = ComboBoxStatusText.Text;
//            baseField.Price = PriceText.Text;
//            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);
//            sqlConnection.Open();
//            if (sqlConnection.State == ConnectionState.Open)
//                MessageBox.Show("подключение успешно");
//            string query = $"INSERT INTO [dbo].[Rooms]([Number],[Floor],[Type],[Capfcity],[Status],[Price])VALUES('{baseField.Number}', '{baseField.Floor}', '{baseField.Type}', '{baseField.Capcfcity}', '{baseField.Status}', '{baseField.Price}')";
//            SqlCommand command = new SqlCommand(query, sqlConnection);
//            command.ExecuteNonQuery();
//        }

//        private void Button_Click(object sender, RoutedEventArgs e)
//        {
//            AddRooms();
//        }
//    }
//}
