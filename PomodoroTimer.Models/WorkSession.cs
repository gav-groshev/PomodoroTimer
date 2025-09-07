
using PomodoroTimer.Interfaces;
using PomodoroTimer.Interfaces.Enums;
using PomodoroTimer.Interfaces.Utils;

namespace PomodoroTimer.Models;

public class WorkSession : IPomodoroSession
{
    public TimeSpan Duration => SessionDurationConfig.IsTestMode
        ? TimeSpan.FromSeconds(25) 
        : TimeSpan.FromMinutes(25);
    public string Description => "Пора работать";
    public SessionType SessionType => SessionType.Work;

    public bool IsWorkSession => true;
}
