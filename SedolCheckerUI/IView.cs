namespace SedolCheckerGUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IView
    {
        string SedolNum { get; }
        bool Valid { set; }
        bool IsUserDefined { set; }
        string Validation { set; }
    }
}
