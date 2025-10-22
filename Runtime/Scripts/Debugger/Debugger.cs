using System;

namespace Josue.Library.Debugger
{
    public class Debugger
    {
        private Action<string> m_LogEvent;
        private Action<string> m_LogWarningEvent;
        private Action<string> m_LogErrorEvent;
        private bool m_Enabled = false;

        public Debugger(Action<string> logEvent, Action<string> logWarningEvent, Action<string> logErrorEvent)
        {
            m_LogEvent = logEvent;
            m_LogWarningEvent = logWarningEvent;
            m_LogErrorEvent = logErrorEvent;
        }

        private void InternalLog(string text, Action<string> logType)
        {
            if (!m_Enabled)
            {
                return;
            }

            logType.Invoke(text);
        }

        public void Log(string text) => InternalLog(text, m_LogEvent);

        public void LogWarning(string text) => InternalLog(text, m_LogWarningEvent);

        public void LogError(string text) => InternalLog(text, m_LogErrorEvent);

        public bool SetDebuggerActive(bool enabled) => m_Enabled = enabled;
    }
}