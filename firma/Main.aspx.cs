using DevExpress.ClipboardSource.SpreadsheetML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.Page {

    static ObservableCollection<Apprentices> lista = new ObservableCollection<Apprentices>();
    static int index = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime data = DateTime.Now;
            dateSubmitted.Value = data.Day + "-" + data.Month + "-" + data.Year;
        }
        alertSpan.Visible = false;
        alertSpan.InnerText = "Aby dodać nowego praktykanta uzupełnij jego dane";
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {
        DateTime data = DateTime.Now;
        dateSubmitted.Value = data.Day + "-" + data.Month + "-" + data.Year;


        string firstNameStr = firstName.Text;
        string lastNameStr = lastName.Text;
        string desiredPositionStr = desiredPosition.Text;
        DateTime dateSubmittedStr = DateTime.Parse(dateSubmitted.Value);
        string phoneNumberStr = phoneNumber.Value;
        string emailStr = email.Value;
        if (!String.IsNullOrEmpty(firstNameStr)&&!String.IsNullOrEmpty(lastNameStr)&&!String.IsNullOrEmpty(phoneNumberStr)&&!String.IsNullOrEmpty(emailStr)) {
            lista.Add(new Apprentices(index, firstNameStr, lastNameStr, desiredPositionStr, dateSubmittedStr, phoneNumberStr, emailStr));
            index++;

            gridView1.DataSource = lista;
            gridView1.DataBind();

            firstName.Text = null;
            lastName.Text = null;
            desiredPosition.SelectedIndex = 0;
            phoneNumber.Value = null;
            email.Value = null;

            alertSpan.Visible = false;
        }
        else
        {
            alertSpan.Visible = true;
        }
    }

    protected void Unnamed_Click1(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;
        int index = row.RowIndex;

        firstName.Text = gridView1.Rows[index].Cells[1].Text;
    }

    protected void Unnamed_Click2(object sender, EventArgs e)
    {
        Button btn = (Button )sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;
        int index = row.RowIndex;


    }
}