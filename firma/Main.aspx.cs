using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.XtraExport.Helpers;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
            dateSubmitted.Text = data.Day + "-" + data.Month + "-" + data.Year;

            alertSpan.Visible = false;
            alertSpan.InnerText = "Aby dodać nowego praktykanta uzupełnij jego dane";

            alertSpan1.Visible = false;
            alertSpan1.InnerText = "Aby zedytować praktykanta uzupełnij jego dane";

            lista = new ObservableCollection<Apprentices>();
            Functions.addData(lista, Functions.getDataFromDataBase());
            gridView1.DataSource = lista;
            gridView1.DataBind();
            sIndex = lista.Count + 1;
        }
    }

    //Dodawanie nowego praktykanta do tabeli
    protected void Unnamed_Click(object sender, EventArgs e)
    {
        DateTime data = DateTime.Now;
        dateSubmitted.Text = data.Day + "-" + data.Month + "-" + data.Year;


        string firstNameStr = firstName.Text;
        string lastNameStr = lastName.Text;
        string desiredPositionStr = desiredPosition.Text;
        DateTime dateSubmittedStr = DateTime.Parse(dateSubmitted.Text);
        string phoneNumberStr = phoneNumber.Text;
        string emailStr = email.Text;
        int id = Functions.lastIndex()+1;
        if (!String.IsNullOrEmpty(firstNameStr)&&!String.IsNullOrEmpty(lastNameStr)&&!String.IsNullOrEmpty(phoneNumberStr)&&!String.IsNullOrEmpty(emailStr)) {
            lista.Add(new Apprentices(sIndex, id, firstNameStr, lastNameStr, desiredPositionStr, dateSubmittedStr, phoneNumberStr, emailStr));
            sIndex++;

            Functions.querryCommand(String.Format("INSERT INTO dbo.Praktykanci (firstName,lastName,desiredPosition,dateSubmitted,phoneNumber,email) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}');",firstNameStr,lastNameStr,desiredPositionStr,dateSubmittedStr.ToString("yyyy-MM-dd"),phoneNumberStr,emailStr));

            gridView1.DataSource = lista;
            gridView1.DataBind();

            firstName.Text = null;
            lastName.Text = null;
            desiredPosition.SelectedIndex = 0;
            phoneNumber.Text = null;
            email.Text = null;

            alertSpan.Visible = false;
            alertSpan1.Visible = false;

            editForm.Visible = false;
        }
        else
        {
            alertSpan.Visible = true;
        }
    }
    //Zacznij edytować wybranego praktykanta
    protected void Unnamed_Click1(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;
        int index = row.RowIndex;

        editForm.Visible = true;

        firstNameEd.Text = gridView1.Rows[index].Cells[2].Text;
        lastNameEd.Text = gridView1.Rows[index].Cells[3].Text;
        desiredPositionEd.SelectedValue = gridView1.Rows[index].Cells[4].Text;
        dateSubmittedEd.Text = Functions.dataToString(DateTime.Parse(gridView1.Rows[index].Cells[5].Text));
        phoneNumberEd.Text = gridView1.Rows[index].Cells[6].Text;
        emailEd.Text = gridView1.Rows[index].Cells[7].Text;
        dbId.Text = gridView1.Rows[index].Cells[1].Text;
        editId.Text = index.ToString();
    }
    //Usuń wybranego praktykanta
    protected void Unnamed_Click2(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;
        int index = row.RowIndex;
        int id = Int32.Parse(gridView1.Rows[index].Cells[0].Text)-1;
        id = lista[id].id;
        lista.RemoveAt(index);
        
        string command = String.Format("DELETE FROM dbo.Praktykanci WHERE id={0}", id);
        Functions.querryCommand(command);

        sIndex = 1;

        for(int i = 0;i<lista.Count;i++)
        {
            lista[i].index = sIndex;
            sIndex++;
        }

        gridView1.DataSource = lista;
        gridView1.DataBind();


    }
    //Aktualizacja danych wybranego praktykanta
    protected void Unnamed_Click3(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(firstNameEd.Text)&&!String.IsNullOrEmpty(lastNameEd.Text)&&!String.IsNullOrEmpty(desiredPositionEd.Text)&&!String.IsNullOrEmpty(dateSubmittedEd.Text)&&!String.IsNullOrEmpty(phoneNumberEd.Text)&&!String.IsNullOrEmpty(emailEd.Text)) {
            int index = Int32.Parse(editId.Text);
            gridView1.Rows[index].Cells[2].Text = firstNameEd.Text;
            gridView1.Rows[index].Cells[3].Text = lastNameEd.Text;
            gridView1.Rows[index].Cells[4].Text = desiredPositionEd.Text;
            gridView1.Rows[index].Cells[5].Text = Functions.dataToString(DateTime.Parse(dateSubmittedEd.Text));
            gridView1.Rows[index].Cells[6].Text = phoneNumberEd.Text;
            gridView1.Rows[index].Cells[7].Text = emailEd.Text;



            DateTime date = DateTime.Parse(dateSubmittedEd.Text);

            firstName.Text = date.ToString();

            int id = lista[index].id;

            string command = String.Format("UPDATE dbo.Praktykanci SET firstName='{0}', lastName='{1}', desiredPosition='{2}', dateSubmitted='{3}', phoneNumber='{4}', email='{5}' WHERE id={6};", firstNameEd.Text, lastNameEd.Text, desiredPositionEd.Text, (date).ToString("yyyy-MM-dd"), phoneNumberEd.Text, emailEd.Text, id);
            Functions.querryCommand(command);

            editForm.Visible = false;

            alertSpan1.Visible = false;
        }
        else
        {
            alertSpan1.Visible = true;
        }
    }
    //Anulwanie edycji praktykanta
    protected void Unnamed_Click4(object sender, EventArgs e)
    {
        editForm.Visible = false;
    }
}