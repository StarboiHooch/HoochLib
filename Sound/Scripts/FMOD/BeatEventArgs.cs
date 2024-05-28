using System;
using HoochLib.Sound.Scripts.FMOD;


public class BeatEventArgs : EventArgs
{
    public BeatEventArgs(int beat, int bar, string eventPath)
    {
        this.beat = beat;
        this.bar = bar;
        this.eventPath = eventPath;
    }

    private int beat;
    private int bar;
    private string eventPath;
    public int Beat => beat;
    public int Bar => bar;
    public string EventPath => eventPath;
}
