using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzTest.CustomerJob
{
    [DisallowConcurrentExecution]//拒绝同一时间重复执行，同一任务串行
    public class SendMessage : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(()=> {
                Console.WriteLine("准备开始上课了！时间：" + DateTime.Now);

                JobDataMap dataMap = context.JobDetail.JobDataMap;

                Console.WriteLine("JobDetail参数1:" + dataMap.Get("student1"));
                Console.WriteLine("JobDetail参数2:" + dataMap.GetInt("year"));

                JobDataMap dataMap1 = context.Trigger.JobDataMap;

                Console.WriteLine("Trigger参数1:" + dataMap1.Get("student2"));
                Console.WriteLine("Trigger参数2:" + dataMap1.GetInt("year1"));

                JobDataMap dataMap2 = context.MergedJobDataMap;//合并参数
                Console.WriteLine("MergedJobDataMap参数1:" + dataMap2.Get("student2"));
                Console.WriteLine("MergedJobDataMap参数2:" + dataMap2.GetInt("year1"));
                Console.WriteLine("MergedJobDataMap参数3:" + dataMap2.Get("student1"));
                Console.WriteLine("MergedJobDataMap参数4:" + dataMap2.GetInt("year"));
                Console.WriteLine();
            });
        }
    }
}
