using AppCore.Models;
using AutoMapper;
using Models.ServiceModels.OnlineCourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class OnlineCourseProfile : Profile
    {
        public OnlineCourseProfile() 
        { 
        }

        private void Map_OnlineCourse_OnlineCourseModel()
        {
            CreateMap<OnlineCourse, OnlineCourseModel>();
        }

        private void Map_OnlineCourse_OnlineCourseDetailViewModel()
        {
            CreateMap<OnlineCourse, OnlineCourseDetailViewModel>();
        }
    }
}
