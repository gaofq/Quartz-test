using Quartz;
using Quartz.Impl;
using Quartz.Simpl;
using Quartz.Xml;
using QuartzTest.CustomerJob;
using QuartzTest.CustomerListener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzTest
{
    /// <summary>
    /// 三大核心对象：
    /// 1.IScheduler:单元/实例，定时任务配置，单元启动后，作业才能正常运行
    /// 2.ITrigger:定时策略
    /// 3.IJob:任务，定时执行动作就是Job
    /// 参数：
    /// 1.传参数：jobDetail.JobDataMap.Add("student1","gaofq");
    /// 2.接参数：dataMap.Get("student1")
    /// Listener监听事件
    /// </summary>
    public class DispatcherManager
    {
        public static async Task Init()
        {

            {
                //代码写法
                //#region Scheduler
                //StdSchedulerFactory factory = new StdSchedulerFactory();
                //IScheduler scheduler = await factory.GetScheduler();

                //scheduler.ListenerManager.AddSchedulerListener(new CustomSchedulerListener());
                //scheduler.ListenerManager.AddTriggerListener(new CustomTriggerListener());
                //scheduler.ListenerManager.AddJobListener(new CustomJobListener());
                //await scheduler.Start();
                //#endregion

                //#region IJobDetail:创建作业;
                //IJobDetail jobDetail = JobBuilder.Create<SendMessage>().WithIdentity("testjob", "group1")
                //    .WithDescription("This is testjob")
                //    .Build();
                //jobDetail.JobDataMap.Add("student1", "gaofq");
                //jobDetail.JobDataMap.Add("year", DateTime.Now.Year);
                //#endregion

                //#region ITrigger：创建时间策略;
                //ITrigger trigger = TriggerBuilder.Create().WithIdentity("sendtrigger", "group1")
                //    .StartNow()//从现在开始
                //    .WithCronSchedule("0/5 * * * * ?")//每隔一分钟
                //    .WithDescription("This is test job's trigger")
                //    .Build();
                //trigger.JobDataMap.Add("student2", "gaofq2");
                //trigger.JobDataMap.Add("year1", DateTime.Now.Year);
                //#endregion

                //await scheduler.ScheduleJob(jobDetail, trigger);
            }

            {
                //配置文件写法
                IScheduler scheduler = await ScheduleManager.BuildScheduler();

                //使用配置文件
                XMLSchedulingDataProcessor processor = new XMLSchedulingDataProcessor(new SimpleTypeLoadHelper());
                await processor.ProcessFileAndScheduleJobs("~/quartz_jobs.xml", scheduler);

                scheduler.ListenerManager.AddSchedulerListener(new CustomSchedulerListener());
                scheduler.ListenerManager.AddTriggerListener(new CustomTriggerListener());
                scheduler.ListenerManager.AddJobListener(new CustomJobListener());
                await scheduler.Start();
            }

        }
    }
}
