using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberU.Models
{
    public class EmailCheckResult
    {
        public String Name;
        public String Title;
        public String Domain;
        public String BreachDate; // Format "2019-01-07"
        public String AddedDate; // Format "2019-01-16T21:46:07Z",
        public String ModifiedDate; // Format "2019-01-16T21:50:21Z",
        public int PwnCount;
        public String Description;
        public String LogoPath;
        public List<String> DataClasses;
        public bool IsVerified;
        public bool IsFabricated;
        public bool IsSensitive;
        public bool IsRetired;
        public bool IsSpamList;
    }
}
