using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public interface IVehicleBuilder
    {
        public IVehicleBuilder BuildElectronics();
        public IVehicleBuilder BuildMainParts();

        public IVehicleBuilder BuildMaterials();
    }
}
