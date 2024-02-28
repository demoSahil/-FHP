using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Resources.Resource;

namespace FHP_Application
{
    /// <summary>
    /// Represents the About Us form in the application.
    /// </summary>
    public partial class Frm_AboutUs : Form
    {
        /// <summary>
        ///  Instance variable to store the resource object.
        /// </summary>
        Resource resource;

        /// <summary>
        /// Initializes a new instance of the <see cref="Frm_AboutUs"/> class.
        /// </summary>
        /// <param name="resource">The resource object providing content for the About Us form.</param>
        public Frm_AboutUs(Resource resource)
        {
            InitializeComponent();
            this.resource = resource;
            SetAboutUsContent();
        }

        /// <summary>
        /// Sets the content for various sections of the About Us form.
        /// </summary>
        public void SetAboutUsContent()
        {
            lbl_aboutUs.Text = resource.GetAboutUsContent(AboutUsSection.AboutUs);
            lbl_OurBusiness.Text = resource.GetAboutUsContent(AboutUsSection.OurBusiness);


        }
    }
}
