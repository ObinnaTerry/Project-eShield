using eShield.CoreData.Entities;
using eShield.CoreData.Interfaces;
using eShield_API.DTOs;

namespace eShield_API.DataService
{
    public class NetworkInfoDataService
    {
        private readonly INetworkInfoRepo _networkInfoRepo;
        private readonly IStudentRepo _studentRepo;

        public NetworkInfoDataService(INetworkInfoRepo networkInfoRepo, IStudentRepo studentRepo)
        {
            _networkInfoRepo = networkInfoRepo;
            _studentRepo = studentRepo;
        }

        public bool? Create(NetworkInfoDTO networkInfoDTO)
        {
            Student? student = _studentRepo.GetAll().Where(x => x.Email == networkInfoDTO.StudentEmail).FirstOrDefault();

            if(student == null)
            {
                return null;
            }

            NetworkInfo networkInfo = new NetworkInfo()
            {
                ExamId = networkInfoDTO.Examcode[0],
                Ipaddress = networkInfoDTO.Ipaddress,
                Macaddress = networkInfoDTO.Macaddress,
                StudentId = student.Id
            };

            _networkInfoRepo.Insert(networkInfo);
            _networkInfoRepo.Save();

            return true;
        }
    }
}
