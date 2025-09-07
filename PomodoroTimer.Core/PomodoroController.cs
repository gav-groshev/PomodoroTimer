using PomodoroTimer.Interfaces;
using PomodoroTimer.Interfaces.Enums;
using PomodoroTimer.Models;

namespace PomodoroTimer.Core
{
    public class PomodoroController
    {
        private readonly TimerService _timerService;
        private readonly SessionManager _sessionManager;

        public event Action<TimeSpan>? OnTick;
        public event Action<IPomodoroSession>? OnSessionChanged;
        public event Action<int>? OnPomodoroCountChanged;

        public PomodoroController()
        {
            _timerService = new TimerService();
            _sessionManager = new SessionManager();

            _timerService.OnTick += time =>
            {
                if (time.TotalSeconds == 0)
                    EndCurrentSession();
                OnTick?.Invoke(time);
            };
        }

        public void Play()
        {
            if (_sessionManager.CurrentSession == null)
                StartSession(new WorkSession());
            else
                _timerService.Resume();
        }

        public void Pause() => _timerService.Pause();
        public void Stop() => _timerService.Stop();

        private void StartSession(IPomodoroSession session)
        {
            _sessionManager.StartSession(session);
            _timerService.Start(session.Duration);
            OnSessionChanged?.Invoke(session);
        }

        private void EndCurrentSession()
        {
            _sessionManager.EndCurrentSession();
            OnPomodoroCountChanged?.Invoke(_sessionManager.CompletedWorkSessions);

            var next = _sessionManager.GetNextSession();
            StartSession(next);
            _sessionManager.NextBreakOverride = null;
        }

        public void SetNextBreakOverride(IPomodoroSession session)
        {
            _sessionManager.SetNextBreakOverride(session);
        }

        public string GetTimeLeftString()
        {
            TimeSpan timeLeft = _timerService.GetTimeLeft();
            return $"{timeLeft.Minutes:D2}:{timeLeft.Seconds:D2}";
        }

        public string GetNextSessionString()
        {
            var next = _sessionManager.GetNextSession();
            return next.LabelText;
        }

        public IPomodoroSession GetCurrentSession() => _sessionManager.CurrentSession;
        public int GetCompletedWorkSessionCount() => _sessionManager.CompletedWorkSessions;
    }

}
