using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Http.Results;

namespace projekt
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["USER_ID"] != null)
            {

                login_session.Text = Session["USER_ID"].ToString();



            }
            else
            {
                Response.Redirect("login.aspx");
            }

            if (Session["USER_ID"] != null)
            {

                string sqlquery = "select imie, nazwisko, email, User_Id from User_log";
                SqlCommand wys = new SqlCommand(sqlquery, con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(wys);
                DataTable tabela = new DataTable();
                sda.Fill(tabela);
                StringBuilder sb = new StringBuilder();
                sb.Append("<center>");

                sb.Append("<table border=1>");
                sb.Append("<tr>");

                // foreach (DataColumn kolumna in tabela.Columns)
                {

                    sb.Append("<th>");
                    sb.Append("imie");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("nazwisko");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("email");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("Login");
                    sb.Append("</th>");


                }
                sb.Append("</th>");

                foreach (DataRow dr in tabela.Rows)
                {
                    sb.Append("<tr>");
                    foreach (DataColumn kolumna in tabela.Columns)
                    {
                        sb.Append("<td>");
                        sb.Append(dr[kolumna.ColumnName].ToString());
                        sb.Append("</td>");
                    }

                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                sb.Append("</center>");

                Panel1.Controls.Add(new Label { Text = sb.ToString() });

                con.Close();
            }
            else
            {
                Response.Redirect("login.aspx");
            }

        }
        protected void Logout_Button_Click(object sender, EventArgs e)
        {
            Session.Remove("USER_ID");
            Session.RemoveAll();
        }
        protected void registration_button_Click(object sender, EventArgs e)
        {




            try
            {
                string Login = txtUser_Id.Text;
                string Email = txtEmail.Text;
                string Password = txtPassword.Text;
                string name = input_name.Text;
                string surname = input_surname.Text;


                if (Login == "" || Email == "" || Password == "" || name == "" || surname == "")
                {
                    lblError.Text = "nieprawidłowe dane";

                }
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select count(*) from User_log where User_Id = '" + Login + "'", con);
                    string getValue = cmd.ExecuteScalar().ToString();

                    if (getValue != "0")
                    {
                        lblError.Text = "Nazwa takiego użytkownika już istnieje";
                    }
                    else
                    {
                        string Register = "Insert into User_log (ID, User_Id, email, Password, imie, nazwisko) values (5, '" + Login + "', '" + Email + "', '" + Password + "', '" + name + "', '" + surname + "' )";
                        SqlCommand cmmd = new SqlCommand(Register, con);
                        SqlDataReader regcomm = cmmd.ExecuteReader();
                        lblError.Text = "Pomyślnie dodano użytkownika";
                        foreach (Control control in Form.Controls)
                        {
                            if (control is TextBox)
                            {
                                ((TextBox)control).Text = string.Empty;
                            }
                        }
                    }

                    con.Close();


                }

            }
            catch (Exception)
            {
                lblError.Text = "nieprawidłowe dane";
            }




        }

    }
}