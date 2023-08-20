using WebAPIDemoProject.Entities;
using WebAPIDemoProject.Entities.ViewEntities;
using WebAPIDemoProject.Repositories;

namespace WebAPIDemoProject.Services
{
    public class TeacherService
    {
        private TeacherRepository teacherRepository;
        private UserDetailRepository userDetailRepository;
        private UserCredentialRepository userCredentialRepository;

        public TeacherService()
        {
            teacherRepository = new TeacherRepository();
            userDetailRepository = new UserDetailRepository();
            userCredentialRepository = new UserCredentialRepository();
        }

        public TeacherView? Get(int id)
        {
            var teacher = teacherRepository.Get(id);
            var user = userDetailRepository.Get(id);

            if (teacher == null || user == null) { return null; }

            return new TeacherView
            {
                Id = user.Id,
                Email = user.Email,
                Location = user.Location,
                Name = user.Name,
                Specification = teacher.Specification,
            };

        }

        public void Delete(int id)
        {
            teacherRepository.Delete(id);
            userDetailRepository.Delete(id);
            userCredentialRepository.Delete(id);
            // teacher_studentReporsitory.Delete(id);
        }

        public TeacherView Add(TeacherView newItem)
        {
            var newUserDetail = userDetailRepository.Add(new UserDetail
            {
                Email = newItem.Email,
                Location = newItem.Location,
                Name = newItem.Name,
                Type = UserDetail.UserType.Teacher
            });

            userCredentialRepository.Add(new UserCredential
            {
                Id = newUserDetail.Id,
                Username = newItem.Email,
                Password = newItem.Password,
            }, false);


            teacherRepository.Add(newItem: new Teacher
            {
                Id = newUserDetail.Id,
                Specification = newItem.Specification
            }, calculateId: false);

            newItem.Id = newUserDetail.Id;
            return newItem;
        }

        public void Update(TeacherView updatedItem)
        {
            userDetailRepository.Update(new UserDetail
            {
                Email = updatedItem.Email,
                Location = updatedItem.Location,
                Name = updatedItem.Name,
                Id = updatedItem.Id,
                Type = UserDetail.UserType.Teacher
            });

            teacherRepository.Update(new Teacher
            {
                Id = updatedItem.Id,
                Specification = updatedItem.Specification
            });

            userCredentialRepository.Update(new UserCredential
            {
                Id = updatedItem.Id,
                Username = updatedItem.Email,
                Password = updatedItem.Password,
            });

        }
    }
}