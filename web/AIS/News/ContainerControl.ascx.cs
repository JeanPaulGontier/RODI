using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AIS_News_ContainerControl : System.Web.UI.UserControl
{
    ContainerType contType;
        public ContainerType ContType
        {
            get
            {
                return contType;
            }

            set
            {
                contType = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            switch(contType)
            {
                case ContainerType.image :
                    
                    break;
                case ContainerType.text:
                    
                    break;
            }

        }

        protected void btn_titleOK_Click(object sender, EventArgs e)
        {

        }

        protected void btn_titleCANCEL_Click(object sender, EventArgs e)
        {

        }

        protected void btn_container_up_Click(object sender, EventArgs e)
        {

        }

        protected void btn_container_down_Click(object sender, EventArgs e)
        {

        }

        protected void btn_container_Delete_Click(object sender, EventArgs e)
        {

        }
    

    public enum ContainerType
    {
        image,
        text,
        imageText,
        textImage,
        filesList,
        button
    }
}