using AppRepository.UnitOfWork;
using Models.DashboardModels.Top;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CS8629 // Nullable value type may be null.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8601 // Possible null reference assignment.
namespace DashboardSubsystem.Implementation
{
    public class TopFeature : ITopFeature
    {
        private readonly IUnitOfWork _uow;
        public TopFeature(IUnitOfWork uow)
        {
            _uow = uow;
        }
        #region ByYear
        public async Task<TopModel> RegistrationOnlineCourse(int year)
        {
            var transactions = await _uow.TransactionRepository.Get(c => c.PaymentDate.Value.Year == year
                                                                        && c.EntityTypeId == (int)Models.Enum.EntityType.OnlineCourse);
            if (transactions.Count() <= 0)
            {
                return new TopModel
                {
                    Title = "Highest Registration Online Course",
                };
            }
            var groups = transactions.GroupBy(c => c.EntityId);
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            foreach (var group in groups)
            {
                int registrationCount = (int)group.Count();
                int id = group.Key == null ? 0 : (int)group.Key;
                keyValuePairs.Add(id, registrationCount);
            }
            var top = keyValuePairs.OrderByDescending(c => c.Value).Take(5);

            var result = new TopModel
            {
                Title = "Highest Registration Online Course",
            };
            foreach (var item in top)
            {
                var course = await _uow.OnlineCourseRepository.GetFirst(c => c.Id == item.Key);
                if (course != null)
                {
                    var model = new Model
                    {
                        Label = course.Title,
                        Y = item.Value,
                    };
                    result.DataPoints.Add(model);
                } else
                {
                    var model = new Model
                    {
                        Label = "Fake Course",
                        Y = item.Value,
                    };
                    result.DataPoints.Add(model);
                }
            }
            result.DataPoints = result.DataPoints.OrderBy(c => c.Y).ToList();
            return result;
        }

        public async Task<TopModel> RegistrationTrainingCourse(int year)
        {
            var transactions = await _uow.TransactionRepository.Get(c => c.PaymentDate.Value.Year == year
                                                                   && c.EntityTypeId == (int)Models.Enum.EntityType.TrainingCourse);
            if (transactions.Count() <= 0)
            {
                return new TopModel
                {
                    Title = "Highest Registration Training Course",
                };
            }
            var allCourses = await _uow.BirdTrainingCourseRepository.Get(null, nameof(BirdTrainingCourse.TrainingCourse));
            var registrations = allCourses.Where(c => transactions.Any(t => t.EntityId == c.Id));
            var groupCourses = registrations.GroupBy(c => c.TrainingCourse);
            Dictionary<TrainingCourse, int> keyValuePairs = new Dictionary<TrainingCourse, int>();
            foreach (var groupCourse in groupCourses)
            {
                int sum = 0;
                foreach (var registration in groupCourse)
                {
                    sum = transactions.Where(c => c.EntityId == registration.Id).Count();
                }
                keyValuePairs.Add(groupCourse.Key, sum);
            }

            var result = new TopModel
            {
                Title = "Highest Registration Training Course",
            };
            foreach (var item in keyValuePairs)
            {
                var model = new Model
                {
                    Label = item.Key.Title,
                    Y = item.Value,
                };
                result.DataPoints.Add(model);
            }
            int totalFake = transactions.Where(c => c.EntityId == null).Count();
            if (totalFake > 0)
            {
                result.DataPoints.Add(new Model
                {
                    Label = "Fake Class",
                    Y = totalFake,
                });
            }
            result.DataPoints = result.DataPoints.OrderBy(c => c.Y).ToList();
            return result;
        }

