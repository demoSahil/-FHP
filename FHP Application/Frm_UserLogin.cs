﻿using FHP_BL;
using FHP_DL;
using FHP_ValueObject;
using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FHP_Application
{
    /// <summary>
    /// Represents the user login form.
    /// </summary>
    public partial class Frm_UserLogin : Form
    {
        //---------------------------------Date Members ----------------------------------\\

        /// <summary>
        /// Represents the current user.
        /// </summary>
        cls_User_VO currentUser;

        /// <summary>
        /// Object for user validation.
        /// </summary>
        cls_ValidateUser_BL validateUser;

        /// <summary>
        /// flg for checking whether user is valid or not
        /// </summary>
        bool userValid;

        /// <summary>
        /// Dictionary containing the current user's permissions, indicating access rights for various operations.
        /// </summary>
        Dictionary<string, bool> currentUserPermissions;

        IDataHandlerUser dataHandlerUser;
        IDataHandlerEmployee dataHandlerEmp;


        //---------------------------------Constructor----------------------------------\\

        /// <summary>
        /// Represents the user login form with provided data handler interfaces for user and employee data.
        /// </summary>
        /// <param name="dataHandlerEmp">Interface for handling employee data.</param>
        /// <param name="dataHandlerUser">Interface for handling user data.</param>
        public Frm_UserLogin(IDataHandlerEmployee dataHandlerEmp,IDataHandlerUser dataHandlerUser)
        {
            InitializeComponent();

            this.dataHandlerUser = dataHandlerUser;
            this.dataHandlerEmp = dataHandlerEmp;
            
            currentUser = new cls_User_VO();
            validateUser = new cls_ValidateUser_BL(dataHandlerUser);

        }

        //---------------------------------Events----------------------------------\\

        /// <summary>
        /// Handles the Click event of the login button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btn_login_Click(object sender, EventArgs e)
        {
            //Getting Username and Password entered by User
            currentUser.UserName = txtBox_userName.Text;
            currentUser.Password = txtBox_password.Text;

            bool isCredentialsValid = false ;

            // Authenticating User
            try
            {
                isCredentialsValid = validateUser.isUserPresent(currentUser);
            }
            catch(cls_BusinessLayerException ex)
            {
                MessageBox.Show(ex.Message,"Something Went Wrong");
            }

            if (isCredentialsValid)
            {
                userValid = true;
                currentUserPermissions = validateUser.GetUserPermission(currentUser);

                this.Visible = false;
                Frm_MainView mainView = new Frm_MainView(currentUserPermissions, currentUser,dataHandlerEmp);
                mainView.ShowDialog();
                this.Close();
            }

            else
            {
                MessageBox.Show(currentUser.ErrorMessage, "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);

                currentUser.ErrorMessage = string.Empty; //making error messageEmpty so that user can reenter credentials
            }
        }

        /// <summary>
        /// Handles the FormClosing event of the user login form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void Frm_UserLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!userValid)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    userValid = true;
                    Application.Exit();
                }
            }

        }
    }
}
