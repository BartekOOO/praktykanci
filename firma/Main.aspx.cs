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
        gridView1.DataSource = lista;
        gridView1.DataBind();
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {
        string firstNameStr = firstName.Text;
        string lastNameStr = lastName.Text;
        string desiredPositionStr = desiredPosition.Text;
        string dateSubmittedStr = dateSubmitted.Value;
        string phoneNumberStr = phoneNumber.Value;
        string emailStr = email.Value;

        lista.Add(new Apprentices(index,firstNameStr,lastNameStr,desiredPositionStr,new DateTime(),phoneNumberStr,emailStr));
        index++;
    }
}