        public async Task<TopModel> RegistrationWorkshop(int year)
        {
            var transactions = await _uow.TransactionRepository.Get(c => c.PaymentDate.Value.Year == year
                                                                     && c.EntityTypeId == (int)Models.Enum.EntityType.WorkshopClass);
            if (transactions.Count() <= 0)
            {
                return new TopModel
                {
                    Title = "Highest Registration Workshop",
                };
            }
            var allClasses = await _uow.WorkshopClassRepository.Get(null, nameof(WorkshopClass.Workshop));
            var workshopClasses = allClasses.Where(c => transactions.Any(t => t.EntityId == c.Id));
            var groupWorkshops = workshopClasses.GroupBy(c => c.Workshop);
            Dictionary<Workshop, int> keyValuePairs = new Dictionary<Workshop, int>();
            foreach (var groupWorkshop in groupWorkshops)
            {
                int sum = 0;
                foreach (var workshopClass in groupWorkshop)
                {
                    sum = transactions.Where(c => c.EntityId == workshopClass.Id).Count();
                }
                keyValuePairs.Add(groupWorkshop.Key, sum);
            }
            

            var result = new TopModel
            {
                Title = "Highest Registration Workshop",
            };
            foreach (var item in keyValuePairs)
            {
                var model = new Model
                {
                    Label = item.Key.Title,
                    Y = item.Value,
                };
                result.DataPoints.Add(model);
            }

            int totalFake = transactions.Where(c => c.EntityId == null).Count();
            if(totalFake > 0)
            {
                result.DataPoints.Add(new Model
                {
                    Label = "Fake Class",
                    Y = totalFake,
                });
            }
            

            result.DataPoints = result.DataPoints.OrderBy(c => c.Y).ToList();
            return result;
        }

        public async Task<TopModel> RevenueOnlineCourse(int year)
        {
            var transactions = await _uow.TransactionRepository.Get(c => c.PaymentDate.Value.Year == year
                                                                      && c.EntityTypeId == (int)Models.Enum.EntityType.OnlineCourse);
            if (transactions.Count() <= 0)
            {
                return new TopModel
                {
                    Title = "Highest Revenue Online Course",
                };
            }
            var groups = transactions.GroupBy(c => c.EntityId);
            Dictionary<int, decimal> keyValuePairs = new Dictionary<int, decimal>();
            foreach (var group in groups)
            {
                decimal sumAll = (decimal)group.Sum(c => c.TotalPayment);
                int id = group.Key == null ? 0 : (int)group.Key;
                keyValuePairs.Add(id, sumAll);
            }
            var top = keyValuePairs.OrderByDescending(c => c.Value).Take(5);

            var result = new TopModel
            {
                Title = "Highest Revenue Online Course",
            };
            foreach (var item in top)
            {
                var course = await _uow.OnlineCourseRepository.GetFirst(c => c.Id == item.Key);
                if (course != null)
                {
                    var model = new Model
                    {
                        Label = course.Title,
                        Y = item.Value,
                    };
                    result.DataPoints.Add(model);
                } else
                {
                    var model = new Model
                    {
                        Label = "Fake Course",
                        Y = item.Value,
                    };
                    result.DataPoints.Add(model);
                }
            }
            result.DataPoints = result.DataPoints.OrderBy(c => c.Y).ToList();
            return result;
        }

        public async Task<TopModel> RevenueTrainingCourse(int year)
        {
            var transactions = await _uow.TransactionRepository.Get(c => c.PaymentDate.Value.Year == year
                                                                    && c.EntityTypeId == (int)Models.Enum.EntityType.TrainingCourse);
            if (transactions.Count() <= 0)
            {
                return new TopModel
                {
                    Title = "Highest Revenue Training Course",
                };
            }
            var allRegistrations = await _uow.BirdTrainingCourseRepository.Get(null, nameof(BirdTrainingCourse.TrainingCourse));
            var registrations = allRegistrations.Where(c => transactions.Any(t => t.EntityId == c.Id));
            var groupCourses = registrations.GroupBy(c => c.TrainingCourse);
            Dictionary<TrainingCourse, decimal> keyValuePairs = new Dictionary<TrainingCourse, decimal>();
            foreach (var groupCourse in groupCourses)
            {
                decimal sum = 0;
                foreach (var registration in groupCourse)
                {
                    sum = (decimal)transactions.Where(c => c.EntityId == registration.Id).Sum(e => e.TotalPayment);
                }
                keyValuePairs.Add(groupCourse.Key, sum);
            }
            

            var result = new TopModel
            {
                Title = "Highest Revenue Training Course",
            };
            foreach (var item in keyValuePairs)
            {
                var model = new Model
                {
                    Label = item.Key.Title,
                    Y = item.Value,
                };
                result.DataPoints.Add(model);
            }

            if(transactions.Any(c => c.EntityId == null))
            {
                decimal totalFake = (decimal)transactions.Where(c => c.EntityId == null).Sum(e => e.TotalPayment);
                result.DataPoints.Add(new Model
                {
                    Label = "Fake Training Course",
                    Y = totalFake,
                });
            }
            result.DataPoints = result.DataPoints.OrderBy(c => c.Y).ToList();
            return result;
        }

