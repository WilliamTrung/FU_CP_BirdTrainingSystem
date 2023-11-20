using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.TrainingSkillService
{
    public interface ITrainingSkillService
    {
        IServiceExtra Extra { get; }
    }
    public class TrainingSkillService : ITrainingSkillService
    {
        public IServiceExtra Extra { get; }
        public TrainingSkillService(IServiceExtra extra)
        {
            Extra = extra;
        }
    }
}
