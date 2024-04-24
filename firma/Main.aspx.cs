using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraExport.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.Page {

    static ObservableCollection<Apprentices> lista = new ObservableCollection<Apprentices>();
    static int sIndex = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime data = DateTime.Now;
            dateSubmitted.Value = data.Day + "-" + data.Month + "-" + data.Year;
            alertSpan.Visible = false;
            alertSpan.InnerText = "Aby dodać nowego praktykanta uzupełnij jego dane";
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
        string phoneNumberStr = phoneNumber.Text;
        string emailStr = email.Text;
        int id = 4;
        if (!String.IsNullOrEmpty(firstNameStr)&&!String.IsNullOrEmpty(lastNameStr)&&!String.IsNullOrEmpty(phoneNumberStr)&&!String.IsNullOrEmpty(emailStr)) {
            lista.Add(new Apprentices(sIndex, id, firstNameStr, lastNameStr, desiredPositionStr, dateSubmittedStr, phoneNumberStr, emailStr));
            sIndex++;

            gridView1.DataSource = lista;
            gridView1.DataBind();

            firstName.Text = null;
            lastName.Text = null;
            desiredPosition.SelectedIndex = 0;
            phoneNumber.Text = null;
            email.Text = null;

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

        editForm.Visible = true;

        firstNameEd.Text = gridView1.Rows[index].Cells[2].Text;
        lastNameEd.Text = gridView1.Rows[index].Cells[3].Text;
        desiredPositionEd.SelectedValue = gridView1.Rows[index].Cells[4].Text;
        phoneNumberEd.Text = gridView1.Rows[index].Cells[6].Text;
        emailEd.Text = gridView1.Rows[index].Cells[7].Text;
        dbId.Text = gridView1.Rows[index].Cells[1].Text;
        editId.Text = index.ToString();
    }

    protected void Unnamed_Click2(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;
        int index = row.RowIndex;

        lista.RemoveAt(index);
        sIndex = 1;

        for(int i = 0;i<lista.Count;i++)
        {
            lista[i].index = sIndex;
            sIndex++;
        }

        gridView1.DataSource = lista;
        gridView1.DataBind();


    }

    protected void Unnamed_Click3(object sender, EventArgs e)
    {
        int index = Int32.Parse(editId.Text);
        gridView1.Rows[index].Cells[2].Text = firstNameEd.Text;
        gridView1.Rows[index].Cells[3].Text = lastNameEd.Text;
        gridView1.Rows[index].Cells[4].Text = desiredPositionEd.Text;
        gridView1.Rows[index].Cells[6].Text = phoneNumberEd.Text;
        gridView1.Rows[index].Cells[7].Text = emailEd.Text;

        editForm.Visible = false;
    }

    protected void Unnamed_Click4(object sender, EventArgs e)
    {
        editForm.Visible = false;
    }
}