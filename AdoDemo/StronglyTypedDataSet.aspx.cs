﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AdoDemo
{
    public partial class StronglyTypedDataSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string connectionString =
                ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                string selectQuery = "Select * from tblStudents";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection);

                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Students");

                Session["DATASET"] = dataSet;

                GridView1.DataSource = from dataRow in dataSet.Tables["Students"].AsEnumerable()
                                       select new Student
                                       {
                                           ID = Convert.ToInt32(dataRow["Id"]),
                                           Name = dataRow["Name"].ToString(),
                                           Gender = dataRow["Gender"].ToString(),
                                           TotalMarks = Convert.ToInt32(dataRow["TotalMarks"])
                                       };
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                DataSet dataSet = new DataSet();
                dataSet = (DataSet)Session["DATASET"];

                GridView1.DataSource = from dataRow in dataSet.Tables["Students"].AsEnumerable()
                                   
                                       select new Student
                                       {
                                           ID = Convert.ToInt32(dataRow["Id"]),
                                           Name = dataRow["Name"].ToString(),
                                           Gender = dataRow["Gender"].ToString(),
                                           TotalMarks = Convert.ToInt32(dataRow["TotalMarks"])
                                       };
                GridView1.DataBind();

            }
            else
            {
                DataSet dataSet = new DataSet();
                dataSet = (DataSet)Session["DATASET"];

                GridView1.DataSource = from dataRow in dataSet.Tables["Students"].AsEnumerable()
                                       where dataRow["Name"].ToString().ToUpper().StartsWith(TextBox1.Text.ToUpper())
                                       select new Student
                                       {
                                           ID = Convert.ToInt32(dataRow["Id"]),
                                           Name = dataRow["Name"].ToString(),
                                           Gender = dataRow["Gender"].ToString(),
                                           TotalMarks = Convert.ToInt32(dataRow["TotalMarks"])
                                       };
                GridView1.DataBind();
            }
        }
    }
}