        public async Task<TopModel> RevenueWorkshop(int year)
        {
            var transactions = await _uow.TransactionRepository.Get(c => c.PaymentDate.Value.Year == year
                                                                     && c.EntityTypeId == (int)Models.Enum.EntityType.WorkshopClass);
            if(transactions.Count() <= 0)
            {
                return new TopModel
                {
                    Title = "Highest Revenue Workshop",
                };
            }
            var allClasses = await _uow.WorkshopClassRepository.Get(null, nameof(WorkshopClass.Workshop));
            var workshopClasses = allClasses.Where(c => transactions.Any(t => t.EntityId == c.Id));
            var groupWorkshops = workshopClasses.GroupBy(c => c.Workshop);
            Dictionary<Workshop, decimal> keyValuePairs = new Dictionary<Workshop, decimal>();
            foreach (var groupWorkshop in groupWorkshops)
            {
                decimal sum = 0;
                foreach (var workshopClass in groupWorkshop)
                {
                    sum = (decimal)transactions.Where(c => c.EntityId == workshopClass.Id).Sum(e => e.TotalPayment);
                }
                keyValuePairs.Add(groupWorkshop.Key, sum);
            }

            var result = new TopModel
            {
                Title = "Highest Revenue Workshop",
            };
            foreach (var item in keyValuePairs)
            {
                var model = new Model
                {
                    Label = item.Key.Title,
                    Y = item.Value,
                };
                result.DataPoints.Add(model);
            }

            if (transactions.Any(c => c.EntityId == null))
            {
                decimal totalFake = (decimal)transactions.Where(c => c.EntityId == null).Sum(e => e.TotalPayment);
                result.DataPoints.Add(new Model
                {
                    Label = "Fake Class",
                    Y = totalFake,
                });
            }
            result.DataPoints = result.DataPoints.OrderBy(c => c.Y).ToList();
            return result;
        }
        #endregion
        #region ByMonth
        public async Task<TopModel> RegistrationOnlineCourse(int month, int year)
        {
            var transactions = await _uow.TransactionRepository.Get(c => c.PaymentDate.Value.Year == year
                                                                        && c.PaymentDate.Value.Month == month
                                                                        && c.EntityTypeId == (int)Models.Enum.EntityType.OnlineCourse);
            if (transactions.Count() <= 0)
            {
                return new TopModel
                {
                    Title = "Highest Registration Online Course In Month",
                };
            }
            var groups = transactions.GroupBy(c => c.EntityId);
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            foreach (var group in groups)
            {
                int registrationCount = (int)group.Count();
                int id = group.Key == null ? 0 : (int)group.Key;
                keyValuePairs.Add(id, registrationCount);
            }
            var top = keyValuePairs.OrderByDescending(c => c.Value).Take(5);

            var result = new TopModel
            {
                Title = "Highest Registration Online Course",
            };
            foreach (var item in top)
            {
                var course = await _uow.OnlineCourseRepository.GetFirst(c => c.Id == item.Key);
                if (course != null)
                {
                    var model = new Model
                    {
                        Label = course.Title,
                        Y = item.Value,
                    };
                    result.DataPoints.Add(model);
                }
                else
                {
                    var model = new Model
                    {
                        Label = "Fake Course",
                        Y = item.Value,
                    };
                    result.DataPoints.Add(model);
                }
            }
            result.DataPoints = result.DataPoints.OrderByDescending(c => c.Y).ToList();
            return result;
        }

