using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BH_EmergentSoftware_Challenge
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IEnumerable<Software> allSoftware = SoftwareManager.GetAllSoftware();

                //Add all of the software to the ViewState
                ViewState.Add(SharedConstants.VIEWSTATE_KEY_ALL_SOFTWARE, allSoftware);

                //Set all of the software in the repeater
                rptSoftware.DataSource = allSoftware;
                rptSoftware.DataBind();

                //Set the currently bound software as a different value in the ViewState (if we wanted to sort it later we could do that with this)
                ViewState.Add(SharedConstants.VIEWSTATE_KEY_BOUND_SOFTWARE, allSoftware);
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            //Get the software that matches the given version number
            SoftwareFilterer softwareFilterer = new SoftwareFilterer();
            IEnumerable<Software> filteredSoftware = softwareFilterer.FilterSoftwareByGreaterVersion((IEnumerable<Software>)ViewState[SharedConstants.VIEWSTATE_KEY_ALL_SOFTWARE], txtVersion.Text.Trim());

            //Rebind the filtered software and save the filtered stuff to the ViewState
            rptSoftware.DataSource = filteredSoftware;
            rptSoftware.DataBind();

            ViewState[SharedConstants.VIEWSTATE_KEY_BOUND_SOFTWARE] = filteredSoftware;
        }
    }
}