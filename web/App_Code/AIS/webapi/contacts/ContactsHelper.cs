using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AIS;
using AIS.Rotary;

/// <summary>
/// Description résumée de ContactsHelper
/// </summary>
public class ContactsHelper
{
    public List<Contact> GetMembres(int cric)
    {
        var members = DataMapping.ListMembers(cric: cric);

        var membres = new List<Contact>();
        foreach (var m in members)
            membres.Add(new Contact
            {
                nim = m.nim,
                name = m.surname + " " + m.name
            });

        membres = membres.OrderBy(m => m.name).ToList();

        return membres;
    }

    public Contact.List GetContactList(Guid guid)
    {
        var sql = new SqlCommand("select * from ais_contacts where guid=@guid");
        sql.Parameters.AddWithValue("guid", guid);

        Contact.List list = Yemon.dnn.DataMapping.ExecSqlFirst<Contact.List>(sql);
        return list;
    }

    public List<Contact.List> GetContactsLists(int cric)
    {
        List<Contact.List> contacts = Yemon.dnn.DataMapping.ExecSql<Contact.List>(new SqlCommand("select * from ais_contacts where cric=" + cric + " order by title"));

        return contacts;
    }
}