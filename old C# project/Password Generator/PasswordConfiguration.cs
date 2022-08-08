using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Generator
{
    public class PasswordConfiguration
    {
        public int minLen { get; set; }
        public int maxLen { get; set; }
        public bool bIncSymbols { get; set; }
        public bool bIncNumbers { get; set; }
        public bool bIncLowerCharacters { get; set; }
        public bool bIncUpperCharacters { get; set; }
        static public PasswordConfiguration? passconfig = null;
        private PasswordConfiguration()
        {
            this.minLen = 8;
            this.maxLen = 12;
            this.bIncSymbols = false;
            this.bIncNumbers = false;
            this.bIncLowerCharacters = true;
            this.bIncUpperCharacters = true;
            Load();
        }
        protected void Load()
        {
            this.minLen = Convert.ToInt32(ConfigurationManager.AppSettings["minLen"]??"8");
            this.maxLen = Convert.ToInt32(ConfigurationManager.AppSettings["maxLen"]??"12");
            this.bIncSymbols = Convert.ToBoolean(ConfigurationManager.AppSettings["incSymbol"] ?? "false");
            this.bIncNumbers = Convert.ToBoolean(ConfigurationManager.AppSettings["incNumbers"] ?? "false");
            this.bIncLowerCharacters = Convert.ToBoolean(ConfigurationManager.AppSettings["incLowChar"] ?? "false");
            this.bIncUpperCharacters = Convert.ToBoolean(ConfigurationManager.AppSettings["incUpperChar"] ?? "false");
        }
        ~PasswordConfiguration()
        {
            Console.WriteLine($"The {ToString()} finalizer is executing.");
            //Save();
        }
        public void Save()
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);


                if (configuration.AppSettings.Settings["minLen"] != null)
                    configuration.AppSettings.Settings["minLen"].Value = this.minLen.ToString();
                else
                    configuration.AppSettings.Settings.Add("minLen", this.minLen.ToString());
                
                if(configuration.AppSettings.Settings["maxLen"] != null)
                    configuration.AppSettings.Settings["maxLen"].Value = this.maxLen.ToString();
                else
                    configuration.AppSettings.Settings.Add("maxLen", this.maxLen.ToString());
                
                if(configuration.AppSettings.Settings["incSymbol"] != null)
                    configuration.AppSettings.Settings["incSymbol"].Value = this.bIncSymbols.ToString();
                else
                    configuration.AppSettings.Settings.Add("incSymbol",this.bIncSymbols.ToString());
                
                if(configuration.AppSettings.Settings["incNumbers"] != null)
                    configuration.AppSettings.Settings["incNumbers"].Value = this.bIncNumbers.ToString();
                else
                    configuration.AppSettings.Settings.Add("incNumbers", this.bIncNumbers.ToString());

                if (configuration.AppSettings.Settings["incLowChar"] != null)
                    configuration.AppSettings.Settings["incLowChar"].Value = this.bIncLowerCharacters.ToString();
                else
                    configuration.AppSettings.Settings.Add("incLowChar", this.bIncLowerCharacters.ToString());

                if (configuration.AppSettings.Settings["incUpperChar"] != null)
                    configuration.AppSettings.Settings["incUpperChar"].Value = this.bIncUpperCharacters.ToString();
                else
                    configuration.AppSettings.Settings.Add("incUpperChar", this.bIncUpperCharacters.ToString());

                configuration.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        static public PasswordConfiguration getInstance()
        {
            if (passconfig == null) passconfig = new PasswordConfiguration();
            return passconfig;
        }
       
        public bool checkIsValid(String password)
        {
            if (password == null) return false;
            if (password.Length < minLen || password.Length > maxLen) return false;
            bool bFoundSymbols = false;
            bool bFoundNumbers = false;
            bool bFoundLowerCharacters = false;
            bool bFoundUpperCharacters = false;
            foreach (char c in password)
            {
                if (c >= '0' && c <= '9')
                    bFoundNumbers = true;
                else if (c >= 'a' && c <= 'z')
                    bFoundLowerCharacters = true;
                else if (c >= 'A' && c <= 'Z')
                    bFoundUpperCharacters = true;
                else
                    bFoundSymbols = true;
            }
            if (bIncSymbols && !bFoundSymbols) return false;
            if (bIncNumbers && !bFoundNumbers) return false;
            if (bIncUpperCharacters && !bFoundUpperCharacters) return false;
            if (bIncLowerCharacters && !bFoundLowerCharacters) return false;
            return true;
        }

        //usually, not every sysmbols,only a few of these symbols should be permitted.
        public char []permited_symbols = { '!','@','#','$','%','^','&','*','(',')','_','-',
                                            '+','=','[',']','{','}','|','\\',':',';','\"','\'',
                                            '<',',','>','.','?','/'};

        //of course you can get a easy way to find a password; I just want to get a password which is random enough
        public String GenerateRandomPassword()
        {
            //in order to create a random enough password, the length should be random
            //every item may be characters,numbers,or symbols and it should have equal chance to any of tem

            //check parameter first to avoid dead loop
            List<char> items = new List<char>();
            if (bIncSymbols) 
                items.AddRange(permited_symbols);
            if(bIncNumbers)
                for(char c = '0';c <= '9'; c++)
                    items.Add(c);
            if (bIncUpperCharacters)
                for (char c = 'A'; c <= 'Z'; c++)
                    items.Add(c);
            if(bIncLowerCharacters)
                for (char c = 'a'; c <= 'z'; c++)
                    items.Add(c);
            char[] itemArr = items.ToArray();   //why I transfer the list to array?
                                                // because locating a item is more quickly in an array
            if (itemArr.Length <= 0) return null;   //not a character is permited
            Random r = new Random();
            int len = r.Next(minLen, maxLen);   //create radom length of password
            String password = "";

            for (int i = 0; i < len; )
            {
                int pos = r.Next(itemArr.Length);
                password.Append(itemArr[pos]);
            }
            //due to every item was random, maybe the password is invalid
            if (checkIsValid(password))
                return password;
            return GenerateRandomPassword();
        }
        public String[] BatchGenerateRandomPassword(int passwordNum)
        {
            //in order to create a random enough password, the length should be random
            //every item may be characters,numbers,or symbols and it should have equal chance to any of tem

            //check parameter first to avoid dead loop
            List<char> items = new List<char>();
            if (bIncSymbols)
                items.AddRange(permited_symbols);
            if (bIncNumbers)
                for (char c = '0'; c <= '9'; c++)
                    items.Add(c);
            if (bIncUpperCharacters)
                for (char c = 'A'; c <= 'Z'; c++)
                    items.Add(c);
            if (bIncLowerCharacters)
                for (char c = 'a'; c <= 'z'; c++)
                    items.Add(c);
            char[] itemArr = items.ToArray();   //why I transfer the list to array?
                                                // because locating a item is more quickly in an array
            if (itemArr.Length <= 0) return null;   //not a character is permited
            Random r = new Random();
            int len = r.Next(minLen, maxLen);   //create radom length of password
            

            String[] passwordList = new string[passwordNum];
            for (int j = 0; j < passwordNum;)   //quit loop only when it get enough valid password
            {
                StringBuilder password = new StringBuilder(len);
                for (int i = 0; i < len;i++)
                {
                    int pos = r.Next(itemArr.Length);
                    password.Append(itemArr[pos]);
                }
                //due to every item was random, maybe the password is invalid
                if (checkIsValid(password.ToString()))
                {
                    passwordList[j] = password.ToString();
                    j++;
                }
            }
            return passwordList;
        }
    }
}
