using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
    public static class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();
        static private ICollection<string> logFileLines;

        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"
            + LoginValidation.currentUserUsername + ";"
            + LoginValidation.currentUserRole + ";"
            + activity;
            currentSessionActivities.Add(activityLine);

            if (File.Exists("test.txt"))
            {
                File.AppendAllText("test.txt", activityLine + "\n");
            }
        }
        static public IEnumerable<string> GetCurrentSessionActivity(string filter)
        {
            List<string> filteredActivities = (from activity in currentSessionActivities
                                               where activity.Contains(filter)
                                               select activity).ToList();
            return filteredActivities;
        }

        static public IEnumerable<string> GetFileContent()
        {

            return logFileLines;
        }

    }
}
