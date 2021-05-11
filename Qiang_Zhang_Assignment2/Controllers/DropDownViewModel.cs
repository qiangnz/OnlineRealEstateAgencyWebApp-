using System.Collections.Generic;

namespace Qiang_Zhang_Assignment2.Controllers
{
    public class DropDownViewModel
    {

        public string EmailAddress { get; set; }

        public List<EmailAddressDropDown> EmailAddressDropDownProperty { get; set; }
    }

    public class EmailAddressDropDown
    {
        public string EmailAddress { get; set; }
    }
}