        public async Task<TopModel> RegistrationTrainingCourse(int month, int year)
        {
            var transactions = await _uow.TransactionRepository.Get(c => c.PaymentDate.Value.Year == year
                                                                   && c.PaymentDate.Value.Month == month
                                                                   && c.EntityTypeId == (int)Models.Enum.EntityType.TrainingCourse);
            if (transactions.Count() <= 0)
            {
                return new TopModel
                {
                    Title = "Highest Registration Training Course In Month",
                };
            }
            var allCourses = await _uow.BirdTrainingCourseRepository.Get(null, nameof(BirdTrainingCourse.TrainingCourse));
            var registrations = allCourses.Where(c => transactions.Any(t => t.EntityId == c.Id));
            var groupCourses = registrations.GroupBy(c => c.TrainingCourse);
            Dictionary<TrainingCourse, int> keyValuePairs = new Dictionary<TrainingCourse, int>();
            foreach (var groupCourse in groupCourses)
            {
                int sum = 0;
                foreach (var registration in groupCourse)
                {
                    sum = transactions.Where(c => c.EntityId == registration.Id).Count();
                }
                keyValuePairs.Add(groupCourse.Key, sum);
            }
            

            var result = new TopModel
            {
                Title = "Highest Registration Training Course",
            };
            foreach (var item in keyValuePairs)
            {
                var model = new Model
                {
                    Label = item.Key.Title,
                    Y = item.Value,
                };
                result.DataPoints.Add(model);
            }
            int totalFake = transactions.Where(c => c.EntityId == null).Count();
            if(totalFake > 0)
            {
                result.DataPoints.Add(new Model
                {
                    Label = "Fake Training Course",
                    Y = totalFake,
                });
            }
            result.DataPoints = result.DataPoints.OrderByDescending(c => c.Y).ToList();
            return result;
        }

        public async Task<TopModel> RegistrationWorkshop(int month, int year)
        {
            var transactions = await _uow.TransactionRepository.Get(c => c.PaymentDate.Value.Year == year && c.PaymentDate.Value.Month == month
                                                                     && c.EntityTypeId == (int)Models.Enum.EntityType.WorkshopClass);
            if (transactions.Count() <= 0)
            {
                return new TopModel
                {
                    Title = "Highest Registration Workshop In Month",
                };
            }
            var allClasses = await _uow.WorkshopClassRepository.Get(null, nameof(WorkshopClass.Workshop));
            var workshopClasses = allClasses.Where(c => transactions.Any(t => t.EntityId == c.Id));
            var groupWorkshops = workshopClasses.GroupBy(c => c.Workshop);
            Dictionary<Workshop, int> keyValuePairs = new Dictionary<Workshop, int>();
            foreach (var groupWorkshop in groupWorkshops)
            {
                int sum = 0;
                foreach (var workshopClass in groupWorkshop)
                {
                    sum = transactions.Where(c => c.EntityId == workshopClass.Id).Count();
                }
                keyValuePairs.Add(groupWorkshop.Key, sum);
            }

            var result = new TopModel
            {
                Title = "Highest Registration Workshop In Month",
            };
            foreach (var item in keyValuePairs)
            {
                var model = new Model
                {
                    Label = item.Key.Title,
                    Y = item.Value,
                };
                result.DataPoints.Add(model);
            }
            int totalFake = transactions.Where(c => c.EntityId == null).Count();
            if (totalFake > 0)
            {
                result.DataPoints.Add(new Model
                {
                    Label = "Fake Class",
                    Y = totalFake,
                });
            }
            result.DataPoints = result.DataPoints.OrderByDescending(c => c.Y).ToList();
            return result;
        }

