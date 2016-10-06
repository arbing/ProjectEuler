using System;
using System.Diagnostics;

namespace ProjectEuler
{
    /// <summary>
    /// 计算CPU消耗时间
    /// </summary>
    public class CalculateTiming
    {
        private TimeSpan startTime;
        private TimeSpan duration;
        public CalculateTiming()
        {
            startTime = new TimeSpan(0);
            duration = new TimeSpan(0);
        }
        public void Start()
        {
            //手动执行垃圾回收
            GC.Collect();
            //挂起当前线程，直到使用GC对所有托管堆上的对象实施Finalize方法
            GC.WaitForPendingFinalizers();
            //获取当前进程、当前线程执行的起始时间
            startTime = Process.GetCurrentProcess().Threads[0].UserProcessorTime;
        }
        public void Stop()
        {
            //获取当前进程、当前线程执行所消耗的时间
            duration = Process.GetCurrentProcess().Threads[0].UserProcessorTime.Subtract(startTime);
        }
        public TimeSpan Result()
        {
            return duration;
        }
    }
}