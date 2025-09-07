
using PomodoroTimer.Interfaces;
using PomodoroTimer.Interfaces.Enums;
using PomodoroTimer.Interfaces.Utils;

namespace PomodoroTimer.Models;

public class LongBreakSession : IPomodoroSession
{
    public TimeSpan Duration => SessionDurationConfig.IsTestMode
        ? TimeSpan.FromSeconds(15)
        : TimeSpan.FromMinutes(15);
    public string Description => "Пора сделать длинный перерыв";

    public SessionType SessionType => SessionType.LongBreak;

    public bool IsWorkSession => false;

}
