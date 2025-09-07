using PomodoroTimer.Interfaces;
using PomodoroTimer.Models;
using System.Timers;
using Timer = System.Timers.Timer;

namespace PomodoroTimer.Core;

public class PomodoroTimerService
{
    private Timer _timer;
    private TimeSpan _timeLeft;
    private IPomodoroSession? _currentSession;

    private List<IPomodoroSession> _sessionHistory;
    private int _completedWorkSessions = 0;

    // События для UI
    public event Action<TimeSpan>? OnTick;
    public event Action<IPomodoroSession>? OnSessionChanged;
    public event Action<int>? OnPomodoroCountChanged;

    /// <summary>
    ///     Инициализация таймера
    /// </summary>
    public PomodoroTimerService()
    {
        _sessionHistory = new List<IPomodoroSession>();
        _timer = new Timer(1000);
        _timer.Elapsed += Timer_Elapsed;
        _timer.AutoReset = true;
    }

    /// <summary>
    ///     Работа таймера
    /// </summary>
    private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
    {
        if (_timeLeft.TotalSeconds > 0)
        {
            _timeLeft = _timeLeft.Subtract(TimeSpan.FromSeconds(1));
            OnTick?.Invoke(_timeLeft);
        }
        else
        {
            EndCurrentSession();
        }
    }

    /// <summary>
    ///     Старт таймера
    /// </summary>
    /// <remarks>
    ///     Если первая сессия - начинаем новую рабочую сессию
    ///     Иначе - ставим текущую сессию на паузу
    /// </remarks>
    public void Play()
    {
        if (_currentSession == null)
        {
            StartNewSession(new WorkSession());
        }
        else
        {
            // переключение play/pause
            if (_timer.Enabled)
                _timer.Stop();
            else
                _timer.Start();
        }
    }

    /// <summary>
    ///     Полная остановка таймера
    /// </summary>
    public void Stop()
    {
        _timer.Stop();
        _currentSession = null;
        _timeLeft = TimeSpan.Zero;
        _sessionHistory.Clear();
        _completedWorkSessions = 0;
        OnTick?.Invoke(_timeLeft);
        OnPomodoroCountChanged?.Invoke(0);
    }

    /// <summary>
    ///     Запуск новой сессии
    /// </summary>
    private void StartNewSession(IPomodoroSession session)
    {
        _currentSession = session;
        _timeLeft = session.Duration;
        _timer.Start();
        OnSessionChanged?.Invoke(session);
    }

    /// <summary>
    ///     Завершение текущей сессии
    /// </summary>
    private void EndCurrentSession()
    {
        _timer.Stop();

        if (_currentSession == null)
            throw new Exception($"Ошибка завершения текущей сессии");

        _sessionHistory.Add(_currentSession);

        if (_currentSession is WorkSession)
        {
            _completedWorkSessions++;
            OnPomodoroCountChanged?.Invoke(_completedWorkSessions);

            // Каждые 5 work session — длинный перерыв 15 минут
            if (_completedWorkSessions % 5 == 0)
            {
                StartNewSession(new LongBreakSession());
                return;
            }

            // После 10 work session — большой перерыв 30 минут
            if (_completedWorkSessions % 10 == 0)
            {
                StartNewSession(new ExtraLongBreakSession());
                return;
            }

            // обычный короткий перерыв
            StartNewSession(new ShortBreakSession());
        }
        else
        {
            // после любого перерыва — возвращаемся к рабочей сессии
            StartNewSession(new WorkSession());
        }
    }

    /// <summary>
    ///     Получаем следующую сессию
    /// </summary>
    /// <returns>
    ///     После 5 рабочих сессий - перерыв 15 минут
    ///     После 10 рабочих сессий - перерыв 30 минут
    /// </returns>
    public IPomodoroSession GetNextSession()
    {
        if (_currentSession is WorkSession)
        {
            if ((_completedWorkSessions + 1) % 10 == 0) return new ExtraLongBreakSession();
            if ((_completedWorkSessions + 1) % 5 == 0) return new LongBreakSession();
            return new ShortBreakSession();
        }

        // После любого перерыва — рабочая сессия
        return new WorkSession();
    }

    public TimeSpan GetTimeLeft()
    {
        return _timeLeft;
    }
}
