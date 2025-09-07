
using PomodoroTimer.Interfaces;
using PomodoroTimer.Interfaces.Enums;
using PomodoroTimer.Interfaces.Utils;

namespace PomodoroTimer.Models;

public class ExtraLongBreakSession : IPomodoroSession
{
    public TimeSpan Duration => SessionDurationConfig.IsTestMode
        ? TimeSpan.FromSeconds(30)
        : TimeSpan.FromMinutes(30);
    public string Description => "Пора отдохнуть";

    public SessionType SessionType => SessionType.ExtraLongBreak;

    public bool IsWorkSession => false;

}
