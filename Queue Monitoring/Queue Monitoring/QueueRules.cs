using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Queue_Monitoring
{
    class QueueRules
    {
        public List<string> RuleSets = new List<string>();
        


        public QueueRules()
        {
            OpenFileandRead();
        }



        private void OpenFileandRead()
        {
            //if no file, return the defaults which will be a null list
            try
            {
                //RuleSets.Clear();
                string tmpline = string.Empty;
                StreamReader DataStream = new StreamReader(@"\\mainnt\common\Public Common\Sage100SupportApps\QueueRules\rules.txt");
                while (DataStream.EndOfStream == false)
                {
                    tmpline = DataStream.ReadLine();
                    if (tmpline.Trim() != "" && tmpline.Contains("//") == false)
                    {
                        RuleSets.Add(tmpline);
                    }

                }
                DataStream.Close();
            }
            catch (Exception e)
            {
                RuleSets.Add("Fatal: " + e.Message);
            }
        }



    }
}
