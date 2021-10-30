using System;

namespace Redbridge.ApiTesting.Framework
{
    public static class WellknownProcedures
    {
        public static class GeneralSurgery
        {
            public static readonly Guid RadicalGallBladderRemoval = Guid.Parse("928c6a39-a659-26b3-97f0-405a2fa97d19");
        }

        public static class Cardiology
        {
            public static readonly Guid CoronaryGraftsStudy = Guid.Parse("112F7080-C4A6-C6ED-7989-80342DA5AE7B");
        }
    }
}
