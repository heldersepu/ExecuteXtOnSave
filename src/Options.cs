using Microsoft.VisualStudio.Shell;
using System.ComponentModel;

namespace ExecuteXtOnSave
{
    public class Options : DialogPage
    {
        public Options()
        {
            ExecuteXtOnSave = true;
            ExecuteXtCommand = "";
        }

        [Category("General")]
        [DisplayName("Execute external on save")]
        [Description("Execute an external command on save")]
        [DefaultValue(true)]
        public bool ExecuteXtOnSave { get; set; }

        [Category("General")]
        [DisplayName("ExecuteXt command")]
        [Description("The external command to execute")]
        [DefaultValue("")]
        public string ExecuteXtCommand { get; set; }

    }
}
