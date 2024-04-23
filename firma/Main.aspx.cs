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

        lista.Add(new Apprentices(index,firstNameStr,lastNameStr,desiredPositionStr,dateSubmittedStr,phoneNumberStr,emailStr));
        index++;

        gridView1.DataSource = lista;
        gridView1.DataBind();

        firstName.Text = null;
        lastName.Text = null;
        desiredPosition.SelectedIndex = 0;
        phoneNumber.Value = null;
        email.Value = null;

    }
}