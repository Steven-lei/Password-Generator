namespace Password_Generator
{
    public partial class FormGenerator : Form
    {
        public FormGenerator()
        {
            InitializeComponent();
            InitConfigData();
        }

        private void InitConfigData()
        {
            PasswordConfiguration passconf = PasswordConfiguration.getInstance();
            this.textBoxMinLen.Text = passconf.minLen.ToString();
            this.textBoxMaxLen.Text = passconf.maxLen.ToString();
            this.checkBoxIncLower.Checked = passconf.bIncLowerCharacters;
            this.checkBoxIncUpper.Checked = passconf.bIncUpperCharacters;
            this.checkBoxIncNumbers.Checked = passconf.bIncNumbers;
            this.checkBoxIncSymbols.Checked = passconf.bIncSymbols;
        }
 
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            int minLen = 0;
            int maxLen = 0;
            bool bIncSymbols = false;
            bool bIncNumbers = false;
            bool bIncLowerCharacters = false;
            bool bIncUpperCharacters = false;
            bool bBatchCreate = false;
            int createnum = 1;
            try
            {
                minLen = Convert.ToInt32(this.textBoxMinLen.Text);
                maxLen = Convert.ToInt32(this.textBoxMaxLen.Text);
                bIncLowerCharacters = this.checkBoxIncLower.Checked;
                bIncUpperCharacters = this.checkBoxIncUpper.Checked;
                bIncSymbols = this.checkBoxIncSymbols.Checked;
                bIncNumbers = this.checkBoxIncNumbers.Checked;
                bBatchCreate = this.checkBoxBatchCreate.Checked;
                if(bBatchCreate)
                    createnum = Convert.ToInt32(this.textBoxCreateCount.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            //check whether parameters is correct

            if (minLen < 0 || minLen > 30 && maxLen < 0 || maxLen > 30)
            {
                MessageBox.Show("wrong length of setting passwordlen");
                return;
            }
            if (minLen > maxLen)
            {
                MessageBox.Show("Maxlen should greater than minLen");
                return;
            }
            if (!bIncLowerCharacters && !bIncUpperCharacters && !bIncNumbers && !bIncSymbols)
            {
                MessageBox.Show("a password show include at least one of characters,numbers, or symbol");
                return;
            }
            PasswordConfiguration passconf = PasswordConfiguration.getInstance();
            passconf.minLen = minLen;
            passconf.maxLen = maxLen;
            passconf.bIncLowerCharacters=  bIncLowerCharacters;
            passconf.bIncUpperCharacters= bIncUpperCharacters;
            passconf.bIncNumbers= bIncNumbers;
            passconf.bIncSymbols= bIncSymbols;
            passconf.Save();
            String[] passwordList = passconf.BatchGenerateRandomPassword(createnum);
            UpdatePasswordList(passwordList);
            passconf = null;
        }
        protected void UpdatePasswordList(string[] passList)
        {
            if (passList == null)
            {
                MessageBox.Show("create failure");
                return;
            }
            //update the view;
            this.listBox1.Items.Clear();
            foreach (string pass in passList)
            {
                int nSel = this.listBox1.Items.Add(pass);
                this.listBox1.SetSelected(nSel, true);
            }
        }

        private void checkBoxBatchCreate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxBatchCreate.Checked)
                this.textBoxCreateCount.ReadOnly = false;
            else
                this.textBoxCreateCount.ReadOnly = true;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            String str = "";
            for(int i=0;i<listBox1.SelectedItems.Count;i++)
            {
                str += listBox1.SelectedItems[i].ToString() + "\r\n";
            }

            Clipboard.SetText(str);
            MessageBox.Show("The following string was copied to clipboard:\r\n" + str);
        }
    }
}