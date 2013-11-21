using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Riveu.NotificationsService
{
    public partial class SupportTicketEditUserControl : System.Web.UI.UserControl
    {
        private object _dataItem = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            DataBinding +=SupportTicketEditUserControl_DataBinding;
            base.OnInit(e);
        }

        void SupportTicketEditUserControl_DataBinding(object sender, EventArgs e)
        {
            object projectValue = DataBinder.Eval(DataItem, "Project");
            if (projectValue == DBNull.Value)
            {
                projectValue = "---";
            }
            projectDropDown.SelectedText = projectValue.ToString();
        }

        public object DataItem
        {
            get
            {
                return this._dataItem;
            }
            set
            {
                this._dataItem = value;
            }
        }
    }
}