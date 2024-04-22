using System;
public class Apprentices
{
    public int id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string desiredPosition { get; set; }
    public DateTime dateSubmitted { get; set; }
    public string phoneNumber { get; set; }
    public string email { get; set; }


    public Apprentices(int id, string firstName, string lastName, string desiredPosition, DateTime dateSubmitted, string phoneNumber, string email)
    {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.desiredPosition = desiredPosition;
        this.dateSubmitted = dateSubmitted;
        this.phoneNumber = phoneNumber;
        this.email = email;
    }

    public string getDate()
    {
        string dzien = this.dateSubmitted.Day.ToString();
        string miesiac = this.dateSubmitted.Month.ToString();
        string rok = this.dateSubmitted.Year.ToString();
        return dzien+"-"+miesiac+"-"+rok;
    }

}