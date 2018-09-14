using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace ControllsDemo
{
    public partial class CascadingDropDown : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlContinents.DataSource = GetData("spGetContinents", null);
                ddlContinents.DataBind();
                //ddlContinents.DataTextField = "ContinentName";
                //ddlContinents.DataValueField = "ContinentId";
                ListItem liContinent = new ListItem("Select Continent", "-1");
                ddlContinents.Items.Insert(0, liContinent);

                ListItem liCountry = new ListItem("Select Country", "-1");
                ddlCountries.Items.Insert(0, liCountry);

                ListItem liCity = new ListItem("Select City", "-1");
                ddlCities.Items.Insert(0, liCity);

                ddlCountries.Enabled = false;
                ddlCities.Enabled = false;
            }
        }
        private DataSet GetData(string SPName, SqlParameter SPParameter)
        {
            string str = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            //SqlCommand cmd = new SqlCommand("spGetContinents", con);
            SqlDataAdapter da = new SqlDataAdapter(SPName, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if(SPParameter != null)
            {
                da.SelectCommand.Parameters.Add(SPParameter);
            }
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
            
            
        }

        protected void ddlContinents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlContinents.SelectedIndex == 0)
            {

            }
            else
            {
                ddlCountries.Enabled = true;
                SqlParameter parameter = new SqlParameter("@ContinentID", ddlContinents.SelectedValue);

                
                    DataSet ds = GetData("spGetCountries", parameter);

                ddlCountries.DataSource = ds;
                ddlCountries.DataBind();
                ListItem liCountry = new ListItem("Select Country", "-1");
                ddlCountries.Items.Insert(0, liCountry);

                ddlCities.SelectedIndex = 0;
                ddlCities.Enabled = false;
               


            }
        }

        protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCountries.SelectedIndex == 0)
            {

            }
            else
            {
                ddlCities.Enabled = true;
                SqlParameter parameter = new SqlParameter("@CountryID", ddlCountries.SelectedValue);


                DataSet ds = GetData("spGetCities", parameter);

                ddlCities.DataSource = ds;
                ddlCities.DataBind();
                ListItem liCity = new ListItem("Select City", "-1");
                ddlCities.Items.Insert(0, liCity);



            }
        }
    }
}