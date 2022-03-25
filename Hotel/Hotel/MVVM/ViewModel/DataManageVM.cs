using Hotel.MVVM.Model;
using Hotel.MVVM.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Hotel.Model;

namespace ManageStaffDBApp.ViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {
        //все отделы
        private List<Clients> allClients = DataWorker.GetAllClients();
        public List<Clients> AllClients
        {
            get { return allClients; }
            set
            {
                allClients = value;
                NotifyPropertyChanged("allClients");
            }
        }

        //все позиции
        private List<Rooms> allRooms = DataWorker.GetAllRooms();
        public List<Rooms> AllRooms
        {
            get
            {
                return allRooms;
            }
            private set
            {
                allRooms = value;
                NotifyPropertyChanged("AllRooms");
            }
        }
        //все сотрудники
        private List<Reservations> allReservations = DataWorker.GetAllReservations();
        public List<Reservations> AllReservations
        {
            get
            {
                return allReservations;
            }
            private set
            {
                allReservations = value;
                NotifyPropertyChanged("AllallReservations");
            }
        }

        //свойства для Rooms
        public static string oldrooms { get; set; }
        public static string Number { get; set; }
        public static int Floor { get; set; }
        public static string Type { get; set; }
        public static int Capfcity { get; set; }
        public static string Status { get; set; }
        public static string Price { get; set; }

        //свойства для Resrvations
        public static string oldRes { get; set; }
        public static DateTime CheckInDate { get; set; }
        public static DateTime CheckOutDate { get; set; }
        public static Rooms Rooms { get; set; }
        public static string ReservationStatus { get; set; }
        public static string typePayment { get; set; }
        public static Clients Clients { get; set; }

        //свойства для Clients
        public static string oldC { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string PhoneNumber { get; set; }
        public static string Gender { get; set; }
        public static string Passport{ get; set; }
        public static DateTime DateOfBrith { get; set; }
   

        //свойства для выделенных элементов
        public TabItem SelectedTabItem { get; set; }
        public static Clients SelectedClients { get; set; }
        public static Rooms SelectedRooms { get; set; }
        public static Reservations SelectedReservations { get; set; }


        #region COMMANDS TO ADD
        private RelayCommand addClients;
        public RelayCommand AddClients
        {
            get
            {
                return addClients ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (FirstName == null || FirstName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "NameBlock");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateClients(FirstName,LastName,PhoneNumber,Gender,Passport,DateOfBrith);
                        UpdateAllDataView();

                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }
        private RelayCommand addRooms;
        public RelayCommand AddRooms
        {
            get
            {
                return addRooms ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if(Number == null || Number.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "NameBlock");
                    }
                   
                    else
                    {
                        resultStr = DataWorker.CreateRooms(Number,Floor,Type,Capfcity,Status,Price);
                        UpdateAllDataView();

                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }
        private RelayCommand addReservations;
        public RelayCommand AddReservations
        {
            get
            {
                return addReservations ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (ReservationStatus == null || ReservationStatus.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "NameBlock");
                    }
                   
                    else
                    {
                        resultStr = DataWorker.CreateReservations(CheckInDate, CheckOutDate,Rooms,ReservationStatus,typePayment,Clients);
                        UpdateAllDataView();

                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }

        #endregion

        private RelayCommand deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    //если сотрудник
                    if(SelectedTabItem.Name == "UsersTab" && SelectedClients != null)
                    {
                        resultStr = DataWorker.DeleteClients(SelectedClients);
                        UpdateAllDataView();
                    }
                    //если позиция
                    if (SelectedTabItem.Name == "PositionsTab" && SelectedRooms != null)
                    {
                        resultStr = DataWorker.DeleteRooms(SelectedRooms);
                        UpdateAllDataView();
                    }
                    //если отдел
                    if (SelectedTabItem.Name == "DepartmentsTab" && SelectedReservations != null)
                    {
                        resultStr = DataWorker.DeleteReservationst(SelectedReservations);
                        UpdateAllDataView();
                    }
                    //обновление
                    SetNullValuesToProperties();
                    ShowMessageToUser(resultStr);
                }
                    );
            }
        }

