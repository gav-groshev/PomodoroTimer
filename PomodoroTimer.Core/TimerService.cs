using System.Timers;
using Timer = System.Timers.Timer;

namespace PomodoroTimer.Core
{
    internal class TimerService
    {
        private Timer _timer;
        private TimeSpan _timeLeft;

        public event Action<TimeSpan>? OnTick;

        public TimerService()
        {
            _timer = new Timer(1000);
            _timer.Elapsed += Timer_Elapsed;
            _timer.AutoReset = true;
        }

        public void Start(TimeSpan duration)
        {
            _timeLeft = duration;
            _timer.Start();
        }

        public void Stop() => _timer.Stop();
        public void Pause() => _timer.Stop();
        public void Resume() => _timer.Start();

        public TimeSpan GetTimeLeft() => _timeLeft;
        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            if (_timeLeft.TotalSeconds > 0)
            {
                _timeLeft -= TimeSpan.FromSeconds(1);
                OnTick?.Invoke(_timeLeft);
            }
            else
            {
                _timer.Stop();
                OnTick?.Invoke(TimeSpan.Zero);
            }
        }
    }
}
