using Easilog.DataContracts;

namespace Redbridge.ApiTesting.Framework
{
    public interface IUserSessionCache
    {
        EntityCache<HospitalData> Hospitals { get; }
        EntityCache<ProcedureData> Procedures { get; }
        EntityCache<SpecialtyData> Specialties { get; }
        EntityCache<SubSpecialtyData> SubSpecialties { get; }
    }
}