        #region EDIT COMMANDS
        private RelayCommand editClients;
        public RelayCommand EditClients
        {
            get
            {
                return editClients ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбран сотрудник";
                    string noPositionStr = "Не выбрана новая должность";
                    if(SelectedClients != null)
                    {
                        if(SelectedClients != null)
                        {
                            resultStr = DataWorker.EditClients(SelectedClients,FirstName,LastName,PhoneNumber,Gender,Passport,DateOfBrith);

                            UpdateAllDataView();
                            SetNullValuesToProperties();
                            ShowMessageToUser(resultStr);
                            window.Close();
                        }
                        else ShowMessageToUser(noPositionStr);
                    }
                    else ShowMessageToUser(resultStr);

                }
                );
            }
        }
        private RelayCommand editRooms;
        public RelayCommand EditRooms
        {
            get
            {
                return editRooms ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбрана позиция";
                    string noDepartmentStr = "Не выбран новый отдел";
                    if (SelectedRooms != null)
                    {
                        if (SelectedRooms != null)
                        {
                            resultStr = DataWorker.EditRooms(SelectedRooms,Number,Floor,typePayment,Capfcity,Status,Price);

                            UpdateAllDataView();
                            SetNullValuesToProperties();
                            ShowMessageToUser(resultStr);
                            window.Close();
                        }
                        else ShowMessageToUser(noDepartmentStr);
                    }
                    else ShowMessageToUser(resultStr);

                }
                );
            }
        }

        private RelayCommand editReservations;
        public RelayCommand EditDepartment
        {
            get
            {
                return editReservations ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбран отдел";
                    if (SelectedReservations != null)
                    {
                        resultStr = DataWorker.EditReservationst(SelectedReservations,CheckInDate,CheckOutDate,Rooms,ReservationStatus,typePayment,Clients);

                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        ShowMessageToUser(resultStr);
                        window.Close();
                    }
                    else ShowMessageToUser(resultStr);

                }
                );
            }
        }
        #endregion

        #region COMMANDS TO OPEN WINDOWS
        private RelayCommand openAddNewDepartmentWnd;
        public RelayCommand OpenAddNewDepartmentWnd
        {
            get
            {
                return openAddNewDepartmentWnd ?? new RelayCommand(obj =>
                    {
                        OpenAddDepartmentWindowMethod();
                    }
                    );
            }
        }
        private RelayCommand openAddNewPositionWnd;
        public RelayCommand OpenAddNewPositionWnd
        {
            get
            {
                return openAddNewPositionWnd ?? new RelayCommand(obj =>
                {
                    OpenAddPositionWindowMethod();
                }
                );
            }
        }
        private RelayCommand openAddNewUserWnd;
        public RelayCommand OpenAddNewUserWnd
        {
            get
            {
                return openAddNewUserWnd ?? new RelayCommand(obj =>
                {
                    OpenAddUserWindowMethod();
                }
                );
            }
        }
        private RelayCommand openEditItemWnd;
        public RelayCommand OpenEditItemWnd
        {
            get
            {
                return openEditItemWnd ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    //если сотрудник
                    if (SelectedTabItem.Name == "UsersTab" && SelectedClients != null)
                    {
                        OpenEditUserWindowMethod(SelectedClients);
                    }
                    //если позиция
                    if (SelectedTabItem.Name == "PositionsTab" && SelectedReservations != null)
                    {
                        OpenEditPositionWindowMethod(SelectedReservations);
                    }
                    //если отдел
                    if (SelectedTabItem.Name == "DepartmentsTab" && SelectedRooms != null)
                    {
                        OpenEditDepartmentWindowMethod(SelectedRooms);
                    }
                }
                    );
            }
        }
        #endregion

        #region METHODS TO OPEN WINDOW
        //методы открытия окон
        private void OpenAddDepartmentWindowMethod()
        {
            AddNewDepartmentWindow newDepartmentWindow = new AddNewDepartmentWindow();
            SetCenterPositionAndOpen(newDepartmentWindow);
        }
        private void OpenAddPositionWindowMethod()
        {
            AddNewPositionWindow newPositionWindow = new AddNewPositionWindow();
            SetCenterPositionAndOpen(newPositionWindow);
        }
        private void OpenAddUserWindowMethod()
        {
            AddNewUserWindow newUserWindow = new AddNewUserWindow();
            SetCenterPositionAndOpen(newUserWindow);
        }
        //окна редактирования
        private void OpenEditDepartmentWindowMethod(Department department)
        {
            EditDepartmentWindow editDepartmentWindow = new EditDepartmentWindow(department);
            SetCenterPositionAndOpen(editDepartmentWindow);
        }
        private void OpenEditPositionWindowMethod(Position position)
        {
            EditPositionWindow editPositionWindow = new EditPositionWindow(position);
            SetCenterPositionAndOpen(editPositionWindow);
        }
        private void OpenEditUserWindowMethod(User user)
        {
            EditUserWindow editUserWindow = new EditUserWindow(user);
            SetCenterPositionAndOpen(editUserWindow);
        }
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        #endregion

        private void SetRedBlockControll(Window wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }

        #region UPDATE VIEWS
        private void SetNullValuesToProperties()
        {
            //для пользователя
            UserName = null;
            UserSurName = null;
            UserPhone = null;
            UserPosition = null;
            //для позиции
            PositionName = null;
            PositionSalary = 0;
            PositionMaxNumber = 0;
            PositionDepartment = null;
            //для отдела
            DepartmentName = null;
        }
        private void UpdateAllDataView()
        {
            UpdateAllDepartmentsView();
            UpdateAllPositionsView();
            UpdateAllUsersView();
        }

        private void UpdateAllDepartmentsView()
        {
            AllDepartments = DataWorker.GetAllDepartments();
            MainWindow.AllDepartmentsView.ItemsSource = null;
            MainWindow.AllDepartmentsView.Items.Clear();
            MainWindow.AllDepartmentsView.ItemsSource = AllDepartments;
            MainWindow.AllDepartmentsView.Items.Refresh();
        }
        private void UpdateAllPositionsView()
        {
            AllPositions = DataWorker.GetAllPositions();
            MainWindow.AllPositionsView.ItemsSource = null;
            MainWindow.AllPositionsView.Items.Clear();
            MainWindow.AllPositionsView.ItemsSource = AllPositions;
            MainWindow.AllPositionsView.Items.Refresh();
        }
        private void UpdateAllUsersView()
        {
            AllUsers = DataWorker.GetAllUsers();
            MainWindow.AllUsersView.ItemsSource = null;
            MainWindow.AllUsersView.Items.Clear();
            MainWindow.AllUsersView.ItemsSource = AllUsers;
            MainWindow.AllUsersView.Items.Refresh();
        }
        #endregion

        private void ShowMessageToUser(string message)
        {
            MessageView messageView = new MessageView(message);
            SetCenterPositionAndOpen(messageView);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
