using Hotel.View;
using ManageStaffDBApp.Model;
using ManageStaffDBApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ManageStaffDBApp.ViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {
        //все Reservation
        private List<Reservation> allReservationts = DataWorker.GetAllReservations();
        public List<Reservation> AllReservationts
        {
            get { return allReservationts; }
            set
            {
                allReservationts = value;
                NotifyPropertyChanged("AllReservations");
            }
        }

        //все Room
        private List<Room> allRooms = DataWorker.GetAllRooms();
        public List<Room> AllRooms
        {
            get
            {
                return allRooms;
            }
            set
            {
                allRooms = value;
                NotifyPropertyChanged("AllRooms");
            }
        }
        //все сотрудники
        private List<Client> allClient = DataWorker.GetAllClients();
        public List<Client> AllClient
        {
            get
            {
                return allClient;
            }
            set
            {
                allClient = value;
                NotifyPropertyChanged("AllClients");
            }
        }

        //свойства для Reservations
       
        public static DateTime ResCheckInDate { get; set; }
        public static DateTime ResCheckOutDate { get; set; }       
        public static Client ResClient { get; set; }  
        public static Room ResRoom { get; set; }     
        public static string ResReservationStatus { get; set; }        
        public static string RestypePayment { get; set; }
        //свойства для Room
        public static string RomNumber { get; set; }
        public static int RomFloor { get; set; }
        public static string RomType { get; set; }
        public static int RomCapfcity { get; set; }
        public static string RomStatus { get; set; }
        public static string RomPrice { get; set; }

        //свойства для Client
        public static string CliFirstName { get; set; }

        public static string CliLastName { get; set; }

        public static string CliPhoneNumber { get; set; }

        public static string CliGender { get; set; }

        public static string CliPassport { get; set; }

        public DateTime CliDateOfBrith { get; set; }

        //свойства для выделенных элементов
        public TabItem SelectedTabItem { get; set; }
        public static Client SelectedClient { get; set; }
        public static Room SelectedRoom { get; set; }
        public static Reservation SelectedReservation { get; set; }


        #region COMMANDS TO ADD
        private RelayCommand addNewReservation;
        public RelayCommand AddNewReservation
        {
            get
            {
                return addNewReservation ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (ResReservationStatus == null || ResReservationStatus.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "DatePickerCheckInDate");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateReservations(ResCheckInDate, ResCheckOutDate,ResClient, ResRoom, ResReservationStatus, RestypePayment);
                        UpdateAllDataView();

                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }
        private RelayCommand addNewRoom;
        public RelayCommand AddNewRoom
        {
            get
            {
                return addNewRoom ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (RomNumber == null || RomNumber.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "NumberText");
                    }
                   
                    else
                    {
                        resultStr = DataWorker.CreateRooms(RomNumber, RomFloor, RomType, RomCapfcity, RomStatus, RomPrice);
                        UpdateAllDataView();

                        ShowMessageToUser(resultStr);
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                }
                );
            }
        }
        private RelayCommand addNewClient;
        public RelayCommand AddNewClient
        {
            get
            {
                return addNewClient ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resultStr = "";
                    if (CliFirstName == null || CliFirstName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "FirstNameText");
                    }
                    if (CliLastName == null || CliLastName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "LastNameText");
                    }
                    //if (UserPhone == null || UserPhone.Replace(" ", "").Length == 0)
                    //{
                    //    SetRedBlockControll(wnd, "SurNameBlock");
                    //}
                   
                    else
                    {
                        resultStr = DataWorker.CreateClient(CliFirstName, CliLastName, CliPhoneNumber, CliGender, CliPassport, CliDateOfBrith);
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
                    if (SelectedTabItem.Name == "ClientsTab" && SelectedClient != null)
                    {
                        resultStr = DataWorker.DeleteClients(SelectedClient);
                        UpdateAllDataView();
                    }
                    //если позиция
                    if (SelectedTabItem.Name == "RoomsTab" && SelectedRoom != null)
                    {
                        resultStr = DataWorker.DeleteRoom(SelectedRoom);
                        UpdateAllDataView();
                    }
                    //если отдел
                    if (SelectedTabItem.Name == "ReservationsTab" && SelectedReservation != null)
                    {
                        resultStr = DataWorker.DeleteReservations(SelectedReservation);
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
        private RelayCommand editClient;
        public RelayCommand EditClient
        {
            get
            {
                return editClient ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбран сотрудник";
                    string noPositionStr = "Не выбрана новая должность";
                    if (SelectedClient != null)
                    {
                        
                            resultStr = DataWorker.EditClient(SelectedClient, CliFirstName, CliLastName,CliPhoneNumber,CliGender,CliPassport, CliDateOfBrith);

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
        private RelayCommand editRoom;
        public RelayCommand EditPosition
        {
            get
            {
                return editRoom ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбрана позиция";
                    string noDepartmentStr = "Не выбран новый отдел";
                    if (SelectedRoom != null)
                    {
                       
                            resultStr = DataWorker.EditRoom(SelectedRoom,RomNumber,RomFloor,RomType,RomCapfcity,RomStatus,RomPrice);

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

        private RelayCommand editReservation;
        public RelayCommand EditReservation
        {
            get
            {
                return editReservation ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбран отдел";
                    if (SelectedReservation != null)
                    {
                        resultStr = DataWorker.EditReservations(SelectedReservation,ResCheckInDate,ResCheckOutDate,ResClient,ResRoom,ResReservationStatus, RestypePayment);

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
        private RelayCommand openAddNewReservationWnd;
        public RelayCommand OpenAddNewDepartmentWnd
        {
            get
            {
                return openAddNewReservationWnd ?? new RelayCommand(obj =>
                    {
                        OpenAddReservationWindowMethod();
                    }
                    );
            }
        }
        private RelayCommand openAddNewRoomWnd;
        public RelayCommand OpenAddNewPositionWnd
        {
            get
            {
                return openAddNewRoomWnd ?? new RelayCommand(obj =>
                {
                    OpenAddRoomWindowMethod();
                }
                );
            }
        }
        private RelayCommand openAddNewClientWnd;
        public RelayCommand OpenAddNewUserWnd
        {
            get
            {
                return openAddNewClientWnd ?? new RelayCommand(obj =>
                {
                    OpenAddClientWindowMethod();
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
                    if (SelectedTabItem.Name == "ClientsTab" && SelectedClient != null)
                    {
                        OpenEditClientWindowMethod(SelectedClient);
                    }
                    //если позиция
                    if (SelectedTabItem.Name == "RoomsTab" && SelectedRoom != null)
                    {
                        OpenEditRoomWindowMethod(SelectedRoom);
                    }
                    //если отдел
                    if (SelectedTabItem.Name == "ReservationsTab" && SelectedReservation != null)
                    {
                        OpenEditReservationWindowMethod(SelectedReservation);
                    }
                }
                    );
            }
        }
        #endregion

        #region METHODS TO OPEN WINDOW
        //методы открытия окон
        private void OpenAddClientWindowMethod()
        {
            AddClient newClientWindow = new AddClient();
            SetCenterPositionAndOpen(newClientWindow);
        }
        private void OpenAddRoomWindowMethod()
        {
            AddRoom newRoomWindow = new AddRoom();
            SetCenterPositionAndOpen(newRoomWindow);
        }
        private void OpenAddReservationWindowMethod()
        {
           AddReservation newReservationWindow = new AddReservation();
            SetCenterPositionAndOpen(newReservationWindow);
        }
        //окна редактирования
        private void OpenEditReservationWindowMethod(Reservation Reservation)
        {
            EditReservation editDepartmentWindow = new EditReservation(Reservation);
            SetCenterPositionAndOpen(editDepartmentWindow);
        }
        private void OpenEditRoomWindowMethod(Room Room)
        {
            EditRoom editPositionWindow = new EditRoom(Room);
            SetCenterPositionAndOpen(editPositionWindow);
        }
        private void OpenEditClientWindowMethod(Client Client)
        {
            EditClient editUserWindow = new EditClient(Client);
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
           CliFirstName= null;
            CliLastName = null;
            CliGender = null;
            CliPassport = null;
            CliPhoneNumber = null;
            CliDateOfBrith = DateTime.Today;
            //для позиции
           RomCapfcity = 0;
           RomFloor = 0;
           RomNumber = null;
           RomPrice = null;
           RomStatus = null;
           RomType = null;
            //для отдела
            ResCheckInDate = DateTime.Today;
            ResCheckOutDate = DateTime.Today;
            ResClient = null;
            ResRoom = null;
            ResReservationStatus = null;
            RestypePayment = null;
        }
        private void UpdateAllDataView()
        {
            UpdateAllDepartmentsView();
            UpdateAllPositionsView();
            UpdateAllUsersView();
        }

        private void UpdateAllDepartmentsView()
        {
            AllReservationts = DataWorker.GetAllReservations();         
            MainWindow.AllReservationsView.ItemsSource = null;
            MainWindow.AllReservationsView.Items.Clear();
            MainWindow.AllReservationsView.ItemsSource = AllReservationts;
            MainWindow.AllReservationsView.Items.Refresh();
        }
        private void UpdateAllPositionsView()
        {
            AllRooms = DataWorker.GetAllRooms();
            MainWindow.AllRoomsView.ItemsSource = null;
            MainWindow.AllRoomsView.Items.Clear();
            MainWindow.AllRoomsView.ItemsSource = AllRooms;
            MainWindow.AllRoomsView.Items.Refresh();
        }
        private void UpdateAllUsersView()
        {
            AllClient = DataWorker.GetAllClients();
            MainWindow.AllClientsView.ItemsSource = null;
            MainWindow.AllClientsView.Items.Clear();
            MainWindow.AllClientsView.ItemsSource = AllClient;
            MainWindow.AllClientsView.Items.Refresh();
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
