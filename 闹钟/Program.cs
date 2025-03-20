using System;
using System.Timers;

class Clock
{
    // 定义事件委托
    public event Action Tick;
    public event Action Alarm;

    private System.Timers.Timer timer;
    private DateTime alarmTime;

    public Clock()
    {
        timer = new System.Timers.Timer(1000);  // 每秒触发一次
        timer.Elapsed += OnTick;
    }

    public void Start()
    {
        timer.Start();
        Console.WriteLine("闹钟已启动...");
    }

    public void Stop()
    {
        timer.Stop();
        Console.WriteLine("闹钟已停止...");
    }

    // 设置闹钟
    public void SetAlarm(DateTime time)
    {
        alarmTime = time;
        Console.WriteLine($"闹钟设置成功，响铃时间：{alarmTime:HH:mm:ss}");
    }

    // Tick 事件触发
    private void OnTick(object sender, ElapsedEventArgs e)
    {
        Tick?.Invoke(); // 触发 Tick 事件
        Console.WriteLine($"滴答... 当前时间：{DateTime.Now:HH:mm:ss}");

        // 检查是否到达闹钟时间
        if (DateTime.Now.Hour == alarmTime.Hour &&
            DateTime.Now.Minute == alarmTime.Minute &&
            DateTime.Now.Second == alarmTime.Second)
        {
            Alarm?.Invoke(); // 触发 Alarm 事件
        }
    }
}

class Program
{
    static void Main()
    {
        Clock clock = new Clock();

        // 订阅事件
        clock.Tick += () => Console.WriteLine("【事件】滴答~");
        clock.Alarm += () => Console.WriteLine("【事件】闹钟响了！！！⏰");

        // 设置闹钟时间（当前时间 + 5 秒）
        DateTime alarmTime = DateTime.Now.AddSeconds(5);
        clock.SetAlarm(alarmTime);

        // 启动闹钟
        clock.Start();

        Console.WriteLine("按 Enter 结束程序...");
        Console.ReadLine();
        clock.Stop();
    }
}
