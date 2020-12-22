using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectStore.ViewModel
{
    public class EditViewModel : CreateViewModel
    {
        public int CertificationId { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