        public async Task<TopModel> RevenueOnlineCourse(int month, int year)
        {
            var transactions = await _uow.TransactionRepository.Get(c => c.PaymentDate.Value.Year == year && c.PaymentDate.Value.Month == month
                                                                      && c.EntityTypeId == (int)Models.Enum.EntityType.OnlineCourse);
            if (transactions.Count() <= 0)
            {
                return new TopModel
                {
                    Title = "Highest Revenue Online Course In Month",
                };
            }
            var groups = transactions.GroupBy(c => c.EntityId);
            Dictionary<int, decimal> keyValuePairs = new Dictionary<int, decimal>();
            foreach (var group in groups)
            {
                decimal sumAll = (decimal)group.Sum(c => c.TotalPayment);
                int id = group.Key == null ? 0 : (int)group.Key;
                keyValuePairs.Add(id, sumAll);
            }
            var top = keyValuePairs.OrderByDescending(c => c.Value).Take(5);

            var result = new TopModel
            {
                Title = "Highest Revenue Online Course In Month",
            };
            foreach (var item in top)
            {
                var course = await _uow.OnlineCourseRepository.GetFirst(c => c.Id == item.Key);
                if (course != null)
                {
                    var model = new Model
                    {
                        Label = course.Title,
                        Y = item.Value,
                    };
                    result.DataPoints.Add(model);
                }
                else
                {
                    var model = new Model
                    {
                        Label = "Fake Course",
                        Y = item.Value,
                    };
                    result.DataPoints.Add(model);
                }
            }
            result.DataPoints = result.DataPoints.OrderByDescending(c => c.Y).ToList();
            return result;
        }

        public async Task<TopModel> RevenueTrainingCourse(int month, int year)
        {
            var transactions = await _uow.TransactionRepository.Get(c => c.PaymentDate.Value.Year == year && c.PaymentDate.Value.Month == month
                                                                    && c.EntityTypeId == (int)Models.Enum.EntityType.TrainingCourse);
            if (transactions.Count() <= 0)
            {
                return new TopModel
                {
                    Title = "Highest Revenue Training Course In Month",
                };
            }
            var allRegistrations = await _uow.BirdTrainingCourseRepository.Get(null, nameof(BirdTrainingCourse.TrainingCourse));
            var registrations = allRegistrations.Where(c => transactions.Any(t => t.EntityId == c.Id));
            var groupCourses = registrations.GroupBy(c => c.TrainingCourse);
            Dictionary<TrainingCourse, decimal> keyValuePairs = new Dictionary<TrainingCourse, decimal>();
            foreach (var groupCourse in groupCourses)
            {
                decimal sum = 0;
                foreach (var registration in groupCourse)
                {
                    sum = (decimal)transactions.Where(c => c.EntityId == registration.Id).Sum(e => e.TotalPayment);
                }
                keyValuePairs.Add(groupCourse.Key, sum);
            }
            

            var result = new TopModel
            {
                Title = "Highest Revenue Training Course In Month",
            };
            foreach (var item in keyValuePairs)
            {
                var model = new Model
                {
                    Label = item.Key.Title,
                    Y = item.Value,
                };
                result.DataPoints.Add(model);
            }
            if(transactions.Any(c => c.EntityId == null))
            {
                decimal totalFake = (decimal)transactions.Where(c => c.EntityId == null).Sum(e => e.TotalPayment);
                result.DataPoints.Add(new Model
                {
                    Label = "Fake Training Course",
                    Y = totalFake,
                });
            }
            result.DataPoints = result.DataPoints.OrderByDescending(c => c.Y).ToList();
            return result;
        }

