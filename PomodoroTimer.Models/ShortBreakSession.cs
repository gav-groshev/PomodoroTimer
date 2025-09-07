
using PomodoroTimer.Interfaces;
using PomodoroTimer.Interfaces.Enums;
using PomodoroTimer.Interfaces.Utils;

namespace PomodoroTimer.Models;

public class ShortBreakSession : IPomodoroSession
{
    public TimeSpan Duration => SessionDurationConfig.IsTestMode
        ? TimeSpan.FromSeconds(5)
        : TimeSpan.FromMinutes(5);
    public string Description => "Пора сделать короткий перерыв";
    public SessionType SessionType => SessionType.ShortBreak;

    public bool IsWorkSession => false;

}
