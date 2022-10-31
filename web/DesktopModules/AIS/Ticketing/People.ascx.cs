using DotNetNuke.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AIS
{
    public partial class Ticketing_People : System.Web.UI.UserControl
    {
        
        public Ticketing.Order.Item item { get { return GetItem();  } set { ViewState["item"] = value;Init(); } }
        public Ticketing ticketing { get; set; }
        public Member member { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Init()
        {
            Ticketing.Order.Item item = (Ticketing.Order.Item)ViewState["item"];

            L_Name.Text = item.name;
            H_GUID.Value = item.guid;

            TXT_Firstname.Text = item.firstname;
            TXT_Lastname.Text = item.lastname;
            TXT_Email.Text = item.email;
            P_Fields.Controls.Clear();
            int i = 1;

            List<Ticketing.Field> fields = new List<Ticketing.Field>();
            if (!("" + item.fields).Equals(""))
            {
                fields = (List<Ticketing.Field>)Functions.Deserialize(item.fields, typeof(List<Ticketing.Field>));
            }

            foreach (Ticketing.Field field in ticketing.fields)
            {
                Label l = new Label();
                l.Text = field.label;
                l.CssClass = "control-label col-sm-3";
                P_Fields.Controls.Add(l);

                Panel p = new Panel();
                p.CssClass = "col-sm-9";

                switch (field.type)
                {
                    case "TEXT":
                        TextBox t = new TextBox();
                        t.ID = "f" + i;
                        t.CssClass = "form-control";
                        if(fields.Count>0)
                        {
                            t.Text = fields[i-1].value;
                        }
                        p.Controls.Add(t);

                        if (!field.comment.Equals(""))
                        {
                            Panel pc = new Panel();
                            Label c = new Label();
                            c.Text = field.comment;
                            pc.Controls.Add(c);
                            p.Controls.Add(pc);
                        }

                        break;
                    case "RADIO":
                        Panel prb = new Panel();
                        //prb.CssClass = "control-label";
                        RadioButtonList rbl = new RadioButtonList();
  
                        rbl.ID = "f" + i;
                        rbl.RepeatDirection = RepeatDirection.Vertical;
                        string[] valeurs = field.value.Split(';');
                        foreach (string v in valeurs)
                        { 
                            rbl.Items.Add(v);
                            if (fields.Count > 0)
                            {
                                if (v == fields[i-1].value)
                                    rbl.SelectedIndex = rbl.Items.Count - 1;
                            }
                        }

                        if (!field.comment.Equals(""))
                        {
                            Panel pc = new Panel();
                            Label c = new Label();
                            c.Text = field.comment;
                            pc.Controls.Add(c);
                            p.Controls.Add(pc);
                        }

                        prb.Controls.Add(rbl);
                        p.Controls.Add(prb);
                        break;

                }
                if (field.mandatory)
                {
                    RequiredFieldValidator r = new RequiredFieldValidator();
                    r.ControlToValidate = "f" + i;
                    r.Text = "Veuillez compléter";
                    r.ForeColor = System.Drawing.Color.Red;
                    r.Display = ValidatorDisplay.Dynamic;
                    p.Controls.Add(r);
                }
               


                P_Fields.Controls.Add(p);

                i++;
            }


            
        }
        Ticketing.Order.Item GetItem()
        {
            Ticketing.Order.Item item =  (Ticketing.Order.Item)ViewState["item"];
            item.firstname = TXT_Firstname.Text.Trim();
            item.lastname = TXT_Lastname.Text.Trim();
            item.email = TXT_Email.Text.Trim();
            item.guid = H_GUID.Value;

            if (ticketing.fields.Count > 0)
            {
                int ii = 1;
                List<Ticketing.Field> item_fields = new List<Ticketing.Field>();
                foreach (Ticketing.Field field in ticketing.fields)
                {
                    Ticketing.Field item_field = new Ticketing.Field();

                    item_field.label = field.label;
                    switch (field.type)
                    {
                        case "TEXT":
                            TextBox tb = FindControlRecursive(P_Fields, "f" + ii) as TextBox;
                            item_field.value = tb.Text;
                            break;
                        case "RADIO":
                            RadioButtonList rbl = FindControlRecursive(P_Fields, "f" + ii) as RadioButtonList;
                            item_field.value = rbl.SelectedValue;
                            break;
                    }
                    item_fields.Add(item_field);

                    ii++;
                }

                item.fields = Functions.Serialize(item_fields);

            }


            return item;
        }

        private Control FindControlRecursive(Control rootControl, string controlID)
        {
            if (rootControl.ID == controlID) return rootControl;

            foreach (Control controlToSearch in rootControl.Controls)
            {
                Control controlToReturn =
                    FindControlRecursive(controlToSearch, controlID);
                if (controlToReturn != null) return controlToReturn;
            }
            return null;
        }



    }


   
}