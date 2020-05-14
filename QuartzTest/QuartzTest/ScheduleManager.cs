using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzTest
{
    public class ScheduleManager
    {
        public async static Task<IScheduler> BuildScheduler()
        {
            var properties = new NameValueCollection();
            properties["quartz.scheduler.instanceName"] = "百腾定时任务监控系统";//服务名称

            // 设置线程池
            properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
            properties["quartz.threadPool.threadCount"] = "5";//线程数量
            properties["quartz.threadPool.threadPriority"] = "Normal";

            // 远程输出配置
            properties["quartz.scheduler.exporter.type"] = "Quartz.Simpl.RemotingSchedulerExporter, Quartz";
            properties["quartz.scheduler.exporter.port"] = "8008";//设置端口
            properties["quartz.scheduler.exporter.bindName"] = "QuartzScheduler";//绑定名称
            properties["quartz.scheduler.exporter.channelType"] = "tcp";//通讯协议类型

            var schedulerFactory = new StdSchedulerFactory(properties);
            IScheduler _scheduler = await schedulerFactory.GetScheduler();
            return _scheduler;
        }
    }
}
