//using System;
//using Easilog.DataContracts;
//using Easilog.Services;

//namespace Redbridge.ApiTesting.Framework
//{
//    public class UserSessionCache : IUserSessionCache
//    {
//        private readonly Lazy<EntityCache<HospitalData>> _lazyHospitals;
//        private readonly Lazy<EntityCache<ProcedureData>> _lazyProcedures;
//        private readonly Lazy<EntityCache<SpecialtyData>> _lazySpecialties;
//        private readonly Lazy<EntityCache<SubSpecialtyData>> _lazySubSpecialties;


//        public UserSessionCache(IEasilogRestWebService proxy)
//        {
//            _lazyHospitals = new Lazy<EntityCache<HospitalData>>(() => new EntityCache<HospitalData>(() => proxy.GetAllHospitalsAsync().Result));
//            _lazyProcedures = new Lazy<EntityCache<ProcedureData>>(() => new EntityCache<ProcedureData>(() => proxy.GetAllProceduresAsync().Result));
//            _lazySpecialties = new Lazy<EntityCache<SpecialtyData>>(() => new EntityCache<SpecialtyData>(() => proxy.GetAllSpecialtiesAsync().Result));
//            _lazySubSpecialties = new Lazy<EntityCache<SubSpecialtyData>>(() => new EntityCache<SubSpecialtyData>(() => proxy.GetAllSubSpecialtiesAsync().Result));
//        }

//        public EntityCache<HospitalData> Hospitals => _lazyHospitals.Value;
//        public EntityCache<ProcedureData> Procedures => _lazyProcedures.Value;
//        public EntityCache<SpecialtyData> Specialties => _lazySpecialties.Value;
//        public EntityCache<SubSpecialtyData> SubSpecialties => _lazySubSpecialties.Value;
//    }
//}
