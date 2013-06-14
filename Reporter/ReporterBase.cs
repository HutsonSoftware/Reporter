using System.Windows.Forms;

namespace Reporter
{
    public partial class ReporterBase : Form
    {
        internal string _title;

        public ReporterBase()
        {
            InitializeComponent();
            _title = "Reporter";
        }
        public string Title { get { return _title; } }
    }

    public class ComboBoxItem
    {
        public string Name;
        public ParameterSet ParameterSet;
        public ComboBoxItem(string name, ParameterSet parameterSet)
        {
            this.Name = name;
            this.ParameterSet = parameterSet;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