        public async Task<TopModel> RevenueWorkshop(int month, int year)
        {
            var transactions = await _uow.TransactionRepository.Get(c => c.PaymentDate.Value.Year == year && c.PaymentDate.Value.Month == month
                                                                     && c.EntityTypeId == (int)Models.Enum.EntityType.WorkshopClass);
            if (transactions.Count() <= 0)
            {
                return new TopModel
                {
                    Title = "Highest Revenue Workshop In Month",
                };
            }
            var allClasses = await _uow.WorkshopClassRepository.Get(null, nameof(WorkshopClass.Workshop));
            var workshopClasses = allClasses.Where(c => transactions.Any(t => t.EntityId == c.Id));
            var groupWorkshops = workshopClasses.GroupBy(c => c.Workshop);
            Dictionary<Workshop, decimal> keyValuePairs = new Dictionary<Workshop, decimal>();
            foreach (var groupWorkshop in groupWorkshops)
            {
                decimal sum = 0;
                foreach (var workshopClass in groupWorkshop)
                {
                    sum = (decimal)transactions.Where(c => c.EntityId == workshopClass.Id).Sum(e => e.TotalPayment);
                }
                keyValuePairs.Add(groupWorkshop.Key, sum);
            }

            var result = new TopModel
            {
                Title = "Highest Revenue Workshop In Month",
            };
            foreach (var item in keyValuePairs)
            {
                var model = new Model
                {
                    Label = item.Key.Title,
                    Y = item.Value,
                };
                result.DataPoints.Add(model);
            }
            if (transactions.Any(c => c.EntityId == null))
            {
                decimal totalFake = (decimal)transactions.Where(c => c.EntityId == null).Sum(e => e.TotalPayment);
                result.DataPoints.Add(new Model
                {
                    Label = "Fake Class",
                    Y = totalFake,
                });
            }
            result.DataPoints = result.DataPoints.OrderByDescending(c => c.Y).ToList();
            return result;
        }


        #endregion
        public async Task<IEnumerable<TopTrainerModel>> TopTrainer(int month, int year)
        {
            var trainerSlots = await _uow.TrainerSlotRepository.Get(c => c.Status == (int)Models.Enum.TrainerSlotStatus.Enabled
                                                                       && c.Date.Month == month && c.Date.Year == year
                                                                       && c.TrainerId != null
                                                                       , nameof(Trainer)
                                                                       , $"{nameof(Trainer)}.{nameof(Trainer.User)}");
            var groupTrainers = trainerSlots.GroupBy(c => c.Trainer);            
            Dictionary<Trainer, int> keyValuePairs = new Dictionary<Trainer, int>();
            foreach (var trainer in groupTrainers)
            {
                keyValuePairs.Add(trainer.Key, trainer.Count());
            }
            var topTrainers = keyValuePairs.OrderByDescending(keyValue => keyValue.Value).ToList().Take(5);
            var result = new List<TopTrainerModel>();
            foreach (var trainer in topTrainers)
            {
                var model = new TopTrainerModel
                {
                    Name = trainer.Key.User.Name,
                };
                //count consultant
                var consultantSlots = trainerSlots.Where(c => c.TrainerId == trainer.Key.Id 
                                                            && c.EntityTypeId == (int)Models.Enum.EntityType.AdviceConsulting);
                var dataPointConsultant = new TopTrainerDataPoint
                {
                    Label = "Consultation",
                    Y = consultantSlots.Count(),
                };
                model.DataPoints.Add(dataPointConsultant);
                //count workshop
                var workshopSlots = trainerSlots.Where(c => c.TrainerId == trainer.Key.Id
                                                        && c.EntityTypeId == (int)Models.Enum.EntityType.WorkshopClass);
                var dataPointWorkshop = new TopTrainerDataPoint
                {
                    Label = "Workshop",
                    Y = workshopSlots.Count(),
                };
                model.DataPoints.Add(dataPointWorkshop);
                //count trainint course
                var trainingSlots = trainerSlots.Where(c => c.TrainerId == trainer.Key.Id 
                                                        && c.EntityTypeId == (int)Models.Enum.EntityType.TrainingCourse);
                var dataPointTrainingCourse = new TopTrainerDataPoint
                {
                    Label = "Training Course",
                    Y = trainingSlots.Count(),
                };
                model.DataPoints.Add(dataPointTrainingCourse);
                result.Add(model);
            }
            return result;
        }
    }
}
