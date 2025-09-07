using PomodoroTimer.Interfaces;
using PomodoroTimer.Interfaces.Enums;
using PomodoroTimer.Models;

namespace PomodoroTimer.Core
{
    public class SessionManager
    {
        private List<IPomodoroSession> _sessionHistory = new();
        private int _completedWorkSessions = 0;

        public IPomodoroSession? NextBreakOverride { get; set; }
        public IPomodoroSession CurrentSession { get; private set; } = null!;

        public void StartSession(IPomodoroSession session)
        {
            CurrentSession = session;
        }

        public void EndCurrentSession()
        {
            _sessionHistory.Add(CurrentSession);

            if (CurrentSession is WorkSession)
                _completedWorkSessions++;
        }

        public IPomodoroSession GetNextSession()
        {
            if (CurrentSession is WorkSession)
            {
                if (NextBreakOverride != null) return NextBreakOverride;
                if ((_completedWorkSessions + 1) % 10 == 0) return new ExtraLongBreakSession();
                if ((_completedWorkSessions + 1) % 5 == 0) return new LongBreakSession();
                return new ShortBreakSession();
            }

            return new WorkSession();
        }

        public void SetNextBreakOverride(IPomodoroSession session)
        {
            NextBreakOverride = session;
        }

        public int CompletedWorkSessions => _completedWorkSessions;
    }

}
