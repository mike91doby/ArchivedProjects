﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace week1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            fillStatesCmb();

            //disable update and delete buttons when adding
            btnDelete.Visible = false;
            btnDelete.Enabled = false;
            btnUpdate.Visible = false;
            btnUpdate.Enabled = false;
            btnYes.Visible = false;
            btnYes.Enabled = false;
            btnNo.Visible = false;
            btnNo.Enabled = false;

            //Create an object containing my data
            //Student mike = new Student("Michael", "Gary", "Dobachesky", "1 Street Drive", "2 Street Drive", "Plainville", "MA", "02762", "5085214255", "Mgdobachesky@email.neit.edu", 4);

            //Fill the form with data from my object
            /*
            txtFName.Text = mike.FName;
            txtMName.Text = mike.MName;
            txtLName.Text = mike.LName;
            txtStreet1.Text = mike.Street1;
            txtStreet2.Text = mike.Street2;
            txtCity.Text = mike.City;
            txtState.Text = mike.State;
            txtZip.Text = mike.Zip;
            txtPhone.Text = mike.Phone;
            txtEmail.Text = mike.Email;
            txtGpa.Text = mike.GPA.ToString();
            */

            //Run function that fills a label if there are no errors
            /*
            if (!mike.Feedback.Contains("ERROR:"))
            {
                //filling the label at start is not important
                //however, checking the fields is
                //fillLabel(mike);
            }
            else
            {
                lblFeedback.Text = mike.Feedback;
            }
            */
        }

        //overloaded constructor, used for the editor view
        public Form1(Int32 intId)
        {
            InitializeComponent();
            fillStatesCmb();

            //disable add button when updating and deleting
            btnSubmit.Visible = false;
            btnSubmit.Enabled = false;
            btnYes.Visible = false;
            btnYes.Enabled = false;
            btnNo.Visible = false;
            btnNo.Enabled = false;

            //get info for this student and store in a datareader
            Student temp = new Student();
            SqlDataReader dr = temp.findData(intId);

            //use the info to fill out the form
            while (dr.Read())
            {
                //loop through the records one at a time (one in this case)
                lblId.Text = dr["ID"].ToString();
                txtFName.Text = dr["FName"].ToString();
                txtMName.Text = dr["MName"].ToString();
                txtLName.Text = dr["LName"].ToString();
                txtStreet1.Text = dr["Street1"].ToString();
                txtStreet2.Text = dr["Street2"].ToString();
                txtCity.Text = dr["City"].ToString();
                cmbState.SelectedItem = dr["State"].ToString();
                txtZip.Text = dr["Zip"].ToString();
                txtPhone.Text = dr["Phone"].ToString();
                txtEmail.Text = dr["Email"].ToString();
                txtGpa.Text = dr["GPA"].ToString();
            }
        }

        private void fillStatesCmb() 
        {
            //get the list of states in the datareader
            SqlDataReader dr = MyUtilities.fillStates();

            //loop through each state
            while(dr.Read())
            {
                cmbState.Items.Add(dr["State"].ToString());
            }

            cmbState.Items.Insert(0, "Please Choose One...");
            cmbState.SelectedIndex = 0;
            dr.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Create new person object using person class
            Student aStudent = new Student();

            //Set the public variables to the values in the text boxes
            aStudent.FName = txtFName.Text;
            aStudent.MName = txtMName.Text;
            aStudent.LName = txtLName.Text;
            aStudent.Street1 = txtStreet1.Text;
            aStudent.Street2 = txtStreet2.Text;
            aStudent.City = txtCity.Text;
            aStudent.State = cmbState.SelectedItem.ToString();
            aStudent.Zip = txtZip.Text;
            aStudent.Phone = txtPhone.Text;
            aStudent.Email = txtEmail.Text;
            if (txtGpa.Text != "")
            {
                aStudent.GPA = Convert.ToDouble(txtGpa.Text);
            }
            else
            {
                aStudent.GPA = -1;
            }

            //Run function that fills a label if there are no errors
            if (!aStudent.Feedback.Contains("ERROR:"))
            {
                fillLabel(aStudent);
                aStudent.AddRecord();
            }
            else
            {
                lblFeedback.Text = aStudent.Feedback;
            }
   
        }

        //Function that fills a label with information from an object created from the Person class
        private void fillLabel(Student temp)
        {
            lblFeedback.Text = "Record Successfully Added:" + "\n";
            lblFeedback.Text += temp.FName + "\n";
            lblFeedback.Text += temp.MName + "\n";
            lblFeedback.Text += temp.LName + "\n";
            lblFeedback.Text += temp.Street1 + "\n";
            if(temp.Street2 != ""){
                lblFeedback.Text += temp.Street2 + "\n";
            }
            lblFeedback.Text += temp.City + "\n";
            lblFeedback.Text += temp.State + "\n";
            lblFeedback.Text += temp.Zip + "\n";
            lblFeedback.Text += temp.Phone + "\n";
            lblFeedback.Text += temp.Email + "\n";
            lblFeedback.Text += temp.GPA + "\n";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //create a student to get access to it's methods
            Student temp = new Student();

            //fill data in the form
            temp.personId = Convert.ToInt32(lblId.Text);
            temp.FName = txtFName.Text;
            temp.MName = txtMName.Text;
            temp.LName = txtLName.Text;
            temp.Street1 = txtStreet1.Text;
            temp.Street2 = txtStreet2.Text;
            temp.City = txtCity.Text;
            temp.State = cmbState.SelectedItem.ToString();
            temp.Zip = txtZip.Text;
            temp.Phone = txtPhone.Text;
            temp.Email = txtEmail.Text;
            if (txtGpa.Text != "")
            {
                temp.GPA = Convert.ToDouble(txtGpa.Text);
            }
            else
            {
                temp.GPA = -1;
            }

            if(temp.Feedback.Contains("ERROR:")) 
            {
                lblFeedback.Text = temp.Feedback;
            }
            else 
            {
                Int32 numRecords = temp.updateContact();
                lblFeedback.Text = numRecords.ToString() + " Record(s) Updated";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnYes.Visible = true;
            btnYes.Enabled = true;
            btnNo.Visible = true;
            btnNo.Enabled = true;

            //create a student to get access to it's methods
            Student temp = new Student();

            //make the id usable as an int
            Int32 personId = Convert.ToInt32(lblId.Text);

             //get number of records to be deleted
            Int32 howMany = temp.recordsSelected(personId);
            lblDeletePrompt.Text = "Delete " + howMany.ToString() + " row(s)?";
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            //create a student to get access to it's methods
            Student temp = new Student();

            //make the id usable as an int
            Int32 personId = Convert.ToInt32(lblId.Text);

            //delete record and store how many were deleted
            Int32 numRecords = temp.DeletePerson(personId);

            //display feedback
            lblFeedback.Text = numRecords.ToString() + " Record(s) Deleted";

            //clear the "are you sure" prompt for deleting
            lblDeletePrompt.Text = "";
            btnYes.Visible = false;
            btnYes.Enabled = false;
            btnNo.Visible = false;
            btnNo.Enabled = false;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            //clear the "are you sure" prompt for deleting
            lblDeletePrompt.Text = "";
            btnYes.Visible = false;
            btnYes.Enabled = false;
            btnNo.Visible = false;
            btnNo.Enabled = false;
        }

    }
}
