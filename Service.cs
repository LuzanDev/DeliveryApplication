using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApplication
{
    internal class Service
    {
		private static List<PackagingMaterial> materials;

		public static List<PackagingMaterial> Materials
        {
			get { return materials; }
		}

		public Service()
		{
			materials = DataBaseControl.GetPackagings();
		}

	}
}
