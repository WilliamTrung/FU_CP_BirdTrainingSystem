using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AppCore.Context
{
    public static class AddModels
    {
        private static List<Skill> Skills
        {
            get
            {
                var skill1 = new Skill { Id = 1, Name = "Behavioral Training", Description = "Modifies bird behaviors through positive reinforcement" };
                var skill2 = new Skill { Id = 2, Name = "Vocal Training", Description = "Develops bird speech and imitation abilities" };
                var skill3 = new Skill { Id = 3, Name = "Showmanship", Description = "Prepares birds for stage performances" };
                var skill4 = new Skill { Id = 4, Name = "Complex Routines", Description = "Teaches birds to chain multiple behaviors" };
                var skill5 = new Skill { Id = 5, Name = "Husbandry", Description = "Provides proper bird nutrition, healthcare, etc." };
                var listSkill = new List<Skill>
                {
                    skill1,
                    skill2,
                    skill3,
                    skill4,
                    skill5
                };
                return listSkill;
            }
        }
        private static List<BirdSkill> BirdSkills
        {
            get
            {
                var birdSkill1 = new BirdSkill { Id = 1, Name = "Flight training", Description = "Teaches controlled flight and landing" };
                var birdSkill2 = new BirdSkill { Id = 2, Name = "Speech training", Description = "Develops vocabulary and mimicking" };
                var birdSkill3 = new BirdSkill { Id = 3, Name = "Behavior training", Description = "Modifies behaviors through positive reinforcement" };
                var birdSkill4 = new BirdSkill { Id = 4, Name = "Sound imitation", Description = "Imitates noises like doorbells and phones" };
                var birdSkill5 = new BirdSkill { Id = 5, Name = "Agility training", Description = "Improves coordination through obstacle courses" };
                var birdSkill6 = new BirdSkill { Id = 6, Name = "Color recognition", Description = "Identifies colors when named" };
                var birdSkill7 = new BirdSkill { Id = 7, Name = "Pose training", Description = "Assumes specific poses on command" };
                var birdSkill8 = new BirdSkill { Id = 8, Name = "Choreographed dances", Description = "Learns dance routines to music" };
                var birdSkill9 = new BirdSkill { Id = 9, Name = "Acrobatics", Description = "Performs athletic tricks like hanging upside down" };
                var birdSkill10 = new BirdSkill { Id = 10, Name = "Games", Description = "Plays games like basketball or bowling" };
                var listBirdSkill = new List<BirdSkill>
                {
                    birdSkill1,
                    birdSkill2,
                    birdSkill3,
                    birdSkill4,
                    birdSkill5,
                    birdSkill6,
                    birdSkill7,
                    birdSkill8,
                    birdSkill9,
                    birdSkill10
                };
                return listBirdSkill;
            }
        }
        private static List<TrainableSkill> TrainableSkills
        {
            get
            {
                var trainableSkill1 = new TrainableSkill { SkillId = 1, BirdSkillId = 3, ShortDescription = "Use positive reinforcement for behavior training" };
                var trainableSkill2 = new TrainableSkill { SkillId = 1, BirdSkillId = 5, ShortDescription = "Build agility through positive reinforcement" };
                var trainableSkill3 = new TrainableSkill { SkillId = 2, BirdSkillId = 2, ShortDescription = "Develop speech through vocal training" };
                var trainableSkill4 = new TrainableSkill { SkillId = 2, BirdSkillId = 4, ShortDescription = "Imitate sounds through vocal training" };
                var trainableSkill5 = new TrainableSkill { SkillId = 3, BirdSkillId = 8, ShortDescription = "Choreographed dances for shows" };
                var trainableSkill6 = new TrainableSkill { SkillId = 3, BirdSkillId = 9, ShortDescription = "Acrobatic tricks for shows" };
                var trainableSkill7 = new TrainableSkill { SkillId = 3, BirdSkillId = 10, ShortDescription = "Games and skits for shows" };
                var trainableSkill8 = new TrainableSkill { SkillId = 4, BirdSkillId = 6, ShortDescription = "Chain behaviors for complex routines" };
                var trainableSkill9 = new TrainableSkill { SkillId = 4, BirdSkillId = 7, ShortDescription = "Pose routines require chaining multiple behaviors" };
                var trainableSkill10 = new TrainableSkill { SkillId = 5, BirdSkillId = 1, ShortDescription = "Proper flight training for exercise" };
                var listTrainableSkill = new List<TrainableSkill>
                {
                    trainableSkill1,
                    trainableSkill2,
                    trainableSkill3,
                    trainableSkill4,
                    trainableSkill5,
                    trainableSkill6,
                    trainableSkill7,
                    trainableSkill8,
                    trainableSkill9,
                    trainableSkill10
                };
                return listTrainableSkill;
            }
        }
        public static void AddSlots(this ModelBuilder modelBuilder)
        {
            var slots = new List<Slot>();
            for(int i = 0; i < 4; i++)
            {
                slots.Add(new Slot
                {
                    Id = i+1,
                    StartTime = new TimeSpan(i+8, 0,0),
                    EndTime = new TimeSpan(i+8, 45, 0)
                });
            }
            for (int i = 0; i < 4; i++)
            {
                slots.Add(new Slot
                {
                    Id = i + 5,
                    StartTime = new TimeSpan(i + 13, 0, 0),
                    EndTime = new TimeSpan(i + 13, 45, 0)
                });
            }
            modelBuilder.Entity<Slot>().HasData(slots);
        }
        public static void AddMembershipModels(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MembershipRank>().HasData(
                new MembershipRank
                {
                    Id = 1,
                    Name = "Standard",
                    Discount = 0,
                    Requirement = 0,
                },
                new MembershipRank
                {
                    Id= 2,
                    Name = "Gold",
                    Discount = 0.1f,
                    Requirement = 50*1000*1000,
                },
                new MembershipRank
                {
                    Id = 3,
                    Name = "Platinum",
                    Discount = 0.2f,
                    Requirement = 100*1000*1000
                });
        }
        public static void AddBirdSpecies(this ModelBuilder modelBuilder)
        {
            var birds = new List<BirdSpecies>()
                {
                    new BirdSpecies(){
                        Id = 1, 
                        Name = "Parakeet", 
                        ShortDetail = "Small, colorful parakeets known for their friendly and social nature." 
                    },
                    new BirdSpecies(){
                        Id = 2, 
                        Name = "Cockatiel", 
                        ShortDetail = "Medium-sized parrots that are easy to tame and often enjoy human interaction." 
                    },
                    new BirdSpecies(){
                        Id = 3, 
                        Name = "Canary", 
                        ShortDetail = "Small songbirds known for their melodious singing." 
                    },
                    new BirdSpecies(){
                        Id = 4, 
                        Name = "Lovebird", 
                        ShortDetail = "Small parrots that are highly social and form strong bonds with their owners."
                    },
                    new BirdSpecies(){
                        Id = 5, 
                        Name = "Cockatoo", 
                        ShortDetail = "Large parrots known for their playful and affectionate personalities." 
                    },
                    new BirdSpecies(){
                        Id = 6, 
                        Name = "Finch", 
                        ShortDetail = "Small, active birds typically kept in aviaries or spacious cages." 
                    },
                    new BirdSpecies(){
                        Id = 7, 
                        Name = "Canary-winged Parakeet", 
                        ShortDetail = "Docile parakeets that are often considered good pets." 
                    },
                    new BirdSpecies(){
                        Id = 8, 
                        Name = "Parrotlet", 
                        ShortDetail = "Tiny parrots with big personalities, known for their inquisitive and playful behavior." 
                    },
                    new BirdSpecies(){
                        Id = 9, 
                        Name = "Budgerigar (Budgie)", 
                        ShortDetail = "Small parakeets that make excellent in-home pets, easy to care for and enjoy human interaction." 
                    },
                    new BirdSpecies(){
                        Id = 10, 
                        Name = "Quaker Parrot (Monk Parakeet)", 
                        ShortDetail = "Medium-sized parrots known for their social nature and ability to mimic words." 
                    }
                };
            modelBuilder.Entity<BirdSpecies>().HasData(birds);
        }
        
        public static void AddTrainerSkills(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>().HasData(Skills);
            modelBuilder.Entity<BirdSkill>().HasData(BirdSkills);
            modelBuilder.Entity<TrainableSkill>().HasData(TrainableSkills);
        }
    }
}
