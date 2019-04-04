using System.Collections.Generic;

namespace KafkaTester
{
    public class MockDb
    {
        private List<SecurityMaster> securityMasters = new List<SecurityMaster>
        {
            new SecurityMaster { SecurityMasterId = 1, SecurityId = "Apple", AssetClassBx = "Equity", SecurityTypeBx = "CommonStock" },
            new SecurityMaster { SecurityMasterId = 2, SecurityId = "Microsoft", AssetClassBx = "Equity", SecurityTypeBx = "CommonStock" },
            new SecurityMaster { SecurityMasterId = 3, SecurityId = "Confluent", AssetClassBx = "Equity", SecurityTypeBx = "CommonStock" },
            new SecurityMaster { SecurityMasterId = 4, SecurityId = "Amazon", AssetClassBx = "Equity", SecurityTypeBx = "CommonStock" },
            new SecurityMaster { SecurityMasterId = 5, SecurityId = "Oracle", AssetClassBx = "Equity", SecurityTypeBx = "CommonStock" },
        };

        public List<SecurityMaster> GetAllSecurities()
        {
            return this.securityMasters;
        }
    }


}