using ProductStockTracking.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStockTracking.DataAccess.Concrete.EntityFramework.Mappings
{
    public class FaultyPhoneDeliveriesMap : EntityTypeConfiguration<FaultyPhoneDelivery>
    {
        public FaultyPhoneDeliveriesMap()
        {
            ToTable(@"FaultyPhones", @"dbo");
            HasKey(i => i.FaultyPhoneId);

            

        }
    }
}
