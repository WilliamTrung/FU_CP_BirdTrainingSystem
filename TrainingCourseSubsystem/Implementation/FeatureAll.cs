using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.Enum.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate.BirdCertificateDetail;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using Models.ServiceModels.TrainingCourseModels.TrainerSkill;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem.Implementation
{
    public class FeatureAll : IFeatureAll
    {
        internal readonly IUnitOfWork _unitOfWork;
        internal readonly IMapper _mapper;
        public FeatureAll(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BirdCertificateDetailViewModel>> GetBirdCertificatesDetail()
        {
            var entities = await _unitOfWork.BirdCertificateDetailRepository.Get();
            var models = _mapper.Map<IEnumerable<BirdCertificateDetailViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<BirdCertificateDetailViewModel>> GetBirdCertificatesDetailByBirdId(int birdId)
        {
            var entities = await _unitOfWork.BirdCertificateDetailRepository.Get(e => e.BirdId == birdId);
            var models = _mapper.Map<IEnumerable<BirdCertificateDetailViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<BirdSkillReceivedViewModel>> GetBirdSkillReceiveds()
        {
            var entities = await _unitOfWork.BirdSkillReceivedRepository.Get(expression: null
                                                                             , nameof(BirdSkillReceived.Bird)
                                                                             , nameof(BirdSkillReceived.BirdSkill));
            var models = _mapper.Map<IEnumerable<BirdSkillReceivedViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<BirdSkillReceivedViewModel>> GetBirdSkillReceivedsByBirdId(int birdId)
        {
            var entities = await _unitOfWork.BirdSkillReceivedRepository.Get(expression: e => e.BirdId == birdId
                                                                             , nameof(BirdSkillReceived.Bird)
                                                                             , nameof(BirdSkillReceived.BirdSkill));
            var models = _mapper.Map<IEnumerable<BirdSkillReceivedViewModel>>(entities);
            return models;
        }

        public async Task CreateBirdSkillReceived(BirdSkillReceivedAddDeleteModel addDeleteModel)
        {
            if (addDeleteModel == null)
            {
                throw new Exception("Client send null param.");
            }
            else
            {
                var entity = _mapper.Map<BirdSkillReceived>(addDeleteModel);
                await _unitOfWork.BirdSkillReceivedRepository.Add(entity);
            }
        }

        public async Task DeleteBirdSkillReceived(BirdSkillReceivedAddDeleteModel addDeleteModel)
        {
            if (addDeleteModel == null)
            {
                throw new Exception("Client send null param.");
            }
            else
            {
                var entity = await _unitOfWork.BirdSkillReceivedRepository.GetFirst(e => e.BirdId == addDeleteModel.BirdId && e.BirdSkillId == addDeleteModel.BirdSkillId);
                if (entity == null)
                {
                    throw new Exception(nameof(BirdSkillReceived) + " is not found");
                }
                else
                {
                    await _unitOfWork.BirdSkillReceivedRepository.Delete(entity);
                }
            }
        }

        public async Task<IEnumerable<BirdCertificateViewModel>> GetBirdCertificates()
        {
            var entities = await _unitOfWork.BirdCertificateRepository.Get();
            var models = _mapper.Map<List<BirdCertificateViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<BirdSpeciesViewModel>> GetBirdSpecies()
        {
            var entities = await _unitOfWork.BirdSpeciesRepository.Get();
            var models = _mapper.Map<List<BirdSpeciesViewModel>>(entities);
            return models;
        }

        public async Task<BirdSpeciesViewModel> GetBirdSpeciesById(int birdSpeciesId)
        {
            var entity = await _unitOfWork.BirdSpeciesRepository.GetFirst(e => e.Id == birdSpeciesId);
            var model = _mapper.Map<BirdSpeciesViewModel>(entity);
            return model;
        }

        public IEnumerable<Status> GetEnumBirdTrainingProgressStatuses()
        {
            var statuses = Enum.GetValues(typeof(Models.Enum.BirdTrainingProgress.Status)).Cast<Models.Enum.BirdTrainingProgress.Status>();
            return statuses;
        }

        public async Task<IEnumerable<TrainingCourseViewModel>> GetTrainingCourses()
        {
            var entities = await _unitOfWork.TrainingCourseRepository.Get(expression: null, nameof(TrainingCourse.BirdSpecies));
            var models = _mapper.Map<IEnumerable<TrainingCourseViewModel>>(entities);
            return models;
        }

        public async Task<TrainingCourseViewModel> GetTrainingCoursesById(int courseId)
        {
            var entities = await _unitOfWork.TrainingCourseRepository.GetFirst(e => e.Id == courseId
                                                                               , nameof(TrainingCourse.BirdSpecies));
            var models = _mapper.Map<TrainingCourseViewModel>(entities);
            return models;
        }

        public async Task<IEnumerable<TrainerSkillViewModel>> GetTrainerSkills()
        {
            var entities = await _unitOfWork.TrainerSkillRepository.Get(expression: null
                                                                        , nameof(TrainerSkill.Skill)
                                                                        , nameof(TrainerSkill.Trainer)
                                                                        , $"{nameof(TrainerSkill.Trainer)}.{nameof(TrainerSkill.Trainer.User)}");
            var models = _mapper.Map<IEnumerable<TrainerSkillViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<TrainerSkillViewModel>> GetTrainerSkillsByTrainerId(int trainerId)
        {
            var entities = await _unitOfWork.TrainerSkillRepository.Get(e => e.TrainerId == trainerId
                                                                        , nameof(TrainerSkill.Skill)
                                                                        , nameof(TrainerSkill.Trainer)
                                                                        , $"{nameof(TrainerSkill.Trainer)}.{nameof(TrainerSkill.Trainer.User)}");
            var models = _mapper.Map<IEnumerable<TrainerSkillViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<TrainableViewSkillModel>> GetTrainableSkills()
        {
            var entities = await _unitOfWork.TrainableSkillRepository.Get(expression: null
                                                                        , nameof(TrainableSkill.Skill)
                                                                        , nameof(TrainableSkill.BirdSkill));
            var models = _mapper.Map<IEnumerable<TrainableViewSkillModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<AcquirableSkillViewModel>> GetAccquirableBirdSkill()
        {
            var entities = await _unitOfWork.AcquirableSkillRepository.Get(expression: null
                                                                        , nameof(AcquirableSkill.BirdSpecies)
                                                                        , nameof(AcquirableSkill.BirdSkill));
            var models = _mapper.Map<IEnumerable<AcquirableSkillViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<AcquirableSkillViewModel>> GetAccquirableBirdSkillByBirdSpeciesId(int birdSpeciesId)
        {
            var entities = await _unitOfWork.AcquirableSkillRepository.Get(expression: e => e.BirdSpeciesId == birdSpeciesId
                                                                        , nameof(AcquirableSkill.BirdSpecies)
                                                                        , nameof(AcquirableSkill.BirdSkill));
            var models = _mapper.Map<IEnumerable<AcquirableSkillViewModel>>(entities);
            return models;
        }
        public async Task<IEnumerable<SkillViewModModel>> GetSkills()
        {
            var entities = await _unitOfWork.SkillRepository.Get();
            var models = _mapper.Map<IEnumerable<SkillViewModModel>>(entities);
            return models;
        }

        public async Task<SkillViewModModel> GetSkillById(int skillId)
        {
            var entity = await _unitOfWork.SkillRepository.GetFirst(e => e.Id == skillId);
            var model = _mapper.Map<SkillViewModModel>(entity);
            return model;
        }

        public async Task<IEnumerable<BirdSkillViewModel>> GetBirdSkills()
        {
            var entities = await _unitOfWork.BirdSkillRepository.Get();
            var models = _mapper.Map<IEnumerable<BirdSkillViewModel>>(entities);
            bool nameAll = true;
            foreach(var model in models)
            {
                if(model.Id == 0 && model.Name == "All")
                {
                    nameAll = false;
                }
            }
            if(nameAll)
            {
                models.ToList().Add(new BirdSkillViewModel() { Id = 0, Name = "All"});
            }
            return models;
        }

        public async Task<BirdSkillViewModel> GetBirdSkillsById(int birdSkillId)
        {
            var entity = await _unitOfWork.BirdSkillRepository.GetFirst(e => e.Id == birdSkillId);
            var model = _mapper.Map<BirdSkillViewModel>(entity);
            return model;
        }

        public async Task<IEnumerable<BirdSkillReceivedViewModel>> ViewBirdSkillReceived(int birdId)
        {
            var birdReceiveds = await _unitOfWork.BirdSkillReceivedRepository.Get(e => e.BirdId == birdId);
            var models = _mapper.Map<IEnumerable<BirdSkillReceivedViewModel>>(birdReceiveds);
            return models;
        }

        public async Task<IEnumerable<TrainerModel>> GetTrainer()
        {
            var entities = await _unitOfWork.TrainerRepository.Get(expression: null, nameof(Trainer.User));
            //List<TrainerModel> models = new List<TrainerModel>();
            //foreach (Models.Entities.Trainer entity in entities)
            //{
            //    var skills = _mapper.Map<List<TrainerSkillViewModel>>(entity.TrainerSkills);
            //    TrainerModel model = new TrainerModel()
            //    {
            //        Id = entity.Id,
            //        Name = entity.User.Name,
            //        Email = entity.User.Email,
            //        Avatar = entity.User.Avatar,
            //        TrainerSkillModels = skills
            //    };
            //    models.Add(model);
            //}
            var models = _mapper.Map<IEnumerable<TrainerModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<TrainerModel>> GetTrainerByBirdSkillId(int birdSkillId)
        {
            var trainableSkills = await _unitOfWork.TrainableSkillRepository.Get(e => e.BirdSkillId == birdSkillId);
            //var trainerSkills = await _unitOfWork.TrainerSkillRepository.Get();

            //trainerSkills = trainerSkills.Where(e => trainableSkills.Any(s => s.SkillId == e.SkillId)).ToList();

            //var trainers = _unitOfWork.TrainerRepository.Get(e => trainerSkills.Any(c => c.TrainerId == e.Id)).Result.ToList();
            //var models = _mapper.Map<IEnumerable<TrainerModel>>(trainers);
            List<TrainerModel> models = new List<TrainerModel>();
            foreach (var trainableSkill in trainableSkills)
            {
                var trainerSkillId = trainableSkill.SkillId;
                List<TrainerModel> trainers = GetTrainerByTrainerSkillId(trainerSkillId).Result.ToList();
                foreach (var trainer in trainers)
                {
                    if (trainer != null)
                    {
                        models.Add(trainer);
                    }
                }
            }
            models.DistinctBy(m => m.Id).ToList();
            return models;
        }

        public async Task<TrainerModel> GetTrainerById(int trainerId)
        {
            var entity = await _unitOfWork.TrainerRepository.GetFirst(e => e.Id == trainerId
                                                                        , nameof(Trainer.User));
            var model = _mapper.Map<TrainerModel>(entity);
            return model;
        }

        public async Task<IEnumerable<TrainerModel>> GetTrainerByTrainerSkillId(int trainerSkillId)
        {
            var trainerSkills = await _unitOfWork.TrainerSkillRepository.Get(e => e.SkillId == trainerSkillId
                                                                                , nameof(TrainerSkill.Trainer)
                                                                                , $"{nameof(TrainerSkill.Trainer)}.{nameof(TrainerSkill.Trainer.User)}");
            List<Trainer> trainerEntities = new List<Trainer>();
            foreach (var trainerSkill in trainerSkills)
            {
                if (trainerSkill.Trainer != null)
                {
                    trainerEntities.Add(trainerSkill.Trainer);
                }
            }
            var models = _mapper.Map<IEnumerable<TrainerModel>>(trainerEntities);
            return models;
        }

        public async Task<IEnumerable<BirdSkillReceivedViewModel>> GetBirdSkillReceivedByBirdId(int birdId)
        {
            var entities = await _unitOfWork.BirdSkillReceivedRepository.Get(e => e.BirdId == birdId
                                                                             , nameof(BirdSkillReceived.Bird)
                                                                             , nameof(BirdSkillReceived.BirdSkill));
            var models = _mapper.Map<IEnumerable<BirdSkillReceivedViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<CustomerModel>> GetCustomerModels()
        {
            var request = _unitOfWork.BirdTrainingCourseRepository.Get().Result.ToList();
            var entities = await _unitOfWork.CustomerRepository.Get(expression: null, nameof(Customer.User));

            entities = entities.Where(e => request.Any(r => r.CustomerId == e.Id)).ToList();

            var models = _mapper.Map<IEnumerable<CustomerModel>>(entities);
            return models;
        }
    }
}