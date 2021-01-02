using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AceTech.Framework;
using AceTech.Framework.Utility;
using AceTech.Main.Model;
using AceTech.Main.View;
using Newtonsoft.Json;

namespace AceTech.Main.ViewModel
{
    public class LoginVM:ViewModelBase
    {
        #region Fields
        static string userJsonFile = "./Model/users.json";
        public static readonly LoginVM loginVM;

        private string userNameValue;
        public string UserName
        {
            get
            {
                return userNameValue;
            }
            set
            {
                if(value!= userNameValue)
                {
                    userNameValue = value;
                    OnPropertyChanged("UserName");
                }
            }
        }

        private string userPwdValue;
        public string UserPwd
        {
            get
            {
                return userPwdValue; 
            }
            set
            {
                if(value!=userPwdValue)
                {
                    userPwdValue = value;
                    OnPropertyChanged("UserPwd");
                }
            }
        }

        
        #endregion

        #region Methods
        static LoginVM()
        {
            loginVM = new LoginVM();
            InitUsersJsonFile();
        }

        private static void InitUsersJsonFile()
        {
            List<UserModel> usersList = new List<UserModel>();
            for(int i=0;i<10;i++)
            {
                UserModel user = new UserModel()
                {
                    UserName = "Fred" + i,
                    UserPwd = Global.GetStringMD5("Fred" + i + i),
                    UserId = i
                };
                usersList.Add(user);
            }
            string usersInfo = JsonConvert.SerializeObject(usersList, Formatting.Indented);
            File.WriteAllText(userJsonFile, usersInfo, Encoding.UTF8); 
        }

        static List<UserModel> ReadJsonFile()
        {
            List<UserModel> usersList = new List<UserModel>();
            string jsonValue = File.ReadAllText(userJsonFile);
            if (!string.IsNullOrWhiteSpace(jsonValue))
            {
                usersList = JsonConvert.DeserializeObject<List<UserModel>>(jsonValue);
                if (usersList != null && usersList.Any())
                {
                    return usersList;
                }
            }
            return null;
        }

       
        #endregion

        #region Commands
        private DelegateCommand loginCmd;
        public DelegateCommand LoginCmd
        {
            get
            {
                if (loginCmd == null)
                {
                    loginCmd = new DelegateCommand(LoginCmdExecuted);
                }
                return loginCmd;
            }
        }

        private void LoginCmdExecuted(object obj)
        {
            var pwdBox = obj as PasswordBox;
            if (pwdBox != null)
            {
                if(string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(pwdBox.Password))
                {
                    MessageBox.Show("UserName or password is empty!");
                    return;
                }
                UserPwd = Global.GetStringMD5(pwdBox.Password);
                List<UserModel> usersList = ReadJsonFile();
                var currentUser = usersList.Where(x => x.UserName == UserName &&
                x.UserPwd == UserPwd).FirstOrDefault();
                if (currentUser != null)
                {
                    LoginWindow.LoginWin.DialogResult = true;
                }
            }
            else
            {
                MessageBox.Show("The username or password is wrong!");
            }
            //Global.LoginSucceed = true;
            //LoginWindow.LoginWin.DialogResult = true;
        }

        private DelegateCommand cancelCmd;
        public DelegateCommand CancelCmd
        {
            get
            {
                if(cancelCmd==null)
                {
                    cancelCmd = new DelegateCommand(CancelCmdExecuted);
                }
                return cancelCmd;
            }
        }

        private void CancelCmdExecuted(object obj)
        {
            if (MessageBox.Show("Are you sure to quit login","Warning",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private DelegateCommand closeCmd;
        public DelegateCommand CloseCmd
        {
            get
            {
                if(closeCmd==null)
                {
                    closeCmd = new DelegateCommand(CloseCmdExecuted);
                }
                return closeCmd;
            }
        }

        private void CloseCmdExecuted(object obj)
        {
            Global.IsClosed = true;
        }
        #endregion

    }
}
