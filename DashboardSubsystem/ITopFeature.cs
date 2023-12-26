using Models.DashboardModels.Top;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardSubsystem
{
    public interface ITopFeature
    {
        Task<TopModel> RevenueWorkshop(int year);
        Task<TopModel> RegistrationWorkshop(int year);
        Task<TopModel> RevenueTrainingCourse(int year);
        Task<TopModel> RegistrationTrainingCourse(int year);
        Task<TopModel> RevenueOnlineCourse(int year);
        Task<TopModel> RegistrationOnlineCourse(int year);
        Task<TopModel> RevenueWorkshop(int month, int year);
        Task<TopModel> RegistrationWorkshop(int month, int year);
        Task<TopModel> RevenueTrainingCourse(int month, int year);
        Task<TopModel> RegistrationTrainingCourse(int month, int year);
        Task<TopModel> RevenueOnlineCourse(int month, int year);
        Task<TopModel> RegistrationOnlineCourse(int month, int year);

        Task<IEnumerable<TopTrainerModel>> TopTrainer(int month, int year);
    }
}
