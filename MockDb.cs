using System.Collections.Generic;

namespace KafkaTester
{
    public class MockDb
    {
        private List<SecurityMaster> securityMasters = new List<SecurityMaster>
        {
            new SecurityMaster { SecurityMasterId = 1, SecurityId = "Apple", AssetClassBx = "Equity", SecurityTypeBx = "CommonStock" }
        };

        public List<SecurityMaster> GetAllSecurities()
        {
            return this.securityMasters;
        }
    }


}