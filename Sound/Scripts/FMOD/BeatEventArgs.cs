using System;


public class BeatEventArgs : EventArgs
{
    public BeatEventArgs(int beat)
    {
        this.beat = beat;
    }

    private int beat;
    public int Beat => beat;
}
