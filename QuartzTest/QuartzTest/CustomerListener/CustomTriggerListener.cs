﻿using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuartzTest.CustomerListener
{
    public class CustomTriggerListener : ITriggerListener
    {
        public string Name => "CustomTriggerListener";

        public async Task TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"CustomTriggerListener TriggerComplete {trigger.Description}");
            });
        }

        public async Task TriggerFired(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"CustomTriggerListener TriggerFired {trigger.Description}");
            });
        }

        public async Task TriggerMisfired(ITrigger trigger, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"CustomTriggerListener TriggerMisfired {trigger.Description}");
            });
        }
        /// <summary>
        /// 是否放弃执行job
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> VetoJobExecution(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"CustomTriggerListener VetoJobExecution {context.Trigger.Description}");
            });

            return false;//false:表示继续执行
        }
    }
}
