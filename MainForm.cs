namespace NUnitUpdate
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.SetAppIcon();
        }

        private void BtProcess_Click(object sender, EventArgs e)
        {
            NUnitV3Upgrade.UpgradeFolder(FolderPanel.SelectedPath);
        }

        private void BtHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Code-Artist");
        }
    }
}