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

        private List<string> accountCodes = new List<string> { "MGR1", "MGR2", "MGR3" };

        public List<SecurityMaster> GetAllSecurities()
        {
            return this.securityMasters;
        }

        public List<Position> GenerateRandomPositions(int numberToProduce)
        {
            var rnd = new System.Random();

            var result = new List<Position>();
            for (var i = 0; i < numberToProduce; ++i) {
                var security = this.securityMasters[rnd.Next(this.securityMasters.Count)];
                var account = this.accountCodes[rnd.Next(this.accountCodes.Count)];

                var position = new Position {
                    SecurityMasterId = security.SecurityMasterId,
                    AccountCode = account,
                    Amount = ((decimal)rnd.NextDouble()) * 100000.0m
                };

                result.Add(position);
            }

            return result;
        }
    }


}