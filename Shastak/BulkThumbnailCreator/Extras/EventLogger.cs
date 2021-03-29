using System;
using System.Configuration;
using System.Diagnostics;

namespace BulkThumbnailCreator.Extras
{
    public static class EventLogger
    {
        private static string LogName { get; set; }
        private static string SourceName { get; set; }

        public static void CreateEventViewerSource()
        {
            LogName = ConfigurationManager.AppSettings.Get("logName");
            SourceName = ConfigurationManager.AppSettings.Get("sourceName");

            // trying to create new Event Source using name of this program from app.config (need Admin permissions)
            try
            {
                if (!EventLog.SourceExists(SourceName))
                {
                    var eventSourceData = new EventSourceCreationData(SourceName, LogName);
                    EventLog.CreateEventSource(eventSourceData);
                }
            }

            // if exception is catched, program uses default Source Name
            catch
            {
                SourceName = LogName;
            }
        }

        public static void WriteLogs(string message, EventLogEntryType type)
        {
            using (EventLog el = new EventLog(LogName))
            {
                string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffff");

                el.Source = SourceName;
                el.WriteEntry($"[{now}] " + message, type, 101, 1);
            }
        }
    }
}
