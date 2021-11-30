using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Data.SqlClient;

namespace Palmer_PhoneBook
{
    public partial class DataEntry : Form
    {
        // my connection string
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDb;AttachDbFilename=|datadirectory|\Palmer_PhoneBook.mdf;Integrated Security=True;Connect Timeout=30";
        //string connectionString = @"Data source=(localdb)\MSSQLLocalDB;AttachdbFilename=C:\Users\Apex1\Palmer_PhoneBook.mdf;integrated Security=true;Connect Timeout=30;";
        Contact myContact;
        (bool, string) validContact;
        (bool, string) validLength;
        string oldCellValue = string.Empty;

        public DataEntry()
        {
            InitializeComponent();
        }

        private void DataEntry_Load(object sender, EventArgs e)
        {
            cellNumTxt.MaskInputRejected += new MaskInputRejectedEventHandler(cellPhone_InputRejected);
            workNumTxt.MaskInputRejected += new MaskInputRejectedEventHandler(workPhone_InputRejected);
            stateTxt.MaskInputRejected += new MaskInputRejectedEventHandler(state_InputRejected);
            zipTxt.MaskInputRejected += new MaskInputRejectedEventHandler(zipTxt_InputRejected);
        }
        private void cellPhone_InputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (cellNumTxt.MaskFull)
            {
                toolTip1.ToolTipTitle = "Max Numbers";
                toolTip1.Show("Maximum number of digits reached", cellNumTxt,3000);
            }
            else if (e.Position == cellNumTxt.Mask.Length)
            {
                toolTip1.ToolTipTitle = "End of Number";
                toolTip1.Show("You can not add extra digits, 10 digits only", cellNumTxt,3000);
            }
            else
            {
                toolTip1.ToolTipTitle = "Invalid Input";
                toolTip1.Show("Invalid input, only digits 0-9 allowed", cellNumTxt,3000);
            }
        }
        private void workPhone_InputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (workNumTxt.MaskFull)
            {
                toolTip1.ToolTipTitle = "Max Numbers";
                toolTip1.Show("Maximum number of digits reached", workNumTxt,3000);
            }
            else if (e.Position == cellNumTxt.Mask.Length)
            {
                toolTip1.ToolTipTitle = "End of Number";
                toolTip1.Show("You can not add extra digits, 10 digits only", workNumTxt,3000);
            }
            else
            {
                toolTip1.ToolTipTitle = "Invalid Input";
                toolTip1.Show("Invalid input, only digits 0-9 allowed", workNumTxt,3000);
            }
        }
        private void state_InputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (stateTxt.MaskFull)
            {
                toolTip1.ToolTipTitle = "Input Error";
                toolTip1.Show("Only state abreveations are allowed", stateTxt,3000);
            }
            else if (e.Position == stateTxt.Mask.Length)
            {
                toolTip1.ToolTipTitle = "Abreviations only";
                toolTip1.Show("Make sure you enter state abreviations only",stateTxt,3000);
            }
            else
            {
                toolTip1.ToolTipTitle = "Invalid Input";
                toolTip1.Show("Invalid input, only a-z or A-Z accepted", stateTxt,3000);
            }
        }
        private void zipTxt_InputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (zipTxt.MaskFull)
            {
                toolTip1.ToolTipTitle = "Max Numbers";
                toolTip1.Show("Maximum number of digits reached", zipTxt,3000);
            }
            else if (e.Position == cellNumTxt.Mask.Length)
            {
                toolTip1.ToolTipTitle = "End of Zipcode";
                toolTip1.Show("You can not add extra digits, 6 digits only", zipTxt,3000);
            }
            else
            {
                toolTip1.ToolTipTitle = "Invalid Input";
                toolTip1.Show("Invalid input, only digits 0-9 allowed", zipTxt,3000);
            }
        }

        private void searchNameBtn_Click(object sender, EventArgs e)
        {
            validContact = ValidateLastNameSearch();

            if (validContact.Item1)
            {
                try
                {
                    string sqlCommd = "SELECT * FROM PHONEBOOK " +
                        "WHERE Lastname = @Lastname OR Lastname LIKE @lastnameWC "+
                        " ORDER BY Lastname";
                    // if name not found use this to requery
                    string sqlCommd2 = "SELECT * FROM PHONEBOOK" +
                        " ORDER BY Lastname";

                    // make instacne of contact just with last name
                    myContact = new Contact();
                    myContact.Lastname = lastNameToolTxt.Text.Trim();

                    using (IDbConnection db = new SqlConnection(connectionString))
                    {

                        string lastnameWildCard = myContact.Lastname + '%';
                        DynamicParameters parameters = new DynamicParameters();
                        parameters.Add("@Lastname", myContact.Lastname, DbType.String, ParameterDirection.Input);
                        parameters.Add("@lastnameWC", lastnameWildCard, DbType.String, ParameterDirection.Input);

                        List<Contact> selectedContactList = new List<Contact>();

                        selectedContactList = db.Query<Contact>(sqlCommd, parameters).ToList();

                        if (selectedContactList.Count == 0)
                        {
                            MessageBox.Show($"No Records for {myContact.lastName} found", "Entry Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // if last name not found then display all contacts
                            List<Contact> allContactList = db.Query<Contact>(sqlCommd2).ToList();
                            contactsView.DataSource = allContactList;
                        }
                        else
                            contactsView.DataSource = selectedContactList;

                    }
                }
                catch (Exception ex)
                { DisplayErrorMsg(ex.Message, "Database Error"); }
            }
            else
                DisplayErrorMsg(validContact.Item2, "Missing or Invalid Input");
        }


        private void browseToolBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlCommd = "SELECT * FROM PHONEBOOK ORDER BY Lastname";

                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    List<Contact> ContactList = new List<Contact>();

                    ContactList = db.Query<Contact>(sqlCommd).ToList();

                    if (ContactList.Count == 0)
                    {
                        MessageBox.Show("Contact list is empty");
                    }
                    else
                        contactsView.DataSource = ContactList;
                }
            }
            catch (Exception ex)
            { DisplayErrorMsg(ex.Message, "Database Error"); }
        }

      
        private void addBtn_Click(object sender, EventArgs e)
        {
            // make sure all fields have values
            validContact = ValidateContact();

            if (validContact.Item1)
            {
                // make sure the values are the right length then process
                validLength = ValidateStringLength();

                if (validLength.Item1)
                {
                    try
                    {
                        // make an instance of contact class with user input
                        myContact = new Contact();
                        int pID = PersonIDToInt(personIdTxt.Text.Trim());
                        myContact.SetContact(pID, firstNameTxt.Text.Trim(), lastNameTxt.Text.Trim(), cellNumTxt.Text.Trim(), workNumTxt.Text.Trim());
                        myContact.SetAddress(addressTxt.Text.Trim(), cityTxt.Text.Trim(), stateTxt.Text.Trim(), zipTxt.Text.Trim());

                        // if the notes is not null then set notes
                        if (!string.IsNullOrEmpty(notesTxt.Text))
                            myContact.notes = notesTxt.Text;

                        string sqlCmmd = "INSERT INTO PhoneBook " +
                            "VALUES(@Firstname,@Lastname,@Address,@City,@State,@Zipcode,@CellPhone,@WorkPhone,@Notes)";

                        int rowsInserted = 0;

                        using (IDbConnection db = new SqlConnection(connectionString))
                        {
                            DynamicParameters parameters = new DynamicParameters();

                            parameters.Add("@Firstname", myContact.Firstname, DbType.String, ParameterDirection.Input);
                            parameters.Add("@Lastname", myContact.Lastname, DbType.String, ParameterDirection.Input);
                            parameters.Add("@Address", myContact.Address, DbType.String, ParameterDirection.Input);
                            parameters.Add("@City", myContact.City, DbType.String, ParameterDirection.Input);
                            parameters.Add("@State", myContact.State, DbType.String, ParameterDirection.Input);
                            parameters.Add("@Zipcode", myContact.Zipcode, DbType.String, ParameterDirection.Input);
                            parameters.Add("@CellPhone", myContact.CellPhone, DbType.String, ParameterDirection.Input);
                            parameters.Add("@WorkPhone", myContact.WorkPhone, DbType.String, ParameterDirection.Input);
                            parameters.Add("@Notes", myContact.Notes, DbType.String, ParameterDirection.Input);

                            rowsInserted = db.Execute(sqlCmmd, parameters);
                            ClearForm();
                            MessageBox.Show($"{rowsInserted} contact(s) has been inserted");

                        }
                    }
                    catch (Exception ex)
                    { DisplayErrorMsg(ex.Message, "Database Error"); }
                }
                else
                    DisplayErrorMsg(validLength.Item2, "Invalid data length");
                
            }
            else
                DisplayErrorMsg(validContact.Item2, "Missing or Invalid Input");
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            // check fields for null or empty
            validContact = ValidateContact();

            if (validContact.Item1)
            {
                // check length of input data then process
                validLength = ValidateStringLength();

                if (validLength.Item1)
                {
                    try
                    {
                        myContact = new Contact();
                        int pId = PersonIDToInt(personIdTxt.Text.Trim());
                        myContact.SetContact(pId, firstNameTxt.Text.Trim(), lastNameTxt.Text.Trim(), cellNumTxt.Text.Trim(), workNumTxt.Text.Trim());
                        myContact.SetAddress(addressTxt.Text.Trim(), cityTxt.Text.Trim(), stateTxt.Text.Trim(), zipTxt.Text.Trim());

                        // if the notes is not null then set notes
                        if (!string.IsNullOrEmpty(notesTxt.Text))
                            myContact.notes = notesTxt.Text;

                        string sqlCmmd = "UPDATE PHONEBOOK " +
                            "SET Firstname = @firstName," +
                            "   Lastname = @lastName," +
                            "   Address = @address," +
                            "   City = @city," +
                            "   State = @state," +
                            "   Zipcode = @zipCode," +
                            "   CellPhone = @cellPhone," +
                            "   WorkPhone = @workPhone," +
                            "   Notes = @notes" +
                            " WHERE person_id = @person_Id";
                        int rowsUpdated = 0;

                        using (IDbConnection db = new SqlConnection(connectionString))
                        {
                            DynamicParameters parameters = new DynamicParameters();

                            parameters.Add("@person_Id", myContact.Person_ID, DbType.Int32, ParameterDirection.Input);
                            parameters.Add("@firstName", myContact.Firstname, DbType.String, ParameterDirection.Input);
                            parameters.Add("@lastName", myContact.Lastname, DbType.String, ParameterDirection.Input);
                            parameters.Add("@address", myContact.Address, DbType.String, ParameterDirection.Input);
                            parameters.Add("@city", myContact.City, DbType.String, ParameterDirection.Input);
                            parameters.Add("@state", myContact.State, DbType.String, ParameterDirection.Input);
                            parameters.Add("@zipCode", myContact.Zipcode, DbType.String, ParameterDirection.Input);
                            parameters.Add("@cellPhone", myContact.CellPhone, DbType.String, ParameterDirection.Input);
                            parameters.Add("@workPhone", myContact.WorkPhone, DbType.String, ParameterDirection.Input);
                            parameters.Add("@notes", myContact.Notes, DbType.String, ParameterDirection.Input);

                            rowsUpdated = db.Execute(sqlCmmd, parameters);
                            if (rowsUpdated == 0)
                                MessageBox.Show("Unable to update, no mathcing Person ID", "No Matching ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                            {
                                ClearForm();
                                MessageBox.Show($"{rowsUpdated} contact has been updated");
                            }
                        }
                    }
                    catch (Exception ex)
                    { DisplayErrorMsg(ex.Message, "Database Error"); }
                }
                else
                    DisplayErrorMsg(validLength.Item2, "Invalid data length");
                
            }
            else
                DisplayErrorMsg(validContact.Item2, "Missing or Invalid Input");

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(personIdTxt.Text))
            {
                try
                {
                    myContact = new Contact();
                    int pId = PersonIDToInt(personIdTxt.Text.Trim());
                    myContact.personId = pId;
                    string sqlCmmd = "DELETE PHONEBOOK WHERE Person_Id = @person_id";

                    int rowsDeleted;

                    using (IDbConnection db = new SqlConnection(connectionString))
                    {
                        DynamicParameters parameters = new DynamicParameters();

                        parameters.Add("@person_id", myContact.Person_ID, DbType.Int32, ParameterDirection.Input);

                        rowsDeleted = db.Execute(sqlCmmd, parameters);
                        if (rowsDeleted == 0)
                        {
                            MessageBox.Show("Id number invalid or not found no contact(s) were deleted", "No Contacts Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                        }
                        else
                        {
                            ClearForm();
                            MessageBox.Show($"{rowsDeleted} contact has been deleted");
                        }
                    }

                }
                catch (Exception ex)
                { DisplayErrorMsg(ex.Message, "Database Error"); }
            }
            else
                DisplayErrorMsg("You must enter a Person Id", "Missing or Invalid Input");

        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlCommd = "SELECT * FROM PHONEBOOK ORDER BY Lastname";

                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    List<Contact> ContactList = new List<Contact>();

                    ContactList = db.Query<Contact>(sqlCommd).ToList();

                    if (ContactList.Count == 0)
                    {
                        MessageBox.Show("Contact list is empty");
                    }
                    else
                        contactsView.DataSource = ContactList;
                }
            }
            catch (Exception ex)
            { DisplayErrorMsg(ex.Message, "Database Error"); }
        }
        private void contactViewDoubleclick(object sender, EventArgs e)
        {
            // must click on the left most square to bring values into UI
            try
            {
                if (contactsView.SelectedRows.Count > 0)
                {
                    personIdTxt.Text = contactsView.SelectedRows[0].Cells[0].Value.ToString();
                    firstNameTxt.Text = contactsView.SelectedRows[0].Cells[1].Value.ToString();
                    lastNameTxt.Text = contactsView.SelectedRows[0].Cells[2].Value.ToString();
                    addressTxt.Text = contactsView.SelectedRows[0].Cells[3].Value.ToString();
                    cityTxt.Text = contactsView.SelectedRows[0].Cells[4].Value.ToString();
                    stateTxt.Text = contactsView.SelectedRows[0].Cells[5].Value.ToString();
                    zipTxt.Text = contactsView.SelectedRows[0].Cells[6].Value.ToString();
                    cellNumTxt.Text = contactsView.SelectedRows[0].Cells[7].Value.ToString();
                    workNumTxt.Text = contactsView.SelectedRows[0].Cells[8].Value.ToString();

                    if (contactsView.SelectedRows[0].Cells[9].Value == null)
                        notesTxt.Text = string.Empty;
                    else
                        notesTxt.Text = contactsView.SelectedRows[0].Cells[9].Value.ToString();
                }
                else
                    DisplayErrorMsg("Please double click a left most square to select contact for C.R.U.D.", "Contact Row Selection Failed");
            }
            catch (Exception ex)
            { DisplayErrorMsg(ex.Message, "Error"); }
        }

        private void contactsView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string updateStatement = "UPDATE PHONEBOOK ";
            string setStatement = "SET ";
            string whereStatement = " WHERE Person_Id = @person_Id";
            string sqlCmmd = string.Empty;
           
            
            if (!oldCellValue.Equals(contactsView.CurrentCell.Value.ToString()))
            {
                try
                {
                    // id will be set in this method
                    SetContactFromRow();

                    if (contactsView.CurrentRow.Cells[9].Value == null)
                        myContact.notes = null;
                    else
                        myContact.notes = contactsView.CurrentRow.Cells[9].Value.ToString();


                    switch (contactsView.CurrentCell.ColumnIndex)
                    {
                        case 1:
                            myContact.firstName = contactsView.CurrentCell.Value.ToString();
                            setStatement += "Firstname = @firstName";
                            break;
                        case 2:
                            myContact.lastName = contactsView.CurrentCell.Value.ToString();
                            setStatement += "Lastname = @lastName";
                            break;
                        case 3:
                            myContact.address = contactsView.CurrentCell.Value.ToString();
                            setStatement += "Address = @address";
                            break;
                        case 4:
                            myContact.city = contactsView.CurrentCell.Value.ToString();
                            setStatement += "City = @city";
                            break;
                        case 5:
                            myContact.state = contactsView.CurrentCell.Value.ToString();
                            setStatement += "State = @state";
                            break;
                        case 6:
                            myContact.zipCode = contactsView.CurrentCell.Value.ToString();
                            setStatement += "Zipcode = @zipCode";
                            break;
                        case 7:
                            myContact.cellPhone = contactsView.CurrentCell.Value.ToString();
                            setStatement += "CellPhone = @cellPhone";
                            break;
                        case 8:
                            myContact.workPhone = contactsView.CurrentCell.Value.ToString();
                            setStatement += "WorkPhone = workPhone";
                            break;
                        case 9:
                            if (contactsView.CurrentCell.Value == null)
                                myContact.notes = null;
                            else
                                myContact.Notes = contactsView.CurrentCell.Value.ToString();
                            setStatement += "Notes = @notes";
                            break;
                    }
                    // combine the strings to make the sql command
                    sqlCmmd = updateStatement + setStatement + whereStatement;

                    // then update new change to data base would this be slow? is there a better time to do the update?
                    int rowsUpdated = 0;

                    using (IDbConnection db = new SqlConnection(connectionString))
                    {
                        DynamicParameters parameters = new DynamicParameters();

                        parameters.Add("@person_Id", myContact.Person_ID, DbType.Int32, ParameterDirection.Input);
                        parameters.Add("@firstName", myContact.Firstname, DbType.String, ParameterDirection.Input);
                        parameters.Add("@lastName", myContact.Lastname, DbType.String, ParameterDirection.Input);
                        parameters.Add("@address", myContact.Address, DbType.String, ParameterDirection.Input);
                        parameters.Add("@city", myContact.City, DbType.String, ParameterDirection.Input);
                        parameters.Add("@state", myContact.State, DbType.String, ParameterDirection.Input);
                        parameters.Add("@zipCode", myContact.Zipcode, DbType.String, ParameterDirection.Input);
                        parameters.Add("@cellPhone", myContact.CellPhone, DbType.String, ParameterDirection.Input);
                        parameters.Add("@workPhone", myContact.WorkPhone, DbType.String, ParameterDirection.Input);
                        parameters.Add("@notes", myContact.Notes, DbType.String, ParameterDirection.Input);

                        rowsUpdated = db.Execute(sqlCmmd, parameters);
                        ClearForm();
                        MessageBox.Show($"{rowsUpdated} cell has been updated");
                    }

                }
                catch (Exception ex)
                {
                    DisplayErrorMsg(ex.Message, "Error");
                }
            }
        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private (bool, string) ValidateLastNameSearch()
        {
            bool valid = true; ;
            string errMsg = string.Empty;
            if (string.IsNullOrEmpty(lastNameToolTxt.Text))
            {
                valid = false;
                errMsg = "You must enter a last name to search for.";
            }
            return (valid, errMsg);
        }
        private (bool, string) ValidateContact()
        {
            bool valid;
            string errMsg = "You must enter contact's ";

            if (string.IsNullOrEmpty(personIdTxt.Text))
            {
                valid = false;
                errMsg += "Person Id";
            }
            else if (string.IsNullOrEmpty(firstNameTxt.Text))
            {
                valid = false;
                errMsg += "First Name";
            }
            else if (string.IsNullOrEmpty(lastNameTxt.Text))
            {
                valid = false;
                errMsg += "Last Name";
            }
            else if (string.IsNullOrEmpty(addressTxt.Text))
            {
                valid = false;
                errMsg += "address";
            }
            else if (string.IsNullOrEmpty(cityTxt.Text))
            {
                valid = false;
                errMsg += "city";
            }
            else if (string.IsNullOrEmpty(stateTxt.Text))
            {
                valid = false;
                errMsg += "state";
            }
            else if (string.IsNullOrEmpty(zipTxt.Text))
            {
                valid = false;
                errMsg += "zipcode";
            }
            else if (string.IsNullOrEmpty(cellNumTxt.Text))
            {
                valid = false;
                errMsg += "cell phone number";
            }
            else if (string.IsNullOrEmpty(workNumTxt.Text))
            {
                valid = false;
                errMsg += "work phone number";
            }
            else valid = true;

            return (valid, errMsg);
        }
        private (bool,string) ValidateStringLength()
        {
            bool valid;
            string errMsg = string.Empty;

            if (firstNameTxt.Text.Trim().Length > 15)
            {
                valid = false;
                errMsg = "First name cannot be more then 15 characters";
            }
            else if (lastNameTxt.Text.Trim().Length > 30)
            {
                valid = false;
                errMsg = "Last name cannot be more then 30 characters";
            }
            else if (addressTxt.Text.Trim().Length > 30)
            {
                valid = false;
                errMsg = "Address cannot be more then 30 characters";
            }
            else if (cityTxt.Text.Trim().Length > 25)
            {
                valid = false;
                errMsg = "City cannot be more then 25 characters";
            }
            else if (notesTxt.Text.Trim().Length > 50)
            {
                valid = false;
                errMsg = "Notes cannot be more then 50 characters";
            }
            else
                valid = true;
            return (valid, errMsg);
        }
        private void DisplayErrorMsg(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private int PersonIDToInt(string personId)
        {
            int newId = Convert.ToInt32(personId);
            return newId;
        }
        private void ClearForm()
        {
            personIdTxt.Text = string.Empty;
            firstNameTxt.Text = string.Empty;
            lastNameTxt.Text = string.Empty;
            addressTxt.Text = string.Empty;
            cityTxt.Text = string.Empty;
            stateTxt.Text = string.Empty;
            zipTxt.Text = string.Empty;
            cellNumTxt.Text = string.Empty;
            workNumTxt.Text = string.Empty;
            notesTxt.Text = string.Empty;
        }

        private void clearAll_Click(object sender, EventArgs e)
        {
            ClearForm();
            lastNameToolTxt.Text = string.Empty;
            contactsView.Columns.Clear();
            contactsView.DataSource = null;

        }
        private void SetContactFromRow()
        {
            myContact = new Contact();
            myContact.personId = (int)contactsView.CurrentRow.Cells[0].Value;
            myContact.firstName = contactsView.CurrentRow.Cells[1].Value.ToString();
            myContact.lastName = contactsView.CurrentRow.Cells[2].Value.ToString();
            myContact.address = contactsView.CurrentRow.Cells[3].Value.ToString();
            myContact.city = contactsView.CurrentRow.Cells[4].Value.ToString();
            myContact.state = contactsView.CurrentRow.Cells[5].Value.ToString();
            myContact.zipCode = contactsView.CurrentRow.Cells[6].Value.ToString();
            myContact.cellPhone = contactsView.CurrentRow.Cells[7].Value.ToString();
            myContact.workPhone = contactsView.CurrentRow.Cells[8].Value.ToString();
        }
        private void contactsView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            oldCellValue = contactsView.CurrentCell.Value.ToString();
        }
        private void contactsView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (contactsView.CurrentCell.ColumnIndex == 0)
                contactsView.ReadOnly = true;
            else if (contactsView.CurrentCell.ColumnIndex >= 1)
            {
                contactsView.ReadOnly = false;
                contactsView.EditMode = DataGridViewEditMode.EditOnKeystroke;
            }           
        }

        private void DisplayStatus(string msg)
        {
            statusStrip1.Visible = true;
            statusLbl.Text = msg;
        }
        private void CloseStatusStrip()
        {
            statusStrip1.Visible = false;
        }
        private void personIdTxt_MouseHover(object sender, EventArgs e)
        {
            DisplayStatus("Enter Person Id Number. Used for adding, updating and deleting");
        }

        private void personIdTxt_MouseLeave(object sender, EventArgs e)
        {
            CloseStatusStrip();
        }

        private void firstNameTxt_MouseHover(object sender, EventArgs e)
        {
            DisplayStatus("Enter contact's first name");
        }

        private void firstNameTxt_MouseLeave(object sender, EventArgs e)
        {
            CloseStatusStrip();
        }

        private void lastNameTxt_MouseHover(object sender, EventArgs e)
        {
            DisplayStatus("Enter contact's last name");
        }

        private void lastNameTxt_MouseLeave(object sender, EventArgs e)
        {
            CloseStatusStrip();
        }

        private void addressTxt_MouseHover(object sender, EventArgs e)
        {
            DisplayStatus("Enter contact's address");
        }

        private void addressTxt_MouseLeave(object sender, EventArgs e)
        {
            CloseStatusStrip();
        }

        private void cityTxt_MouseHover(object sender, EventArgs e)
        {
            DisplayStatus("Enter contact's city");
        }

        private void cityTxt_MouseLeave(object sender, EventArgs e)
        {
            CloseStatusStrip();
        }

        private void zipTxt_MouseHover(object sender, EventArgs e)
        {
            DisplayStatus("Enter contact's zipcode");
        }

        private void zipTxt_MouseLeave(object sender, EventArgs e)
        {
            CloseStatusStrip();
        }

        private void cellNumTxt_MouseHover(object sender, EventArgs e)
        {
            DisplayStatus("Enter contact's cell phone number");           
        }

        private void cellNumTxt_MouseLeave(object sender, EventArgs e)
        {
            CloseStatusStrip();
        }

        private void workNumTxt_MouseHover(object sender, EventArgs e)
        {
            DisplayStatus("Enter contact's work phone number");
        }

        private void workNumTxt_MouseLeave(object sender, EventArgs e)
        {
            CloseStatusStrip();
        }

        private void notesTxt_MouseHover(object sender, EventArgs e)
        {
            DisplayStatus("Enter any comments about contact");
        }

        private void notesTxt_MouseLeave(object sender, EventArgs e)
        {
            CloseStatusStrip();
        }

        private void contactsView_MouseHover(object sender, EventArgs e)
        {
            DisplayStatus("Displays contact list.\n Double click on left most square to select row in UI or select single cell to edit");
        }

        private void contactsView_MouseLeave(object sender, EventArgs e)
        {
            CloseStatusStrip();
        }

        private void stateTxt_MouseHover(object sender, EventArgs e)
        {
            DisplayStatus("Enter contact's state of residency");
        }

        private void stateTxt_MouseLeave(object sender, EventArgs e)
        {
            CloseStatusStrip();
        }


    }
}
